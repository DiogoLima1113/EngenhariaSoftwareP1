using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngenhariaSoftware.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        /// <summary>
        /// Realiza o login do usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// AcessToken e tipo de Usuário
        /// Tipos:
        /// 0 = vendedor
        /// 1 = gerente
        /// 2 = cliente
        /// </returns>
        public LoginResponse Post([FromBody]User user)
        {
            return _service.GenerateToken(user);
        }
    }
}