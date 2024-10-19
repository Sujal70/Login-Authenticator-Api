namespace LT.Core.ModelEntities
{
    /// <summary>
    /// Model entity class to send / receive response to the client UI 
    /// </summary>
    public class SurveyCorporateModel
    {
        public decimal CorporateNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TimezoneId { get; set; }
        public decimal Parent { get; set; }
        public string CorporateName { get; set; }
        public string EmailAddress { get; set; }
        public string CorporateId { get; set; }
        public string CorporatePassword { get; set; }
        public string IpAddress { get; set; }
        public string LastIpAddress { get; set; }
        public string Folder { get; set; }
        public int TimeFormat { get; set; }
        public int DateFormat { get; set; }
        public bool IsSuperAdmin { get; set; }
        public int AccountType { get; set; }
        public DateTime MSDate { get; set; }
        public DateTime ExpiresOn { get; set; }
        public bool IsWLC { get; set; }
        public bool IsDelete { get; set; }
    }
}
