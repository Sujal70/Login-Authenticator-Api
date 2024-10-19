using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;


namespace LT.Core.DBEntities
{
    /// <summary>
    /// DB entity with seperate Schema as ACL in same LT DB 
    /// </summary>
    public class LTWebApiUsers : BaseDBEntity
    {
        [Key]
        public string UniqueId { get; set; }
        public string JWTToken { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public bool? IsSubAdmin { get; set; }
    }
}
