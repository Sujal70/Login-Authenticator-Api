using ConfigReader.Entities;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IDocumentsService
    {
        public List<Documents> GetAll(Message message);
        public void Add(Documents entity, Message message);
        public void Update(Documents entity, Message message);
        public void Delete(Documents entity, Message message);
        public Documents GetSingle(Documents searchModel, Message message);
    }
}
