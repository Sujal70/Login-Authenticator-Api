using ConfigReader.Entities;
using LT.Core.Common;

namespace LT.Application.BusinessInterfaces
{
    public interface IAuthService
    {
        UserData GetToken(Message message, UserData userData);
    
    }
}
