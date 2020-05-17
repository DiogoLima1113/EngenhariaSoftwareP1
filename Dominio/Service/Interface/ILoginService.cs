using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Dominio.Entity;

namespace EngenhariaSoftware.Dominio.Service.Interface
{
    public interface ILoginService
    {
        LoginResponse GenerateToken(User user);
    }
}