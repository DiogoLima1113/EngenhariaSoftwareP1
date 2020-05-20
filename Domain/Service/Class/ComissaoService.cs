using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class ComissaoService : IComissaoService
    {
        private IComissaoDbRepository _comissaosRepository;

        public ComissaoService(IComissaoDbRepository comissaosRepository)
        {
            _comissaosRepository = comissaosRepository;
        }

        public Comissao Adicionar(Comissao comissao)
        {
            return _comissaosRepository.Adicionar(comissao);
        }

        public IEnumerable<Comissao> Obter(int idUsuario)
        {
            return _comissaosRepository.Obter(idUsuario);
        }

        public IEnumerable<Comissao> ObterTodos()
        {
            return _comissaosRepository.ObterTodos();
        }
    }
}