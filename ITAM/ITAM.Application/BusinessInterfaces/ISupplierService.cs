using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface ISupplierService
    {
        public List<Supplier> GetAll(Message message);
        public void Add(Supplier entity, Message message);
        public void Update(Supplier entity, Message message);
        public void Delete(Supplier entity, Message message);
        public Supplier GetSingle(Supplier searchModel, Message message);
    }
}
