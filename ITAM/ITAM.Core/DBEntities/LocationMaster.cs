using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class LocationMaster:BaseModelEntity
    {
        [Key]
        public int LocationId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string PostalAddress { get; set; }
        public string GeoLocation { get; set; }
        [ForeignKey("LocationType")]
        public int LocationTypeId { get; set; }
        [ForeignKey("NoteMaster")]
        public decimal NotesId { get; set; }
        public virtual LocationType LocationType { get; set; }
        public virtual NoteMaster NoteMaster { get; set; }
    }
}
