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
            return value.Id + "," + 
                   Convert.ToInt32(value.Type) + ",'" + 
                   value.Date.ToString("yyyy-MM-dd H:mm:ss") + "'," + 
                   value.EmployeeId + ",'" + 
                   value.Description + "'";
        }

        protected override string GetUpdateString(EmployeeActivity value)
        {
            string returned = "";
            returned += "id = " + value.Id + ",";
            returned += "type = " + Convert.ToInt32(value.Type) + ",";
            returned += "date = '" + value.Date.ToString("yyyy-MM-dd H:mm:ss") + "',";
            returned += "employee_id = " + value.EmployeeId;
            returned += "description = '" + value.Description + "',";
            return returned;
        }
        protected override EmployeeActivity GetObjectFromReader(MySqlDataReader reader)
        {
            return new EmployeeActivity
            {
                Id = reader.GetInt32(0),
                Type = (EmployeeActivityType)reader.GetInt32(1),
                Date = reader.GetDateTime(2),
                EmployeeId = reader.GetInt32(4),
                Description = reader.GetString(5)
            };
        }
    }
}
