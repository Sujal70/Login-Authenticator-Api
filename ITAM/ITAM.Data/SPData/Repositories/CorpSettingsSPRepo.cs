using DataHelper.SPData.Common.Repositories;
using LT.Core.SPEntities.ModelEntities;
using LT.Core.SPEntities.SPResults;
using LT.Data.SPData.Interfaces;

namespace LT.Data.SPData.Repositories
{
    public class CorpSettingsSPRepo : GenericSPRepository<CorpSettingsModel, CorpSettingsResult>, ICorpSettingsSPRepo
    {
        public CorpSettingsSPRepo() : base(ProcNames.LoginSelectCorpSettingsSP) { }

        /// <summary>
        /// Override this method to transfer the sp actual result into final model entity 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="spResult"></param>
        /// <returns>List<CorpSettingsModel></returns>
        protected override List<CorpSettingsModel> SetEntityResult(object message, IEnumerable<CorpSettingsResult> spResult)
        {
            return (from a in spResult
                    select new CorpSettingsModel
                    {
                        CorporateId = a.Corporate_Id,
                        IsLockAccount = a.IsLockAccount,
                        IsAccountSecuritySettings = a.IsAccountSecuritySettings,
                        IsOldPassword = a.IsOldPassword,
                        IsExpirePasswordAfterDays = a.IsExpirePasswordAfterDays,
                        IsAccountBlocked = a.IsAccountBlocked,
                        IsFirstLogon = a.IsFirstLogon,
                        IsBlockIp = a.IsBlockIp,
                        IsMarkedForDeletion = a.IsMarkedForDeletion,
                        FolderActivate = a.Folder_Activate,
                        IsTrial = a.IsTrial,
                        NextChargeDate = a.NextChargeDate,
                        IsEnable = a.IsEnable,
                        IsForcedBlock = a.IsForcedBlock,
                        AccountType = a.Account_Type,
                        PaymentType = a.PaymentType,
                        IsEngageAdmin = a.IsEngageAdmin,
                        EmailAddress = a.Email_Address,
                        IsMultipleLoginAlert = a.IsMultipleLoginAlert,
                        IsChatEnabled = a.IsChatEnabled,
                        LastUsedTool = a.Last_Used_Tool,
                        Is2StepAuthEnabled = a.Is2StepAuthEnabled,
                        FirstName = a.First_name,
                        LastName = a.Last_name,
                        CorporateName = a.Corporate_name,
                        CorporateNo = a.Corporate_no,
                        LanguageCode = a.Lang,
                        IsEmailRelay = a.IsEmailRelay

                    }).ToList();
        }
    }

}
