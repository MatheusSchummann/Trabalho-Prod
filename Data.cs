using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann
{
    public class Data
    {
        private int dia;
        private int mes;
        private int ano;

        public Data(int dia, int mes, int ano)
        {
            this.dia = dia;
            this.mes = mes;
            this.ano = ano; 
        }
        public int Dia 
        { 
            get { return dia; }
            set { dia = value; }
        }
        public int Mes
        {
            get { return mes; }
            set { this.mes = value; }
        }

        public int Ano
        {
            get { return ano; }
            set { this.ano = value; }
        }
        public bool ValidaData()
        {
            if (mes < 1 || mes > 12)
                return false;

            int[] diasNoMes = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (mes == 2 && (ano % 4 == 0 && (ano % 100 != 0 || ano % 400 == 0)))
                diasNoMes[1] = 29;

            if (dia < 1 || dia > diasNoMes[mes - 1])
                return false;

            return true;
        }
    }
}
