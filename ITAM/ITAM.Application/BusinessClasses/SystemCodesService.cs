using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;

namespace ITAM.Application.BusinessClasses
{
    public class SystemCodesService:ISystemCodesService
    {
        private readonly ISystemCodesRepo _systemCodes;
        public SystemCodesService(ISystemCodesRepo systemCodes)
        {
            _systemCodes = systemCodes;
        }

        public void Add(SystemCodes Entity, Message message)
        {
            _systemCodes.Add(Entity, message);
        }
        public void Update(SystemCodes Entity, Message message)
        {
            _systemCodes.Update(Entity, message);
        }
        public void Delete(SystemCodes Entity, Message message)
        {
            _systemCodes.Delete(Entity, message);
        }
        public List<SystemCodes> GetAll(Message message)
        {
            var result = _systemCodes.ListAll(message);
            return result;
        }
        public SystemCodes GetSingle(SystemCodes searchModel, Message message)
        {
            BaseSpecification<SystemCodes> spec = new()
            {
                Criteria = a => a.SystemCodeId == searchModel.SystemCodeId
            };

            var result = _systemCodes.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}

