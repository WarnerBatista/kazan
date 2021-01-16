using KazanExpedicao.Helpers;
using KazanExpedicao.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace KazanExpedicao.Repositories
{
    public class VendaItemRepository
    {
        public bool GravarQuantidade(double quantidade, int vendaId)
        {
            Banco banco = new Banco();
            banco.command.CommandText = @"UPDATE TabItemVenda SET QtdSep = @qtde WHERE NumPedRep = @vendaId";
            banco.command.AddParameterWithValue("qtde", quantidade);
            banco.command.AddParameterWithValue("vendaId", vendaId);
            try{
                return banco.ExecutarSql() > 0;
            }
            catch { }
            return false;
        }
        public List<ItemVendaModel> BuscarItens(int vendaId)
        {
            Banco banco = new Banco();
            var listItens = new List<ItemVendaModel>();
            banco.command.CommandText = @"SELECT iv.codPro, p.Descricao, iv.Quant, a.Galpao FROM TabItemVenda iv 
                                INNER JOIN TabProdutos p ON (iv.codPro = p.codigo) 
                                INNER JOIN TabArmazenagemItem a ON (a.numero = iv.codPro) 
                                WHERE iv.NumPedRep = @vendaId";
            banco.command.AddParameterWithValue("vendaId", vendaId);
            try
            {
                using(var dados = banco.ExecutarSelect())
                {
                    if(dados.Rows.Count > 0)
                    {
                        foreach(DataRow row in dados.Rows)
                        {
                            var item = new ItemVendaModel();
                            item.Codigo = Convert.ToInt32(row["codPro"]);
                            item.Descricao = row["Descricao"].ToString();
                            item.Quantidade = Convert.ToDouble(row["Quant"]);
                            item.Localizacao = row["Galpao"].ToString();
                            listItens.Add(item);
                        }
                    }
                }
            }
            catch { }
            return listItens;
        }
    }
}
