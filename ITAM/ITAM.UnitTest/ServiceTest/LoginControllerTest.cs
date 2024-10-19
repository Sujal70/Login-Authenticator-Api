using LT.Api.Controllers;
using LT.Application.BusinessInterfaces;
using LT.Core.ModelEntities;
using Xunit;


namespace LT.UnitTest.ServiceTest
{
    /// <summary>
    /// Unit test controller including authorize attribute 
    /// only mock data access layer
    /// </summary>
    public class LoginControllerTest(ICorpService corpService, IAuthService authService)
    {
        private readonly LoginController loginctrl = new(corpService, authService);

        [InlineData("letstalkdevelopers@gmail.com", "Welcome@123", true)]
        [InlineData("mpatel@gmail.com", "xyz123", false)]
        [Theory]
        public void AuthenticateUser(string UserName, string Password, bool success)
        {
            var model = new LoginModel { UserName = UserName, Password = Password };
            var result = loginctrl.AuthenticateUser(model);
            if (success)
            {
                Assert.True(result.Message.Status);
            }
            else
            {
                Assert.False(result.Message.Status);
            }
        }

    }

}
