using ConfigReader;
using ConfigReader.Entities;
using LoggerServiceInvoker.Common;
using LT.Core.BaseEntities;
using LT.Core.Common;
using LT.Core.ModelEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using LT.Api.Utilities;

namespace LT.Api.Controllers.Common
{
    /// <summary>
    ///  This is the Base controller to perform Logging Exception and soma Form Data Validation
    ///  It has Authorize Level as Accesstoken which can be overriden in inherited controllers 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthorizeLevel.AccessToken)]
    public class BaseController : Controller
    {
        public string CallParams { get; set; }
        public readonly Message message;

        public BaseController(Message _message)
        {
            message = _message;
        }
        public BaseController()
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // formData name should be same in Base , Page , Search Controller
            CallParams = JsonConvert.SerializeObject(context.ActionArguments);
            if (!context.ActionArguments.TryGetValue("formData", out object formData) && !context.ModelState.IsValid)
            {
                message.UserMessage = "Invalid Model Data";
                ProcessInvalidAttributes(message, context);
                message.OutParam = formData;
                message.Fail();

                MainViewModel<Message> failedResult = new(message);
                context.Result = new UnprocessableEntityObjectResult(failedResult);
            }
            base.OnActionExecuting(context);
        }

        protected virtual void ProcessInvalidAttributes(Message message, ActionExecutingContext context)
        {
            message.UserMessage = "Model Data has some invalid paramters";
            //TBD read model state and add individual messages in messages array
            // Check in context context.ModelState.Values
        }

        protected void LogInfo(Message message)
        {
            if (AppSettings.AppConfig.LoggerSetting.ILoggerEnabled)
            {
                LoggerEntity newEntity = new()
                {
                    Message = message,
                    LogTypeEnumId = (int)LogType.Information,
                    LoggerSetting = AppSettings.AppConfig.LoggerSetting,
                    MainCorpNo = TokenClaimModel.MainCorpNo,
                    LoginCorpNo = TokenClaimModel.LoginCorpNo,
                    ExceptionsLevelEnumId = null
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new(nameValueCollection);
                _loggerService.LogInfo(AppSettings.AppConfig.LoggerMicroServiceEndPoint, newEntity, AppSettings.AppConfig.SecretKey);
                message.Messages = null;
            }
        }

        protected void LogInfo(decimal loginCorp, decimal maincorp, Message message)
        {
            if (AppSettings.AppConfig.LoggerSetting.ILoggerEnabled)
            {
                LoggerEntity newEntity = new()
                {
                    Message = message,
                    LogTypeEnumId = (int)LogType.Information,
                    LoggerSetting = AppSettings.AppConfig.LoggerSetting,
                    MainCorpNo = Convert.ToInt32(maincorp),
                    LoginCorpNo = Convert.ToInt32(loginCorp),
                    ExceptionsLevelEnumId = null
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new(nameValueCollection);
                _loggerService.LogInfo(AppSettings.AppConfig.LoggerMicroServiceEndPoint, newEntity, AppSettings.AppConfig.SecretKey);
                message.Messages = null;
            }
        }

        protected void LogException(Exception ex, Message message)
        {
            message.Fail();
            message.ExceptionMessage = ex.Message;
            message.UserMessage = Constants.Somethingwrong;
            if (AppSettings.AppConfig.LoggerSetting.ILoggerEnabled)
            {
                LoggerEntity newEntity = new()
                {
                    LoginCorpNo = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo : 0,
                    MainCorpNo = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo : 0,
                    LogTypeEnumId = (int)LogType.Exception,
                    ExceptionsLevelEnumId = (int)ExceptionLevel.Low,
                    LoggerSetting = AppSettings.AppConfig.LoggerSetting,
                    Message = message
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new(nameValueCollection);
                _loggerService.LogException(ex, AppSettings.AppConfig.LoggerMicroServiceEndPoint, newEntity, AppSettings.AppConfig.SecretKey);
                //message.Messages = ;
            }
        }

        protected bool IsValidFormData(BaseModelEntity formData, Message message)
        {

            if (formData != null)
            {
                if (formData.CorpNo != 0)
                {

                    message.Messages.AddLog("Invalid Corp No");
                    message.Fail();
                }

                if (!message.Status)
                    return false;
            }
            return true;
        }

        protected bool IsValidSearchData(BaseSearchEntity searchData, Message message)
        {

            if (searchData != null)
            {
                if (searchData.CorpNo != 0)
                {
                    message.Messages.AddLog("Invalid Corp No");
                    message.Fail();
                }
                var result = PostValidateSearch(searchData, message);

                if (!result)
                {
                    message.Messages.AddLog("Invalid Search Data");
                    message.Fail();
                }

                if (!message.Status)
                    return false;
            }
            return true;
        }

        protected virtual bool PostValidateSearch<S>(S searchModel, Message message) where S : BaseSearchEntity
        {
            message.UserMessage = "Search was not overrdidden";
            return true;
        }

        protected string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        protected Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".zip", "application/zip"}
            };
        }

