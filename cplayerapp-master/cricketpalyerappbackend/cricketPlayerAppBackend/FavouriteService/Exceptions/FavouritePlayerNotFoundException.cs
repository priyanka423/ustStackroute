using System;

namespace FavouriteService.Exceptions
{
    public class FavouritePlayerNotFoundException : ApplicationException
    {
        public FavouritePlayerNotFoundException() { }
        public FavouritePlayerNotFoundException(string message) : base(message) { }
    }
}
