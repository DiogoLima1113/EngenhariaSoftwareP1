using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObterTodos();
        
        Cliente Obter(string cpf);

        void Adicionar(Cliente cliente);

        Cliente Editar(string cpf, Cliente cliente);

        void Deletar(string cpf);
    }
}