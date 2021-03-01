using System;

namespace FavouriteService.Exceptions
{
    public class FavouritePlayerNotAddedException: ApplicationException
    {
        public FavouritePlayerNotAddedException() { }
        public FavouritePlayerNotAddedException(string message) : base(message) { }
    }
}
