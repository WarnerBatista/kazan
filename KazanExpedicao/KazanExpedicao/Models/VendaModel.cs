using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Models
{
    public class VendaModel
    {
        public int VendaId { get; set; }
        public string Status { get; set; }
        public string NomeCliente { get; set; }
        public int Ordem { get; set; }
    }
}
