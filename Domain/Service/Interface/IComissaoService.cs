using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IComissaoService
    {
        IEnumerable<Comissao> ObterTodos();
        
        IEnumerable<Comissao> Obter(int idUsuario);

        Comissao Adicionar(Comissao comissao);
    }
}