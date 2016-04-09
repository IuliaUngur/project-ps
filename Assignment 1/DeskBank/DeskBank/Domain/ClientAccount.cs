using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeskBank.Domain;
using DeskBank.Gateways;

namespace DeskBank
{
    public class ClientAccount:IIdentifiable
    {
        public int Id { get; set; }
        public AccountType Type { get; set; }
        public float MoneyAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int OwnerPNC { get; set; }

        public static ClientAccountGateway Gateway { get; set; }
    }
}
