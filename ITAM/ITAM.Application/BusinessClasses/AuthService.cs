using LT.Infrastructure.UnitOfWork.Interfaces;
using AutoMapper;
using ConfigReader.Entities;
using DataHelper.HelperClasses;
using LT.Application.BusinessInterfaces;
using LT.Core.Common;
using LT.Core.DBEntities;
using LT.Core.ModelEntities;

namespace LT.Application.BusinessClasses
{
    /// <summary>
    /// Basic private methods are designed here to minimize the loc in main busienss class
    /// </summary>
    /// <summary>
    /// Business class to process the Authentication of corporate account
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthService(IUnitOfWork unitOfWork, ICorpService corpService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="message"></param>
        /// <param name="loginUser"></param>
        /// <returns>UserData</returns>
        public Boolean ValidateUser(Message message, LoginModel loginUser)
        {
            BaseSpecification<LoginModel> spec = new()
            {
                Criteria = e => e.UserId == loginUser.UserId && e.Password == loginUser.Password
            };
            var result = _unitOfWork.TokenRepo.GetUniqueRecordBySpec(spec, message);
            //return _mapper.Map<UserData>(_unitOfWork.TokenRepo.GetUniqueRecordBySpec(spec, message));
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
