using KazanExpedicao.Models;
using KazanExpedicao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Services
{
    public class UsuarioService
    {
        public UsuarioModel Buscar(UsuarioModel model)
        {
            var repository = new UsuarioRepository();
            return repository.VerificaLogin(model);
        }
    }
}
