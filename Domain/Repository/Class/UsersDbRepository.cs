using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class UsersDbRepository : IUsersDbRepository
    {
        private IConnectionProvider _provider;

        public UsersDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(User user)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO usuarios 
                            (id, AccessKey, Nome, CPF, Tipo) VALUES
                            (@Id, @AccessKey, @Nome, @CPF, @Tipo)",
                new
                {
                    Id = user.Id,
                    AccessKey = user.AccessKey,
                    Nome = user.Nome,
                    CPF = user.CPF,
                    Tipo = user.Tipo
                });
            }
        }

        public void Deletar(string id)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query("DELETE FROM usuarios WHERE id = @Id", new { Id = id });
            }
        }

        public void Editar(string id, User user)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query($@"UPDATE usuarios 
                            SET AccessKey = @AccessKey,
                                Nome = @Nome,
                                CPF = @CPF,
                                Tipo = @Tipo
                            WHERE id = @Id",
                new
                {
                    Id = id,
                    AccessKey = user.AccessKey,
                    Nome = user.Nome,
                    CPF = user.CPF,
                    Tipo = user.Tipo
                });
            }
        }

        public User Find(string id)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<User>(
                    "SELECT Id, AccessKey, Nome, CPF, Tipo " +
                    "FROM usuarios " +
                    "WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<User> ObterTodos()
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<User>(
                    "SELECT Id, AccessKey, Nome, CPF, Tipo " +
                    "FROM usuarios ");
            }
        }
    }
}