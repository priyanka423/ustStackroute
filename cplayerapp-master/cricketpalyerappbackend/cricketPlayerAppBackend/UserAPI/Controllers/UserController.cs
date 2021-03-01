using MuzixApp.Models;
using MuzixApp.Services;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace MuzixApp.Controllers
{
    //[Authorize]
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        /*
            UserService should  be injected through constructor injection. Please note that we should not create service
            object using the new keyword
        */
        IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        /*
        * method which will create a specific user 
        * This handler method should map to the URL "/api/user" using HTTP POST method
        */
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public ActionResult<User> RegisterUser(User user)
        {
            try
            {
                userService.RegisterUser(user);
                return user;
            }
            catch (UserNotCreatedException unx)
            {
                return Conflict(unx.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /*
        * method  will delete a user from a database.
        * This handler method should map to the URL "/api/user/{id}" using HTTP Delete
        * method" where "id" should be replaced by a valid userId without {}
        */
        [HttpDelete]
        [Route("{userId}")]
        public ActionResult DeleteUser(string UserId)
        {
            try
            {
                return Ok(userService.DeleteUser(UserId));
            }
            catch (UserNotFoundException une)
            {
                return NotFound(une.Message);
            }
        }

        /*
        * method which show details of a specific user. 
        * This handler method should map to the URL "/api/user/{id}" using HTTP GET method where "id" should be
        * replaced by a valid userId without {}
        */
        [HttpGet]
        [Route("{userId}")]
        public ActionResult<User> GetUserById(string userId)
        {
            try
            {
                return userService.GetUserById(userId);
            }
            catch (UserNotFoundException une)
            {
                return NotFound(une.Message);
            }
        }

    }
}
