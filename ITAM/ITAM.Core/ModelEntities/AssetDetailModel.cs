using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.ModelEntities
{
    public class AssetDetailModel:BaseModelEntity
    {
        public string SerialNo { get; set; }
        public decimal MDMLinkId { get; set; }
        public string AssetDescription { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
        public string AssetName { get; set; }
        public string Status { get; set; }
        public decimal DeptId { get; set; }
    }
}
