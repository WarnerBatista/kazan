using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Models
{
    public class ItemVendaModel
    {
        public int Codigo { get; set; }
        public double Quantidade { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
    }
}
