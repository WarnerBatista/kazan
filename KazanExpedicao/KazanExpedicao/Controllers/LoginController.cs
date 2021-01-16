using KazanExpedicao.Models;
using KazanExpedicao.Services;
using KazanExpedicao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly UsuarioService _service;
        public LoginController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public UsuarioModel Index(string login, string senha)
        {
            var model = new UsuarioModel();
            model.Nome = login;
            model.Senha = senha;
            return _service.Buscar(model);
        }

        [HttpPost]
        public ActionResult<TokenVM> Autenticacao([FromBody] UsuarioModel model)
        {
            UsuarioModel user = _service.Buscar(model);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });
            return TokenService.GenerateToken(user);
        }
    }
}
