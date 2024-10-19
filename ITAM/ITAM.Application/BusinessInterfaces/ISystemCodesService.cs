using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Core.DBEntities;

namespace ITAM.Application.BusinessInterfaces
{
    public interface ISystemCodesService
    {
        public List<SystemCodes> GetAll(Message message);
        public void Add(SystemCodes entity, Message message);
        public void Update(SystemCodes entity, Message message);
        public void Delete(SystemCodes entity, Message message);
        public SystemCodes GetSingle(SystemCodes searchModel, Message message);
    }
}
