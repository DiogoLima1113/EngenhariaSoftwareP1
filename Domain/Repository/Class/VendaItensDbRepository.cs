using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class VendaItensDbRepository : IVendaItensDbRepository
    {
        private IConnectionProvider _provider;

        public VendaItensDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(VendaItem venda)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO vendaItem 
                            (VendaId, ProdutoId, Quantidade) VALUES
                            (@VendaId, @ProdutoId, @Quantidade)",
                new
                {
                    VendaId = venda.VendaId,
                    ProdutoId = venda.ProdutoId,
                    Quantidade = venda.Quantidade
                });
            }
        }

        public IEnumerable<VendaItem> Obter(int idVenda)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<VendaItem>(
                    "SELECT VendaId, ProdutoId, Quantidade " +
                    "FROM vendaItem " +
                    "WHERE VendaId = @VendaId", new { VendaId = idVenda });
            }
        }
    }
}