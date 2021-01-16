using KazanWF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazanWF.Helper
{
    public static class VendaHelper
    {
        public static async Task<List<VendaModel>> ObterStatusVenda()
        {
            ApiHelper api = new ApiHelper();
            return await api.Get<List<VendaModel>>("Venda");
        }
    }
}
