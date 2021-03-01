using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuzixApp.Models
{
    public class User
    {
        [BsonId]
        public string userName { get; set; }
        public string password { get; set; }
        

    }
}
