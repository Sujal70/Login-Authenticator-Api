using ConfigReader.Entities;
using LT.Core.Common;
using LT.Core.ModelEntities;

namespace LT.Application.BusinessInterfaces
{
    public interface IAuthService
    {
        Boolean ValidateUser(Message message, LoginModel loginData);
    
    }
}
