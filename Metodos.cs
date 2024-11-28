using System;
using System.IO;
using System.Security.Cryptography;
using Trabalho_Matheus_Schumann.CadastroClientes;
using Trabalho_Matheus_Schumann.Estoque;
using Trabalho_Matheus_Schumann.Venda;

namespace Trabalho_Matheus_Schumann
{
    public class Metodos
    {
        CadProdutos cadProdutos = new CadProdutos();
        CadClientes cadClientes = new CadClientes();
        CadEstoque cadEstoque = new CadEstoque();
        CadVendas cadVendas = new CadVendas();
        PersistenciaDados persistenciaDados = new PersistenciaDados();

        public void LeituraDados()
        {

            if (persistenciaDados.ExisteArquivo("Produtos.csv"))
            {
                persistenciaDados.LeituraDadosCadProdutos("Produtos.csv", cadProdutos);
            }

            if (persistenciaDados.ExisteArquivo("Clientes.csv"))
            {
                persistenciaDados.LeituraDadosCadClientes("Clientes.csv", cadClientes);
            }

            if (persistenciaDados.ExisteArquivo("Estoque.csv"))
            {
                persistenciaDados.LeituraDadosCadEstoque("Estoque.csv", cadEstoque, cadProdutos);
            }
            if (persistenciaDados.ExisteArquivo("Vendas.csv"))
            {
                persistenciaDados.LeituraDadosCadVendas("Vendas.csv", cadVendas, cadProdutos, cadEstoque);
            }

        }
        public void Met1()
        {
            bool manutencao = false, loop, organico = false;
            string formato = "", link, material, fabricante, escolhaS, descricao, ingredientes;
            double tamanho;
            int escolha = 0, codigo, garantia, dia, mes, ano;

            Console.Clear();
            Console.WriteLine("\t****Cadastro Produtos****");
            Console.WriteLine("Escolha a categoria desejada");
            do
            {
                Console.WriteLine("1- Duráveis");
                Console.WriteLine("2- Perecíveis");
                Console.WriteLine("3- Digitais");
                Console.WriteLine("4- Voltar");
                escolha = LerNumero("Escolha a categoria desejada: ");

                switch (escolha)
                {
                    case 1:
                        dadosPadraoEntrada();
                        garantia = LerNumero("Digite a garantia (ano): ");
                        Console.Write("Digite o material: ");
                        material = Console.ReadLine();

                        do
                        {
                            loop = false;
                            Console.Write("Deseja manutenção? 's' 'n': ");
                            escolhaS = Console.ReadLine();
                            if (escolhaS == "s" || escolhaS == "S")
                            {
                                manutencao = true;
                                loop = true;
                            }
                            else if (escolhaS == "n" || escolhaS == "N")
                            {
                                manutencao = false;
                                loop = true;
                            }
                        } while (!loop);

                        Duravel duravel = new Duravel(codigo, descricao, fabricante, garantia, material, manutencao);
                        cadProdutos.Insere(duravel);
                        Console.Clear();
                        Console.WriteLine("Produto Salvo!");
                        persistenciaDados.EscritaDadosCadProdutos(cadProdutos, "Produtos.csv");
                        break;

                    case 2:
                        bool validador;
                        Data dataValidade; 
                        dadosPadraoEntrada();
                        do
                        {
                            Console.WriteLine("Informe a data de validade");
                            dia = LerNumero("Dia: ");
                            mes = LerNumero("Mês: ");
                            ano = LerNumero("Ano: ");
                            dataValidade = new Data(dia, mes, ano);
                            validador = dataValidade.ValidaData();
                            if (validador == false)
                            {
                                Console.WriteLine("Data invalida!");
                            }
                        } while (validador == false);

                        do
                        {
                            loop = false;
                            Console.Write("É orgânico? 's' 'n': ");
                            escolhaS = Console.ReadLine();
                            if (escolhaS == "s" || escolhaS == "S")
                            {
                                organico = true;
                                loop = true;
                            }
                            else if (escolhaS == "n" || escolhaS == "N")
                            {
                                organico = false;
                                loop = true;
                            }
                        } while (!loop);

                        Console.Write("Digite os ingredientes: ");
                        ingredientes = Console.ReadLine();
                        Perecivel perecivel = new Perecivel(codigo, descricao, fabricante, organico, ingredientes, dataValidade);
                        cadProdutos.Insere(perecivel);
                        Console.Clear();
                        Console.WriteLine("Produto Salvo!");
                        persistenciaDados.EscritaDadosCadProdutos(cadProdutos, "Produtos.csv");
                        break;

                    case 3:
                        int escolhaFormato;
                        bool validadorFormato = false;
                        Console.Clear();
                        dadosPadraoEntrada();
                        tamanho = LerNumeroDouble("Digite o tamanho em mb: ");
           
                        do {
                            Console.WriteLine("Escolha o formato");
                            Console.WriteLine("1- Pdf");
                            Console.WriteLine("2- Stream");
                            Console.WriteLine("3- Mp3");
                            Console.WriteLine("4- Mp4");
                            Console.WriteLine("5- Word");
                            Console.Write("Comando: ");
                            escolhaFormato = int.Parse(Console.ReadLine());
                            switch (escolhaFormato)
                            {
                                case 1:
                                    formato = "Pdf";
                                    validadorFormato = true;
                                    break;
                                case 2:
                                    validadorFormato = true;
                                    formato = "Stream";
                                    break;
                                case 3:
                                    validadorFormato = true;
                                    formato = "Mp3";
                                    break;
                                case 4:
                                    validadorFormato = true;
                                    formato = "Mp4";
                                    break;
                                case 5:
                                    validadorFormato = true;
                                    formato = "Word";
                                    break;
                                default:
                                    Console.WriteLine("Comando invalido");
                                    break;
                            }
                        } while (validadorFormato == false);

                        Console.Write("Digite o link: ");
                        link = Console.ReadLine();

                        Digital digital = new Digital(codigo, descricao, fabricante, tamanho, formato, link);
                        cadProdutos.Insere(digital);
                        Console.Clear();
                        Console.WriteLine("Produto Salvo!");
                        persistenciaDados.EscritaDadosCadProdutos(cadProdutos, "Produtos.csv");
                        break;
                }
                Console.Clear();
            } while (escolha != 4);


            void dadosPadraoEntrada()
            {
                bool verificaCodigo = false;
                do
                {
                    codigo = LerNumero("Digite o código: ");
                    verificaCodigo = cadProdutos.VerificaNovoCodigo(codigo);
                } while (verificaCodigo == false);

                Console.Write("Digite a descrição: ");
                descricao = Console.ReadLine();
                Console.Write("Digite o fabricante: ");
                fabricante = Console.ReadLine();
            }
        }

