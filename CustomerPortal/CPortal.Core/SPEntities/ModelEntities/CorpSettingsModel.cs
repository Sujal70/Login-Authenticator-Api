namespace LT.Core.SPEntities.ModelEntities
{
    /// <summary>
    /// Model entity class to send / receive response to the client UI 
    /// </summary>
    public class CorpSettingsModel
    {
        public string CorporateId { get; set; }
        public bool IsLockAccount { get; set; }
        public bool IsAccountSecuritySettings { get; set; }
        public bool IsOldPassword { get; set; }
        public bool IsExpirePasswordAfterDays { get; set; }
        public bool IsAccountBlocked { get; set; }
        public bool IsFirstLogon { get; set; }
        public bool IsBlockIp { get; set; }
        public bool IsMarkedForDeletion { get; set; }
        public bool FolderActivate { get; set; }
        public bool IsTrial { get; set; }
        public DateTime? NextChargeDate { get; set; }
        public bool IsEnable { get; set; }
        public int IsForcedBlock { get; set; }
        public int AccountType { get; set; }
        public string PaymentType { get; set; }
        public bool? IsEngageAdmin { get; set; }
        public string EmailAddress { get; set; }
        public bool? IsMultipleLoginAlert { get; set; }
        public bool? IsChatEnabled { get; set; }
        public byte? LastUsedTool { get; set; }
        public bool? Is2StepAuthEnabled { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CorporateName { get; set; }
        public decimal CorporateNo { get; set; }
        public string LanguageCode { get; set; }
        public bool IsEmailRelay { get; set; }
    }
}
