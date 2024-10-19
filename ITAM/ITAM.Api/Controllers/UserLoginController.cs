using ConfigReader.Entities;
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
        public UserLoginController(IUserLoginServices userLoginServices)
        {
            _userLoginServices = userLoginServices;
        }
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            Message message = new Message();
            var user = _userLoginServices.AuthenticateUser(username, password,message);
            if(user != null)
            {
                return Ok(new {user});
            }
            return BadRequest();
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
