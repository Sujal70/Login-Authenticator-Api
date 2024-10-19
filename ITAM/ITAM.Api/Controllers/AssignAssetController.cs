using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class AssignAssetController : PageController<AssignAsset, LocationSearchEntity>
    {
        public readonly IAssignAssetService assignAssetService;

        public AssignAssetController(IAssignAssetService _assignAssetService, Message message) : base(message)
        {
            assignAssetService = _assignAssetService;
        }
        protected override void InternalUpdateNewDetails(AssignAsset newEntity, Message message)
        {
            assignAssetService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(AssignAsset updatedEntity, Message message)
        {
            assignAssetService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(AssignAsset deleteEntity, Message message)
        {
            assignAssetService.Delete(deleteEntity, message);
        }

        protected override List<AssignAsset> GetList(LocationSearchEntity searchModel, Message message)
        {
            //var list = assignAssetService.GetAll(message);
            var list = assignAssetService.GetData(searchModel);
            return list;
        }
        //protected override AssignAsset GetSingleRecord(AssignAsset searchModel, Message message)
        //{
        //    var result = assignAssetService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
