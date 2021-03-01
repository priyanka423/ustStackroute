using MuzixApp.Models;

namespace MuzixApp.Services
{
    public interface IUserService
    {
        public bool DeleteUser(string userId);
        public User GetUserById(string userId);
        public User RegisterUser(User user);

    }
}
