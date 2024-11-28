using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Matheus_Schumann.CadastroClientes;
using Trabalho_Matheus_Schumann.Estoque;

namespace Trabalho_Matheus_Schumann.Venda
{
    public class ItemVenda
    {
        ItemEstoque produtoVenda;
        private int quantidadeProdutoVenda;
        private double valorProdutoVenda;

        public ItemVenda(ItemEstoque produtoVenda, int quantidadeProdutoVenda, double valorProdutoVenda)
        {
            this.produtoVenda = produtoVenda;
            this.quantidadeProdutoVenda = quantidadeProdutoVenda;
            this.valorProdutoVenda = valorProdutoVenda;
        }
        public ItemEstoque ProdutoVenda
        {
            get { return produtoVenda; }
            set { produtoVenda = value; }
        }
        public int QuantidadeProdutoVenda
        { 
            get { return quantidadeProdutoVenda; }
            set { quantidadeProdutoVenda = value; }
        }
        public double ValorProdutoVenda
        {
            get { return valorProdutoVenda; }
            set { valorProdutoVenda = value; }
        }

    }
}
