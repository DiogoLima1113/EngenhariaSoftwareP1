using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IComissaoDbRepository
    {
        IEnumerable<Comissao> Obter(int idUsuario);

        IEnumerable<Comissao> ObterTodos();

        Comissao Adicionar(Comissao formaPagamento);
    }
}