using System.ComponentModel.DataAnnotations;

namespace LT.Core.DBEntities
{
    /// <summary>
    /// DB entity with seperate Schema as ACL in same LT DB 
    /// </summary>
    public class LTTimezoneDiffInSecUS
    {
        [Key]

        public int Timezone_Id { get; set; }
        public int TimeZoneDiffinSec { get; set; }
    }
}
