using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.Venda
{
    public class CadVendas
    {
        List<Vendas> vendas = new List<Vendas>();
        public Vendas GetVenda(int posicao)
        {
            return vendas[posicao]; 
        }
        public void Insere(Vendas venda)
        {
            vendas.Add(venda);
        }
        public int Tamanho()
        {
            return vendas.Count;
        }
        public void ListaVendas()
        {
            Console.WriteLine("Vendas Realizadas");
            for(int i = 0; i < vendas.Count; i++)
            {
                Console.WriteLine($"Codigo do Produto: {vendas[i].ItemVenda.ProdutoVenda.ProdutoEstoque.Codigo}, Quantidade: {vendas[i].ItemVenda.QuantidadeProdutoVenda}, Valor Total: {vendas[i].ValorTotal} ");
            }

        }
    }
}
