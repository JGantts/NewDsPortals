using System;

namespace Nework.Orchestration.Exceptions
{
    public class OrchestrationException : Exception
    {
        public OrchestrationException() : base()
        { }

        public OrchestrationException(string message) : base(message)
        { }

        public OrchestrationException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
