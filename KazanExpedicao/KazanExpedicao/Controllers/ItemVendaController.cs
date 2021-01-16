using KazanExpedicao.Models;
using KazanExpedicao.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemVendaController : Controller
    {
        private readonly ItemVendaService _service;
        public ItemVendaController(ItemVendaService service)
        {
            _service = service;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<ItemVendaModel> Details(int id)
        {
            return _service.BuscarPorId(id);
        }
    }
}
