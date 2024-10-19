using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface ILocationTypeService
    {
        public List<LocationType> GetAll(Message message);
        public void Add(LocationType entity, Message message);
        public void Update(LocationType entity, Message message);
        public void Delete(LocationType entity, Message message);
        public LocationType GetSingle(LocationType searchModel, Message message);
    }
}
