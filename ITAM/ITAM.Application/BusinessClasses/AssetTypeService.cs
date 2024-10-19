using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class AssetTypeService: IAssetTypeService
    {
        private readonly IAssetTypeRepo _assetTypeRepo;
        public AssetTypeService(IAssetTypeRepo assetTypeRepo)
        {
            _assetTypeRepo = assetTypeRepo;
        }

        public void Add(AssetType Entity, Message message)
        {
            _assetTypeRepo.Add(Entity, message);
        }
        public void Update(AssetType Entity, Message message)
        {
            _assetTypeRepo.Update(Entity, message);
        }
        public void Delete(AssetType Entity, Message message)
        {
            _assetTypeRepo.Delete(Entity, message);
        }
        public List<AssetType> GetAll(Message message)
        {
            var result = _assetTypeRepo.ListAll(message);
            return result;
        }
        public AssetType GetSingle(AssetType searchModel, Message message)
        {
            BaseSpecification<AssetType> spec = new()
            {
                Criteria = a => a.AssetTypeId == searchModel.AssetTypeId
            };

            var result = _assetTypeRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
