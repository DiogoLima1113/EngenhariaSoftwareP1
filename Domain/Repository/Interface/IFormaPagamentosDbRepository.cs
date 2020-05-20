using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IFormaPagamentosDbRepository
    {
        FormaPagamento Obter(int id);

        IEnumerable<FormaPagamento> ObterTodos();

        void Adicionar(FormaPagamento formaPagamento);

        void Deletar(int id);
    }
}