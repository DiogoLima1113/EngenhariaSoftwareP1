using System.Collections.Generic;
using System.Linq;
using Dapper;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;

namespace EngenhariaSoftware.Domain.Repository.Class
{
    public class ComissaoDbRepository : IComissaoDbRepository
    {
        private IConnectionProvider _provider;

        public ComissaoDbRepository(IConnectionProvider provider)
        {
            _provider = provider;
        }

        public Comissao Adicionar(Comissao comissao)
        {
            using (var con = _provider.CreateConnection())
            {
                var valor = con.QueryFirstOrDefault<float>($@"SELECT SUM(ValorTotal) FROM venda
                            WHERE IdUsuario = @IdUsuario AND data BETWEEN @DataInicio AND @DataFim
                            GROUP BY idUsuario",
                new
                {
                    IdUsuario = comissao.IdUsuario,
                    DataInicio = comissao.DataInicio,
                    DataFim = comissao.DataFim
                });
                con.Execute($@"INSERT INTO comissao 
                            (idUsuario, dataInicio, dataFim, valor) VALUES
                            (@IdUsuario, @DataInicio, @DataFim, @Valor)",
                new
                {
                    IdUsuario = comissao.IdUsuario,
                    DataInicio = comissao.DataInicio,
                    DataFim = comissao.DataFim,
                    Valor = valor * 0.1
                });
                return con.QueryFirstOrDefault<Comissao>(@"
                        SELECT id, idUsuario, dataInicio, dataFim, valor
                        FROM comissao
                        WHERE IdUsuario = @IdUsuario AND 
                              DataInicio = @DataInicio AND
                              DataFim = @DataFim",
                new
                {
                    IdUsuario = comissao.IdUsuario,
                    DataInicio = comissao.DataInicio,
                    DataFim = comissao.DataFim,
                });
            }
        }

        public IEnumerable<Comissao> Obter(int idUsuario)
        {
            using (var con = _provider.CreateConnection())
            {
                return con.Query<Comissao>(@"
                        SELECT id, idUsuario, dataInicio, dataFim, valor
                        FROM comissao
                        WHERE IdUsuario = @IdUsuario",
                new
                {
                    IdUsuario = idUsuario
                });
            }
        }

        public IEnumerable<Comissao> ObterTodos()
        {
            using (var con = _provider.CreateConnection())
            {
                return con.Query<Comissao>(@"
                        SELECT id, idUsuario, dataInicio, dataFim, valor
                        FROM comissao");
            }
        }
    }
}