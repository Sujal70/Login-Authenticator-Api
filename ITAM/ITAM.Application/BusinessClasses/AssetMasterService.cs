using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Core.SPEntities.ModelEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.SPData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class AssetMasterService : IAssetMasterService
    {
        private readonly IAssetMasterRepo _assetMaster;
        private readonly IAssetMasterSPRepo _assetMasterSPRepo;

        public AssetMasterService(IAssetMasterRepo assetMaster, IAssetMasterSPRepo assetMasterSPRepo)
        {
            _assetMasterSPRepo = assetMasterSPRepo;
            _assetMaster = assetMaster;
        }

        public void Add(AssetMaster entity, Message message)
        {
            _assetMaster.Add(entity, message);
        }

        public void Delete(AssetMaster entity, Message message)
        {
            _assetMaster.Delete(entity, message);
        }

        public List<AssetMaster> GetAll(Message message)
        {
            List<AssetMaster> list = _assetMaster.ListAll(message);
            return list;
        }

        public AssetMasterModel GetSingle(AssetMasterSearch searchModel, Message message)
        {
            //BaseSpecification<AssetMaster> spec = new()
            //{
            //    Criteria = a => a.AssetId == searchModel.AssetId
            //};
            //var assetMaster = _assetMaster.GetUniqueRecordBySpec(spec, message);
            //return assetMaster;
            return _assetMasterSPRepo.GetSPData(new { @AssetId = 1 }, message).FirstOrDefault();
        }

        public void Update(AssetMaster entity, Message message)
        {
            _assetMaster.Update(entity, message);
        }
    }
}
