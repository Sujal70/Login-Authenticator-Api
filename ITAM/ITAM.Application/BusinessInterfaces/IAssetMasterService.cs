using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Core.SPEntities.ModelEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssetMasterService
    {
        public List<AssetMaster> GetAll(Message message);
        public void Add(AssetMaster entity, Message message);
        public void Update(AssetMaster entity, Message message);
        public void Delete(AssetMaster entity, Message message);
        public AssetMasterModel GetSingle(AssetMasterSearch searchModel, Message message);
    }
}
