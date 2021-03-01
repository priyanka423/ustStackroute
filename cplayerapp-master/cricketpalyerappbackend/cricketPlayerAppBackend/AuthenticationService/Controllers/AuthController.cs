using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class AuthController : ControllerBase
    {
        
        private IAuthService _authService;
        private ITokenGenerator _tokenGenerator;
        

        public AuthController(IAuthService authService,ITokenGenerator tokenGenerator)
        {
            _authService = authService;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] User user)
        {
            try
            {
                var userStatus = _authService.RegisterUser(user);
                return Created("api/auth/register", userStatus);
            }
            catch (UserAlreadyExistsException uaex)
            {
                return Conflict(uaex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }



        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromBody] User user)
        {
            try
            {
                if (_authService.LoginUser(user))
                {
                    var token = _tokenGenerator.JWTToken(user.UserId);
                    var status = "success";
                    var res = new { status = "success",userId=user.UserId,token1=token };
                    var jsonObj = JsonConvert.SerializeObject(res);
                   // return jsonObj;
                    /*object[] array = new object[3] { user.UserId, token, status };*/
                    return Ok(jsonObj);
                }
                else
                {
                    var token = _tokenGenerator.JWTToken(user.UserId);
                    var status = "failure";

                    object[] array1 = new object[3] { user.UserId, token, status };
                    return Ok(array1);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            var authHeader = HttpContext.Request.Headers["Authorization"].ToString();
            bool isAuthenticated = false;
            if (authHeader.StartsWith("Bearer"))
            {
                string token = authHeader.Substring(7);
                isAuthenticated = Startup.IsTokenValid(token);
            }

            Dictionary<string, bool> result = new Dictionary<string, bool>();
            result.Add("isAuthenticated", isAuthenticated);
            return Ok(result);
        }


    }
}
