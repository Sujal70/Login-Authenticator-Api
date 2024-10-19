using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class AssetInventoryService : IAssetInventoryService
    {
        private readonly IAssetInventoryRepo _assetInventoryRepo;
        public AssetInventoryService(IAssetInventoryRepo assetInventoryRepo)
        {
            _assetInventoryRepo = assetInventoryRepo;
        }
        public void Add(AssetInventory Entity, Message message)
        {
            _assetInventoryRepo.Add(Entity, message);
        }
        public void Update(AssetInventory Entity, Message message)
        {
            _assetInventoryRepo.Update(Entity, message);
        }
        public void Delete(AssetInventory Entity, Message message)
        {
            _assetInventoryRepo.Delete(Entity, message);
        }
        public List<AssetInventory> GetAll(Message message)
        {
            var result = _assetInventoryRepo.ListAll(message);
            return result;
        }
        public AssetInventory GetSingle(AssetInventory searchModel, Message message)
        {
            BaseSpecification<AssetInventory> spec = new()
            {
                Criteria = a => a.InventoryId == searchModel.InventoryId
            };

            var result = _assetInventoryRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}