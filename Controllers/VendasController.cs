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
    public class VendasController : ControllerBase
    {
        private IVendaService _service;

        public VendasController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VendaDTO>> Get()
        {
            return new ActionResult<IEnumerable<VendaDTO>>(_service.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<VendaDTO> Get(int id)
        {
            return _service.Obter(id);
        }

        [HttpPost]
        public void Post([FromBody] VendaDTO venda)
        {
            try
            {
                _service.Adicionar(venda);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
            }
        }
    }
}