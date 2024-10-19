using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssetTypeService
    {
        public List<AssetType> GetAll(Message message);
        public void Add(AssetType entity, Message message);
        public void Update(AssetType entity, Message message);
        public void Delete(AssetType entity, Message message);
        public AssetType GetSingle(AssetType searchModel, Message message);
    }
}
