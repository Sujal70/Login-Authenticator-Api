using AutoMapper;
using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using LT.Core.Common;

namespace ITAM.Application.BusinessClasses
{
    public class AssetDetailService:IAssetDetailService
    {
        private readonly IAssetDetailRepo _assetDetail;
        private readonly IMapper _mapper;
        public AssetDetailService(IAssetDetailRepo assetDetail, IMapper mapper)
        {
            _assetDetail = assetDetail;
            _mapper=mapper;
        }

        //public void Add(AssetDetail Entity, Message message)
        //{
        //    _assetDetail.Add(Entity, message);
        //}
        //public void Update(AssetDetail Entity, Message message)
        //{
        //    _assetDetail.Update(Entity, message);
        //}
        //public void Delete(AssetDetail Entity, Message message)
        //{
        //    _assetDetail.Delete(Entity, message);
        //}




        public List<AssetDetailModel> GetAll(AssestSearchEntity assestSearchEntity, Message message)
        {
            //var result = _assetDetail.ListAll(message);
            BaseSpecification<AssetDetail> spec = new()
            {
                Criteria = a => a.AssetMaster.AssetTypeId == assestSearchEntity.AssetTypeId,
                Includes = [t => t.AssetMaster, t => t.AssetMaster.AssetType, t => t.AssetMaster.AssetType.Supplier, t => t.AssetMaster.AssetType.Manufacturer],
            };
            var listAll = _assetDetail.List(spec, message);
            var result = _mapper.Map<List<AssetDetailModel>>(listAll);
            //_mapper.Map<UserData>(_unitOfWork.TokenRepo.GetUniqueRecordBySpec(spec, message))
            return result;
        }

        //public AssetDetail GetSingle(AssetDetail searchModel, Message message)
        //{
        //    BaseSpecification<AssetDetail> spec = new()
        //    {
        //        Criteria = a => a.AssetDetailId == searchModel.AssetDetailId
        //    };

        //    var result = _assetDetail.GetUniqueRecordBySpec(spec, message);
        //    return result;
        //}

        //public List<AssetDetail> GetData(AssestSearchEntity assetSearchEntity)
        //{
        //    var result = _assetDetail.GetAssetData(assetSearchEntity);
        //    return result;
        //}
    }
}
