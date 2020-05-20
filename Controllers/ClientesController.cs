using System;
using System.Collections.Generic;
using EngenhariaSoftware.Domain.Entity;
using EngenhariaSoftware.Domain.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngenhariaSoftware.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteService _service;

        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return new ActionResult<IEnumerable<Cliente>>(_service.ObterTodos());
        }

        [HttpGet("{cpf}")]
        public ActionResult<Cliente> Get(string cpf)
        {
            return _service.Obter(cpf);
        }

        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            try
            {
                _service.Adicionar(cliente);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPut("{cpf}")]
        public ActionResult<Cliente> Put(string cpf, [FromBody] Cliente cliente)
        {
            ActionResult<Cliente> resposta = null;
            try
            {
                resposta = new ActionResult<Cliente>(_service.Editar(cpf, cliente));
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
            return resposta;
        }

        [HttpDelete("{cpf}")]
        public void Delete(string cpf)
        {
            try
            {
                _service.Deletar(cpf);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }
    }
}