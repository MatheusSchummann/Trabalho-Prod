using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann
{
    public abstract class Produto
    {
        private int codigo;
        private string descricao;
        private string fabricante;
        public Perecivel Perecivel { get; set; }
        public Duravel Duravel { get; set; }
        public Digital Digital { get; set; }


        public Produto(int codigo, string descricao, string fabricante)
        {
            this.codigo = codigo;
            this.descricao = descricao;
            this.fabricante = fabricante;
        }
        public int Codigo
        {
            get { return this.codigo; }
            set { this.codigo = value; }
        }
        public string Descricao
        {
            get { return this.descricao; }
            set { this.descricao = value; }
        }
        public string Fabricante
        {
            get { return this.fabricante; }
            set { this.fabricante = value; }
        }
        public abstract void ExibirDetalhes();
    }
}
