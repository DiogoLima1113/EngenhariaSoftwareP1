using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class ProdutosDbRepository : IProdutosDbRepository
    {
        private IConnectionProvider _provider;

        public ProdutosDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(Produto produto)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO produtos 
                            (Descricao, Preco, Categoria) VALUES
                            (@Descricao, @Preco, @Categoria)",
                new
                {
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Categoria = produto.Categoria
                });
            }
        }

        public void Deletar(string id)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query("DELETE FROM produtos WHERE id = @Id", new { Id = id });
            }
        }

        public void Editar(string id, Produto produto)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Query($@"UPDATE usuarios 
                            SET Descricao = @Descricao,
                                Preco = @Preco,
                                Categoria = @Categoria
                            WHERE id = @Id",
                new
                {
                    Id = produto.Id,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Categoria = produto.Categoria
                });
            }
        }

        public Produto Obter(string id)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Produto>(
                    "SELECT Id, Descricao, Preco, Categoria " +
                    "FROM produtos " +
                    "WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Produto> ObterTodos()
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<Produto>(
                    "SELECT Id, Descricao, Preco, Categoria " +
                    "FROM produtos ");
            }
        }
    }
}