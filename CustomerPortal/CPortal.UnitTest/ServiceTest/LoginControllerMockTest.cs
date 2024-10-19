using ConfigReader.Entities;
using LT.Api.Controllers;
using LT.Application.BusinessInterfaces;
using LT.Core.ModelEntities;
using Moq;
using Xunit;

namespace LT.UnitTest.ServiceTest
{
    /// <summary>
    /// Unit test controller with actual moq NuGet Package
    /// It mock service layer
    /// </summary>
    public class LoginControllerMockTests
    {
        private readonly Mock<IAuthService> _mockauthService;
        private readonly Mock<ICorpService> _mockCorpService;
        private readonly LoginController loginctrl;
        public LoginControllerMockTests()
        {
            _mockCorpService = new Mock<ICorpService>();
            _mockauthService = new Mock<IAuthService>();
            loginctrl = new LoginController(_mockCorpService.Object, _mockauthService.Object);
        }

        [InlineData("letstalkdevelopers@gmail.com", "Welcome@123", true)]
        [InlineData("mpatel@gmail.com", "xyz123", false)]
        [Theory]
        public void AuthenticateUserMock(string UserName, string Password, bool success)
        {


            var message = new Message();
            var loginModel = new ParentDetail() { UserName = UserName, Password = Password };
            var corpmodel = new SurveyCorporateModel() { CorporateNo = 126888, CorporateId = "mock data", AccountType = 14, CorporateName = "mocktest" };
            var result = new LT.Core.SPEntities.ModelEntities.CorpSettingsModel();

            _mockCorpService.Setup(bl => bl.GetCorpSettings(corpmodel.Parent, corpmodel.CorporateNo, message))
                          .Returns(result);

            var finalresult = loginctrl.AuthenticateUser(loginModel);
            if (success)
            {
                Assert.True(finalresult.Message.Status);
            }
            else
            {
                Assert.False(finalresult.Message.Status);
            }
        }

    }
}