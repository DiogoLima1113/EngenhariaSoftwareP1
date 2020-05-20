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
    public class FormaPagamentoController : ControllerBase
    {
        private IFormaPagamentoService _service;

        public FormaPagamentoController(IFormaPagamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FormaPagamento>> Get()
        {
            return new ActionResult<IEnumerable<FormaPagamento>>(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<FormaPagamento> Get(int id)
        {
            return _service.Obter(id);
        }

        [HttpPost]
        public void Post([FromBody] FormaPagamento formaPagamento)
        {
            try
            {
                _service.Adicionar(formaPagamento);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
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