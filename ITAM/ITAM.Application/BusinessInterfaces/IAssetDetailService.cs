using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using ITAM.Core.SearchEntity;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssetDetailService
    {
        //public void Add(AssetDetail entity, Message message);
        //public void Delete(AssetDetail entity, Message message);
        //public void Update(AssetDetail entity, Message message);
        //public AssetDetail GetSingle(AssetDetail searchModel, Message message);
        public List<AssetDetailModel> GetAll(AssestSearchEntity assestSearchEntity, Message message);
        //public List<AssetDetail> GetData(AssestSearchEntity assetSearchEntity);
    }
}
