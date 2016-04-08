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
        public string Description { get; set; }
        
        public static EmployeeActivityGateway Gateway { get; set; }
        
        public Employee Employee
        {
            get
            {
                return Employee.Gateway.Get(this.EmployeeId);
            }
            set
            {
                Employee.Gateway.Update(this.EmployeeId, value);
            }
        }

        public int EmployeeId { get; set; }

    }
}
