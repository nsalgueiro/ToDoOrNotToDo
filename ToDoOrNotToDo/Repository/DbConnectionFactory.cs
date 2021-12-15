using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ToDoOrNotToDo.Repository
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateMysqlConnection();
    }


    public class DbConnectionFactory : IDbConnectionFactory
    {
        private MySqlConnection connection;

        public IDbConnection CreateMysqlConnection()
        {
            string connectionString = "server=localhost;database=todoschema;user=todouser;password=todopassword";
            return new MySqlConnection(connectionString);
        }

        /*
        public TodoDbConnection()
        {
            InitializeDbConnection();
        }
        */

        /*
        void InitializeDbConnection()
        {
            string connectionString = "server=localhost;database=todoschema;user=todouser;password=todopassword";
            connection = new MySqlConnection(connectionString);
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            } catch (MySqlException ex)
            {
                return false;
            }
        }

        public IEnumerable<Object> GetQueryResults(string query)
        {

            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}", reader.GetString("name"), reader.GetString("email"));
            }
            reader.Close();

            CloseConnection();

            return null;
        }
        */
    }
}
