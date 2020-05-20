using System;

namespace EngenhariaSoftware.Domain.Entity
{
    public class Venda
    {
        public int Id { get; set; }
        public float ValorTotal { get; set; }
        public string IdUsuario { get; set; }
        public string CpfCliente { get; set; }
        public int IdFormaPagamento { get; set; }
        public string Encomenda { get; set; }
        public DateTime Data { get; set; }
    }
}