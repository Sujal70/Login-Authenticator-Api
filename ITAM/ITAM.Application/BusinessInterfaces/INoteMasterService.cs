using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface INoteMasterService
    {
        public List<NoteMaster> GetAll(Message message);
        public void Add(NoteMaster entity, Message message);
        public void Update(NoteMaster entity, Message message);
        public void Delete(NoteMaster entity, Message message);
        public NoteMaster GetSingle(NoteMaster searchModel, Message message);
    }
}
