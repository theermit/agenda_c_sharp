using System;
using System.Collections.Generic;
using libDAO.Models;
using libDAO.DAOs;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = "";

            while(opcao != "4")
            {
                Console.WriteLine("Gestor de Contatos:\n");
                Console.WriteLine("Opções:");
                Console.WriteLine("1 - Exibir contatos;\n2 - Incluir contato;\n3 - Apagar contato;\n4 - Sair;\n\n");
                Console.WriteLine("Digite a opção:");
                opcao = Console.ReadLine();
                switch(opcao)
                {
                    case "1":
                        Console.WriteLine("Relação de contatos:\n\n");
                        VisualizarContatos();
                        break;
                    case "2":
                        Console.WriteLine("Incluir contato");
                        InserirContato();
                        break;
                    case "3":
                        Console.WriteLine("Excluir contato:");
                        ApagarContato();
                        break;
                    case "4":
                        Console.WriteLine("Até mais!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
        static async Task VisualizarContatos()
        {
            IContatoDAO contatoDAO = new ContatoDAO();
            List<Contato> ListaContato;

            try 
            {
                ListaContato = await contatoDAO.List();
            }
            catch(Exception e)
            {
                Console.WriteLine("Falha na consulta ao banco de dados. {0}", e.Message);
                return;
            }

            if(ListaContato.Count == 0)
            {
                Console.WriteLine("Não há contatos gravados.");
            }
            else 
                foreach(var contato in ListaContato)
                    Console.WriteLine("Id: {0}\t Nome: {1}\t Telefone: {2}", contato.Id, contato.Nome, contato.Telefone);
        }
        static void InserirContato()
        {
            IContatoDAO contatoDAO = new ContatoDAO();
            Contato contato = new Contato();
            Console.WriteLine("Digite o nome do contato:");
            contato.Nome = Console.ReadLine();
            Console.WriteLine("Digite o telefone do contato:");
            contato.Telefone = Console.ReadLine();
            try 
            {
                contatoDAO.Create(contato);
            }
            catch(Exception e)
            {
                Console.WriteLine("Falha na criação do contato. {0}", e.Message);
                return;
            }
        }
        static void ApagarContato()
        {
            IContatoDAO contatoDAO = new ContatoDAO();
            Console.WriteLine("Digite o número do contato a ser excluído:");
            var Id = Int32.Parse(Console.ReadLine());
            try 
            {
                contatoDAO.Destroy(Id);
            }
            catch(Exception e)
            {
                Console.WriteLine("Falha ao apagar contato. {0}", e.Message);
                return;
            }
        }
    }
}
