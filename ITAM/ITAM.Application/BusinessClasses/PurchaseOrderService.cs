using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class PurchaseOrderService:IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepo _purchaseOrder;
        public PurchaseOrderService(IPurchaseOrderRepo purchaseOrder)
        {
            _purchaseOrder = purchaseOrder;
        }

        public void Add(PurchaseOrder Entity, Message message)
        {
            _purchaseOrder.Add(Entity, message);
        }
        public void Update(PurchaseOrder Entity, Message message)
        {
            _purchaseOrder.Update(Entity, message);
        }
        public void Delete(PurchaseOrder Entity, Message message)
        {
            _purchaseOrder.Delete(Entity, message);
        }
        public List<PurchaseOrder> GetAll(Message message)
        {
            var result = _purchaseOrder.ListAll(message);
            return result;
        }
        public PurchaseOrder GetSingle(PurchaseOrder searchModel, Message message)
        {
            BaseSpecification<PurchaseOrder> spec = new()
            {
                Criteria = a => a.POId == searchModel.POId
            };

            var result = _purchaseOrder.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
