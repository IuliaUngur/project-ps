using DeskBank.Gateways;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Domain
{
    public class EmployeeActivity : IIdentifiable
    {
        public int Id { get; set; }
        public EmployeeActivityType Type { get; set; }
        public DateTime Date { get; set; }
        public Client TargetClient { get; set; }
        public int EmployeeId { get; set; }

        public static EmployeeActivityGateway Gateway { get; set; }

    }
}
