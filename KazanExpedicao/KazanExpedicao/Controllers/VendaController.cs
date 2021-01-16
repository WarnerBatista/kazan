using KazanExpedicao.Models;
using KazanExpedicao.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KazanExpedicao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : Controller
    {
        private readonly VendaService _service;
        public VendaController(VendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<VendaModel> Get()
        {
            return _service.ObterStatus();
        }

        [HttpPost ("{id}")]
        public bool Post(int id, string status)
        {
            if (id > 0)
                return _service.AtualizarStatus(status, id);
            return false;
        }
    }
}
