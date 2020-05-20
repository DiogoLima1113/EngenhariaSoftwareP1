using System;

namespace EngenhariaSoftware.Domain.Entity
{
    public class Comissao
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public float Valor { get; set; }
    }
}