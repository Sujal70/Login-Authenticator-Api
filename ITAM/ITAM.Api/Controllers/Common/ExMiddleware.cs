using ConfigReader.Entities;
using LoggerServiceInvoker.Common;
using LT.Api.Utilities;
using LT.Core.BaseEntities;
using LT.Core.Common;
using System.Collections.Specialized;
using System.Net;

namespace LT.Api.Controllers.Common
{
    /// <summary>
    /// Custom Exception Middleware to Handle and centralize the Exception in API.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// construtor of ExceptionMiddleware for Injecting logger service and Request Delegate.
        /// </summary>
        /// <param name="next">Request Delegate to process HTTP Request</param>
        /// <param name="ltLogger">Logger service for logging</param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;

        }

        /// <summary>
        /// process the current HttpContext
        /// </summary>
        /// <param name="httpContext">The HttpContext for the current request.</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext, Message message)
        {
           
            try
            {

                /*Call the next middleware in the pipeline*/
                await _next(httpContext);

            }

            catch (Exception ex)
            {
                TokenClaimModel tokenClaimModel = (TokenClaimModel)httpContext.Items["tokenClaimModel"];
                message.Fail();
                message.UserMessage = Constants.Somethingwrong;
                message.ExceptionMessage = ex.Message;
                MainViewModel<string> failedResult = new(message);
                LogException(tokenClaimModel,ex, message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                await httpContext.Response.WriteAsJsonAsync<MainViewModel<string>>(failedResult);
            }
        }


        protected void LogException(TokenClaimModel tokenClaimModel,Exception ex, Message message)
        {
            if (AppSettings.AppConfig.LoggerSetting.ILoggerEnabled)
            {

                LoggerEntity newEntity = new()
                {
                    LoginCorpNo = tokenClaimModel != null ? tokenClaimModel.LoginCorpNo : 0,
                    MainCorpNo = tokenClaimModel != null ? tokenClaimModel.LoginCorpNo : 0,
                    LogTypeEnumId = (int)LogType.Exception,
                    ExceptionsLevelEnumId = (int)ExceptionLevel.Low,
                    LoggerSetting = AppSettings.AppConfig.LoggerSetting,
                    Message = message
                };
                var nameValueCollection = new NameValueCollection();
                LoggerServiceBase _loggerService = new(nameValueCollection);
                _loggerService.LogException(ex, AppSettings.AppConfig.LoggerMicroServiceEndPoint, newEntity, AppSettings.AppConfig.SecretKey);
                message.Messages = null;
            }
        }


    }
}