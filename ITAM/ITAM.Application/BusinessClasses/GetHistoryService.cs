using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Core.DBEntities;
using ITAM.Core.ModelEntities;
using ITAM.Data.EFData.Interfaces;
using ITAM.Data.EFData.Repositories;
using LT.Core.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessClasses
{
    public class GetHistoryService: IGetHistoryService
    {
        private readonly IGetHistoryRepo _getHistoryRepo;
        private readonly IUserLoginRepo _userLoginRepo;

        public GetHistoryService(IGetHistoryRepo getHistoryRepo, IUserLoginRepo userLoginRepo)
        {
            _getHistoryRepo = getHistoryRepo;
            _userLoginRepo = userLoginRepo;
        }
        public HistoryData getHistoryData(int userId, Message message)
        {
            BaseSpecification<HistoryData> spec = new()
            {
                Criteria = a => a.UserLogin.UserId == userId,
                Includes =  [t=>t.UserLogin]
            };
            var result = _getHistoryRepo.GetUniqueRecordBySpec(spec, message);
            return result;
        }
    }
}
