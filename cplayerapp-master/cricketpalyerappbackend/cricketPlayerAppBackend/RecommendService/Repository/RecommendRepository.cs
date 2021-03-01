using MongoDB.Driver;
using Newtonsoft.Json;
using RecommendService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecommendService.Repository
{
    public class RecommendRepository : IRecommendRepository
    {
        RecommendContext recommendContext;
        dynamic res = "";
        public RecommendRepository(RecommendContext recommendContext)
        {
            this.recommendContext = recommendContext;
        }

        public List<Recommend> GetRecommendedPlayers()
        {
            try
            {
                var recommendList = recommendContext.Recommends.Find(c=>c.Count>2).Sort(Builders <Recommend>.Sort.Descending("Count")).ToList();
                return recommendList;
            }
            catch (Exception)
            {
                return null;
            }
        }
               
        public async Task<Object> GetAllRecommendedPlayers()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:49845/api/Favourite/getFavouritesFromFavouriteService/"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject(apiResponse);
                }
                
                IEnumerable<dynamic> sequence = res;
                List<dynamic> list = sequence.ToList();
                
                recommendContext.Recommends.DeleteMany(players => true);
                foreach (var f in list)
                {
                    
                    int playerId = f["playerId"];
                    var rec = recommendContext.Recommends.Find(b => b.PlayerId == playerId).FirstOrDefault();
                    if( rec!= null)
                    {
                        int count = rec.Count + 1;
                        var upadate = Builders<Recommend>.Update.Set("Count", count);
                        recommendContext.Recommends.UpdateOne(r => r.PlayerId == playerId, upadate);
                    }
                    else
                    {
                        Recommend recommend = new Recommend();
                        recommend.PlayerId = f["playerId"];
                        
                        recommend.Count = 1;
                        recommendContext.Recommends.InsertOne(recommend);
                    }                    
                }
                List<Recommend> recommends = GetRecommendedPlayers();
                return recommends;
            }
        }

    }
}
