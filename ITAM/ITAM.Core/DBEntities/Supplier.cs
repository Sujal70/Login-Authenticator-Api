using LT.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace ITAM.Core.DBEntities
{
    public class Supplier:BaseModelEntity
    {
        [Key]
        public decimal SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string ContractInformation { get; set; }
    }
}
