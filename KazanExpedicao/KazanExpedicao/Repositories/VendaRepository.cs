using KazanExpedicao.Helpers;
using KazanExpedicao.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KazanExpedicao.Repositories
{
    public class VendaRepository
    {
        public bool AtualizaStatusVenda(string status, int modelId)
        {
            Banco banco = new Banco();
            banco.command.CommandText = "UPDATE TabPedVenda SET status= @status WHERE numero= @numero";
            banco.command.AddParameterWithValue("status", status);
            banco.command.AddParameterWithValue("numero", modelId);
            try
            {
                return banco.ExecutarSql() > 0;
            }
            catch { }
            return false;
        }

        public List<VendaModel> VerificaStatusVenda()
        {
            Banco banco = new Banco();
            DataTable dados = new DataTable();
            var lstModel = new List<VendaModel>();
            banco.command.CommandText = @"SELECT v.numero, v.status, c.razao FROM TabPedVenda v INNER JOIN TabClientes c
                                        ON(v.CodCli = c.Codigo)
                                        WHERE STATUS = 'L' ORDER BY numero";
           
            try
            {
                dados = banco.ExecutarSelect();
                if (dados.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow row in dados.Rows)
                    {
                        var model = new VendaModel();
                        model.VendaId = Convert.ToInt32(row["numero"]);
                        model.Status = row["status"].ToString();
                        model.NomeCliente = row["razao"].ToString();
                        model.Ordem = i;
                        i++;
                        lstModel.Add(model);
                    }
                }
            }
            catch { }
            
            return lstModel;
        }
    }
}
