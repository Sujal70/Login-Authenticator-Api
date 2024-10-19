using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class DocumentsController : PageController<Documents, BaseSearchEntity>
    {
        public readonly IDocumentsService documentsService;

        public DocumentsController(IDocumentsService _documentsService, Message message) : base(message)
        {
            documentsService = _documentsService;
        }
        protected override void InternalUpdateNewDetails(Documents newEntity, Message message)
        {
            documentsService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(Documents updatedEntity, Message message)
        {
            documentsService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(Documents deleteEntity, Message message)
        {
            documentsService.Delete(deleteEntity, message);
        }

        protected override List<Documents> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = documentsService.GetAll(message);
            return list;
        }
        //protected override Documents GetSingleRecord(Documents searchModel, Message message)
        //{
        //    var result = documentsService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
