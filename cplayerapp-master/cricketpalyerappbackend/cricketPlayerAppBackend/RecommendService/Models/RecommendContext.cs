using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecommendService.Models
{
    public class RecommendContext
    {
        //declare variables to connect to MongoDB database
        MongoClient mongoClient;
        IMongoDatabase database;
        public RecommendContext(IConfiguration configuration)
        {
            //Initialize MongoClient and Database using connection string and database name from configuration
            mongoClient = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
            database = mongoClient.GetDatabase(configuration.GetSection("MongoDB:RecommendDatabase").Value);
        }

        //Define a MongoCollection to represent the Recommends collection of MongoDB
        public IMongoCollection<Recommend> Recommends => database.GetCollection<Recommend>("recommends");
    }
}
