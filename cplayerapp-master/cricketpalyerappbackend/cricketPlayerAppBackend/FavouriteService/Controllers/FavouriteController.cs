using FavouriteService.Exceptions;
using FavouriteService.Models;
using FavouriteService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FavouriteService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class FavouriteController : ControllerBase
    {
        IFavouriteService favouriteService;
        public FavouriteController(IFavouriteService favouriteService)
        {
            this.favouriteService = favouriteService;
        }
        [HttpPost]
        public ActionResult Add([FromBody] Favourite favourite)
        {
            try
            {
                Favourite fav = favouriteService.AddFavourite(favourite);
                return Created("/api/favourite", fav);
            }
            catch (FavouritePlayerNotAddedException favouriteException)
            {
                return Conflict(favouriteException.Message);
            }
        }
        [HttpDelete("{playerId:int}/{userId}")]
        public ActionResult Delete(int playerId,string userId)
        {
            try
            {
                var deleteStatus = favouriteService.DeleteFavourite(playerId, userId);
                return Ok(deleteStatus);
            }
            catch (FavouritePlayerNotFoundException favException)
            {
                return NotFound(favException.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("{playerId:int}")]
        public ActionResult GetFavouriteByPlayerId(int playerId)
        {
            try
            {
                return Ok(favouriteService.GetFavouriteByPlayerId(playerId));
            }
            catch (FavouritePlayerNotFoundException favException)
            {
                return NotFound(favException.Message);
            }
        }
        [HttpGet("{userId}")]
        public ActionResult GetAllFavourites(string userId)
        {
            try
            {
                return Ok(favouriteService.GetAllFavouritesByUserId(userId));
            }
            catch (FavouritePlayerNotFoundException favException)
            {
                return NotFound(favException.Message);
            }
        }
    }
}
