using System.Collections.Generic;
using System.Linq;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class VendaService : IVendaService
    {
        private IVendasDbRepository _vendasRepository;
        private IVendaAdapter _vendasAdapter;
        private IVendaItensDbRepository _vendasItensRepository;

        public VendaService(
            IVendasDbRepository vendasRepository, 
            IVendaAdapter vendasAdapter,
            IVendaItensDbRepository vendasItensRepository)
        {
            _vendasRepository = vendasRepository;
            _vendasAdapter = vendasAdapter;
            _vendasItensRepository = vendasItensRepository;
        }

        public void Adicionar(VendaDTO venda)
        {
            _vendasRepository.Adicionar(_vendasAdapter.Converter(venda));
            foreach (var item in venda.Itens)
            {
                _vendasItensRepository.Adicionar(_vendasAdapter.Converter(item, venda.Id));
            }
        }

        public VendaDTO Obter(int id)
        {
            var venda = _vendasAdapter.Converter(_vendasRepository.Obter(id));
            var itens = _vendasItensRepository.Obter(id);
            IEnumerable<VendaItemDTO> lista = new List<VendaItemDTO>();
            foreach (var item in itens)
            {
                lista.Append(_vendasAdapter.Converter(item));
            }
            venda.Itens = lista;
            return venda;
        }

        public IEnumerable<VendaDTO> ObterTodos()
        {
            IEnumerable<Venda> vendas = new List<Venda>();
            IEnumerable<VendaDTO> vendasRetorno = new List<VendaDTO>();

            foreach (var venda in vendas)
            {
                var vendaConvertida = _vendasAdapter.Converter(_vendasRepository.Obter(venda.Id));
                var itens = _vendasItensRepository.Obter(venda.Id);
                IEnumerable<VendaItemDTO> lista = new List<VendaItemDTO>();
                foreach (var item in itens)
                {
                    lista.Append(_vendasAdapter.Converter(item));
                }
                vendaConvertida.Itens = lista;
                vendasRetorno.Append(vendaConvertida);
            }
            
            return vendasRetorno;
        }
    }
}