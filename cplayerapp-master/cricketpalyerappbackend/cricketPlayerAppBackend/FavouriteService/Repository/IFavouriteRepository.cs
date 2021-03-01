using FavouriteService.Models;
using System.Collections.Generic;

namespace FavouriteService.Repository
{
    public interface IFavouriteRepository
    {
        Favourite AddFavourite(Favourite favourite);
        bool DeleteFavourite(int playerId,string userId);
        Favourite GetFavouriteByPlayerId(int playerId);
        List<Favourite> GetAllFavouritesByUserId(string userId);
        Favourite GetFavouriteByPlayerIdUserId(int playerId, string userId);

    }
}
