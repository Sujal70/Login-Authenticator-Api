using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;

namespace ITAM.Application.BusinessClasses
{
    public class SupplierService:ISupplierService
    {
        private readonly ISupplierRepo _supplierRepo;
        public SupplierService(ISupplierRepo supplierRepo)
        {
            _supplierRepo = supplierRepo;
        }

        public void Add(Supplier Entity, Message message)
        {
            _supplierRepo.Add(Entity, message);
        }
        public void Update(Supplier Entity, Message message)
        {
            _supplierRepo.Update(Entity, message);
        }
        public void Delete(Supplier Entity, Message message)
        {
            _supplierRepo.Delete(Entity, message);
        }
        public List<Supplier> GetAll(Message message)
        {
            var result = _supplierRepo.ListAll(message);
            return result;
        }
        public Supplier GetSingle(Supplier searchModel, Message message)
        {
            BaseSpecification<Supplier> spec = new()
            {
                Criteria = a => a.SupplierId == searchModel.SupplierId
            };

            var result = _supplierRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
