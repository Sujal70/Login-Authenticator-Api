using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class LocationMasterController : PageController<LocationMaster, BaseSearchEntity>
    {
        public readonly ILocationMasterService locationMasterService;

        public LocationMasterController(ILocationMasterService _locationMasterService, Message message) : base(message)
        {
            locationMasterService = _locationMasterService;
        }
        protected override void InternalUpdateNewDetails(LocationMaster newEntity, Message message)
        {
            locationMasterService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(LocationMaster updatedEntity, Message message)
        {
            locationMasterService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(LocationMaster deleteEntity, Message message)
        {
            locationMasterService.Delete(deleteEntity, message);
        }

        protected override List<LocationMaster> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = locationMasterService.GetAll(message);
            return list;
        }
        //protected override LocationMaster GetSingleRecord(LocationMaster searchModel, Message message)
        //{
        //    var result = locationMasterService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
