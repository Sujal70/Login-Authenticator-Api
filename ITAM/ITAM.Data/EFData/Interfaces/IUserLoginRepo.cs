using DataHelper.EFData.Common.Interfaces;
using ITAM.Core.DBEntities;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Data.EFData.Interfaces
{
    public interface IUserLoginRepo : IGenericBaseRepo<UserLogin,InboxContext>
    {
        public void deleteUser(int userId);
    }
}
