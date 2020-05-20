using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IVendaService
    {
        IEnumerable<VendaDTO> ObterTodos();
        
        VendaDTO Obter(int id);

        void Adicionar(VendaDTO formaPagamento);
    }
}