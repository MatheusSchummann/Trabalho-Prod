using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.CadastroClientes
{
    public class Cliente
    {
        private int codigo;
        private string nome;
        private string foneRes;
        private string foneCelular;
        Endereco endereco;
        Data nascimento;

        public Cliente(int codigo, string nome, string foneRes, string foneCelular, Endereco endereco, Data nascimento)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.foneRes = foneRes;
            this.foneCelular = foneCelular;
            this.endereco = endereco;
            this.nascimento = nascimento;
        }
        public Endereco Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        public Data Nascimento 
        { 
            get { return nascimento; }
            set { nascimento = value; }
        }

        public int Codigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { this.nome = value; }
        }
        public string FoneRes
        {
            get { return foneRes; }
            set { this.foneRes = value; }
        }
        public string FoneCelular
        {
            get { return foneCelular; }
            set { this.foneCelular = value; }
        }

    }
}
