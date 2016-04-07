using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Gateways
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}
