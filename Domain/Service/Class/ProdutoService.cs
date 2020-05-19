using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class ProdutoService : IProdutoService
    {
        private IProdutosDbRepository _produtosRepository;

        public ProdutoService(IProdutosDbRepository produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }

        public void Adicionar(Produto produto)
        {
            _produtosRepository.Adicionar(produto);
        }

        public void Deletar(string id)
        {
            _produtosRepository.Deletar(id);
        }

        public Produto Editar(string id, Produto produto)
        {
            _produtosRepository.Editar(id, produto);
            return _produtosRepository.Obter(id);
        }

        public Produto Obter(string id)
        {
            return _produtosRepository.Obter(id);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _produtosRepository.ObterTodos();
        }
    }
}