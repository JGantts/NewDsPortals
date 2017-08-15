using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nework.Gui
{
    class NeworkGuiException : Exception
    {
        public NeworkGuiException() : base()
        { }

        public NeworkGuiException(string message) : base(message)
        { }

        public NeworkGuiException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
