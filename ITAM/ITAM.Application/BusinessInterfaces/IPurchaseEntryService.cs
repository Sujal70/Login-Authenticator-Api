using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IPurchaseEntryService
    {
        public List<PurchaseEntry> GetAll(Message message);
        public void Add(PurchaseEntry entity, Message message);
        public void Update(PurchaseEntry entity, Message message);
        public void Delete(PurchaseEntry entity, Message message);
        public PurchaseEntry GetSingle(PurchaseEntry searchModel, Message message);
        public PurchaseEntry GetNew(ISpecification<PurchaseEntry> spec, Message message);
        public List<PurchaseEntry> GetData(OrderSearchEntity orderSearchEntity);
    }
}
