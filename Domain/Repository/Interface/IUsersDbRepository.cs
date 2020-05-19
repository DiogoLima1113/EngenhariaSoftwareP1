using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Repository.Interface
{
    public interface IUsersDbRepository
    {
        User Find(string userID);

        IEnumerable<User> ObterTodos();

        void Adicionar(User user);

        void Editar(string id, User user);

        void Deletar(string id);
    }
}