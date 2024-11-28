using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann
{
    public class CadProdutos
    {
   
        List<Produto> produto = new List<Produto>();
        
        
        public int Tamanho()
        {
            return produto.Count;
        }

        public bool VerificaNovoCodigo(int codigo)
        {
            for (int i = 0; i < produto.Count; i++)
            {
                if (codigo == produto[i].Codigo)
                {
                    Console.WriteLine("Codigo já existente");
                    return false;
                }
            }
            return true;
        }
        public bool VerificaCodigoExistente(int codigo)
        {
            for (int i = 0; i < produto.Count; i++)
            {
                if (codigo == produto[i].Codigo)
                {
                    return true;
                }
                Console.WriteLine(produto[i].Codigo);
            }

            Console.WriteLine("Código Inexistente");

            return false;
        }


        public int RetornaPosicaoCodigo(int codigo)
        {
            for (int i = 0; i < produto.Count; i++) 
            {
                if(codigo == produto[i].Codigo)
                {
                    return i;
                }
            }
            return -1;
        }
        public void ProdutosVencidos(Data dataVencimento)
        {
            Console.WriteLine("**Vencimento Pereciveis**");
            for (int i = 0; i < produto.Count; i++)
            {
                if (this.produto[i] is Perecivel perecivel)
                {
                    int diasParaVencer = perecivel.DiasAteVencimento(dataVencimento);

                    if (diasParaVencer <= 0)
                    {
                        Console.WriteLine($"Produto Vencido! Código: {produto[i].Codigo}, Descrição: {produto[i].Descricao}");
                    }
                    else 
                    {
                        Console.WriteLine($"Produto dentro da validade! Dias para vencimento: {diasParaVencer}, Produto: {produto[i].Descricao}, Código: {produto[i].Codigo}");
                    }
                }
            }
        }
        public void Insere(Produto produto)
        {
            this.produto.Add(produto);
            return;
        }
        public Produto GetProduto(int posicao)
        {
            return this.produto[posicao];
        }

        public void ListaProduto()
        {
            Console.WriteLine("**DIGITAL**");
            for (int i = 0; i < produto.Count; i++)
            {
                if (this.produto[i] is Digital digital)
                {
                    produto[i].ExibirDetalhes();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("**DURAVEL**");
            for (int i = 0; i < produto.Count; i++)
            {
                if (this.produto[i] is Duravel duravel)
                {
                    produto[i].ExibirDetalhes();
                    Console.WriteLine();
                }
            }
            Console.WriteLine("**PERECIVEL**");
            for (int i = 0; i < produto.Count; i++)
            {
                if (this.produto[i] is Perecivel perecivel)
                {
                    produto[i].ExibirDetalhes();
                    Console.WriteLine();
                }
            }
        }   
    }
}
