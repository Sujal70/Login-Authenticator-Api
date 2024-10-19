using LT.Infrastructure.UnitOfWork.Interfaces;
using LT.UnitTest.MockRepos.Common;
using ConfigReader;
using LT.Api.Core_DI;
using LT.Core.BaseEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LT.UnitTest
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ByaW1hcnlncm91cHNpZCI6IjEyMzE3IiwianRpIjoiNGIxZmEyMWUtZGI1MC00ODk1LWFiNTQtZTQ2YjAwNDUyYzU5IiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiRmFsc2UiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ByaW1hcnlzaWQiOiIxMjY4ODgiLCJUaW1lem9uZUlkIjoiMTQiLCJUaW1lRm9ybWF0IjoiMiIsIkRhdGVGb3JtYXQiOiI0IiwiRm9sZGVyTmFtZSI6InNhaV90ZXN0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlIgMSBNYW1oaW1rYXIiLCJDb3JwTmFtZSI6IkxUIE9yZ2FuaXphdGlvbiIsIkFjY291bnRUeXBlIjoiNCIsIklzTm9naW4iOiJGYWxzZSIsIk1hc3RlckxvZ2luIjoiMCIsIklwIjoiMTI3LjAuMC4xIiwiTHRtY0NvcnBObyI6Ii0xMDAiLCJuYmYiOjE3MTY5NzU4OTgsImV4cCI6MTcxNzA2MjI5OCwiaXNzIjoidHJhbnNsYXRlYXBpLnNldmVucHYuY29tIiwiYXVkIjoibHR0b255LnNldmVucHYuY29tIn0.1HDhJU3tjmrSYuXtE3oZccVpIjY1WjiTDH6kyX3Yuhc";
            services.AddBALDependencies();
            services.AddScoped<IUnitOfWork, MockUnitOfWork>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            AppSettings.AppConfig = AppConfiguration.ApplyConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json"));
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
            AppSettings.TokenClaimModel = TokenConfiguration.ApplyToken(jwtToken, token);
        }
    }
}


