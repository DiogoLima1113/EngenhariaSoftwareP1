using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IVendasDbRepository
    {
        Venda Obter(int id);

        IEnumerable<Venda> ObterTodos();

        void Adicionar(Venda venda);
    }
}