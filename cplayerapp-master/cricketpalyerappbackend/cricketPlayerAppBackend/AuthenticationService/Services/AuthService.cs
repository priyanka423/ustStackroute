using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public class AuthService : IAuthService
    {
         private IAuthRepository repository;
        public AuthService(IAuthRepository _repository)
        {
            repository = _repository;
        }
        public bool LoginUser(User user)
        {
            /* var loginInfo = repository.LoginUser(user);
             if(loginInfo)
             {
                 return true;
             }
             else
             {
                 return false;
             }*/

            if (repository.LoginUser(user))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RegisterUser(User user)
        {
            var userstatus = repository.IsUserExists(user.UserId);
            if(!userstatus)
            {
                repository.CreateUser(user);
                return true;
            }
            else
            {
                throw new UserAlreadyExistsException($"This userId {user.UserId} already in use");
            }
        }
    }
}
