using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Exceptions
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string m) : base(m) { }
    }
}
