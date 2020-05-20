using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Class;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class VendaAdapter : IVendaAdapter
    {
        private ClientesDbRepository _clienteRepository;
        private UsersDbRepository _userRepository;
        private FormaPagamentosDbRepository _pagamentoRepository;
        private VendaItensDbRepository _itensRepository;
        private ProdutosDbRepository _produtosRepository;

        public VendaAdapter(
            ClientesDbRepository clienteRepository,
            UsersDbRepository userRepository,
            FormaPagamentosDbRepository pagamentoRepository,
            VendaItensDbRepository itensRepository,
            ProdutosDbRepository produtosRepository)
        {
            _clienteRepository = clienteRepository;
            _userRepository = userRepository;
            _pagamentoRepository = pagamentoRepository;
            _itensRepository = itensRepository;
            _produtosRepository = produtosRepository;
        }

        public Venda Converter(VendaDTO venda)
        {
            var retorno = new Venda();
            retorno.CpfCliente = venda.Cliente.CPF;
            retorno.Data = venda.Data;
            retorno.Id = venda.Id;
            retorno.IdFormaPagamento = venda.Pagamento.Id;
            retorno.IdUsuario = venda.Usuario.Id;
            retorno.ValorTotal = venda.Valor;
            if (venda.Encomenda)
            {
                retorno.Encomenda = "s";
            }
            else
            {
                retorno.Encomenda = "n";
            }

            return retorno;
        }

        public VendaDTO Converter(Venda venda)
        {
            var retorno = new VendaDTO();
            retorno.Cliente = _clienteRepository.Obter(venda.CpfCliente);
            retorno.Data = venda.Data;
            retorno.Id = venda.Id;
            retorno.Pagamento = _pagamentoRepository.Obter(venda.IdFormaPagamento);
            retorno.Usuario = _userRepository.Find(venda.IdUsuario);
            retorno.Valor = venda.ValorTotal;
            if (venda.Encomenda == "s")
            {
                retorno.Encomenda = true;
            }
            else
            {
                retorno.Encomenda = false;
            }
            return retorno;
        }

        public VendaItem Converter(VendaItemDTO item, int idVenda)
        {
            var retorno = new VendaItem();
            retorno.ProdutoId = item.Item.Id;
            retorno.Quantidade = item.Quantidade;
            retorno.VendaId = idVenda;
            return retorno;
        }

        public VendaItemDTO Converter(VendaItem item)
        {
            var retorno = new VendaItemDTO();
            retorno.Item = _produtosRepository.Obter(item.ProdutoId);
            retorno.Quantidade = item.Quantidade;
            return retorno;
        }
    }
}