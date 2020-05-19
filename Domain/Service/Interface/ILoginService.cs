using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface ILoginService
    {
        LoginResponse GenerateToken(User user);
    }
}