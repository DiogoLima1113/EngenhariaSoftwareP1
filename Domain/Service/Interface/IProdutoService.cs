using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IProdutoService
    {
        IEnumerable<Produto> ObterTodos();
        
        Produto Obter(int id);

        void Adicionar(Produto produto);

        Produto Editar(int id, Produto produto);

        void Deletar(int id);
    }
}