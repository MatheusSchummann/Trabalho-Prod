using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.Venda
{
   public class Main
   {
        /*Criar um menu de opções onde deve ser possível:
        1. Cadastrar os produtos que a empresa comercializa (duráveis, perecíveis e digitais);
        2. Listar os produtos que a empresa comercializa (listar separadamente por categoria (duráveis,
        perecíveis e digitais));
        3. Informar uma data e listar os produtos que estão a XX dias de vencerem (informar o valor de xx);
        4. Cadastrar os clientes da empresa;
        5. Listar os clientes da empresa;
        6. Cadastrar o estoque de produtos;
        7. Cadastrar uma venda:
            a. Informar um cliente válido (informar o código de um cliente cadastrado);
            b. Informar os itens vendidos (informar o código e a quantidade). Verificar se a quantidade está
            disponível no estoque. Se não estiver, avisar com uma mensagem.
            c. Cadastrar a data em que a venda foi realizada.
            d. Calcular o valor total da venda.
            e. Realizar a baixa do estoque da quantidade dos itens vendidos
        8. Listar todas as vendas realizadas. */
        public void Menu()
        {
            Metodos metodos = new Metodos();
            int escolha = 0;

            metodos.LeituraDados();

            do
            {
                Console.WriteLine("\t****************");
                Console.WriteLine("\t**SISTEMA PROD**");
                Console.WriteLine("\t****************");

                Console.WriteLine("1- Cadastrar produtos");
                Console.WriteLine("2- Lista produtos");
                Console.WriteLine("3- Dias para vencimento");
                Console.WriteLine("4- Cadastrar clientes");
                Console.WriteLine("5- Lista clientes");
                Console.WriteLine("6- Cadastrar estoque");
                Console.WriteLine("7- Cadastrar vendas");
                Console.WriteLine("8- Lista de vendas");
                Console.WriteLine("9- Encerrar sistema");
                escolha = LerNumero("Comando: "); 

                switch (escolha)
                {
                    case 1:
                        metodos.Met1();
                        break;
                    case 2:
                        metodos.Met2();
                        break;
                    case 3:
                        metodos.Met3();
                        break;
                    case 4:
                        metodos.Met4();
                        break;
                    case 5:
                        metodos.Met5();
                        break;
                    case 6:
                        metodos.Met6();
                        break;
                    case 7:
                        metodos.Met7();
                        break;
                    case 8:
                        metodos.Met8();
                        break;
                    default:
                        Console.WriteLine("Comando desconhecido");
                        break;
                }

            } while (escolha != 9);

        }
        private int LerNumero(string mensagem)
        {
            int numero;
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();
                if (int.TryParse(entrada, out numero))
                    return numero;
                else
                    Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }

    }
}
