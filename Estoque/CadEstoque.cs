using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Matheus_Schumann.CadastroClientes;

namespace Trabalho_Matheus_Schumann.Estoque
{
    public class CadEstoque
    {
        List<ItemEstoque> estoque = new List<ItemEstoque>();
        public int Tamanho()
        {
            return estoque.Count;
        }
        public ItemEstoque GetEstoque(int posicao)
        {
            return this.estoque[posicao];
        }
        public bool Insere(ItemEstoque itemEstoque)
        {
            estoque.Add(itemEstoque);
            return true;
        }
        public double ValorVenda(int quantidade, int posicao)
        {
            double valorFinal;
            valorFinal = quantidade * estoque[posicao].ValorProdutoEstoque;
            return valorFinal;
        }
        public bool VerificaCodigoExistente(int codigo)
        {
            for (int i = 0; i < estoque.Count; i++)
            {
                if (codigo == estoque[i].ProdutoEstoque.Codigo)
                {
                    return true;
                }
            }
            Console.WriteLine("Código não Cadastrado no estoque");
            return false;
        }
        public int RetornaPosicaoCodigo(int codigo)
        {
            for (int i = 0; i < estoque.Count; i++)
            {
                if (codigo == estoque[i].ProdutoEstoque.Codigo)
                {
                    return i;
                }
            }
            Console.WriteLine("Codigo não encontrado");
            return -1;
        }

        public bool QuantidadeEstoque(int quantidade, int posicao)
        {
            if (quantidade <= estoque[posicao].QuantidadeProdutoEstoque)
            {
                int valor = estoque[posicao].QuantidadeProdutoEstoque - quantidade;
                estoque[posicao].QuantidadeProdutoEstoque = valor;
                return true;
            }
            Console.WriteLine("Valor invalido");
            return false;
            
        }
        public void ListaEstoque()
        {
            for (int i = 0; i < estoque.Count; i++)
            {
                Console.Write($"Codigo produto: {estoque[i].ProdutoEstoque.Codigo} QuantidadeEstoque: {estoque[i].QuantidadeProdutoEstoque}");
                Console.WriteLine("\n");
            }

        }


    }
}
