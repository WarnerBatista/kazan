using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace KazanExpedicao.Helpers
{
    public class Banco
    {
        private MySqlConnection StringConexao = new MySqlConnection("Server=187.50.172.74; Database=wms; Uid=userwms; Pwd=WmsKaz20");
        public MySqlCommand command = new MySqlCommand();

        public int ExecutarSql()
        {
            int retorno;
            try
            {
                if (StringConexao.State == ConnectionState.Closed)
                    StringConexao.Open();
                command.Connection = StringConexao;
                retorno = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception)
            {
            }
            finally
            {
                StringConexao.Close();
            }
            return 0;
        }

        public DataTable ExecutarSelect()
        {
            DataTable dados = new DataTable();
            MySqlDataAdapter adapter;
            try
            {
                if (StringConexao.State == ConnectionState.Closed)
                    StringConexao.Open();
                command.Connection = StringConexao;
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(dados);
            }
            catch (Exception e)
            {
            }
            finally
            {
                StringConexao.Close();
            }
            return dados;
        }
    }
    public static class BancoExtensao
    {
        public static void AddParameterWithValue(this MySqlCommand command, string parameterName, object parameterValue)
        {
            if (parameterValue == null)
                parameterValue = string.Empty;
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
    }
}
