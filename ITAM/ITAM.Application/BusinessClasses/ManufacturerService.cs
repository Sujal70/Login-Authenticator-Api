using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using LT.Core.BaseEntities;

namespace ITAM.Application.BusinessClasses
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IManufacturerRepo _manufactuerRepo;
        public ManufacturerService(IManufacturerRepo manufactuerRepo)
        {
            _manufactuerRepo = manufactuerRepo;
        }

        public void Add(Manufacturer entity, Message message)
        {
            _manufactuerRepo.Add(entity, message);
        }

        public void Delete(Manufacturer entity, Message message)
        {
            _manufactuerRepo?.Delete(entity, message);
        }

        public List<Manufacturer> GetAll(Message message)
        {
            var result=_manufactuerRepo.ListAll(message); 
            return result;
        }

        public Manufacturer GetSingle(Manufacturer searchModel, Message message)
        {
            BaseSpecification<Manufacturer> spec = new()
            {
                Criteria = a => a.ManufacturerId == searchModel.ManufacturerId

            };

            var manufacturer = _manufactuerRepo.GetUniqueRecordBySpec(spec, message);
            return manufacturer;
        }

        public void Update(Manufacturer entity, Message message)
        {
            _manufactuerRepo.Update(entity, message);
        }
    }
}