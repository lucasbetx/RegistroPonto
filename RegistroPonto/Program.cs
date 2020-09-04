using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroPonto.Enumerable;

namespace RegistroPonto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> lista = new List<Pessoa>();


            Console.WriteLine("Registro de pontos");
            Console.WriteLine("Você deseja sair do programa ou continuar: ");
            Console.Write("Digite (c) para continuar ou (s) para sair: ");
            char verifica = char.Parse(Console.ReadLine());

            while (verifica == 'c')
            {
                Console.WriteLine();
                Console.WriteLine("Você deseja registrar o ponto ou gerar reports: ");
                Console.Write("Digite (p) para ponto ou (r) para report : ");
                char escolha = char.Parse(Console.ReadLine());

                if (escolha == 'r')
                {
                    StreamWriter sw = new StreamWriter("C:\\Users\\Computador\\Desktop\\RegistroPonto.txt");

                    List<string> output = new List<string>();

                    foreach (var person in lista)
                    {
                        sw.WriteLine("------------------------------------------------------");

                        sw.WriteLine("Nome: " + person.Nome);
                        sw.WriteLine("Horas trabalhadas: ");
                        sw.WriteLine("Entrada ou Saida: " + person.ESaida);
                        sw.WriteLine("Registro: ");

                        sw.WriteLine("------------------------------------------------------");
                    }


                    sw.Close();
                }

                else if (escolha == 'p')
                {
                    Console.WriteLine();
                    Console.Write("Digite seu nome completo: ");
                    string verificaNome = Console.ReadLine();
                    Pessoa pes = lista.Find(x => x.Nome == verificaNome);
                    Console.WriteLine();

                    if (pes != null)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Seu nome ainda não existe no registro de pontos, faça o cadastro!");
                        Console.WriteLine();
                        Console.WriteLine("Cadastro: ");
                        Console.WriteLine();
                        Console.Write("Entrada ou saida: (e/s): ");
                        char status = char.Parse(Console.ReadLine());
                        EntradaSaida entradaSaida;
                        Enum.TryParse(status.ToString(), true, out entradaSaida);

                        Console.Write("Nome completo do Colaborador: ");
                        string nome = Console.ReadLine();

                        Console.Write("Identificador do colaborador: ");
                        Guid id = Guid.NewGuid();
                        Console.WriteLine(id);


                        Console.Write("Data/Hora de registro do ponto: ");

                        DateTimeOffset data;
                        data = DateTimeOffset.Now;
                        Console.WriteLine(data);

                        lista.Add(new Pessoa(id, nome, entradaSaida));

                        //pessoa.AddRegistro(data);
                    }
                }
                else
                {
                    Console.WriteLine("Você digitou errado, por favor insira o dado correto!");
                }

                Console.WriteLine();
                Console.Write("Você deseja sair do programa ou continuar (c/s): ");
                verifica = char.Parse(Console.ReadLine());

            }
        }
    }
}