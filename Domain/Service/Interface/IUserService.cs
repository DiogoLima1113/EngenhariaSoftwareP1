using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;

namespace EngenhariaSoftware.Domain.Service.Interface
{
    public interface IUserService
    {
        IEnumerable<User> ObterTodos();
        
        User Obter(string id);

        void Adicionar(User user);

        User Editar(string id, User user);

        void Deletar(string id);
    }
}