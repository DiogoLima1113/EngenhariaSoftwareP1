using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IFormaPagamentoService
    {
        IEnumerable<FormaPagamento> ObterTodos();
        
        FormaPagamento Obter(int id);

        void Adicionar(FormaPagamento formaPagamento);

        void Deletar(int id);
    }
}