using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class ClientesDbRepository : IClientesDbRepository
    {
        private IConnectionProvider _provider;

        public ClientesDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(Cliente cliente)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO clientes 
                            (CPF, Nome, Telefone) VALUES
                            (@CPF, @Nome, @Telefone)",
                new
                {
                    CPF = cliente.CPF,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone
                });
            }
        }

        public void Deletar(string cpf)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query("DELETE FROM clientes WHERE CPF = @CPF", new { CPF = cpf });
            }
        }

        public void Editar(string cpf, Cliente cliente)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query($@"UPDATE clientes 
                            SET Nome = @Nome,
                                Telefone = @Telefone
                            WHERE CPF = @CPF",
                new
                {
                    CPF = cpf,
                    Nome = cliente.Nome,
                    Telefone = cliente.Telefone
                });
            }
        }

        public Cliente Obter(string cpf)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Cliente>(
                    "SELECT CPF, Nome, Telefone " +
                    "FROM clientes " +
                    "WHERE CPF = @CPF", new { CPF = cpf });
            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<Cliente>(
                    "SELECT CPF, Nome, Telefone " +
                    "FROM clientes ");
            }
        }
    }
}