using DeskBank.Gateways;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Domain
{
    public class EmployeeActivityGateway : Gateway<EmployeeActivity>
    {
        public EmployeeActivityGateway() : base("employee_activities") { }
        protected override string GetValuesString(EmployeeActivity value)
        {
            return value.Id + "," + (int)value.Type + ",'" + value.Date + "'," + value.TargetClient.Id + "," + value.EmployeeId;
        }

        protected override string GetUpdateString(EmployeeActivity value)
        {
            string returned = "";
            returned += "id = " + value.Id + ",";
            returned += "type = " + (int)value.Type + ",";
            returned += "date = '" + value.Date + "',";
            returned += "target_client_id = " + value.TargetClient.Id;
            returned += "employee_id = " + value.EmployeeId;
            return returned;
        }
        protected override EmployeeActivity GetObjectFromReader(MySqlDataReader reader)
        {
            return new EmployeeActivity
            {
                Id = reader.GetInt32(0),
                Type = (EmployeeActivityType)reader.GetInt32(1),
                Date = reader.GetDateTime(2),
                TargetClient = _GetTargetClient(reader.GetInt32(3)),
                EmployeeId = reader.GetInt32(4)
            };
        }

        private Client _GetTargetClient(int p)
        {
            return Client.Gateway.Get(p);
        }
    }
}
