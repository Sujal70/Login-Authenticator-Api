using DataHelper.EFData.Common.Interfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using ITAM.Core.SearchEntity;
using LT.Core;

namespace ITAM.Data.EFData.Interfaces
{
    public interface IAssetDetailRepo: IGenericBaseRepo<AssetDetail, InboxContext>
    {
        public List<AssetDetail> GetAssetData(AssestSearchEntity assetSearchEntity);
    }
}
