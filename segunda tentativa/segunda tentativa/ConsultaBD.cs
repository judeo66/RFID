using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segunda_tentativa
{
    class ConsultaBD
    {
        public string Consulta(string stCodigo)
        {
            Conexao objConexao = new Conexao();
            string query = "call BuscaUsuario('" + stCodigo + "')";
            int[] arrIndice = { 0 };
            ArrayList arrListresult = objConexao.Consulta(query, arrIndice);
            return Convert.ToString(arrListresult[0]);

        }
        public bool Executa_a_procudure(string stCodigo)
        {
            try
            {
                Conexao objConexao = new Conexao();
                string query = "call RegistrarES('"+stCodigo+"')";
                objConexao.Procedure(query);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
