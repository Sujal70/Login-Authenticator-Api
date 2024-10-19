using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class AssetDetail:BaseModelEntity
    {
        [Key]
        public decimal AssetDetailId { get; set; }
        [ForeignKey("AssetMaster")]
        public decimal AssetId { get; set; }
        public string SerialNo { get; set; }
        public decimal MDMLinkId { get; set; }
        public string Barcode { get; set; }
        public string AssetNo { get; set; }
        public string Status { get; set; }
        public virtual AssetMaster AssetMaster { get; set; }
    }
}
