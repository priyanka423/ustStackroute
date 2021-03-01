using System;
using System.Runtime.Serialization;

namespace MuzixApp.Services
{
    [Serializable]
    internal class UserNotCreatedException : Exception
    {
        public UserNotCreatedException()
        {
        }

        public UserNotCreatedException(string message) : base(message)
        {
        }

        public UserNotCreatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotCreatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}