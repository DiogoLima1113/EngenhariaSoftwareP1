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
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return new ActionResult<IEnumerable<Produto>>(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> Get(string id)
        {
            return _service.Obter(id);
        }

        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            try
            {
                _service.Adicionar(produto);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Produto> Put(string id, [FromBody] Produto produto)
        {
            ActionResult<Produto> resposta = null;
            try
            {
                resposta = new ActionResult<Produto>(_service.Editar(id, produto));
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