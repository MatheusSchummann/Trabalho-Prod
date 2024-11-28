using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Matheus_Schumann.CadastroClientes
{
    public class CadClientes
    {
        List<Cliente> cliente = new List<Cliente>();
        public int Tamanho()
        {
            return cliente.Count;
        }
        public bool VerificaNovoCodigo(int codigo)
        {
            for (int i = 0; i < cliente.Count; i++)
            {
                if (codigo == cliente[i].Codigo)
                {
                    Console.WriteLine("Codigo já existente");
                    return false;
                }
            }
            return true;
        }
        public bool VerificaCodigoExistente(int codigo)
        {
            for (int i = 0; i < cliente.Count; i++)
            {
                if (codigo == cliente[i].Codigo)
                {
                    return true;
                }
            }
            Console.WriteLine("Código Inexistente");
            return false;
        }
        public int RetornaPosicaoCodigo(int codigo)
        {
            for (int i = 0; i < cliente.Count; i++)
            {
                if (codigo == cliente[i].Codigo)
                {
                    return i;
                }
            }
            Console.WriteLine("Codigo não encontrado");
            return -1;
        }
        public bool Insere(Cliente cliente)
        { 
            this.cliente.Add(cliente);    
            return true;
        }
        public void ListaClientes()
        {
            for (int i = 0; i < cliente.Count; i++)
            {
                Console.WriteLine($"Codigo: {cliente[i].Codigo}, Nome: {cliente[i].Nome}");
                
            }
            Console.WriteLine();
        }
        public Cliente GetCliente(int posicao)
        {
            return this.cliente[posicao];
        }

    }
}
