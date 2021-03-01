using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FavouriteService.Models
{
    public class FavouriteContext
    {
        //declare variables to connect to MongoDB database
        MongoClient mongoClient;
        IMongoDatabase database;
        public FavouriteContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration
            //mongoClient = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            mongoClient = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);

            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:FavouriteDatabase").Value);
        }

        //Define a MongoCollection to represent the Favourites collection of MongoDB
        public IMongoCollection<Favourite> Favourites => database.GetCollection<Favourite>("favourites");
    }
}
