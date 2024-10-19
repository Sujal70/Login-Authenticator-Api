using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class SupplierController : PageController<Supplier, BaseSearchEntity>
    {
        public readonly ISupplierService supplierService;

        public SupplierController(ISupplierService _supplierService, Message message) : base(message)
        {
            supplierService = _supplierService;
        }
        protected override void InternalUpdateNewDetails(Supplier newEntity, Message message)
        {
            supplierService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(Supplier updatedEntity, Message message)
        {
            supplierService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(Supplier deleteEntity, Message message)
        {
            supplierService.Delete(deleteEntity, message);
        }

        protected override List<Supplier> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = supplierService.GetAll(message);
            return list;
        }
        //protected override Supplier GetSingleRecord(Supplier searchModel, Message message)
        //{
        //    var result = supplierService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