        public void Met2()
        {
            Console.Clear();
            Console.WriteLine("\t****Lista Produtos****");
            cadProdutos.ListaProduto();
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
        }
        public void Met3()
        {
            int dia, mes, ano;
            bool validador = false;
            Data dataVencimento;
            Console.Clear();
            Console.WriteLine("\t****Dias para Vencimento****");
            do
            {
                Console.WriteLine("Informe a data para busca");
                dia = LerNumero("Dia: ");
                mes = LerNumero("Mês: ");
                ano = LerNumero("Ano: ");
                dataVencimento = new Data(dia, mes, ano);
                validador = dataVencimento.ValidaData();
                if (validador == false) 
                {
                    Console.WriteLine("Data invalida!");
                }
            } while (validador == false);

            cadProdutos.ProdutosVencidos(dataVencimento);
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
        }

        public void Met4()
        {
            int codigo, numero, dia, mes, ano; ;
            string nome, foneRes, foneCelular, rua, complemento, bairro, cep, cidade, uf;
            Endereco endereco;
            Data nascimento;
            Cliente cliente;
            bool loop = false;
            bool verificaCodigo = false , validador = false;
            Console.Clear();

            do
            {
                Console.WriteLine("\t****Cadastro Clientes****");
                do
                {
                    codigo = LerNumero("Informe o codigo: ");
                    verificaCodigo = cadClientes.VerificaNovoCodigo(codigo);
                } while (verificaCodigo == false);

                Console.Write("Digite o nome: ");
                nome = Console.ReadLine();
                Console.Write("Informe o foneRes: ");
                foneRes = Console.ReadLine();
                Console.Write("Informe o foneCelular: ");
                foneCelular = Console.ReadLine();
                do
                {
                    Console.WriteLine("Informe seu nascimento");
                    dia = LerNumero("Dia: ");
                    mes = LerNumero("Mês: ");
                    ano = LerNumero("Ano: ");
                    nascimento = new Data(dia, mes, ano);
                    validador = nascimento.ValidaData();
                    if (validador == false)
                    {
                        Console.WriteLine("Data invalida!");
                    }
                } while (validador == false);

                Console.Write("Informe a cidade: ");
                cidade = Console.ReadLine();
                Console.Write("Informe o CEP: ");
                cep = Console.ReadLine();
                Console.Write("Informe o bairro: ");
                bairro = Console.ReadLine();
                Console.Write("Informe a rua: ");
                rua = Console.ReadLine();
                numero = LerNumero("Informe o numero: ");
                Console.Write("Informe o complemento: ");
                complemento = Console.ReadLine();
                Console.Write("Informe o uf: ");
                uf = Console.ReadLine();    

                endereco = new Endereco(rua, numero, complemento, bairro, cep, cidade, uf);
                nascimento = new Data(dia, mes, ano);
                cliente = new Cliente(codigo, nome, foneRes, foneCelular, endereco, nascimento);

                loop = cadClientes.Insere(cliente);

            } while (loop == false);
            persistenciaDados.EscritaDadosCadClientes(cadClientes, "Clientes.csv");
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
        }

