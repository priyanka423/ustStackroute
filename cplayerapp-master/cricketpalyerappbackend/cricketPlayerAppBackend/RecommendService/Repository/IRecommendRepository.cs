using RecommendService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecommendService.Repository
{
    public interface IRecommendRepository
    {
        List<Recommend> GetRecommendedPlayers();
        Task<Object> GetAllRecommendedPlayers();
    }
}
