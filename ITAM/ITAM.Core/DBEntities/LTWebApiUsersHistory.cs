using System.ComponentModel.DataAnnotations;

namespace LT.Core.DBEntities
{
    /// <summary>
    /// DB entity with seperate Schema as ACL in same LT DB 
    /// </summary>
    public class LTWebApiUsersHistory
    {
        [Key]
        public long Id { get; set; }
        public long MainCorpNo { get; set; }
        public long LoginCorpNo { get; set; }
        public string UniqueId { get; set; }
        public string JWTToken { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public bool? IsSubAdmin { get; set; }
    }
}
