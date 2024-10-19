using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class AssetInventoryController : PageController<AssetInventory, BaseSearchEntity>
    {
        public readonly IAssetInventoryService assetInventoryService;
        public AssetInventoryController(IAssetInventoryService _assetInventoryService, Message message) : base(message)
        {
            assetInventoryService = _assetInventoryService;
        }
        protected override void InternalUpdateNewDetails(AssetInventory newEntity, Message message)
        {
            assetInventoryService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(AssetInventory updatedEntity, Message message)
        {
            assetInventoryService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(AssetInventory deleteEntity, Message message)
        {
            assetInventoryService.Delete(deleteEntity, message);
        }

        protected override List<AssetInventory> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = assetInventoryService.GetAll(message);
            return list;
        }
        //protected override AssetInventory GetSingleRecord(AssetInventory searchModel, Message message)
        //{
        //    var result = assetInventoryService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}