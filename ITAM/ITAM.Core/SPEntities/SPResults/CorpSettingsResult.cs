namespace LT.Core.SPEntities.SPResults
{
    /// <summary>
    /// SP  actual result entity
    /// </summary>
    public class CorpSettingsResult
    {
        public string Corporate_Id { get; set; }
        public bool IsLockAccount { get; set; }
        public bool IsAccountSecuritySettings { get; set; }
        public bool IsOldPassword { get; set; }
        public bool IsExpirePasswordAfterDays { get; set; }
        public bool IsAccountBlocked { get; set; }
        public bool IsFirstLogon { get; set; }
        public bool IsBlockIp { get; set; }
        public bool IsMarkedForDeletion { get; set; }
        public bool Folder_Activate { get; set; }
        public bool IsTrial { get; set; }
        public DateTime? NextChargeDate { get; set; }
        public bool IsEnable { get; set; }
        public int IsForcedBlock { get; set; }
        public int Account_Type { get; set; }
        public string PaymentType { get; set; }
        public bool? IsEngageAdmin { get; set; }
        public string Email_Address { get; set; }
        public bool? IsMultipleLoginAlert { get; set; }
        public bool? IsChatEnabled { get; set; }
        public byte? Last_Used_Tool { get; set; }
        public bool? Is2StepAuthEnabled { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Corporate_name { get; set; }
        public decimal Corporate_no { get; set; }
        public string Lang { get; set; }
        public bool IsEmailRelay { get; set; }
    }
}
