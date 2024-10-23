using ConfigReader.Entities;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessInterfaces
{
    public interface IUserLoginServices 
    {
        public UserLogin AuthenticateUser(string username, string password,Message message,string ipAddress);
        public void PostUser(LoginSearchEntity loginSearchEntity, Message message);
        public void DeleteUser(int userId, Message message);
        public void logUserLogin(string username, string ipAddress);
    }
}
