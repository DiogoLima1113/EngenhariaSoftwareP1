using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class ClienteService : IClienteService
    {
        private IClientesDbRepository _clientesRepository;

        public ClienteService(IClientesDbRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        public void Adicionar(Cliente cliente)
        {
            _clientesRepository.Adicionar(cliente);
        }

        public void Deletar(string cpf)
        {
            _clientesRepository.Deletar(cpf);
        }

        public Cliente Editar(string cpf, Cliente cliente)
        {
            _clientesRepository.Editar(cpf, cliente);
            return _clientesRepository.Obter(cpf);
        }

        public Cliente Obter(string cpf)
        {
            return _clientesRepository.Obter(cpf);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clientesRepository.ObterTodos();
        }
    }
}