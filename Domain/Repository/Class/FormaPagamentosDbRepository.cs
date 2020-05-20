using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class FormaPagamentosDbRepository : IFormaPagamentosDbRepository
    {
        private IConnectionProvider _provider;

        public FormaPagamentosDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(FormaPagamento formaPagamento)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO formaPagamento 
                            (Descricao) VALUES
                            (@Descricao)",
                new
                {
                    Descricao = formaPagamento.Descricao
                });
            }
        }

        public void Deletar(int id)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query("DELETE FROM formaPagamento WHERE Id = @ID", new { Id  = id });
            }
        }

        public FormaPagamento Obter(int id)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<FormaPagamento>(
                    "SELECT CPF, Nome, Telefone " +
                    "FROM formaPagamento " +
                    "WHERE Id = @ID", new { Id = id });
            }
        }

        public IEnumerable<FormaPagamento> ObterTodos()
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<FormaPagamento>(
                    "SELECT Id, Descricao " +
                    "FROM formaPagamento ");
            }
        }
    }
}