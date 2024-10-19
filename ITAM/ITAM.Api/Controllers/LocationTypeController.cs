using ConfigReader.Entities;
using ITAM.Application.BusinessClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class LocationTypeController : PageController<LocationType, BaseSearchEntity>
    {
        public readonly ILocationTypeService locationTypeService;

        public LocationTypeController(ILocationTypeService _locationTypeService, Message message) : base(message)
        {
            locationTypeService = _locationTypeService;
        }
        protected override void InternalUpdateNewDetails(LocationType newEntity, Message message)
        {
            locationTypeService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(LocationType updatedEntity, Message message)
        {
            locationTypeService.Update(updatedEntity, message);
        }

        protected override void InternalDeleteDetails(LocationType deleteEntity, Message message)
        {
            locationTypeService.Delete(deleteEntity, message);
        }

        protected override List<LocationType> GetList(BaseSearchEntity searchModel, Message message)
        {
            var list = locationTypeService.GetAll(message);
            return list;
        }
        //protected override LocationType GetSingleRecord(LocationType searchModel, Message message)
        //{
        //    var result = locationTypeService.GetSingle(searchModel, message);
        //    return result;
        //}
    }
}
