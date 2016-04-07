using DeskBank.Gateways;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Domain
{
    public class ClientGateway : Gateway<Client>
    {
        public ClientGateway() : base("clients") { }
        protected override string GetValuesString(Client value)
        {
            return value.Id + ",'" +value.Name + "'," +value.PNC + ",'" +value.Address +"'";
        }

        protected override string GetUpdateString(Client value)
        {
            string returned ="";
            returned += "id = " + value.Id + ",";
            returned += "name = '" + value.Name + "',";
            returned += "cnp = " + value.PNC + ",";
            returned += "address = '" + value.Address + "'";
            return returned;
        }
        protected override Client GetObjectFromReader(MySqlDataReader reader)
        {
            return new Client {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                PNC = reader.GetInt32(2),
                Address = reader.GetString(3)
            };
        }
    }
}