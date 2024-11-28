using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.CadastroClientes
{
    public class Endereco
    {
        private string rua;
        private int numero;
        private string complemento;
        private string bairro;
        private string cep;
        private string cidade;
        private string uf;
        public Endereco(string rua, int numero, string complemento, string bairro, string cep, string cidade, string uf)  
        { 
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.uf = uf;
        }
        public string Rua
        {
            get { return this.rua; }
            set { this.rua = value; }
        }
        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }
        public string Complemento
        {
            get { return this.complemento; }
            set { this.complemento = value; }
        }

        public string Bairro
        {
            get { return this.bairro; }
            set { this.bairro = value; }
        }
        public string Cep
        {
            get { return this.cep; }
            set { this.cep = value; }
        }
        public string Cidade
        {
            get { return this.cidade; }
            set { this.cidade = value; }
        }
        public string Uf
        {
            get { return this.uf; }
            set { this.uf = value; }
        }
    }
}
