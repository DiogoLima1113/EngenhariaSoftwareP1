using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Repository.Interface;
using EngenhariaSoftware.Domain.Service.Interface;

namespace EngenhariaSoftware.Domain.Service.Class
{
    public class UserService : IUserService
    {
        private IUsersDbRepository _usersRepository;

        public UserService(IUsersDbRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void Adicionar(User user)
        {
            _usersRepository.Adicionar(user);
        }

        public void Deletar(string id)
        {
            _usersRepository.Deletar(id);
        }

        public User Editar(string id, User user)
        {
            _usersRepository.Editar(id, user);
            return _usersRepository.Find(id);
        }

        public User Obter(string id)
        {
            return _usersRepository.Find(id);
        }

        public IEnumerable<User> ObterTodos()
        {
            return _usersRepository.ObterTodos();
        }
    }
}