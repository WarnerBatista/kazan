using KazanExpedicao.Models;
using KazanExpedicao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Services
{
    public class ItemVendaService
    {
        public List<ItemVendaModel> BuscarPorId(int vendaId)
        {
            var repository = new VendaItemRepository();
            return repository.BuscarItens(vendaId);
        }

        public bool SetQuantidadeSeparada()
        {
            return false;
        }
    }
}
