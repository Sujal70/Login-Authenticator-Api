using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class PurchaseEntry:BaseModelEntity
    {
        [Key]
        public decimal PODetailId { get; set; }
        [ForeignKey("PurchaseOrder")]
        public decimal POId { get; set; }
        [ForeignKey("AssetMaster")]
        public decimal AssetId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal ItemTotal { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
