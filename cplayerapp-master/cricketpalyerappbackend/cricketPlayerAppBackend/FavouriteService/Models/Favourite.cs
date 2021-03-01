using MongoDB.Bson.Serialization.Attributes;
using System;

namespace FavouriteService.Models
{
    public class Favourite
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public int PlayerId { get; set; }
        public string CreatedBy { get; set; }
        public string PlayerImage { get; set; }
        public string playerName { get; set; }
    }
}
