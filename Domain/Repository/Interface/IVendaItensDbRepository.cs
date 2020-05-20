using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IVendaItensDbRepository
    {
        IEnumerable<VendaItem> Obter(int idVenda);

        void Adicionar(VendaItem venda);
    }
}