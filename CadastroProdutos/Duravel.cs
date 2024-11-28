using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann
{
    public class Duravel : Produto
    {
        private int garantia;
        private string material;
        private bool manutencao;

        public Duravel(int codigo, string descricao, string fabricante, int garantia, string material, bool manutencao) : base(codigo, descricao, fabricante )
        {
            this.garantia = garantia;
            this.material = material;
            this.manutencao = manutencao;
        }

        public int Garantia 
        {
            get { return garantia; } 
            set { this.garantia = value; }
        }
        public string Material
        {
            get { return material; }
            set { this.material = value; }
        }
        public bool Manutencao
        {
            get { return manutencao; }
            set { this.manutencao = value; }
        }
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Codigo: {Codigo}\nDescrição: {Descricao}\nFabricante: {Fabricante}\nGarantia: {Garantia}\nMaterial: {Material}\nManutenção: {Manutencao}");
        }
    }
}
