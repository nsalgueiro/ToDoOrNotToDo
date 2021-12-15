using System;
using System.Collections.Generic;
using System.Data.Common;
using MySql.Data.MySqlClient;
using ToDoOrNotToDo.Models;

namespace ToDoOrNotToDo.Repository
{
    public class TodoRepository: ITodoRepository
    {
        private IDbConnectionFactory _dbConnectionFactory;

        public TodoRepository(IDbConnectionFactory dbConnectionFactory) =>
            _dbConnectionFactory = dbConnectionFactory;


        public void Delete(int id)
        {
            using (MySqlConnection con = GetSqlConnection())
            {
                con.Open();

                string query = "DELETE FROM todos WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                var rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated >= 1)
                {
                    Console.WriteLine("{0} row(s) with id - {1} deleted successfully!",
                        rowsUpdated, id);
                }
                else
                {
                    Console.WriteLine("Failed to delete row with id - {0}.", id);
                }
                con.Close();
            }


        }

        public IEnumerable<Todo> GetAll()
        {
            List<Todo> result = new List<Todo>();

            using (MySqlConnection dbConnection = GetSqlConnection())
            {
                dbConnection.Open();
                var query = "SELECT * FROM todos";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Todo todo = new Todo()
                    {
                        Title = reader.GetString("title"),
                        Description = reader.GetString("description"),
                        Status = reader.GetString("status"),
                        Id = reader.GetInt32("id")
                    };

                    result.Add(todo);

                }
                reader.Close();
                dbConnection.Close();
            }

            return result;
        }

        public Todo GetById(int TodoId)
        {
            List<Todo> result = new List<Todo>();

            using (MySqlConnection dbConnection = GetSqlConnection())
            {
                dbConnection.Open();
                var query = "SELECT * FROM todos where id = @id";

                MySqlCommand cmd = new MySqlCommand(query, dbConnection);
                cmd.Parameters.AddWithValue("@id", TodoId);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Todo todo = new Todo()
                    {
                        Title = reader.GetString("title"),
                        Description = reader.GetString("description"),
                        Status = reader.GetString("status"),
                        Id = reader.GetInt32("id")
                    };

                    result.Add(todo);

                }
                reader.Close();
                dbConnection.Close();
            }
            // We should never have more than one result as ID is the primary key, probably can change this later
            return result.Count > 0 ?  result[0] : null ;
        }

        public void Insert(Todo todo)
        {
            using( MySqlConnection con = GetSqlConnection())
            {
                con.Open();
                string query = "INSERT INTO todos (title, description, status) VALUES (@title, @description, @status)";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@title", todo.Title);
                cmd.Parameters.AddWithValue("@description", todo.Description);
                cmd.Parameters.AddWithValue("@status", todo.Status);
                cmd.Prepare();
                var rowsInserted = cmd.ExecuteNonQuery();
                if (rowsInserted >= 1)
                {
                    Console.WriteLine("{0} row(s) with title - {1} - and status - {2} inserted successfully!",
                        rowsInserted, todo.Title, todo.Status);
                }
                else
                {
                    Console.WriteLine("Failed to insert row with title - {0} - and status - {1}.", todo.Title, todo.Status);
                }
                con.Close();
            }
        }

        public void Update(int id, Todo todo)
        {
            using (MySqlConnection con = GetSqlConnection())
            {
                con.Open();

                string query = "UPDATE todos SET title = @title, description = @description, status = @status WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@title", todo.Title);
                cmd.Parameters.AddWithValue("@description", todo.Description);
                cmd.Parameters.AddWithValue("@status", todo.Status);
                cmd.Prepare();
                var rowsUpdated = cmd.ExecuteNonQuery();
                if (rowsUpdated >= 1)
                {
                    Console.WriteLine("{0} row(s) with id - {1} title - {2} - and status - {3} updated successfully!",
                        rowsUpdated, id, todo.Title, todo.Status);
                }
                else
                {
                    Console.WriteLine("Failed to update row with title - {0} - and status - {1}.", todo.Title, todo.Status);
                }
                con.Close();
            }
        }

        private MySqlConnection GetSqlConnection()
        {
            return (MySqlConnection)_dbConnectionFactory.CreateMysqlConnection();
        }

    }
}
