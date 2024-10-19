using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IAssetInventoryService
    {
        public void Add(AssetInventory entity, Message message);
        public void Delete(AssetInventory entity, Message message);
        public void Update(AssetInventory entity, Message message);
        public List<AssetInventory> GetAll(Message message);
        public AssetInventory GetSingle(AssetInventory searchModel, Message message);

    }
}