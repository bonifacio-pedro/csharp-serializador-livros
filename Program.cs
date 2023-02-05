using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Serializador_de_livros
{
    internal class Program
    {
        public static void Escolha(ref string escolha)
        {
            Console.Clear();
            Console.WriteLine("(1) CADASTRAR LIVRO");
            Console.WriteLine("(2) VER LIVROS");
            Console.WriteLine("(3) SALVAR");
            Console.WriteLine("(4) SAIR");

            try
            {
                string escolhaTemp = Console.ReadKey(true).KeyChar.ToString().ToLower();
                escolha = escolhaTemp;
            } catch(Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
                Console.ReadKey();
            }
        }

        private static void Mensagem(string mensagem, bool clear)
        {
            if (clear)
            {
                Console.Clear();
                Console.WriteLine(mensagem);
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(mensagem);
                Console.ReadKey();
            }
        }

        static void Main(string[] args)
        {
            string escolha = "";
            List<Livros> todosLivros = null;
            Livros.EncheLista(ref todosLivros);

            do
            {
                Escolha(ref escolha);

                if(escolha == "1")
                {
                    Livros livro = null;
                    

                    if (Livros.CadastraLivro(ref livro) != null)
                    {
                        todosLivros.Add(livro);
                        Mensagem("LIVRO CADASTRADO COM SUCESSO!", true);
                    }
                }
                else if (escolha == "2")
                {
                    Livros.VerLivros();
                }
                else if (escolha == "3")
                {
                    Console.WriteLine("DESEJA SALVAR SEUS LIVROS? (S/N)");

                    string escolhaTemp = Console.ReadKey(true).KeyChar.ToString().ToLower();

                    if (escolhaTemp == "s")
                    {
                        Livros.CriaXml(todosLivros);
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (escolha == "4")
                {
                    Mensagem("SAINDO....", true);
                    break;
                }
                else
                {
                    Mensagem("FAÇA UMA ESCOLHA VÁLIDA!", true);
                    continue;
                }

            } while (escolha != "4");
        }
    }
}
