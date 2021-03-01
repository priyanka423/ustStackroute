using FavouriteService.Models;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FavouriteService.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        FavouriteContext favouriteContext;
        public FavouriteRepository(FavouriteContext favouriteContext)
        {
            this.favouriteContext = favouriteContext;
        }
        public Favourite AddFavourite(Favourite favourite)
        {
            try
            {
                  favouriteContext.Favourites.InsertOne(favourite);
                  return favourite;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteFavourite(int playerId,string userId)
        {
            try
            {
                favouriteContext.Favourites.DeleteOne(f => f.PlayerId == playerId && f.CreatedBy == userId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Favourite> GetAllFavouritesByUserId(string userId)
        {
            try
            {
                var favouriteList = favouriteContext.Favourites.Find(u => u.CreatedBy == userId).ToList();
                return favouriteList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Favourite GetFavouriteByPlayerId(int playerId)
        {
            try
            {
                var favourite = favouriteContext.Favourites.Find(b => b.PlayerId == playerId).FirstOrDefault();
                return favourite;
            }
            catch
            {
                return null;
            }            
        }

        public Favourite GetFavouriteByPlayerIdUserId(int playerId, string userId)
        {
            try
            {
                var favourite = favouriteContext.Favourites.Find(b => b.PlayerId == playerId && b.CreatedBy == userId).FirstOrDefault();
                return favourite;
            }
            catch
            {
                return null;
            }
        }
    }
}
