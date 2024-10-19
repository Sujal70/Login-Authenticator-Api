using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class PurchaseEntryController : PageController<PurchaseEntry, OrderSearchEntity>
    {
        public readonly IPurchaseEntryService purchaseEntryService;

        public PurchaseEntryController(IPurchaseEntryService _purchaseEntryService, Message message) : base(message)
        {
            purchaseEntryService = _purchaseEntryService;
        }
        protected override void InternalUpdateNewDetails(PurchaseEntry newEntity, Message message)
        {
            purchaseEntryService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(PurchaseEntry updatedEntity, Message message)
        {
            purchaseEntryService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(PurchaseEntry deleteEntity, Message message)
        {
            purchaseEntryService.Delete(deleteEntity, message);
        }

        protected override List<PurchaseEntry> GetList(OrderSearchEntity orderSearchEntity, Message message)
        {
            var list = purchaseEntryService.GetData(orderSearchEntity);
            //var list = purchaseEntryService.GetAll(message);
            return list;
        }
        //protected override PurchaseEntry GetSingleRecord(PurchaseEntry searchEntity, Message message)
        //{
        //    var result = purchaseEntryService.GetSingle(searchEntity, message);
        //    return result;
        //}
    }
}
