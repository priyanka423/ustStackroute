using FavouriteService.Exceptions;
using FavouriteService.Models;
using FavouriteService.Repository;
using System.Collections.Generic;

namespace FavouriteService.Service
{
    public class FavouriteService : IFavouriteService
    {
        IFavouriteRepository favouriteRepository;
        public FavouriteService(IFavouriteRepository favouriteRepository)
        {
            this.favouriteRepository = favouriteRepository;
        }
        public Favourite AddFavourite(Favourite favourite)
        {
            var fav = favouriteRepository.GetFavouriteByPlayerIdUserId(favourite.PlayerId,favourite.CreatedBy);
            if (fav == null)
            {
                return favouriteRepository.AddFavourite(favourite);
            }
            else
            {
                throw new FavouritePlayerNotAddedException("This favourite player already exists");
            }
        }

        public bool DeleteFavourite(int playerId, string userId)
        {
            if (favouriteRepository.GetFavouriteByPlayerIdUserId(playerId,userId) != null)
            {
                var deleteStatus = favouriteRepository.DeleteFavourite(playerId, userId);
                if (deleteStatus)
                {
                    return deleteStatus;
                }
                else
                {
                    throw new FavouritePlayerNotFoundException("This favourite player not found for this userName");
                }
            }
            else
            {
                throw new FavouritePlayerNotFoundException("This favourite player not found for this userName");
            }

        }

        public List<Favourite> GetAllFavouritesByUserId(string userId)
        {
            var favourites = favouriteRepository.GetAllFavouritesByUserId(userId);
            if (favourites != null)
            {
                return favourites;
            }
            else
            {
                throw new FavouritePlayerNotFoundException("This favourite player not found");
            }
        }

        public Favourite GetFavouriteByPlayerId(int playerId)
        {
            var favourite = favouriteRepository.GetFavouriteByPlayerId(playerId);
            if (favourite != null)
            {
                return favourite;
            }
            else
            {
                throw new FavouritePlayerNotFoundException("This favourite player not found");
            }
        }
    }
}
