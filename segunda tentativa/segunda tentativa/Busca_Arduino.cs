using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace segunda_tentativa
{
    class Busca_Arduino
    {
        public int Busca_Ard(int nQtdPortas)
        {
            if (nQtdPortas != SerialPort.GetPortNames().Length)                             // se a quantidade de portas mudou
            {
                nQtdPortas = SerialPort.GetPortNames().Length;                               // define a qtd de portas
            }
            return nQtdPortas;                                                              // retorna a quantidade de portas

            // ver esse comando depois
        }
    }
}
