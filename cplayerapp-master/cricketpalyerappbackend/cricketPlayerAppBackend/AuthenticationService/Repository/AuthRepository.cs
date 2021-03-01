using AuthenticationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Repository
{
    public class AuthRepository : IAuthRepository
    {
        AuthDbContext context;
        public AuthRepository(AuthDbContext _context)
        {
            context = _context;
        }
        public bool CreateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool IsUserExists(string userId)
        {
            var isExists = context.Users.Find(userId);
            if (isExists != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LoginUser(User user)
        {
            /* if(context.Users.Find(user.UserId)!=null)
             {
                 context.Users.FirstOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);
                 return true;
              }
             else
             {
                 return false;
             }*/
            var ob = context.Users.FirstOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);
            if (ob != null)
                return true;
            else
                return false;
        }
    }
    }
