using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using ITAM.Core.SearchEntity;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class AssetDetailController : PageController<AssetDetailModel, AssestSearchEntity>
    {
        public readonly IAssetDetailService assetDetailService;

        public AssetDetailController(IAssetDetailService _assetDetailService, Message message) : base(message)
        {
            assetDetailService = _assetDetailService;
        }
        //protected override void InternalUpdateNewDetails(AssetDetail newEntity, Message message)
        //{
        //    assetDetailService.Add(newEntity, message);
        //}
        //protected override void InternalUpdateExistingDetails(AssetDetail updatedEntity, Message message)
        //{
        //    assetDetailService.Update(updatedEntity, message);
        //}

        //protected override void InternalDeleteDetails(AssetDetail deleteEntity, Message message)
        //{
        //    assetDetailService.Delete(deleteEntity, message);
        //}

        protected override List<AssetDetailModel> GetList(AssestSearchEntity searchModel, Message message)
        {
            var list = assetDetailService.GetAll(searchModel, message);
            //var list = assetDetailService.GetData(searchModel);
            return list;
        }
        //protected override AssetDetail GetSingleRecord(AssetDetail searchModel, Message message)
        //{
        //    var result = assetDetailService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
