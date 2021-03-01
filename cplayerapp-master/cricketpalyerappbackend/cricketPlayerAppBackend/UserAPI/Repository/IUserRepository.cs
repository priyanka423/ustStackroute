using MuzixApp.Models;

namespace MuzixApp.Repository
{
    public interface IUserRepository
    {
        User RegisterUser(User user);
        bool DeleteUser(string userId);
        User GetUserById(string userId);

    }
}
