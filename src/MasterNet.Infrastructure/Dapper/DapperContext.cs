using System.Data;
using System.Data.SqlClient;
using MasterNet.Application.Interfaces;
using Microsoft.Extensions.Configuration;

namespace MasterNet.Infrastructure.Dapper
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
