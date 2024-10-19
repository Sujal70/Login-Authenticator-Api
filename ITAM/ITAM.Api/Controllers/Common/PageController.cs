using ConfigReader;
using ConfigReader.Entities;
using LT.Core.BaseEntities;
using LT.Core.Common;
using Microsoft.AspNetCore.Mvc;
using LT.Api.Utilities;

namespace LT.Api.Controllers.Common
{
    /// <summary>
    /// Generic Controller class to perform Insert Update and Delete Operations
    /// It takes two Generic Types as M and S
    /// </summary>
    /// <typeparam name="M">M is of Type BaseModelEntity or should be inherited from BaseModelEntity with Parameter Less constructor</typeparam>
    /// <typeparam name="S">S is of Type  BaseSearchEntity or should be inherited from BaseSearchEntity with Parameter Less constructor</typeparam>
    /// <returns></returns>
    public abstract class PageController<M, S> : SearchController<M, S> where M : BaseModelEntity, new() where S : BaseSearchEntity
    {
        protected PageController() { }
        protected PageController(Message message) : base(message) { }


        /// <summary>
        /// It Insert ot Update an exisitng record based on Flag Property value either Add (1) or Edit (0)
        /// </summary>
        /// <param name="formData"></param>
        /// <returns> MainViewModel<M></returns>
        [HttpPost("insertupdate")]
        public virtual MainViewModel<M> InsertUpdate([FromBody] M formData)
        {

            message.ApiAddress = Request.Path;
            message.Messages.AddLog("Entered in insertupdate API", CallParams);
            if (IsValidFormData(formData, message))
            {
                formData.CorpNo = TokenClaimModel != null ? TokenClaimModel.MainCorpNo : 0;
                formData.CreatedBy = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo : 0;
                int action = formData.Flag;
                if (action == ActionFlags.Add)
                    InternalUpdateNewDetails(formData, message);
                else
                    InternalUpdateExistingDetails(formData, message);

                if (message.Status)
                    message.UserMessage = action == ActionFlags.Add ? Constants.RecordCreatedSuccessfully : Constants.RecordUpdatedSuccessfully;
            }
            message.Messages.AddLog("Exit from insertupdate API");
            LogInfo(message);
            message.Messages = null;
            return new MainViewModel<M>(message);
        }


        /// <summary>
        /// It Deletes the Selected record
        /// </summary>
        /// <param name="formData"></param>
        /// <returns>MainViewModel<M></returns>
        [HttpPost("delete")]
        public virtual MainViewModel<M> DeleteEntity([FromBody] M formData)
        {
            message.ApiAddress = Request.Path;
            message.Messages.AddLog("Entered delete in API", CallParams);
            if (IsValidFormData(formData, message))
            {
                formData.CorpNo = TokenClaimModel != null ? TokenClaimModel.LoginCorpNo : 0;
                InternalDeleteDetails(formData, message);

                if (message.Status)
                    message.UserMessage = Constants.RecordDeletedSuccessfully;

            }
            message.Messages.AddLog("Exit from delete API");
            LogInfo(message);
            message.Messages = null;
            return new MainViewModel<M>(message);
        }

        /// <summary>
        ///  Must override in parent controller to save the New request object
        /// </summary>
        /// <param name="newEntity"></param>
        /// <param name="message"></param>
        protected virtual void InternalUpdateNewDetails(M newEntity, Message message)
        {
            message.UserMessage = "UpdateNewDetails was not overrdidden";
        }

        /// <summary>
        /// Must override in parent controller to update the existing request object
        /// </summary>
        /// <param name="updatedEntity"></param>
        /// <param name="message"></param>
        protected virtual void InternalUpdateExistingDetails(M updatedEntity, Message message)
        {
            message.UserMessage = "UpdateExistingDetails was not overridden";
        }

        /// <summary>
        /// Must override in parent controller to delete the existing request object
        /// </summary>
        /// <param name="deleteEntity"></param>
        /// <param name="message"></param>
        protected virtual void InternalDeleteDetails(M deleteEntity, Message message)
        {
            message.UserMessage = "InternalDeleteDetailsById was not overridden";
        }

    }
}
