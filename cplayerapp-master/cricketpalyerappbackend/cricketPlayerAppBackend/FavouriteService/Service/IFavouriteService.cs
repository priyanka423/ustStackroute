using FavouriteService.Models;
using System.Collections.Generic;

namespace FavouriteService.Service
{
    public interface IFavouriteService
    {
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(int playerId,string userId);
        Favourite GetFavouriteByPlayerId(int playerId);
        List<Favourite> GetAllFavouritesByUserId(string userId);
    }
}
