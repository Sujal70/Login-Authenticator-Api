using LT.Core.BaseEntities;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class AssignAsset:BaseModelEntity
    {
        [Key]
        public int AssignId { get; set; }
        [ForeignKey("LocationMaster")]
        public int LocationId { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("AssetMaster")]
        public decimal AssetId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual AssetMaster AssetMaster { get; set; }
    }
}
