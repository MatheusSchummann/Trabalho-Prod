using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Matheus_Schumann.CadastroClientes;
using Trabalho_Matheus_Schumann.Estoque;
using Trabalho_Matheus_Schumann.Venda;

namespace Trabalho_Matheus_Schumann
{
    public class PersistenciaDados
    {

        public PersistenciaDados()
        {
        }
        public void EscritaDadosCadProdutos(CadProdutos cadastro, string arquivo)
        {
            StreamWriter sw = null;
            Digital digital = null;
            Duravel duravel = null;
            Perecivel perecivel = null;

            string linha;

            try
            {
                sw = new StreamWriter(arquivo);
                for (int i = 0; i < cadastro.Tamanho(); i++)
                {
                    if (cadastro.GetProduto(i) is Digital digitale)
                    {
                        digital = (Digital)cadastro.GetProduto(i);
                        double tamanho = digital.Tamanho + 0.1;
                        linha = digital.Codigo + ";" + digital.Descricao + ";" + digital.Fabricante + ";" + tamanho + ";" + digital.Formato + ";" + digital.Link;
                        sw.WriteLine(linha);
                    }
                    else if (cadastro.GetProduto(i) is Perecivel perecivele)
                    {
                        perecivel = (Perecivel)cadastro.GetProduto(i);
                        linha = perecivel.Codigo + ";" + perecivel.Descricao + ";" + perecivel.Fabricante + ";" + perecivel.Organico + ";" + perecivel.Ingredientes + ";" + perecivel.DataValidadePerecivel.Dia + ";" + perecivel.DataValidadePerecivel.Mes + ";" + perecivel.DataValidadePerecivel.Ano;
                        sw.WriteLine(linha);
                    }
                    else if (cadastro.GetProduto(i) is Duravel duravele)
                    {
                        duravel = (Duravel)cadastro.GetProduto(i);
                        linha = duravel.Codigo + ";" + duravel.Descricao + ";" + duravel.Fabricante + ";" + duravel.Garantia + ";" + duravel.Material + ";" + duravel.Manutencao;
                        sw.WriteLine(linha);
                    }
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                sw.Close();
            }
        }
        public void EscritaDadosCadClientes(CadClientes cadastro, string arquivo)
        {
            StreamWriter sw = null;
            Cliente cliente = null;
            string linha;
            try
            {
                sw = new StreamWriter(arquivo);
                for (int i = 0; i < cadastro.Tamanho(); i++)
                {

                    cliente =cadastro.GetCliente(i);
                    linha = cliente.Codigo + ";" + cliente.Nome + ";" + cliente.FoneRes + ";" + cliente.FoneCelular + ";" + cliente.Nascimento.Dia + ";" + cliente.Nascimento.Mes + ";" + cliente.Nascimento.Ano + ";" +
                    cliente.Endereco.Rua + ";" + cliente.Endereco.Numero + ";" + cliente.Endereco.Complemento + ";" + cliente.Endereco.Bairro + ";" + cliente.Endereco.Cep + ";" + cliente.Endereco.Cidade + ";" + cliente.Endereco.Uf;
                    sw.WriteLine(linha);
              
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                sw.Close();
            }
        }

        public void EscritaDadosCadEstoque(CadEstoque cadastro, string arquivo)
        {
            StreamWriter sw = null;
            ItemEstoque estoque = null;
            string linha;
            try
            {
                sw = new StreamWriter(arquivo);
                for (int i = 0; i < cadastro.Tamanho(); i++)
                {
                    if (cadastro.GetEstoque(i).ProdutoEstoque is Perecivel perecivel)
                    {
                        estoque = cadastro.GetEstoque(i);
                        linha = estoque.QuantidadeProdutoEstoque + ";" + estoque.ValorProdutoEstoque + ";" + estoque.ProdutoEstoque.Codigo + ";" + estoque.ProdutoEstoque.Descricao + ";" + estoque.ProdutoEstoque.Fabricante; ;
                        sw.WriteLine(linha);
                    }
                    else if (cadastro.GetEstoque(i).ProdutoEstoque is Digital digital)
                    {
                        estoque = cadastro.GetEstoque(i);
                        linha = estoque.QuantidadeProdutoEstoque + ";" + estoque.ValorProdutoEstoque + ";" + estoque.ProdutoEstoque.Codigo + ";" + estoque.ProdutoEstoque.Descricao + ";" + estoque.ProdutoEstoque.Fabricante;
                        sw.WriteLine(linha);

                    }
                    else if (cadastro.GetEstoque(i).ProdutoEstoque is Duravel duravel)
                    {
                        estoque = cadastro.GetEstoque(i);
                        linha = estoque.QuantidadeProdutoEstoque + ";" + estoque.ValorProdutoEstoque + ";" + estoque.ProdutoEstoque.Codigo + ";" + estoque.ProdutoEstoque.Descricao + ";" + estoque.ProdutoEstoque.Fabricante;
                        sw.WriteLine(linha);
                    }
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                sw.Close();
            }
        }

        public void EscritaDadosCadVendas(CadVendas cadastro, string arquivo)
        {
            StreamWriter sw = null;
            string linha;
            try
            {
                sw = new StreamWriter(arquivo);
                for (int i = 0; i < cadastro.Tamanho(); i++)
                {
                    if (cadastro.GetVenda(i).ItemVenda.ProdutoVenda.ProdutoEstoque is Digital digital)
                    {
                        Vendas venda = cadastro.GetVenda(i);
                        linha = venda.ValorTotal + ";" + venda.DataVenda.Dia + ";" + venda.DataVenda.Mes + ";" + venda.DataVenda.Ano + ";" +
                                venda.Cliente.Codigo + ";" + venda.Cliente.Nome + ";" + venda.Cliente.FoneRes + ";" +
                                venda.Cliente.FoneCelular + ";" + venda.Cliente.Endereco.Rua + ";" + venda.Cliente.Endereco.Numero + ";" +
                                venda.Cliente.Endereco.Complemento + ";" + venda.Cliente.Endereco.Bairro + ";" +
                                venda.Cliente.Endereco.Cep + ";" + venda.Cliente.Endereco.Cidade + ";" + venda.Cliente.Endereco.Uf + ";" +
                                venda.Cliente.Nascimento.Dia + ";" + venda.Cliente.Nascimento.Mes + ";" + venda.Cliente.Nascimento.Ano + ";" +
                                venda.ItemVenda.QuantidadeProdutoVenda + ";" + venda.ItemVenda.ValorProdutoVenda + ";" + venda.ItemVenda.ProdutoVenda.QuantidadeProdutoEstoque + ";" +
                                venda.ItemVenda.ProdutoVenda.ValorProdutoEstoque + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Codigo + ";" +
                                venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Descricao + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Fabricante;
  
                        sw.WriteLine(linha);
                    }
                    else if (cadastro.GetVenda(i).ItemVenda.ProdutoVenda.ProdutoEstoque is Perecivel perecivel)
                    {
                        Vendas venda = cadastro.GetVenda(i);
                        linha = venda.ValorTotal + ";" + venda.DataVenda.Dia + ";" + venda.DataVenda.Mes + ";" + venda.DataVenda.Ano + ";" +
                                venda.Cliente.Codigo + ";" + venda.Cliente.Nome + ";" + venda.Cliente.FoneRes + ";" +
                                venda.Cliente.FoneCelular + ";" + venda.Cliente.Endereco.Rua + ";" + venda.Cliente.Endereco.Numero + ";" +
                                venda.Cliente.Endereco.Complemento + ";" + venda.Cliente.Endereco.Bairro + ";" +
                                venda.Cliente.Endereco.Cep + ";" + venda.Cliente.Endereco.Cidade + ";" + venda.Cliente.Endereco.Uf + ";" +
                                venda.Cliente.Nascimento.Dia + ";" + venda.Cliente.Nascimento.Mes + ";" + venda.Cliente.Nascimento.Ano + ";" +
                                venda.ItemVenda.QuantidadeProdutoVenda + ";" + venda.ItemVenda.ValorProdutoVenda + ";" + venda.ItemVenda.ProdutoVenda.QuantidadeProdutoEstoque + ";" +
                                venda.ItemVenda.ProdutoVenda.ValorProdutoEstoque + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Codigo + ";" +
                                venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Descricao + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Fabricante;

                        sw.WriteLine(linha);

                    }
                    else if (cadastro.GetVenda(i).ItemVenda.ProdutoVenda.ProdutoEstoque is Perecivel duravel)
                    {
                        Vendas venda = cadastro.GetVenda(i);
                        linha = venda.ValorTotal + ";" + venda.DataVenda.Dia + ";" + venda.DataVenda.Mes + ";" + venda.DataVenda.Ano + ";" +
                                venda.Cliente.Codigo + ";" + venda.Cliente.Nome + ";" + venda.Cliente.FoneRes + ";" +
                                venda.Cliente.FoneCelular + ";" + venda.Cliente.Endereco.Rua + ";" + venda.Cliente.Endereco.Numero + ";" +
                                venda.Cliente.Endereco.Complemento + ";" + venda.Cliente.Endereco.Bairro + ";" +
                                venda.Cliente.Endereco.Cep + ";" + venda.Cliente.Endereco.Cidade + ";" + venda.Cliente.Endereco.Uf + ";" +
                                venda.Cliente.Nascimento.Dia + ";" + venda.Cliente.Nascimento.Mes + ";" + venda.Cliente.Nascimento.Ano + ";" +
                                venda.ItemVenda.QuantidadeProdutoVenda + ";" + venda.ItemVenda.ValorProdutoVenda + ";" + venda.ItemVenda.ProdutoVenda.QuantidadeProdutoEstoque + ";" +
                                venda.ItemVenda.ProdutoVenda.ValorProdutoEstoque + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Codigo + ";" +
                                venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Descricao + ";" + venda.ItemVenda.ProdutoVenda.ProdutoEstoque.Fabricante;

                        sw.WriteLine(linha);
                    }

                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao escrever vendas digitais: {ex.Message}");
                sw?.Close();
            }
        }


        public bool ExisteArquivo(string arquivo)
        {
            return File.Exists(arquivo);
        }
        public void LeituraDadosCadProdutos(string arquivo, CadProdutos cadastro)
        {
            try
            {
                if (File.Exists(arquivo))
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(';');

                            if (dados.Length < 6)
                            {
                                Console.WriteLine("Erro: Dados insuficientes na linha.");
                                continue;
                            }
                            int codigo = int.Parse(dados[0]);
                            string descricao = dados[1];
                            string fabricante = dados[2];

                            Produto produto;
           

                            if (dados.Length == 6) 
                            {
                                if (dados[3].Contains(".") || dados[3].Contains(",")) 
                                {
                                    double tamanho0 = double.Parse(dados[3]);
                                    string formato = dados[4];
                                    string link = dados[5];
                                    double tamanho = tamanho0 - 0.1;
                                    produto = new Digital(codigo, descricao, fabricante, tamanho, formato, link);
                                    cadastro.Insere(produto);
                                }
                                else 
                                {
                                    int garantia = int.Parse(dados[3]);
                                    string material = dados[4];
                                    bool manutencao = bool.Parse(dados[5]);

                                    produto = new Duravel(codigo, descricao, fabricante, garantia, material, manutencao);
                                    cadastro.Insere(produto);
                                }
                            }
                            else if (dados.Length == 8) 
                            {
                                bool organico = bool.Parse(dados[3]);
                                string ingredientes = dados[4];
                                int dia = int.Parse(dados[5]);
                                int mes = int.Parse(dados[6]);
                                int ano = int.Parse(dados[7]);

                                Data validade = new Data(dia, mes, ano);

                                produto = new Perecivel(codigo, descricao, fabricante, organico, ingredientes, validade);
                                cadastro.Insere(produto);
                            }
                            else
                            {
                                Console.WriteLine("Erro: Tipo de produto não identificado.");
                                continue;
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler dados dos produtos: {ex.Message}");
            }
        }

        public void LeituraDadosCadClientes(string arquivo, CadClientes cadastro)
        {
            if (ExisteArquivo(arquivo))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(';');
                            if (dados.Length == 14)
                            {

                                int codigo = int.Parse(dados[0]);
                                string nome = dados[1];
                                string foneRes = dados[2];
                                string foneCelular = dados[3];

                                int dia = int.Parse(dados[4]);
                                int mes = int.Parse(dados[5]);
                                int ano = int.Parse(dados[6]);

                                Data nascimento = new Data(dia, mes, ano);

                                string rua = dados[7];
                                int numero = int.Parse(dados[8]);
                                string complemento = dados[9];
                                string bairro = dados[10];
                                string cep = dados[11];
                                string cidade = dados[12];
                                string uf = dados[13];

                                Endereco endereco = new Endereco(rua, numero, complemento, bairro, cep, cidade, uf);

                                Cliente cliente = new Cliente(codigo, nome, foneRes, foneCelular, endereco, nascimento);

                                cadastro.Insere(cliente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao ler dados de clientes: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado.");
            }
        }


        public void LeituraDadosCadEstoque(string arquivo, CadEstoque cadastro, CadProdutos cadProdutos)
        {
            
            try
            {
                if (File.Exists(arquivo))
                {
                    using (StreamReader sr = new StreamReader(arquivo))
                    {
                        string linha;
                        while ((linha = sr.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(';');

                            if (dados.Length == 5)
                            {

                                int quantidade = int.Parse(dados[0]);
                                double valor = double.Parse(dados[1]);
                                int codigo = int.Parse(dados[2]);
                                string descricao = dados[3];
                                string fabricante = dados[4];
                                int posicao = cadProdutos.RetornaPosicaoCodigo(codigo);
                                Produto produto = cadProdutos.GetProduto(posicao);
                                ItemEstoque itemEstoque = new ItemEstoque(produto, quantidade, valor);
                                cadastro.Insere(itemEstoque);
                            }

                        }
                    }
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler dados de estoque: {ex.Message}");
            }
        }
        public void LeituraDadosCadVendas(string arquivo, CadVendas cadastro, CadProdutos cadProdutos, CadEstoque cadEstoque)
        {
            StreamReader sr = null;
            string linha;
            try
            {
                sr = new StreamReader(arquivo);
                while ((linha = sr.ReadLine()) != null)
                {
                    string[] dados = linha.Split(';');
                    if (dados.Length == 25) 
                    {
              
                        double ValorTotal = double.Parse(dados[0]);
                        int diaVenda = int.Parse(dados[1]);
                        int mesVenda = int.Parse(dados[2]);
                        int anoVenda = int.Parse(dados[3]);
                        int codigoCliente = int.Parse(dados[4]);
                        string nome = dados[5];
                        string foneRes = dados[6];
                        string foneCelular = dados[7];
                        string rua = dados[8];
                        int numero = int.Parse(dados[9]);
                        string complemento = dados[10];
                        string bairro = dados[11];
                        string cep = dados[12];
                        string cidade = dados[13];
                        string uf = dados[14];
                        int diaNascimento = int.Parse(dados[15]);
                        int mesNascimento = int.Parse(dados[16]);
                        int anoNascimento = int.Parse(dados[17]);
                        int itemsQuantidadeVenda = int.Parse(dados[18]);
                        double itemsValorVenda = double.Parse(dados[19]);
                        int quantidadeProdutoEstoque = int.Parse(dados[20]);
                        double valorProdutoEstoque = double.Parse(dados[21]);
                        int codigoProduto = int.Parse(dados[22]);
                        string descricaoProduto = dados[23];
                        string fabricanteProduto = dados[24];

                        Data dataVenda = new Data(diaVenda, mesVenda, anoVenda);
                        Endereco endereco = new Endereco(rua, numero, complemento, bairro, cep, cidade, uf);
                        Data dataNascimento = new Data(diaNascimento, mesNascimento, anoNascimento);
                        Cliente cliente = new Cliente(codigoCliente, nome, foneRes, foneCelular, endereco, dataNascimento);
                        int posicao = cadEstoque.RetornaPosicaoCodigo(codigoProduto);


                        Produto produto = cadProdutos.GetProduto(posicao);
                        ItemEstoque itemEstoque = new ItemEstoque(produto, quantidadeProdutoEstoque, valorProdutoEstoque);
                        ItemVenda itemVenda = new ItemVenda(itemEstoque, itemsQuantidadeVenda, itemsValorVenda);

                        Vendas venda = new Vendas(dataVenda, cliente, itemVenda, ValorTotal);

                        cadastro.Insere(venda);

                    }
                    
                }   

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar arquivo: {ex.Message}");
            }
            finally
            {
                sr?.Close();
            }
        }
    }
}