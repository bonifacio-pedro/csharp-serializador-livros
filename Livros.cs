using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serializador_de_livros
{
    public class Livros
    {
        public string nome;
        public string genero;
        public double nota;
        private static string caminho = @"save.xml";
        public static void CriaXml(List<Livros> listaLivros)
        {
            try
            {
                XmlSerializer xmlEscritor = new XmlSerializer(typeof(List<Livros>));
                
                if (File.Exists(caminho))
                {
                    FileStream fs = File.Open(caminho, FileMode.Open);
                    xmlEscritor.Serialize(fs, listaLivros);
                    fs.Close();
                }
                else
                {
                    FileStream fs = File.Create(caminho);
                    xmlEscritor.Serialize(fs, listaLivros);
                    fs.Close();
                }

                Console.WriteLine("LIVROS SALVOS COM SUCESSO!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
            }
            
            
        }

        public static Livros CadastraLivro(ref Livros livro)
        {
            try
            {
                Console.Clear();
                Console.Write("NOME DO LIVRO: ");
                string nome = Console.ReadLine();
                Console.Write("\r\nGÊNERO DO LIVRO: ");
                string genero = Console.ReadLine();
                Console.Write("\r\nNOTA DO LIVRO (0-10): ");
                double nota = Convert.ToDouble(Console.ReadLine());

                if (nota > 10 || nota < 0)
                {
                    throw new Exception("NOTA INVÁLIDA");
                }

                return livro = new Livros(nome.ToUpper(),genero.ToUpper(),nota);
            }
            catch(Exception e) 
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
                return null;
            }
            
        }

        public static List<Livros> EncheLista(ref List<Livros> listaAPreencher)
        {
            try
            {
                if (File.Exists(caminho))
                {
                    XmlSerializer xmlLeitor = new XmlSerializer(typeof(List<Livros>));
                    FileStream fs = File.Open(caminho, FileMode.Open);
                    List<Livros> listaLivros = (List<Livros>)xmlLeitor.Deserialize(fs);
                    fs.Close();
                    return listaAPreencher = listaLivros;
                }
                else
                {
                    return listaAPreencher = new List<Livros>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TIVEMOS UM ERRO EM CARREGAR O ARQUIVO PARA PREENCHER A LISTA: " + e.Message);
                return null;
            }
            
        }

        public static void VerLivros()
        {
            try
            {
                XmlSerializer xmlLeitor = new XmlSerializer(typeof(List<Livros>));

                if (File.Exists(caminho))
                {
                    FileStream fs = File.Open(caminho, FileMode.Open);
                    List<Livros> listaLivros = (List<Livros>)xmlLeitor.Deserialize(fs);
                    fs.Close();

                    if (listaLivros.Count > 0)
                    {
                        foreach (Livros livro in listaLivros)
                        {
                            Console.Clear();
                            Console.WriteLine("==============================");
                            Console.WriteLine("NOME: " + livro.nome);
                            Console.WriteLine("GÊNERO: " + livro.genero);
                            Console.WriteLine("NOTA: " + livro.nota);
                            Console.WriteLine("==============================");

                            Console.WriteLine(listaLivros.IndexOf(livro) + "-" + (Convert.ToUInt32(listaLivros.Count) - 1));
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        throw new Exception("AINDA NÃO TEMOS NENHUM LIVRO CADASTRADO.");
                    }
                }
                else
                {
                    throw new Exception("AINDA NÃO TEMOS NENHUM ARQUIVO DE LIVROS SALVO.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("EXCEÇÃO: " + e.Message);
                Console.ReadKey();
            }
            
        }
        public Livros(string nome, string genero, double nota)
        {
            this.nome = nome;
            this.genero = genero;
            this.nota = nota;
        }

        public Livros()
        {

        }

    }
}
