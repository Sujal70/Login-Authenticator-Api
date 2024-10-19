using DataHelper.SPData.Common.Repositories;
using ITAM.Core.SPEntities.ModelEntities;
using ITAM.Core.SPEntities.SPResults;
using ITAM.Data.SPData.Interfaces;

namespace ITAM.Data.SPData.Repositories
{
    public class AssetMasterSPRepo : GenericSPRepository<AssetMasterModel, AssetMaster_Result>, IAssetMasterSPRepo
    {
        public AssetMasterSPRepo() : base() { }

        /// <summary>
        /// Override this method to transfer the sp actual result into final model entity 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="spResult"></param>
        /// <returns>List<CorpSettingsModel></returns>
        protected override List<AssetMasterModel> SetEntityResult(object message, IEnumerable<AssetMaster_Result> spResult)
        {
            return (from a in spResult
                    select new AssetMasterModel
                    {
                        AssetName = a.AssetName,
                        AssetDescription = a.AssetDescription,
                        ManufacturerName = a.Manufacturer_Name,
                        SupplierName = a.Supplier_Name,
                    }).ToList();
        }
    }

}

