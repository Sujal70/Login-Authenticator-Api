using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;

namespace ITAM.Application.BusinessClasses
{
    public class LocationMasterService:ILocationMasterService
    {
        private readonly ILocationMasterRepo _locationMasterRepo;
        public LocationMasterService(ILocationMasterRepo locationMasterRepo)
        {
            _locationMasterRepo = locationMasterRepo;
        }
        public void Add(LocationMaster Entity, Message message)
        {
            _locationMasterRepo.Add(Entity, message);
        }
        public void Update(LocationMaster Entity, Message message)
        {
            _locationMasterRepo.Update(Entity, message);
        }
        public void Delete(LocationMaster Entity, Message message)
        {
            _locationMasterRepo.Delete(Entity, message);
        }
        public List<LocationMaster> GetAll(Message message)
        {
            var result = _locationMasterRepo.ListAll(message);
            return result;
        }
        public LocationMaster GetSingle(LocationMaster searchModel, Message message)
        {
            BaseSpecification<LocationMaster> spec = new()
            {
                Criteria = a => a.LocationId == searchModel.LocationId
            };

            var result = _locationMasterRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
