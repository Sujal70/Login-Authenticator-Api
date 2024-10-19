using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class AssetTypeController : PageController<AssetType, BaseSearchEntity>
    {
        public readonly IAssetTypeService assetTypeService;

        public AssetTypeController(IAssetTypeService _assetTypeService, Message message) : base(message)
        {
            assetTypeService = _assetTypeService;
        }
        protected override void InternalUpdateNewDetails(AssetType newEntity, Message message)
        {
            assetTypeService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(AssetType updatedEntity, Message message)
        {
            assetTypeService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(AssetType deleteEntity, Message message)
        {
            assetTypeService.Delete(deleteEntity, message);
        }

        protected override List<AssetType> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = assetTypeService.GetAll(message);
            return list;
        }
        //protected override AssetType GetSingleRecord(AssetType searchModel, Message message)
        //{
        //    var result = assetTypeService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}