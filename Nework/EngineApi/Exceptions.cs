using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.EngineApi
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