        protected void ReturnFailedResult(AuthorizationFilterContext context, Message message)
        {
            MainViewModel<Message> failedResult = new(message);
            failedResult.Message.Fail();
            context.Result = new UnauthorizedObjectResult(failedResult);
        }

        protected string GetAccessToken(SurveyCorporateModel corpModel, bool IsNogin)
        {
            Claim[] claims = new Claim[]
            {
                new(ClaimTypes.PrimaryGroupSid,  corpModel.Parent == 0 ? corpModel.CorporateNo.ToString() : corpModel.Parent.ToString()),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.Role, corpModel.IsSuperAdmin.ToString()),
                new (ClaimTypes.PrimarySid, corpModel.CorporateNo.ToString()),
                new ("TimezoneId" ,corpModel.TimezoneId.ToString()),
                new ("TimeFormat", corpModel.TimeFormat.ToString()),
                new ("DateFormat", corpModel.DateFormat.ToString()),
                new ("FolderName", corpModel.Folder.ToString()),
                new (ClaimTypes.Name, corpModel.FirstName + " " + corpModel.LastName),
                new ("CorpName", corpModel.CorporateName),
                new ("AccountType", corpModel.AccountType.ToString()),
                new ("IsNogin", IsNogin.ToString()),
                new ("MasterLogin", "0"),
                new ("Ip", corpModel.LastIpAddress),
                new ("LtmcCorpNo", "-100"),
            };
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(AppSettings.AppConfig.JwtSettings.Key));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new(
                issuer: AppSettings.AppConfig.JwtSettings.Issuer,
                audience: AppSettings.AppConfig.JwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        protected string GetAccessToken(SurveyCorporateModel corpModel)
        {
            Claim[] claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.PrimaryGroupSid,  corpModel.Parent == 0 ? corpModel.CorporateNo.ToString() : corpModel.Parent.ToString()),
                new (ClaimTypes.PrimarySid, corpModel.CorporateNo.ToString()),
            };
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(AppSettings.AppConfig.JwtSettings.Key));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken securityToken = new(
                issuer: AppSettings.AppConfig.JwtSettings.Issuer,
                audience: AppSettings.AppConfig.JwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        protected static string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
  
        public static bool IsHex(IEnumerable<char> chars)
        {
            bool isHex;
            foreach (var c in chars)
            {
                isHex = ((c >= '0' && c <= '9') ||
                         (c >= 'a' && c <= 'f') ||
                         (c >= 'A' && c <= 'F'));

                if (!isHex)
                    return false;
            }
            return true;
        }

        public TokenClaimModel TokenClaimModel
        {
            get
            {
                return (TokenClaimModel)HttpContext.Items["tokenClaimModel"];
            }
        }

    }
}