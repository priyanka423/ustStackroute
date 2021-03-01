using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MuzixApp.Models;

namespace UserService.Models
{
    public class UserContext
    {
        //declare variable to connect to MongoDB database
        MongoClient mongoClient;
        IMongoDatabase database;

        public UserContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration
            mongoClient = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:UserDatabase").Value);

        }

        //Define a MongoCollection to represent the Users collection of MongoDB
        public IMongoCollection<User> Users => database.GetCollection<User>("users");


    }
}
