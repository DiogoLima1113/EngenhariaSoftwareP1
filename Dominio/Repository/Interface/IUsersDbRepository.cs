using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Dominio.Repository.Interface
{
    public interface IUsersDbRepository
    {
        User Find(string userID);
    }
}