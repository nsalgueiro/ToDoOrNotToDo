using System.Data;
using MySql.Data.MySqlClient;

namespace ToDoOrNotToDo.Helpers
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateMysqlConnection();
    }


    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateMysqlConnection()
        {
            string connectionString = "server=localhost;database=todoschema;user=todouser;password=todopassword";
            return new MySqlConnection(connectionString);
        }

    }
}
