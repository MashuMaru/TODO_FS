using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TodoApp.Api
{
    public class DbContext
    {
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["DbConnectionString"];
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
    }
}