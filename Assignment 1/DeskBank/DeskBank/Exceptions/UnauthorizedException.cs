using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}
