using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace segunda_tentativa
{
    class Conexao
    {
        string Server = "localhost",                                                                    // servidor usado
               Port = "3306",                                                                           // porta usada
               Database = "db_controle_usuario",                                                        // nome do banco de dados
               User = "root",                                                                           // nome de usuario
               Password = "root";                                                                       // senha

        MySqlDataReader rdr;                                                                            // variavel de leitura do bd

        private MySqlConnection sqlConect = new MySqlConnection();                                      // variavel com a conexao do banco
        MySqlCommand sqlComando = new MySqlCommand();                                                   // comado que vai ser execultado



        /// <summary>
        /// metodo que conecta ao banco
        /// </summary>
        /// <returns></returns>
        private void ConectaBanco()
        {
            string strConect;                                                                           // string com os parametros de conexao

            if (sqlConect.State != System.Data.ConnectionState.Open)                                    // se a conexao estiver fechada
            {
                strConect = "server = " + Server + "; Port = " + Port +                                 // parametriza a variavel
                    "; Database = " + Database + "; User = " + User + "; Password = " + Password + ";";
                sqlConect = new MySqlConnection(strConect);                                             // faz a conexao com o bd
                try                                                                                     // tenta fazer a conexao com o bd
                {
                    sqlConect.Open();                                                                   // abre a conexao

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Atualiza(string strComando)
        {
            sqlComando.CommandText = strComando;                                                        // atribui a variavel de comando a string com o comando que vem do parametro
            try
            {
                ConectaBanco();                                                                         // abre a conexao
                sqlComando.Connection = sqlConect;                                                      // atribui o comando ao banco de dados da conexao
                sqlComando.ExecuteScalar();                                                             // execulta a consulta
                DesconectaBanco();
                return true;                                                                            // retorna que foi executado com sucesso
            }
            catch (Exception)
            {
                DesconectaBanco();
                return false;                                                                           // retorna que foi não executado com sucesso
            }
        }

        /// <summary>
        /// metodo para fazer consulta no bd
        /// </summary>
        /// <param name="strComando">recebe comando qe vai ser executado</param>
        /// <returns>retorna o resultado da consulta</returns>
        public ArrayList Consulta(string strComando, int[] Campos)
        {
            ArrayList arrListResultado = new ArrayList();                                               // array com os resultados da consulta
            sqlComando.CommandText = strComando;                                                        // atribui a variavel de comando a string com o comando que vem do parametro
            try
            {
                ConectaBanco();                                                                         // abre a conexao
                sqlComando.Connection = sqlConect;                                                      // atribui o comando ao banco de dados da conexao
                rdr = sqlComando.ExecuteReader();                                                       // execulta a consulta
                while (rdr.Read())                                                                      // enquanto tiver campos para ler
                {
                    for (int i = 0; i < Campos.Length; i++)
                    {
                        arrListResultado.Add(rdr[Campos[i]]);                                           // adiciona a array o valor lido  
                    }
                    // incrementa o indice
                }
                DesconectaBanco();
                return arrListResultado;                                                                // retorna o valor do array com o resultdo da consulta
            }
            catch (Exception)                                                                           // se não der certo
            {
                DesconectaBanco();
                return null;                                                                            // retorna valor nulo
            }
        }

        /// <summary>
        /// metodo que insere no bd
        /// </summary>
        /// <param name="strComando">comando a ser executado</param>
        /// <returns>retorna o resutado</returns>
        public bool Insere(string strComando)
        {
            sqlComando.CommandText = strComando;                                                        // atribui a variavel de comando a string com o comando que vem do parametro
            try
            {
                ConectaBanco();                                                                         // abre a conexao
                sqlComando.Connection = sqlConect;                                                      // atribui o comando ao banco de dados da conexao
                sqlComando.ExecuteScalar();                                                             // execulta a consulta
                DesconectaBanco();
                return true;                                                                            // retorna que foi executado com sucesso
            }
            catch (Exception)
            {
                DesconectaBanco();
                return false;                                                                           // retorna que foi não executado com sucesso
            }
        }
        /// <summary>
        /// metodo que executa a procedure no bd
        /// </summary>
        /// <param name="strComando">comando a ser executado</param>
        /// <returns>retorna o resutado</returns>
        public bool Procedure(string strComando)
        {
            sqlComando.CommandText = strComando;                                                        // atribui a variavel de comando a string com o comando que vem do parametro
            try
            {
                ConectaBanco();                                                                         // abre a conexao
                sqlComando.Connection = sqlConect;                                                      // atribui o comando ao banco de dados da conexao
                sqlComando.ExecuteNonQuery();                                                           // execulta a consulta
                DesconectaBanco();
                return true;                                                                            // retorna que foi executado com sucesso
            }
            catch (Exception)
            {
                DesconectaBanco();
                return false;                                                                           // retorna que foi não executado com sucesso
            }
        }
        /// <summary>
        /// metodo que desconecta do bd
        /// </summary>
        private void DesconectaBanco()
        {
            if (sqlConect.State != System.Data.ConnectionState.Closed)                                  // se a conexao estiver aberta
            {
                try                                                                                     // tenta fazer a conexao com o bd
                {
                    sqlConect.Close();                                                                  // fecha a conexao
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
