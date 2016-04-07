using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeskBank.Gateways
{
    public abstract class Gateway<T> where T:IIdentifiable
    {
        private string _addSql;
        private string _removeSqlId;
        private string _getSqlId;
        private string _getSqlAll;
        private string _updateSql;
        private string _tableName;

        private string _connectionString =
            "Server=localhost;Database=desk_bank;Uid=root;Pwd=;";

        public Gateway(string tableName)
        {
            _tableName = tableName;
            _addSql = "INSERT INTO " + _tableName + " VALUES (%s)";
            _removeSqlId = "DELETE FROM " + _tableName + " WHERE id=%d";
            _getSqlId = "SELECT * FROM " + _tableName + " WHERE id=%d";
            _getSqlAll = "SELECT * FROM " + _tableName;
            _updateSql = "UPDATE " + _tableName + " SET (%s) WHERE id = %d";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        protected abstract string GetValuesString(T value);
        protected abstract string GetUpdateString(T value);
        protected abstract T GetObjectFromReader(MySqlDataReader reader);

        public void Add(T value)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(_addSql.Replace("%s",GetValuesString(value)), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }

        }
        public void Remove(int id)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(_removeSqlId.Replace("%d", id.ToString()), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public void Update(int id, T value)
        {
            using (MySqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(_updateSql.Replace("%d", id.ToString()).Replace("%s", GetUpdateString(value)), conn))
                {
                    command.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        public T Get(int id)
        {
            T returned;

            using (MySqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(_getSqlId.Replace("%d", id.ToString()), conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        reader.NextResult();
                        returned = GetObjectFromReader(reader); 
                    }
                }
                conn.Close();
            }

            return returned; 
        }

        public List<T> GetAll()
        {
            List<T> returned = new List<T>();
            using (MySqlConnection conn = this.GetConnection())
            {
                conn.Open();
                using (MySqlCommand command = new MySqlCommand(_getSqlAll, conn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                            returned.Add(GetObjectFromReader(reader));
                    }
                }
                conn.Close();
            }

            return returned;
        }
    }
}
