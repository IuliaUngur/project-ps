using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Exceptions
{
    public class GatewayException : Exception
    {
        public GatewayException(string m) : base(m) { }
    }
}
