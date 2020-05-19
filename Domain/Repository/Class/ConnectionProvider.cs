using System;
using System.Data;
using System.Data.SqlClient;
using EngenhariaSoftware.Domain.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class ConnectionProvider : IConnectionProvider
    {
        private IConfiguration _configuration;

        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
            var dataBase = _configuration.GetSection("DataBaseProvider");

            switch (dataBase.Value.ToUpper())
            {
                case "POSTGRES":
                case "POSTGRESSQL":
                    return new NpgsqlConnection(_configuration.GetConnectionString("postgres"));//SqlConnection(_configuration.GetConnectionString("postgres"));//
                default:
                    throw new Exception("DataBaseProvider inválido");
            }
        }
    }
}