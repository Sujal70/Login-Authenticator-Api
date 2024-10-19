using ConfigReader;
using ConfigReader.Entities;
using LT.Api.Controllers.Common;
using LT.Application.BusinessInterfaces;
using LT.Core.Common;
using LT.Core.ModelEntities;
using LT.Core.SPEntities.SPResults;
using Microsoft.AspNetCore.Mvc;

namespace LT.Api.Controllers
{
    /// <summary>
    /// All actions required to process authentication flow and inherited from Basecontrollers
    /// </summary>
    [Authorize(AuthorizeLevel.ITAMToken)]
    public class CustomerDetailsController : BaseController
    {
        private readonly ICorpService _corpService;
        public CustomerDetailsController(ICorpService corpService, Message message) : base(message)
        {
            _corpService = corpService;
        }
        /// <summary>
        /// AuthenticateUser
        /// </summary>
        /// <param name="formData"></param>
        /// <returns>MainViewModel<SplashPageDisplaySettings></returns>
        [HttpPost("parentEmailDetail")]
        public MainViewModel<ParentsEmailDetails> AuthenticateUser()
        {
            Message message = new()
            {
                ScreenId = (int)ScreenMasterEnum.LTLogin,
                ApiAddress = Request.Path
            };
            ParentsEmailDetails parentDetails = _corpService.GetParentsEmailDetails( message);
            return new MainViewModel<ParentsEmailDetails>(parentDetails, message);
        }

    }

}