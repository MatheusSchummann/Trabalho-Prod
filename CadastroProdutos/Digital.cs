using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Trabalho_Matheus_Schumann
{
    public class Digital : Produto
    {
        private double tamanho;
        private string formato;
        private string link;
        public Digital(int codigo, string descricao, string fabricante, double tamanho, string formato, string link) : base(codigo, descricao, fabricante)
        {
            this.tamanho = tamanho;
            this.formato = formato;
            this.link = link;
        }
        public double Tamanho
        {
            get { return tamanho; }
            set { this.tamanho = value; }
        }
        public string Formato
        {
            get { return formato; }
            set { this.formato = value; }
        }
        public string Link
        {
            get { return link; }
            set { this.link = value; }
        }

        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Codigo: {Codigo}\nDescrição: {Descricao}\nFabricante: {Fabricante}\nTamanho: {Tamanho}\nFormato: {Formato}\nLink: {Link}");
        }
    }
}
