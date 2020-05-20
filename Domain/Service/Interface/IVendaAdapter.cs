using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IVendaAdapter
    {
        Venda Converter(VendaDTO venda);
        VendaDTO Converter(Venda venda);

        VendaItem Converter(VendaItemDTO item, int idVenda);
        VendaItemDTO Converter(VendaItem item);
    }
}