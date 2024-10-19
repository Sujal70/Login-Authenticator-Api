using ITAM.Core.DBEntities;
using ITAM.Data.EFData.Interfaces;
using LT.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Repositories
{
    public class UserLoginRepo : IUserLoginRepo
    {
        public InboxContext _dbContext {  get; }
        public UserLoginRepo(InboxContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void deleteUser(int userId)
        {
            UserLogin user = _dbContext.SujalUser1059.Find(userId);
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
