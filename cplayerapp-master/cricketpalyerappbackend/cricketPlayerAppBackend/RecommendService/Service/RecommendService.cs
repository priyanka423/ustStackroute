using RecommendService.Exceptions;
using RecommendService.Models;
using RecommendService.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecommendService.Service
{
    public class RecommendService : IRecommendService
    {
        IRecommendRepository recommendRepository;
        public RecommendService(IRecommendRepository recommendRepository)
        {
            this.recommendRepository = recommendRepository;
        }
         
        public Task<object> GetAllRecommendedPlayers()
        {
            return recommendRepository.GetAllRecommendedPlayers();
        }
    }
}
