using Microsoft.Data.SqlClient;
using System.Data;

namespace Data_general.DataContext
{
    public class DapperContext
    {
        public readonly IConfiguration _configuration;
        public readonly string _connectionString;


        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }       

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    
    }
}
