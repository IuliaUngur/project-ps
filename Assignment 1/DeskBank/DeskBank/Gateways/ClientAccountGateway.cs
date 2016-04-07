using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeskBank.Gateways;
using MySql.Data.MySqlClient;

namespace DeskBank.Domain
{
    public class ClientAccountGateway : Gateway<ClientAccount>
    {
        public ClientAccountGateway() : base("client_accounts") { }
        protected override string GetValuesString(ClientAccount value)
        {
            return value.Id + "," + (int) value.Type + "," + value.MoneyAmount + ",'" + value.CreatedOn +"'";
        }

        protected override string GetUpdateString(ClientAccount value)
        {
            string returned = "";
            returned += "id = " + value.Id + ",";
            returned += "type = " + (int) value.Type + ",";
            returned += "money_amount = " + value.MoneyAmount + ",";
            returned += "created_on = '" + value.CreatedOn + "'";
            return returned;
        }
        protected override ClientAccount GetObjectFromReader(MySqlDataReader reader)
        {
            return new ClientAccount
            {
                Id = reader.GetInt32(0),
                Type = (AccountType) reader.GetInt32(1),
                MoneyAmount = reader.GetInt32(2),
                CreatedOn = reader.GetDateTime(3)
            };
        }
    }
}
