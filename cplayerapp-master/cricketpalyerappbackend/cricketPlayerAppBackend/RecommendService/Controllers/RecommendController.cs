using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecommendService.Exceptions;
using RecommendService.Models;
using RecommendService.Service;
using System.Threading.Tasks;

namespace RecommendService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendController : ControllerBase
    {
        IRecommendService recommendService;
        public RecommendController(IRecommendService recommendService)
        {
            this.recommendService = recommendService;
        }
        [HttpGet("getRecommends")]
        public async Task<IActionResult> GetAllRecommendedPlayers()
        {
            var recommends = await recommendService.GetAllRecommendedPlayers();
            return new OkObjectResult(recommends);
        }
    }
}
