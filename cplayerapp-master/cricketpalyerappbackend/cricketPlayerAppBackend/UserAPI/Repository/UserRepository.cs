using MongoDB.Driver;
using MuzixApp.Models;
using System.Linq;
using UserService.Models;

namespace MuzixApp.Repository
{
    public class UserRepository : IUserRepository
    {
        UserContext dbContext;
        //define a private variable to represent UserContext
        public UserRepository(UserContext _context)
        {
            dbContext = _context;
        }

        //This method should be used to delete an existing user.
        public bool DeleteUser(string userId)
        {
            var status = dbContext.Users.DeleteOneAsync(x => x.userName == userId);
            return true;
        }

        //This method should be used to delete an existing user
        public User GetUserById(string userId)
        {
            var user = dbContext.Users.Find(u => u.userName == userId).FirstOrDefault();
            return user;
        }
        //This method is used to register a new user
        public User RegisterUser(User user)
        {
            dbContext.Users.InsertOne(user);
            return user;
        }
        

    }
}
