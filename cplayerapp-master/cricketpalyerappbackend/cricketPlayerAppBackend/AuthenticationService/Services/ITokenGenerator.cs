﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Services
{
   public  interface ITokenGenerator
    {
    
            string JWTToken(string userId);
    }
}
