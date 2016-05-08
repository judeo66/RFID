using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace segunda_tentativa
{
    public partial class Form1 : Form
    {
        DateTime dtInicio, dtFim = DateTime.Now;
        string szBufferCOM;
        Form2 ObjForm2;
        bool BoolConecta;                                                                   // booleana que diz se esta conectado ou não
        public Form1()
        {
            InitializeComponent();                                                          // inicializa o form
            timerBuscaArd.Enabled = true;
            this.Visible = false;
            this.ShowInTaskbar = false; 

        }

        private void bgConectaArd_DoWork(object sender, DoWorkEventArgs e)
        {

            if (BoolConecta == true)
            {
                BoolConecta = false;
                serialConexao.Write("*");

                Thread.Sleep(00);                                                     // para a execusão por 3 segundos para dar tempo da resposta

                if (BoolConecta == false)                                               // se continuar descontado ao arduino
                {
                    ObjForm2 = new Form2("arduino desconectado");                              // notificação de que o arduino esta conectado
                    ObjForm2.Show();                                                        // mostra a notificação
                    serialConexao.Close();                                              // fecha a conexão que foi aberta
                }
            }
            else
            {
                foreach (string stNomePorta in SerialPort.GetPortNames())                       // verifica todas as portas que estão abertas
                {
                    try                                                                         // tenta conectar aporta
                    {
                        serialConexao.PortName = stNomePorta;                               // define o nome da porta que ele vai conectar
                        serialConexao.BaudRate = 9600;                                      // velocidade de comunicação com a porte
                        serialConexao.DataBits = 8;                                         // 8 bits de transmição
                        serialConexao.Parity = Parity.None;                                 // sem paridade
                        serialConexao.Open();                                               // conecta na porta

                        BoolConecta = false;                                                    // deicha a conexao falsa de novo para testar novamente
                        serialConexao.Write("*");                                               // manda msg de verifição

                        Thread.Sleep(600);                                                     // para a execusão por 3 segundos para dar tempo da resposta

                        if (BoolConecta == false)                                               // se continuar descontado ao arduino
                        {
                            serialConexao.Close();                                              // fecha a conexão que foi aberta
                        }
                        else
                        {
                            ObjForm2 = new Form2("arduino conectado");                              // notificação de que o arduino esta conectado
                            ObjForm2.Show();                                                        // mostra a notificação
                        }

                    }
                    catch                                                                       // se não conseguir, sai da rotina
                    {
                        BoolConecta = false;                                                    // informa que esta desconectado
                    }
                }
            }
        }

        private void serialConexao_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                timerBuscaArd.Enabled = false;
                szBufferCOM = string.Empty;                                                 // declara a string que vai receber os dados
                szBufferCOM = serialConexao.ReadExisting();                                 // variavel recebe o resultado que o arduino manda
                if (szBufferCOM == "*")                                                     // se ele recebeu a mensagem de verificação
                {
                    BoolConecta = true;                                                     // declara como conectado
                }
                else                                                                        // se  a mensagem for diferente de *
                {
                    dtInicio = DateTime.Now;                                                    // inicio da execusão
                    bgPesquisaCartao.RunWorkerAsync();

                }
                timerBuscaArd.Enabled = true;
        }

        private void timerBuscaArd_Tick(object sender, EventArgs e)
        {
            bgConectaArd.RunWorkerAsync();                                                              // recebe a conexao que vem do ObjConexaoArd
        }

        private void bgPesquisaCartao_DoWork(object sender, DoWorkEventArgs e)
        {
            try                                                                     // tenta
            {
                ConsultaBD ObjConsulta = new ConsultaBD();                          // faz objeto para pesquisa no bd
                string stNomeUsusario = ObjConsulta.Consulta(szBufferCOM);          // faz pesquisa no bd
                ObjForm2 = new Form2("Bem vindo " + stNomeUsusario);                 // notificação de que a conexão fechou
                ObjForm2.Show();                                                    // mostra a notificação
                ObjConsulta.Executa_a_procudure(szBufferCOM);
                dtFim = DateTime.Now;
                int a = 0;
            }
            catch (Exception)
            {
                ObjForm2 = new Form2("Cartão invalido");                 // notificação de que a conexão fechou
                ObjForm2.Show();
            }
        }
    }
}
