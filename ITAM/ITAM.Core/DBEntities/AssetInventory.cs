using LT.Core.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class AssetInventory:BaseModelEntity
    {
        [Key]
        public decimal InventoryId { get; set; }
        [ForeignKey("AssetMaster")]
        public decimal AssetId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Tax { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime WarrantyDate { get; set; }
    }
}
