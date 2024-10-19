using ConfigReader;
using ConfigReader.Entities;
using LT.Application.BusinessInterfaces;
using LT.Core.BaseEntities;
using LT.Core.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LT.Api.Controllers.Common
{
    public enum AuthorizeLevel
    {
        None = 0,
        AccessToken = 1,
        ApplicationKey = 3,
        ITAMToken = 4
    }
    public sealed class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public const string TokenExpire = "Your Token is expired! Please relogin.";
        public const string Somethingwrong = "Something went wrong, please contact application support team";
        public const string InvalidToken = "Invalid Token / Token not found / Unable to Parse Token";
        private static TokenClaimModel tokenClaimModel;

        public List<AuthorizeLevel> SecurityLevels { get; } = new List<AuthorizeLevel>();

        public AuthorizeAttribute(params AuthorizeLevel[] securityLevels)
        {
            if (Array.Exists(securityLevels, r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("Invalid Security Levels in LTAuthorizeAttribute");
            securityLevels.ToList().ForEach(y => SecurityLevels.Add(y));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            var endpoint = httpContext.GetEndpoint();
            var result = endpoint.Metadata.GetMetadata<AuthorizeAttribute>();

            Message message = new();
            if (result.SecurityLevels.Contains(AuthorizeLevel.None))
            {
                return;
            }
            if (result.SecurityLevels.Contains(AuthorizeLevel.AccessToken))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").LastOrDefault();
                if (!ParseAccessToken(context.HttpContext, token ?? string.Empty, message))
                {
                    message.UserMessage = InvalidToken;
                    ReturnFailedResult(context, message);
                }
                else if (tokenClaimModel == null || tokenClaimModel.MainCorpNo == 0)
                {
                    ReturnFailedResult(context, message);
                }
            }
            else if (SecurityLevels.Contains(AuthorizeLevel.ApplicationKey))
            {
                var secretKey = context.HttpContext.Request.Headers["SecretKey"].FirstOrDefault()?.Split(" ").Last();
                if (secretKey != null && ParseApplicationKey(httpContext, secretKey, message))
                {
                    return;
                }
                else
                {
                    message.UserMessage = "InvalidSecretKey";
                    ReturnFailedResult(context, message);
                }
            }
            else if (SecurityLevels.Contains(AuthorizeLevel.ITAMToken))
            {
                var secretKey = context.HttpContext.Request.Headers["ITAMToken"].FirstOrDefault()?.Split(" ").Last();
                if (secretKey != null && ParseITAMToken(context.HttpContext, secretKey, message))
                {
                    return;
                }
                else
                {
                    message.UserMessage = "InvalidSecretKey";
                    ReturnFailedResult(context, message);
                }
            }
        }
        private static bool ParseITAMToken(HttpContext httpContext, string applicationKey, Message message)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.AppConfig.JwtSettings.Key);
                tokenHandler.ValidateToken(applicationKey, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken != null)
                {
                    tokenClaimModel = TokenConfiguration.ApplyItsmTokenKey(jwtToken, applicationKey);
                    httpContext.Items.Add("tokenClaimModel", tokenClaimModel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                message.Fail();
                message.UserMessage = ex.Message.ToString();
            }
            return false;
        }

        private bool ParseApplicationKey(HttpContext httpContext, string applicationKey, Message message)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.AppConfig.JwtSettings.Key);
                tokenHandler.ValidateToken(applicationKey, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken != null)
                {
                    tokenClaimModel = TokenConfiguration.ApplyApplicationKey(jwtToken, applicationKey);
                    httpContext.Items.Add("tokenClaimModel", tokenClaimModel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                message.Fail();
                message.UserMessage = ex.Message.ToString();
            }
            return false;
        }

        private static bool ParseAccessToken(HttpContext httpContext, string token, Message message)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.AppConfig.JwtSettings.Key);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                if (jwtToken != null)
                {
                    tokenClaimModel = TokenConfiguration.ApplyApplicationKey(jwtToken, token);

                    if (VerifyToken(httpContext, token, message))
                    {
                        httpContext.Items.Remove("tokenClaimModel");
                        httpContext.Items.Add("tokenClaimModel", tokenClaimModel);
                        return true;
                    }
                }
                else
                {
                    message.UserMessage = InvalidToken;
                }
            }
            catch (Exception ex)
            {
                LogException(ex, message);
            }
            return false;
        }

        private static bool VerifyToken(HttpContext httpContext, string token, Message message)
        {
            // Retrieve Redis connection and cache service from DI
            ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(AppSettings.AppConfig.CacheSettings.RedisCacheConfig);
            IDistributedCache _cache = httpContext.RequestServices.GetRequiredService<IDistributedCache>();

            if (connection.IsConnected)
            {
                // Read Data from Redis cache
                byte[] cachedData = _cache.GetAsync("User_" + token).Result;
                if (cachedData != null)
                {
                    // If the data is found in the cache, decode and deserialize cached data
                    string cachedDataString = Encoding.UTF8.GetString(cachedData);
                    UserData userData = JsonConvert.DeserializeObject<UserData>(cachedDataString);
                    if (userData != null && userData.JWTToken != token)
                    {
                        return false;
                    }
                }
                else
                {
                    return FetchAndCacheUserData(httpContext, token, message, _cache);
                }
            }
            else
            {
                return FetchAndCacheUserData(httpContext, token, message, _cache);
            }

            return true;
        }

        private static bool FetchAndCacheUserData(HttpContext httpContext, string token, Message message, IDistributedCache _cache)
        {
            // Fetch user data from the database
            UserData userDataFromDB = new()
            {
                MainCorpNo = tokenClaimModel.MainCorpNo,
                LoginCorpNo = tokenClaimModel.LoginCorpNo,
                JWTToken = token
            };

            userDataFromDB = GetWebApiUserToken(userDataFromDB, httpContext, message);  //DB hit to get webapi token

            if (userDataFromDB.JWTToken != null && userDataFromDB.JWTToken.Length > 0)
            {
                if (userDataFromDB.JWTToken != token)
                {
                    return false;
                }
                else
                {
                    string cachedDataString = JsonConvert.SerializeObject(userDataFromDB);
                    byte[] dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                    DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(AppSettings.AppConfig.JwtSettings.MinutesToExpiration))
                        .SetSlidingExpiration(TimeSpan.FromMinutes(AppSettings.AppConfig.JwtSettings.MinutesToExpiration));

                    _cache.Set("User_" + userDataFromDB.JWTToken, dataToCache, options);
                }
            }

            return true;
        }

        private static UserData GetWebApiUserToken(UserData userDataConnected, HttpContext httpContext, Message message)
        {
            IAuthService _tokenService = httpContext.RequestServices.GetRequiredService<IAuthService>();
            return _tokenService.GetToken(message, userDataConnected);
        }

        protected static void LogException(Exception ex, Message message)
        {
            message.Fail();
            message.ExceptionMessage = ex.Message;
            message.UserMessage = Somethingwrong;
            message.ScreenId = (int)ScreenMasterEnum.NA_Reporting;
        }

        protected void ReturnFailedResult(AuthorizationFilterContext context, Message message)
        {
            MainViewModel<Message> failedResult = new(message);
            failedResult.Message.Fail();
            context.Result = new UnauthorizedObjectResult(failedResult);
        }
    }


}
