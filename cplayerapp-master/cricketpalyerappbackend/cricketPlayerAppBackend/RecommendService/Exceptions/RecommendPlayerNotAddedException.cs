using System;

namespace RecommendService.Exceptions
{
    public class RecommendPlayerNotAddedException : ApplicationException
    {
        public RecommendPlayerNotAddedException() { }
        public RecommendPlayerNotAddedException(string message) : base(message) { }
    }
}
