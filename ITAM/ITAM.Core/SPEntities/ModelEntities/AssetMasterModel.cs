using LT.Core.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Core.SPEntities.ModelEntities
{
    public class AssetMasterModel:BaseModelEntity
    {
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public string ManufacturerName { get; set; }
        public string SupplierName { get; set; }
    }
}
