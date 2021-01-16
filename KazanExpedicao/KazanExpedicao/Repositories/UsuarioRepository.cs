using KazanExpedicao.Helpers;
using KazanExpedicao.Models;
using System;

namespace KazanExpedicao.Repositories
{
    public class UsuarioRepository
    {
        public UsuarioModel VerificaLogin(UsuarioModel model)
        {
            Banco banco = new Banco();
            banco.command.CommandText = @"SELECT codigo, nome, senha, funcao FROM TabUsuarios WHERE (nome= @nome AND senha= @senha AND situacao= 'A')";
            banco.command.AddParameterWithValue("nome", model.Nome);
            banco.command.AddParameterWithValue("senha", model.Senha);
            try
            {
                using (var dtb = banco.ExecutarSelect())
                {
                    if (dtb.Rows.Count > 0)
                    {
                        var usuario = new UsuarioModel()
                        {
                            Codigo = Convert.ToInt32(dtb.Rows[0]["codigo"]),
                            Nome = dtb.Rows[0]["nome"].ToString(),
                            Senha = dtb.Rows[0]["senha"].ToString(),
                            Funcao = dtb.Rows[0]["funcao"].ToString()
                        };
                        return usuario;
                    }
                }
            }
            catch { }
            return null;
        }
    }
}
