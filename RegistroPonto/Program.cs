using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPonto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                List<Pessoa> lista = new List<Pessoa>();

                var path = @"C:\Users\Computador\Desktop\RegistroPonto.txt";

                StreamWriter sw = File.CreateText(path);

                sw.Close();

                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Seus reports serão gerados automaticamente na sua área de trabalho!!");
                Console.WriteLine("Para um report ser gerado por completo, é necessario registrar entrada e saida para o colaborador!!");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("- REGISTRO DE PONTOS");
                Console.WriteLine();
                Console.WriteLine("Você deseja sair do programa ou continuar? ");
                Console.Write("Digite (c) para continuar ou qualquer caractere para sair: ");
                char verifica = char.Parse(Console.ReadLine());

                while (verifica == 'c')
                {

                    Registro registro = new Registro();

                    Console.WriteLine();
                    Console.WriteLine("Registre seu ponto agora.");
                    Console.Write("Digite (p) para ponto: ");
                    char escolha = char.Parse(Console.ReadLine());

                    if (escolha == 'p')
                    {
                        Console.WriteLine();
                        Console.Write("Digite seu nome completo: ");
                        string verificaNome = Console.ReadLine();
                        Pessoa pessoa = lista.Find(x => x.Nome == verificaNome);
                        Console.WriteLine();

                        if (pessoa != null)
                        {
                            string stsColab;

                            Console.WriteLine("Colaborador ja cadastrado.");
                            Console.WriteLine();
                            Console.WriteLine("Nome completo do Colaborador: " + pessoa.Nome);
                            Console.WriteLine("Identificador do colaborador: " + pessoa.Id);
                            
                            if (pessoa.ESaida == 'e')
                            {
                                stsColab = "Entrada";
                                Console.WriteLine("Status atual - Entrada ou saida: " + stsColab);
                            }
                            else
                            {
                                stsColab = "Saida";
                                Console.WriteLine("Status atual - Entrada ou saida: " + stsColab);
                            }

                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Novo Registro: ");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine();
                            Guid id = pessoa.Id;

                            Console.Write("Entrada ou saida: (e/s): ");
                            char status = char.Parse(Console.ReadLine());

                            if (status == 's')
                            {
                                if (pessoa.ESaida == 'e')
                                {
                                    Console.Write("Data/Hora de registro do ponto: ");

                                    registro.DataHoraRegistro = DateTimeOffset.Now;
                                    Console.WriteLine(registro.DataHoraRegistro);

                                    if (lista.Exists(x => x.Id == id))
                                        lista.FirstOrDefault(x => x.Id == id).Registros.Add(registro);

                                    Console.WriteLine();
                                    Console.WriteLine("Registro Salvo com Sucesso!");

                                    pessoa.ESaida = status;

                                    pessoa.GravaTxt(pessoa.Nome);
                                }
                                else
                                {
                                    Console.WriteLine("Você não pode registrar duas entradas e saidas no mesmo dia!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Você não pode registrar duas entradas ou duas saidas no mesmo dia!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Seu nome ainda não existe no registro de pontos, por favor, faça o cadastro!");
                            Console.WriteLine();
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Cadastro: ");
                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine();
                            Console.Write("Entrada ou saida: (e/s): ");

                            char status = char.Parse(Console.ReadLine());

                            while (status != 'e')
                            {
                                if (status == 's')
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Você precisa registrar uma entrada!");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Por favor, digite o dado corretamente!");
                                    Console.WriteLine();
                                }
                                Console.Write("Entrada ou saida: (e/s): ");
                                status = char.Parse(Console.ReadLine());
                            }

                            Console.WriteLine();
                            Console.Write("Nome completo do Colaborador: " + verificaNome);
                            Console.WriteLine();

                            Console.Write("Identificador do colaborador: ");
                            Guid id = Guid.NewGuid();
                            Console.WriteLine(id);

                            Console.Write("Data/Hora de registro do ponto: ");

                            registro.DataHoraRegistro = DateTimeOffset.Now;

                            Console.WriteLine(registro.DataHoraRegistro);

                            lista.Add(new Pessoa(id, verificaNome, status));
                            if (lista.Exists(x => x.Id == id))
                                lista.FirstOrDefault(x => x.Id == id).Registros.Add(registro);

                            Console.WriteLine();
                            Console.WriteLine("Colaborador Cadastrado com sucesso!");

                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Você digitou errado, por favor insira o dado de forma correta!");
                    }

                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                    Console.Write("Você deseja sair do programa ou continuar (c/s): ");
                    verifica = char.Parse(Console.ReadLine());

                }

                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Obrigado por testar o programa !!");
                Console.WriteLine("Por : Lucas B. Teixeira");
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro : " + e.Message);
                Console.WriteLine("Por favor, feche o programa e tente novamente!!");
                Console.WriteLine();
            }
        }
    }
}