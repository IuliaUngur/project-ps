using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DeskBank.Gateways
{
    class DataBaseContext<T>
    {
        private string _tableName;
        private List<T> _localStorage;
        private string _connectionString = "";
        public DataBaseContext(string tableName)
        {
            _tableName = tableName;
        }

        public void Insert(T toAdd)
        {
            var counter = 0;
            string query = "INSERT INTO " + _tableName;
            Dictionary<string, string> propretyNameValues = new Dictionary<string, string>();

            PropertyInfo[] properties = toAdd.GetType().GetProperties();

            /*
             *  For every property of the object create a key value pair
             */
            foreach (PropertyInfo property in properties)
            {
                propretyNameValues.Add(property.Name, property.GetValue(toAdd, null).ToString());
            }

            query += "(";
            foreach (string key in propretyNameValues.Keys)
            {
                query += key + (counter < propretyNameValues.Keys.Count ? "," : "");
                counter++;
            }
            query += ")";

            counter = 0;
            query += " VALUES (";
            foreach (string value in propretyNameValues.Values)
            {
                query += value + (counter < propretyNameValues.Values.Count ? "," : "");
                counter++;
            }
            query += ")";
        } 

        public List<T> Select(T filter)
        {
            List<T> returnedList = new List<T>();
            string query = "SELECT * FROM " + _tableName + " WHERE ";
            PropertyInfo[] properties = filter.GetType().GetProperties();
            
            /*
             *  For every property of the object create a and clause for the WHERE statement
             */
            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(filter, null) != null)
                {
                    query += property.Name + " = '" + property.GetValue(filter, null).ToString() + "' AND ";
                }
            }

            query += " 1 "; // in cazul in care avem un and "nimic" sa nu fie sintax error, sau in cazul in care where "nimic"

            using(SqlConnection dbConnection = new SqlConnection(this._connectionString)) 
            {
                using (SqlCommand command = new SqlCommand(query, dbConnection))
                {
                    using(SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while(reader.NextResult()) {
                            
                            T newT = (T)Activator.CreateInstance(filter.GetType());
                            /*
                             *  For every property of the object set the value of the property on the new object
                             */
                            foreach (PropertyInfo property in properties)
                            {
                                property.SetValue(newT, reader.GetValue(reader.GetOrdinal(property.Name)));
                            }
                        }
                    }
                    
                }
                    
            }

            return returnedList;
        }
    }
}
