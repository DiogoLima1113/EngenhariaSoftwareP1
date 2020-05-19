using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IProdutosDbRepository
    {
        Produto Obter(string produtoID);

        IEnumerable<Produto> ObterTodos();

        void Adicionar(Produto produto);

        void Editar(string id, Produto produto);

        void Deletar(string id);
    }
}