        public void Met5()
        {
            Console.Clear();    
            Console.WriteLine("\t****Lista Clientes****");
            cadClientes.ListaClientes();
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
        }
        public void Met6()
        {
            ItemEstoque itemEstoque;
            int quantidade, codigo, posicao;

            double valor;
            bool loop, codigoValido = false;
            Console.Clear();
            Console.WriteLine("\t****Cadastro Estoque****");
            do
            {
                Console.WriteLine("Qual produto deseja cadastrar? ");
                cadProdutos.ListaProduto();
                do
                {
                    codigo = LerNumero("Informe o codigo do produto: ");
                    codigoValido = cadProdutos.VerificaCodigoExistente(codigo);
                } while (codigoValido == false);
                posicao = cadProdutos.RetornaPosicaoCodigo(codigo);
                Produto item = cadProdutos.GetProduto(posicao);
                quantidade = LerNumero("Informe a quantidade de unidades para o estoque: ");
                valor = LerNumero("Informe o valo por unidade: ");
                itemEstoque = new ItemEstoque(item, quantidade, valor);
                loop = cadEstoque.Insere(itemEstoque);

            } while(loop == false);
            persistenciaDados.EscritaDadosCadEstoque(cadEstoque, "Estoque.csv");
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();

        }
        public void Met7()
        {
            Data dataVenda;
            Cliente cliente;
            ItemVenda itemVenda;
            Vendas vendas;
            bool validador1 = false, validador2 = false, validador3=false, validador4=false;
            int codigoCliente, codigoProduto, posicaoCliente, posicaoEstoque, quantidadeItems, dia, mes, ano;
            double valorVenda;

            Console.Clear();
            Console.WriteLine("\t****Cadastro Venda****");
            Console.WriteLine("Codigos clientes:");
            cadClientes.ListaClientes();
            do
            {
                codigoCliente = LerNumero("Informe o codigo do cliente: ");
                validador1  = cadClientes.VerificaCodigoExistente(codigoCliente);
            } while (validador1 == false);

            posicaoCliente = cadClientes.RetornaPosicaoCodigo(codigoCliente);
            cliente = cadClientes.GetCliente(posicaoCliente);
            Console.Clear();
            Console.WriteLine("\t****Cadastro venda****");
            Console.WriteLine("Produtos do estoque:");
            cadEstoque.ListaEstoque();
            do
            {
                codigoProduto = LerNumero("Informe o codigo do produto: ");
                validador2 = cadEstoque.VerificaCodigoExistente(codigoProduto);
            } while (validador2 == false);

            posicaoEstoque = cadEstoque.RetornaPosicaoCodigo(codigoProduto);
            do
            {
                quantidadeItems = LerNumero("Informe a quantidade que deseja retirar: ");
                validador3 = cadEstoque.QuantidadeEstoque(quantidadeItems, posicaoEstoque);
            } while(validador3 == false);

            valorVenda = cadEstoque.ValorVenda(quantidadeItems, posicaoEstoque);
            ItemEstoque produto = cadEstoque.GetEstoque(posicaoEstoque);
            itemVenda = new ItemVenda(produto, quantidadeItems, valorVenda);
            do
            {
                Console.WriteLine("Informe a data da venda");
                dia = LerNumero("Dia: ");
                mes = LerNumero("Mês: ");
                ano = LerNumero("Ano: ");
                dataVenda = new Data(dia, mes, ano);
                validador4 = dataVenda.ValidaData();
                if (validador4 == false)
                {
                    Console.WriteLine("Data invalida!");
                }
            } while (validador4 == false);

            vendas = new Vendas(dataVenda, cliente, itemVenda, valorVenda);
            cadVendas.Insere(vendas);
  
            persistenciaDados.EscritaDadosCadVendas(cadVendas, "Vendas.csv");
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
        }
        public void Met8()
        {
            Console.Clear();
            Console.WriteLine("\t****Lista Vendas****");
            cadVendas.ListaVendas();
            Console.WriteLine("Aperte qualquer tecla para continuar... ");
            Console.ReadKey();
            Console.Clear();
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
        private double LerNumeroDouble(string mensagem)
        {
            double numero;
            string entrada;
            while (true)
            {
                Console.Write(mensagem);
                entrada = Console.ReadLine();
                if (double.TryParse(entrada, out numero))
                    return numero;
                else
                    Console.WriteLine("Entrada inválida. Tente novamente.");
            }
        }
    }
}
