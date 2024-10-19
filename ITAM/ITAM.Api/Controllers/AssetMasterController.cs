using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Core.SPEntities.ModelEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    //[Authorize(AuthorizeLevel.AccessToken)]
    public class AssetMasterController : PageController<AssetMasterModel, AssetMasterSearch>
    {
        private readonly IAssetMasterService assetMasterService;

        //public AssetMasterController(IAssetMasterService _assetMasterService, Message message) : base(message) => assetMasterService = _assetMasterService;
        //protected override void InternalUpdateNewDetails(AssetMaster newEntity, Message message)
        //{
        //    assetMasterService.Add(newEntity, message);
        //}
        //protected override void InternalUpdateExistingDetails(AssetMaster updatedEntity, Message message)
        //{
        //    assetMasterService.Update(updatedEntity, message);
        //}

        //protected override void InternalDeleteDetails(AssetMaster deleteEntity, Message message)
        //{
        //    assetMasterService.Delete(deleteEntity, message);
        //}

        //protected override List<AssetMaster> GetList(BaseSearchEntity searchModel, Message message)
        //{
        //    var list = assetMasterService.GetAll(message);
        //    return list;
        //}
        protected override AssetMasterModel GetSingleRecord(AssetMasterSearch searchModel, Message message)
        {
            var result = assetMasterService.GetSingle(searchModel, message);
            return result;
        }
    }
}
