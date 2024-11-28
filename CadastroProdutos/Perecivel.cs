using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann
{
    public class Perecivel : Produto
    {
        Data dataValidadePerecivel;
        private bool organico;
        private string ingredientes;
        public Perecivel(int codigo, string descricao, string fabricante, bool organico, string ingredientes, Data dataValidadePerecivel) : base(codigo, descricao, fabricante)
        {
            this.organico = organico;
            this.ingredientes = ingredientes;
            this.dataValidadePerecivel = dataValidadePerecivel;
        }

        public Data DataValidadePerecivel
        {
            get { return dataValidadePerecivel; }
            set { dataValidadePerecivel = value; }
        }

        public bool Organico
        {
            get { return this.organico; }
            set { this.organico = value; }
        }
        public string Ingredientes
        {
            get { return this.ingredientes; }
            set { this.ingredientes = value; }
        }
        public override void ExibirDetalhes()
        {
            Console.WriteLine($"Codigo: {Codigo}\nDescrição: {Descricao}\nFabricante: {Fabricante}\nOrganico: {Organico}\nIngredientes: {Ingredientes}");
        }
        public int DiasAteVencimento(Data dataRef)
        {
            DateTime dataValidadeDateTime = new DateTime(dataValidadePerecivel.Ano, dataValidadePerecivel.Mes, dataValidadePerecivel.Dia);
            DateTime dataRefDateTime = new DateTime(dataRef.Ano, dataRef.Mes, dataRef.Dia);

            if (dataRefDateTime > dataValidadeDateTime)
            {
                return 0;
            }
            TimeSpan diferenca = dataValidadeDateTime - dataRefDateTime;

            return diferenca.Days;
        }

    }
}
