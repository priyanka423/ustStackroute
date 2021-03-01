using MuzixApp.Models;
using MuzixApp.Repository;

namespace MuzixApp.Services
{
    public class UserService : IUserService
    {
        //Use constructor Injection to inject all required dependencies.
        IUserRepository repository;
        public UserService(IUserRepository _repository)
        {
            repository = _repository;
        }


        //This method should be used to delete an existing user.
        public bool DeleteUser(string userId)
        {
            var userAvailableStatus = GetUserById(userId);
            if (userAvailableStatus == null)
            {
                throw new UserNotFoundException($"This user id does not exist");
            }
            else
            {
                return repository.DeleteUser(userId);
            }
        }
        //This method should be used to delete an existing user
        public User GetUserById(string userId)
        {
            var user = repository.GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException($"This user id does not exist");
            }
            else return user;
        }
        //This method is used to register a new user
        public User RegisterUser(User user)
        {
            var userInfo = repository.GetUserById(user.userName);
            if (userInfo == null)
            {
                repository.RegisterUser(user);
                return user;
            }
            else
            {
                throw new UserNotCreatedException($"This user id already exists");
            }
        }

        

    }
}
