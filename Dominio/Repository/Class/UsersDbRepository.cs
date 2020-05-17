using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Dominio.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class UsersDbRepository : IUsersDbRepository
    {
        private IConfiguration _configuration;
        private IConnectionProvider _provider;

        public UsersDbRepository(IConfiguration configuration, IConnectionProvider provider)
        {
            _configuration = configuration;
            _provider = provider;
        }

        public User Find(string id)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<User>(
                    "SELECT Id, AccessKey, Tipo " +
                    "FROM dbo.Users " +
                    "WHERE Id = @Id", new { Id = id });
            }
        }
    }
}