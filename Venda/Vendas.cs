using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Matheus_Schumann.CadastroClientes;

namespace Trabalho_Matheus_Schumann.Venda
{
    public class Vendas
    {
        Data dataVenda;
        Cliente cliente;
        ItemVenda itemVenda;
        private double valorTotal;

        public Vendas(Data dataVenda, Cliente cliente, ItemVenda itemVenda, double valorTotal)
        {
            this.dataVenda = dataVenda;
            this.cliente = cliente;
            this.itemVenda = itemVenda;
            this.valorTotal = valorTotal;   
        }
        public Data DataVenda
        {
            get { return dataVenda; }
            set { dataVenda = value; }
        }
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        public ItemVenda ItemVenda
        {
            get { return itemVenda; }
            set { itemVenda = value; }
        }
        public double ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
    }
}
