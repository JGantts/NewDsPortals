using System;

namespace Nework.EngineApi.Exceptions
{
    public class EngineApiException : Exception
    {
        public EngineApiException() : base()
        { }

        public EngineApiException(string message) : base(message)
        { }

        public EngineApiException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
