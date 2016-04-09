using DeskBank.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBank.Domain
{
    public class Employee:IIdentifiable 
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public EmployeeType Type { get; set; }

        public static EmployeeGateway Gateway { get; set; }
                
    }
}
