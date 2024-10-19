using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace LT.Core.DBEntities
{
    /// <summary>
    /// DB entity with seperate Schema as ACL in same LT DB 
    /// </summary>
    public class MSSurveyCorporate
    {
        [Key]
        public decimal Corporate_No { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Timezone_Id { get; set; }
        public decimal Parent { get; set; }
        public string Corporate_Name { get; set; }
        public string Email_Address { get; set; }
        public string Corporate_Id { get; set; }
        public string Corporate_Password { get; set; }
        public string Ip_Address { get; set; }
        public string Last_Ip_Address { get; set; }
        public string Folder { get; set; }
        public int TimeFormat { get; set; }
        public int DateFormat { get; set; }
        public bool IsSuperAdmin { get; set; }
        public int Account_Type { get; set; }
        public DateTime MS_Date { get; set; }
        public DateTime Expires_On { get; set; }
        public string Lang { get; set; }
        public bool Del { get; set; }
        public bool IsDelete { get; set; }
        public bool IsWLC { get; set; }
    }
}
