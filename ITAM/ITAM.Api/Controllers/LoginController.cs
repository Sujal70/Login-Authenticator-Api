using ConfigReader;
using ConfigReader.Entities;
using LT.Api.Controllers.Common;
using LT.Application.BusinessInterfaces;
using LT.Core.Common;
using LT.Core.ModelEntities;
using Microsoft.AspNetCore.Mvc;

namespace LT.Api.Controllers
{
    /// <summary>
    /// All actions required to process authentication flow and inherited from Basecontrollers
    /// </summary>
    [Authorize(AuthorizeLevel.None)]
    public class LoginController(ICorpService corpService, IAuthService authService) : BaseController
    {
        /// <summary>
        /// AuthenticateUser
        /// </summary>
        /// <param name="formData"></param>
        /// <returns>MainViewModel<SplashPageDisplaySettings></returns>
        [HttpPost("authenticate")]
        public MainViewModel<string> AuthenticateUser([FromBody] LoginModel formData)
        {
            Message message = new()
            {
                ScreenId = (int)ScreenMasterEnum.LTLogin,
                ApiAddress = Request.Path
            };
            bool result = authService.ValidateUser(message, formData);
            if (result)
            {
                SurveyCorporateModel sur = new()
                {
                    FirstName = "Ayush",
                    LastName = "Yadav",
                    AccountType = 1,
                    CorporateId = "324",
                    CorporateName = "ZI Systech",
                    EmailAddress = "ayadav1@zarca.com"
                };

                 string token = GetAccessToken(sur);
                 return new MainViewModel<string>(token, message);
            }
            else
            {
                message.Fail(); 
                message.UserMessage = "Invalid UserId or Password";
                return new MainViewModel<string>(message.UserMessage, message);
            }
        }
    }

}