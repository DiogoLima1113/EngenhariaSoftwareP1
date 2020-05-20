using System;
using System.Collections.Generic;

namespace EngenhariaSoftware.Domain.Entity
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public IEnumerable<VendaItemDTO> Itens { get; set; }
        public User Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public FormaPagamento Pagamento { get; set; }
        public bool Encomenda { get; set; }
        public DateTime Data { get; set; }
    }
}