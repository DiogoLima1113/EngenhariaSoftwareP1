using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngenhariaSoftware.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUserService _service;

        public UsuariosController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return new ActionResult<IEnumerable<User>>(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            return _service.Obter(id);
        }

        [HttpPost]
        public void Post([FromBody] User user)
        {
            try
            {
                _service.Adicionar(user);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(string id, [FromBody] User user)
        {
            ActionResult<User> resposta = null;
            try
            {
                resposta = new ActionResult<User>(_service.Editar(id, user));
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
            return resposta;
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            try
            {
                _service.Deletar(id);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }
    }
}