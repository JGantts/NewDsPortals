using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.Orchestration
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
