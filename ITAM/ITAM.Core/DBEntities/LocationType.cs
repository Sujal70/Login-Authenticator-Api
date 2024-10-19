using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace ITAM.Core.DBEntities
{
    public class LocationType:BaseModelEntity
    {
        [Key]
        public int LocationTypeId { get; set; }
        public string LocationTypeInfo { get; set; }
    }
}
