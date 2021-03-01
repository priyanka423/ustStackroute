using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace RecommendService.Models
{
    public class Recommend
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int PlayerId { get; set; }
       
        public int Category { get; set; }
        public int Count { get; set; }
       
    }
}
