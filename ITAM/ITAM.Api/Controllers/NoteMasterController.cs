using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class NoteMasterController : PageController<NoteMaster, BaseSearchEntity>
    {
        public readonly INoteMasterService noteMasterService;

        public NoteMasterController(INoteMasterService _noteMasterService, Message message) : base(message)
        {
            noteMasterService = _noteMasterService;
        }
        protected override void InternalUpdateNewDetails(NoteMaster newEntity, Message message)
        {
            noteMasterService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(NoteMaster updatedEntity, Message message)
        {
            noteMasterService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(NoteMaster deleteEntity, Message message)
        {
            noteMasterService.Delete(deleteEntity, message);
        }

        protected override List<NoteMaster> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = noteMasterService.GetAll(message);
            return list;
        }
        //protected override NoteMaster GetSingleRecord(NoteMaster searchModel, Message message)
        //{
        //    var result = noteMasterService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
