using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IPurchaseOrderService
    {
        public List<PurchaseOrder> GetAll(Message message);
        public void Add(PurchaseOrder entity, Message message);
        public void Update(PurchaseOrder entity, Message message);
        public void Delete(PurchaseOrder entity, Message message);
        public PurchaseOrder GetSingle(PurchaseOrder searchModel, Message message);
    }
}