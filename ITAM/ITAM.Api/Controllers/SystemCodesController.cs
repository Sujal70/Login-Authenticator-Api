using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class SystemCodesController : PageController<SystemCodes, BaseSearchEntity>
    {
        public readonly ISystemCodesService systemCodesService;

        public SystemCodesController(ISystemCodesService _systemCodesService, Message message) : base(message)
        {
            systemCodesService = _systemCodesService;
        }
        protected override void InternalUpdateNewDetails(SystemCodes newEntity, Message message)
        {
            systemCodesService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(SystemCodes updatedEntity, Message message)
        {
            systemCodesService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(SystemCodes deleteEntity, Message message)
        {
            systemCodesService.Delete(deleteEntity, message);
        }

        protected override List<SystemCodes> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = systemCodesService.GetAll(message);
            return list;
        }
        //protected override SystemCodes GetSingleRecord(SystemCodes searchModel, Message message)
        //{
        //    var result = systemCodesService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
