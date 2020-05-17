using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Dominio.Entity
{
    public class LoginResponse
    {
        public bool Authenticated { get; private set; }
        public string Message { get; private set; }
        public string AcessToken { get; private set; }
        public string Created { get; private set; }
        public string Expiration { get; private set; }

        public UserType? TipoUsuario { get; private set; }

        public LoginResponse(
            bool authenticated,
            string message,
            string acessToken = null,
            string created = null,
            string expiration = null,
            UserType? tipoUsuario = null)
        {
            Authenticated = authenticated;
            Message = message;
            AcessToken = acessToken;
            Created = created;
            Expiration = expiration;
            TipoUsuario = tipoUsuario;
        }
    }
}