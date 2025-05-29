using System;
using System.IO;

namespace EditorTextos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Editor de Textos" +
                              "\n1 - Criar novo documento" +
                              "\n2 - Abrir documento existente" +
                              "\n0 - Sair");
            Console.Write("\nEscolha uma opção: ");
            short opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1: Editar(); break;
                case 2: Abrir(); break;
                case 0: Console.Clear();
                    Console.WriteLine("Obrigado por usar o Editor de Textos!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    Menu();
                    break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do documento que deseja abrir?" +
                              "\nExemplo: C:\\meusDocumentos\\meuArquivo.txt");
            string path = Console.ReadLine();

            using (var arquivo = new StreamReader(path))
            {
                Console.Clear();
                string texto = arquivo.ReadToEnd();
                Console.WriteLine("Documento aberto com sucesso!" +
                                  "\n------------------------");
                Console.WriteLine("");
                Console.WriteLine(texto);
                Console.WriteLine("");
                Console.WriteLine("------------------------");
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();   
            Menu();   
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Pressione ESC para sair e salvar o documento" +
                              "\nDigite seu texto abaixo");
            Console.WriteLine("------------------------");
            string texto = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);
                if (key.Key == ConsoleKey.Escape)
                    break;
                if (key.Key == ConsoleKey.Enter)
                {
                    texto += Environment.NewLine;
                    Console.WriteLine();
                }
                else
                {
                    texto += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            while (true);

            Salvar(texto);
        }

        static void Salvar(string texto)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho deseja salvar o documento?" +
                              "\nExemplo: C:\\meusDocumentos\\meuArquivo.txt");
            var path = Console.ReadLine();

            using (var arquivo = new StreamWriter(path))
            {
                arquivo.Write(texto);

            }

            Console.Clear();
            Console.WriteLine($"Documento {path} salvo com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            Menu();

        }
    }
}