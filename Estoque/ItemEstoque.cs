using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.Estoque
{
    public class ItemEstoque
    {
        Produto produtoEstoque;
        private int quantidadeProdutoEstoque;
        private double valorProdutoEstoque;

        public ItemEstoque(Produto produtoEstoque, int quantidadeProdutoEstoque, double valorProdutoEstoque)
        {
            this.produtoEstoque = produtoEstoque;
            this.quantidadeProdutoEstoque = quantidadeProdutoEstoque;
            this.valorProdutoEstoque = valorProdutoEstoque;
            
        }
        public Produto ProdutoEstoque
        {
            get { return produtoEstoque; }
            set { produtoEstoque = value; }
        }

        public int QuantidadeProdutoEstoque
        {        
            get { return this.quantidadeProdutoEstoque; }
            set { this.quantidadeProdutoEstoque = value; }
        }
        public double ValorProdutoEstoque
        {
            get { return this.valorProdutoEstoque; }
            set { this.valorProdutoEstoque = value; }
        }
    }
}
