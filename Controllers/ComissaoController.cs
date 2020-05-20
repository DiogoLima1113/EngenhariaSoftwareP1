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
    public class ComissaoController : ControllerBase
    {
        private IComissaoService _service;

        public ComissaoController(IComissaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comissao>> Get()
        {
            return new ActionResult<IEnumerable<Comissao>>(_service.ObterTodos());
        }

        [HttpGet("{idUsuario}")]
        public ActionResult<IEnumerable<Comissao>> Get(int idUsuario)
        {
            return new ActionResult<IEnumerable<Comissao>>(_service.Obter(idUsuario));
        }

        [HttpPost]
        public ActionResult<Comissao> Post([FromBody] Comissao comissao)
        {
            var retorno = new Comissao();
            try
            {
                retorno =  _service.Adicionar(comissao);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
            return retorno;
        }
    }
}