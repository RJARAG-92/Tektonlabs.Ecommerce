using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Tektonlabs.Ecommerce.Persistencia.Contexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("EcommerceConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}

