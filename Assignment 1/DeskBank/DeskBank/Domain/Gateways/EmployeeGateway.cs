using DeskBank.Gateways;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeskBank.Domain
{
    public class EmployeeGateway : Gateway<Employee>
    {
        public EmployeeGateway(): base("employees"){}

        protected override string GetValuesString(Employee value)
        {
            return value.Id + ",'" + 
                   value.UserName + "','" + 
                   value.Password + "'," + 
                   value.Type;
        }

        protected override string GetUpdateString(Employee value)
        {
            string returned = "";
            returned += "id = " + value.Id + ",";
            returned += "user_name = '" + value.UserName + "',";
            returned += "password = '" + value.Password + "',";
            returned += "type = " + Convert.ToInt32(value.Type);
            return returned;
        }
        protected override Employee GetObjectFromReader(MySqlDataReader reader)
        {
            return new Employee
            {
                Id = reader.GetInt32(0),
                UserName = reader.GetString(1),
                Password = reader.GetString(2),
                Type = (EmployeeType)reader.GetInt32(3)
            };
        }
    }
}
