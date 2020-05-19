using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterTodos();
        
        Produto Obter(string id);

        void Adicionar(Produto produto);

        Produto Editar(string id, Produto produto);

        void Deletar(string id);
    }
}