using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITAM.Core.DBEntities
{
    public class PurchaseOrder:BaseModelEntity
    {
        [Key]
        public decimal POId { get; set; }
        public string OrderNo { get; set; }
        public DateTime RaisedBy { get; set; }
        public decimal SupplierId { get; set; }
        public string Status { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Taxes { get; set; }
        public decimal OtherCharges { get; set; }
        public decimal NetAmount { get; set; }
    }
}
