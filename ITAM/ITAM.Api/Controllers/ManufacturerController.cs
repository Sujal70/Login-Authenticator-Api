using ConfigReader.Entities;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using LT.Api.Controllers.Common;
using LT.Core.BaseEntities;

namespace ITAM.Api.Controllers
{
    [Authorize(AuthorizeLevel.None)]
    public class ManufacturerController : PageController<Manufacturer, BaseSearchEntity> 
    {
        public readonly IManufacturerService manufacturerService;

        public ManufacturerController(IManufacturerService _manufacturerService, Message message):base(message) => manufacturerService = _manufacturerService;
        protected override List<Manufacturer> GetList(BaseSearchEntity SearchModel, Message message)
        {
            var list = manufacturerService.GetAll(message);
            return list;
        }
        //protected override Manufacturer GetSingleRecord(Manufacturer searchModel, Message message)
        //{
        //    var result=manufacturerService.GetSingle(searchModel, message);
        //    return result;
        //}
        protected override void InternalUpdateNewDetails(Manufacturer newEntity, Message message)
        {
            manufacturerService.Add(newEntity, message);
        }
        protected override void InternalUpdateExistingDetails(Manufacturer updatedEntity, Message message)
        {
            manufacturerService.Update(updatedEntity, message);
        }
        protected override void InternalDeleteDetails(Manufacturer deleteEntity, Message message)
        {
            manufacturerService.Delete(deleteEntity, message);
        }
    }
}