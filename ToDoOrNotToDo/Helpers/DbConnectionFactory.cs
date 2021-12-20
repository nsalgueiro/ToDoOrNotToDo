using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ToDoOrNotToDo.Helpers
{

    public interface IDbConnectionFactory
    {
        IDbConnection CreateMysqlConnection();
    }


    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration Config;

        public DbConnectionFactory(IConfiguration configuration)
        {
            Config = configuration;
        }

        public IDbConnection CreateMysqlConnection()
        {
            var connectionString = Config["ConnectionStrings:MySqlConnection"];

            return new MySqlConnection(connectionString);
        }

    }
}
