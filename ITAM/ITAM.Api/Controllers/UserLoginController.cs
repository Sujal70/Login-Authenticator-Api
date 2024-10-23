using ConfigReader.Entities;
using ITAM.Api.TokenHandler;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using Microsoft.AspNetCore.Mvc;

namespace ITAM.Api.Controllers
{
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly IUserLoginServices _userLoginServices;
        private readonly IloginAttemptService _loginAttemptService;
        private readonly IConfiguration _configuration;

        public UserLoginController(IUserLoginServices userLoginServices, IloginAttemptService loginAttemptService,IConfiguration configuration)
        {
            _userLoginServices = userLoginServices;
            _loginAttemptService = loginAttemptService;
            _configuration = configuration;
        }
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            Message message = new Message();
            var ipAddress=HttpContext.Connection.RemoteIpAddress?.ToString();
            // Check if CAPTCHA is required due to too many failed attempts
            if (_loginAttemptService.captchaShow(username))
            {
                return BadRequest(new
                {
                    message = "You have failed to login more than 3 times. Please complete the CAPTCHA.",
                    showCaptcha = true // Indicate that CAPTCHA should be shown
                });
            }

            // Authenticate the user
            var user = _userLoginServices.AuthenticateUser(username, password, message,ipAddress);

            if (user != null)
            {
                // Generate JWT token for the authenticated user
                var tokenService =new JwtTokenService(_configuration);
                var token = tokenService.GenerateToken(username);
                return Ok(new { user,token,ipAddress });
            }

            // Handle failed login case and CAPTCHA indication
            if (_loginAttemptService.captchaShow(username))
            {
                return BadRequest(new
                {
                    message = "You have failed to login more than 3 times. Please complete the CAPTCHA.",
                    showCaptcha = true // Indicate CAPTCHA should be shown
                });
            }

            return BadRequest(new { message = message.UserMessage, showCaptcha = false });
        }
        //[HttpPost("postUser")]
        //public ActionResult<UserLogin> PostUser([FromBody] UserLogin userLogin)
        //{
        //    Message message = new Message();
        //    userLogin.CreatedDate = DateTime.UtcNow;
        //    _userLoginServices.PostUser(userLogin,message);
        //    return Ok(new { message = "User Added Successfully" });
        //}
        [HttpPost("postUser")]
        public ActionResult<UserLogin> PostUser(LoginSearchEntity loginSearchEntity)
        {
            Message message = new Message();
            _userLoginServices.PostUser(loginSearchEntity, message);
            return Ok(new { message = "User Added Successfully" });
        }
        [HttpDelete("deleteUser")]
        public void deleteUser(int userId,Message message)
        {
            _userLoginServices.DeleteUser(userId, message);
            return;
        }
    }
}
