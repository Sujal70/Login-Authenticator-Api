using DataHelper.SPData.Common.Interfaces;
using ITAM.Core.SPEntities.ModelEntities;
using ITAM.Core.SPEntities.SPResults;

namespace ITAM.Data.SPData.Interfaces
{
    public interface IAssetMasterSPRepo : IGenericSPRepository<AssetMasterModel, AssetMaster_Result>
    {
    }
}
