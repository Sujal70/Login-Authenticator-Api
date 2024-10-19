using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class AssetType:BaseModelEntity
    {
        [Key]
        public int AssetTypeId { get; set; }
        public string Description { get; set; }
        [ForeignKey("Manufacturer")]
        public decimal ManufacturerId { get; set; }
        [ForeignKey("Supplier")]
        public decimal SupplierId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
