using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IProdutosDbRepository
    {
        Produto Obter(int produtoID);

        IEnumerable<Produto> ObterTodos();

        void Adicionar(Produto produto);

        void Editar(int id, Produto produto);

        void Deletar(int id);
    }
}