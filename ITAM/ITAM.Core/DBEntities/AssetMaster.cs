using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class AssetMaster: BaseModelEntity
    {
        [Key]
        public decimal AssetId { get; set; }
        [ForeignKey("AssetType")]
        public int AssetTypeId { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public string ModelNo { get; set; }
        public decimal DeptId { get; set; }
        public virtual AssetType AssetType { get; set; }
    }
}
