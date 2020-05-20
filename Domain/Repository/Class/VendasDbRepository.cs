using System.Collections.Generic;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class VendasDbRepository : IVendasDbRepository
    {
        private IConnectionProvider _provider;

        public VendasDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public void Adicionar(Venda venda)
        {
            using (var con = _provider.CreateConnection())
            {
                con.Execute($@"INSERT INTO venda 
                            (ValorTotal, IdUsuario, CpfCliente, IdFormaPagamento, Encomenda, Data) VALUES
                            (@ValorTotal, @IdUsuario, @CpfCliente, @IdFormaPagamento, @Encomenda, @Data)",
                new
                {
                    ValorTotal = venda.ValorTotal,
                    IdUsuario = venda.IdUsuario,
                    CpfCliente = venda.CpfCliente,
                    IdFormaPagamento = venda.IdFormaPagamento,
                    Encomenda = venda.Encomenda,
                    Data = venda.Data
                });
            }
        }

        public Venda Obter(int id)
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Venda>(
                    "SELECT ValorTotal, IdUsuario, CpfCliente, IdFormaPagamento, Encomenda, Data " +
                    "FROM venda " +
                    "WHERE Id = @ID", new { Id = id });
            }
        }

        public IEnumerable<Venda> ObterTodos()
        {
            using (var connection = _provider.CreateConnection())
            {
                return connection.Query<Venda>(
                    "SELECT ValorTotal, IdUsuario, CpfCliente, IdFormaPagamento, Encomenda, Data " +
                    "FROM venda ");
            }
        }
    }
}