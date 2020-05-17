namespace EngenhariaSoftware.Domain.Entity
{
    public class User
    {
        public string Id { get; set; }
        public string AccessKey { get; set; }

        public UserType Tipo { get; set; } 
        
    }

    public enum UserType{
        vendedor,
        gerente,
        caixa
    } 
}