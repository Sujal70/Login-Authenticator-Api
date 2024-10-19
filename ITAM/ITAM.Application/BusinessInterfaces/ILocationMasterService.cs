using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface ILocationMasterService
    {
        public List<LocationMaster> GetAll(Message message);
        public void Add(LocationMaster entity, Message message);
        public void Update(LocationMaster entity, Message message);
        public void Delete(LocationMaster entity, Message message);
        public LocationMaster GetSingle(LocationMaster searchModel, Message message);
    }
}
