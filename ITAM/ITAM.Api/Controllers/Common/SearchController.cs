using ConfigReader;
using ConfigReader.Entities;
using LT.Core.BaseEntities;
using LT.Core.Common;
using Microsoft.AspNetCore.Mvc;
using LT.Api.Utilities;

namespace LT.Api.Controllers.Common
{
    /// <summary>
    /// Generic Controller class to perform Search with Single or List of Records
    /// It takes two Generic Types as M and S
    /// </summary>
    /// <typeparam name="M">M is of Type Class with Parameter Less constructor</typeparam>
    /// <typeparam name="S">S is of Type  BaseSearchEntity or should be inherited from BaseSearchEntity with Parameter Less constructor</typeparam>
    /// <returns></returns>
    public class SearchController<M, S> : BaseController where M : class, new() where S : BaseSearchEntity
    {
        public SearchController() { }
        public SearchController(Message message) : base(message)
        {
        }
        /// <summary>
        /// It returns a single record of Type M wrapped with MainViewModel which has
        /// Two parameters as T and Message
        /// </summary>
        /// <param name="formData"></param>
        /// <returns>MainViewModel<M></returns>
        [HttpPost("search")]
        public virtual MainViewModel<M> GetSingle([FromBody] S formData)
        {
            message.ApiAddress = Request.Path;
            message.ScreenId = (int)ScreenMasterEnum.LTLogin;
            message.Messages.AddLog("Entered in Search Detail API", CallParams);
            M results = new();
            if (IsValidSearchData(formData, message))
            {
                formData.CorpNo = TokenClaimModel != null ? TokenClaimModel.MainCorpNo:0;
                formData.CorpNoSub = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo:0;
                formData.ServerTimeZoneId = TokenClaimModel != null ? AppSettings.AppConfig.ServerTimeZoneId:0;
                results = GetSingleRecord(formData, message);
            }
            else
            {
                message.Fail();
            }
            message.Messages.AddLog("Exit from API");
            LogInfo(message);
            message.Messages = null;
            return new MainViewModel<M>(results, message);
        }

        /// <summary>
        /// It returns a list of records of Type M wrapped with MainViewModel which has
        /// Two parameters as T and Message
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public MainViewModel<List<M>> List([FromQuery] S formData)
        {
            message.ApiAddress = Request.Path;
            message.ScreenId = (int)ScreenMasterEnum.LTLogin;
            message.Messages.AddLog("Entered in " + Request.Path, CallParams);
            List<M> result = null;
            if (IsValidSearchData(formData, message))
            {
                formData.CorpNo = TokenClaimModel != null ? TokenClaimModel.MainCorpNo : 0;
                formData.CorpNoSub = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo : 0;
                formData.ServerTimeZoneId = TokenClaimModel != null ? TokenClaimModel.TimeZoneId : 0;
                result = GetList(formData, message);
            }
            if (result == null)
            {
                message.Fail();
                message.UserMessage = Constants.NoRecordFound;
            }
            else
            {
                message.UserMessage = "Search Result successfull";
            }
            message.Messages.AddLog("Exit from " + Request.Path);
            LogInfo(message);
            message.Messages = null;
            return new MainViewModel<List<M>>(result, message);
        }

        /// <summary>
        /// Must override in parent controller to get the actual result to be sent to the response
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="message"></param>
        /// <returns>List<M></returns>
        protected virtual List<M> GetList(S searchModel, Message message)
        {
            message.UserMessage = "Search was not overrdidden";
            return new List<M>();
        }

        /// <summary>
        /// Must override in parent controller to get the actual result to be sent to the response
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="message"></param>
        /// <returns>M</returns>
        protected virtual M GetSingleRecord(S searchModel, Message message)
        {
            HttpClient client = new();
            client.GetAsync("");
            message.UserMessage = "GetRecordDetail was not overrdidden";
            return new M();
        }
    }
}