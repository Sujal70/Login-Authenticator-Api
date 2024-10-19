using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessClasses
{
    public class LocationTypeService:ILocationTypeService
    {
        private readonly ILocationTypeRepo _locationType;
        public LocationTypeService(ILocationTypeRepo locationType)
        {
            _locationType = locationType;
        }

        public void Add(LocationType Entity, Message message)
        {
            _locationType.Add(Entity, message);
        }
        public void Update(LocationType Entity, Message message)
        {
            _locationType.Update(Entity, message);
        }
        public void Delete(LocationType Entity, Message message)
        {
            _locationType.Delete(Entity, message);
        }
        public List<LocationType> GetAll(Message message)
        {
            var result = _locationType.ListAll(message);
            return result;
        }
        public LocationType GetSingle(LocationType searchModel, Message message)
        {
            BaseSpecification<LocationType> spec = new()
            {
                Criteria = a => a.LocationTypeId == searchModel.LocationTypeId
            };

            var result = _locationType.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
