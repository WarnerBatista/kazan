using KazanExpedicao.Models;
using KazanExpedicao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Services
{
    public class VendaService
    {
        public List<VendaModel> ObterStatus()
        {
            var vendaRepository = new VendaRepository();
            return vendaRepository.VerificaStatusVenda();
        }
        
        public bool AtualizarStatus(string status, int modelId)
        {
            var repository = new VendaRepository();
            return repository.AtualizaStatusVenda(status, modelId);
        }
    }
}
