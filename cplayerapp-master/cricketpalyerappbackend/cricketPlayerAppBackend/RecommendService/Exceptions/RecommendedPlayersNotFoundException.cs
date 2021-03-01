using System;

namespace RecommendService.Exceptions
{
    public class RecommendedPlayersNotFoundException : ApplicationException
    {
        public RecommendedPlayersNotFoundException() { }
        public RecommendedPlayersNotFoundException(string message) : base(message) { }
    }
}
