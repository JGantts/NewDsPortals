using System;

namespace Nework.CommonLibrary.Exceptions
{
    class CommonLibraryException : Exception
    {
        public CommonLibraryException() : base()
        { }

        public CommonLibraryException(string message) : base(message)
        { }

        public CommonLibraryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
