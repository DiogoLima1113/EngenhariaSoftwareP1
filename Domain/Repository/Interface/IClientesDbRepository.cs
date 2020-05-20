using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IClientesDbRepository
    {
        Cliente Obter(string cpf);

        IEnumerable<Cliente> ObterTodos();

        void Adicionar(Cliente cliente);

        void Editar(string cpf, Cliente cliente);

        void Deletar(string cpf);
    }
}