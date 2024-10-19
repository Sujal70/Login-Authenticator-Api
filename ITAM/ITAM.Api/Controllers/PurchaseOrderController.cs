using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class PurchaseOrderController : PageController<PurchaseOrder, BaseSearchEntity>
    {
        public readonly IPurchaseOrderService purchaseOrderService;
        public readonly IPurchaseEntryService purchaseEntryService;
        public readonly IAssetInventoryService assetInventoryService;
        public PurchaseOrderController(IPurchaseOrderService _purchaseOrderService, IAssetInventoryService _assetInventoryService, IPurchaseEntryService _purchaseEntryService, Message message) : base(message)
        {
            purchaseOrderService = _purchaseOrderService;
            purchaseEntryService = _purchaseEntryService;
            assetInventoryService = _assetInventoryService;
        }
        protected override void InternalUpdateNewDetails(PurchaseOrder newEntity, Message message)
        {
            purchaseOrderService.Add(newEntity, message);
            BaseSpecification<PurchaseEntry> spec = new()
            {
                Criteria = a => a.POId == newEntity.POId

            };
            var purchaseEntry = purchaseEntryService.GetNew(spec, message);
            if (purchaseEntry != null) {
                AssetInventory insertQuery = new()
                {
                    InventoryId = 100,
                    AssetId = purchaseEntry.AssetId,
                    Quantity = purchaseEntry.Quantity,
                    UnitRate = 10,
                    Tax = newEntity.Taxes,
                    ExpiryDate = DateTime.Now,
                    WarrantyDate = DateTime.Now
                };
                assetInventoryService.Add(insertQuery, message);
            }
        }
        protected override void InternalUpdateExistingDetails(PurchaseOrder updatedEntity, Message message)
        {
            purchaseOrderService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(PurchaseOrder deleteEntity, Message message)
        {
            purchaseOrderService.Delete(deleteEntity, message);
        }

        protected override List<PurchaseOrder> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = purchaseOrderService.GetAll(message);
            return list;
        }
        //protected override PurchaseOrder GetSingleRecord(PurchaseOrder searchModel, Message message)
        //{
        //    var result = purchaseOrderService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
