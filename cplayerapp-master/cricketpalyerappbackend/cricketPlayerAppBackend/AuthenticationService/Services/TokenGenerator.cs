using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
    public class TokenGenerator : ITokenGenerator
    {
       
        
            public string JWTToken(string userId)
            {
                var userClaims = new[]
                {
              new Claim(JwtRegisteredClaimNames.UniqueName,userId),
              new Claim(JwtRegisteredClaimNames.Jti,new Guid().ToString())
            };

                var userKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("USTAuthenticationAPIKeyforSecurity"));
                var userCredentials = new SigningCredentials(userKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "AuthenticationService",
                    audience: "PlayerAPI",
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: userCredentials,
                    claims: userClaims
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }

