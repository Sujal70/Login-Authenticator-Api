using ConfigReader.Entities;
using DataHelper.HelperClasses;
using ITAM.Application.BusinessInterfaces;
using ITAM.Application.LoginAttemptServicr;
using ITAM.Application.passwordHash;
using ITAM.Core.DBEntities;
using ITAM.Core.SearchEntity;
using ITAM.Data.EFData.Interfaces;
using LT.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAM.Application.BusinessClasses
{
    public class UserLoginServices : IUserLoginServices
    {
        private readonly IUserLoginRepo _userLoginRepo;
        private readonly IloginAttemptService _loginAttemptService;

        public UserLoginServices(IUserLoginRepo userLoginRepo, IloginAttemptService loginAttemptService)
        {
            _userLoginRepo = userLoginRepo;
            _loginAttemptService = loginAttemptService;
        }
        public UserLogin AuthenticateUser(string username,string password , Message message, string ipAddress)
        {
            if (_loginAttemptService.captchaShow(username)){

                return null; // Return null to indicate login blocked due to too many failed attempts
            }
            password = hashPassword.ComputeHash(password);
            BaseSpecification<UserLogin> spec = new()
            {
                Criteria = a => a.UserName == username && a.Password == password,
            };
            var res = _userLoginRepo.GetUniqueRecordBySpec(spec, message);
            if (res != null)
            {
                // Reset failed attempts on successful login
                _loginAttemptService.ResetFailedAttempts(username);
                logUserLogin(username, ipAddress);
                return res;
            }
            else
            {
                // Record the failed attempt
                _loginAttemptService.RecordFailedAttempt(username);
                if (_loginAttemptService.captchaShow(username))
                {
                    message.UserMessage = "You have failed to login more than 3 times. Please complete the CAPTCHA.";
                }
                else
                {
                    message.UserMessage = "Invalid username or password.";
                }
                return null;
            }
        }
        //public void PostUser(UserLogin userLogin , Message message)
        //{
        //    userLogin.Password = hashPassword.ComputeHash(userLogin.Password);
        //    //_userLoginRepo.Add(userLogin, message);
        //    _userLoginRepo.Add(userLogin, message);
        //}
        public void PostUser(LoginSearchEntity loginSearchEntity, Message message)
        {
            loginSearchEntity.Password = hashPassword.ComputeHash(loginSearchEntity.Password);
            UserLogin userlogin = new UserLogin()
            {
                UserName = loginSearchEntity.UserName,
                Password = loginSearchEntity.Password,
                CreatedDate = DateTime.UtcNow,
            };
            _userLoginRepo.Add(userlogin, message);
        }
        public void DeleteUser(int userId,Message message)
        {
            BaseSpecification<UserLogin> spec = new()
            {
                Criteria = a => a.UserId == userId,
            };
            _userLoginRepo.Delete(spec, message);


            //_userLoginRepo.deleteUser(userId);
            //return ;
        }
        public void logUserLogin(string username, string ipAddress)
        {
            Console.WriteLine($"User {username} logged in from ipAddress {ipAddress}");
            Console.WriteLine($"User {username} logged in from ipAddress {ipAddress}");
        }
    }
}
