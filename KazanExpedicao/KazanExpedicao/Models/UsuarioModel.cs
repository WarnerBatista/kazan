using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Models
{
    public class UsuarioModel
    {
        public int Codigo { get; set; }
        public string Situacao { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Funcao { get; set; }
    }
}
