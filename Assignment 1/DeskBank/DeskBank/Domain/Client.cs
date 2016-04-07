using DeskBank.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBank.Domain
{
    public class Client:IIdentifiable
    { 
        public string Name { get; set; }
        public int Id { get; set; }
        public int PNC { get; set; }
        public string Address { get; set; }

        public static ClientGateway Gateway { get; set; }

    }
}
