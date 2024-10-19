using LT.Infrastructure.UnitOfWork.Interfaces;
using AutoMapper;
using ConfigReader.Entities;
using DataHelper.HelperClasses;
using LT.Application.BusinessInterfaces;
using LT.Core.Common;
using LT.Core.DBEntities;

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
        public UserData GetToken(Message message, UserData loginUser)
        {
            BaseSpecification<LTWebApiUsers> spec = new()
            {
                Criteria = e => e.MainCorpNo == loginUser.MainCorpNo && e.LoginCorpNo == loginUser.LoginCorpNo && e.JWTToken == loginUser.JWTToken
            };
            return _mapper.Map<UserData>(_unitOfWork.TokenRepo.GetUniqueRecordBySpec(spec, message));
        }
    }
}
