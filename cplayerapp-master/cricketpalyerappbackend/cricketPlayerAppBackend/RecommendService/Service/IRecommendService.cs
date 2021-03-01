using RecommendService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecommendService.Service
{
    public interface IRecommendService
    {
        Task<Object> GetAllRecommendedPlayers();
    }
}
