using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private IFormaPagamentosDbRepository _formaPagamentosRepository;

        public FormaPagamentoService(IFormaPagamentosDbRepository formaPagamentosRepository)
        {
            _formaPagamentosRepository = formaPagamentosRepository;
        }

        public void Adicionar(FormaPagamento formaPagamento)
        {
            _formaPagamentosRepository.Adicionar(formaPagamento);
        }

        public void Deletar(int id)
        {
            _formaPagamentosRepository.Deletar(id);
        }

        public FormaPagamento Obter(int id)
        {
            return _formaPagamentosRepository.Obter(id);
        }

        public IEnumerable<FormaPagamento> ObterTodos()
        {
            return _formaPagamentosRepository.ObterTodos();
        }
    }
}