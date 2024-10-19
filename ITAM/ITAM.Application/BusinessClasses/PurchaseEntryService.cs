using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class PurchaseEntryService:IPurchaseEntryService
    {
        private readonly IPurchaseEntryRepo _purchaseEntry;
        public PurchaseEntryService(IPurchaseEntryRepo purchaseEntry)
        {
            _purchaseEntry = purchaseEntry;
        }
        public void Add(PurchaseEntry Entity, Message message)
        {
            _purchaseEntry.Add(Entity, message);
        }
        public void Update(PurchaseEntry Entity, Message message)
        {
            _purchaseEntry.Update(Entity, message);
        }
        public void Delete(PurchaseEntry Entity, Message message)
        {
            _purchaseEntry.Delete(Entity, message);
        }
        public List<PurchaseEntry> GetAll(Message message)
        {
            var result = _purchaseEntry.ListAll(message);
            return result;
        }
        public PurchaseEntry GetSingle(PurchaseEntry searchModel, Message message)
        {
            BaseSpecification<PurchaseEntry> spec = new()
            {
                Criteria = a => a.POId == searchModel.POId
            };

            var manufacturer = _purchaseEntry.GetUniqueRecordBySpec(spec, message);
            return manufacturer;
        }
        public PurchaseEntry GetNew(ISpecification<PurchaseEntry> spec, Message message)
        {
            var manufacturer = _purchaseEntry.GetUniqueRecordBySpec(spec, message);
            return manufacturer;
        }
        public List<PurchaseEntry> GetData(OrderSearchEntity orderSearchEntity)
        {
            var result = _purchaseEntry.GetOrderData(orderSearchEntity);
            return result;
        }
    }
}
