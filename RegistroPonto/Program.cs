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
                Pessoa pess = new Pessoa();
                Registro registro = new Registro();
                List<Registro> regis = new List<Registro>();


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

                        foreach (var person in lista.OrderBy(s => s.Nome))
                        {
                            sw.WriteLine("------------------------------------------------------");

                            var dateFormat = "yyyy-MM-dd";

                            sw.WriteLine("Nome: " + person.Nome);

                            sw.WriteLine("Data Registro Diario: " + person.Registros);

                            sw.WriteLine("Horas trabalhadas: " + person.HorasTrabalhadas);

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
                            Console.WriteLine("Nome completo do Colaborador: " + pes.Nome);
                            Console.WriteLine("Id: " + pes.Id);
                            Console.WriteLine("Entrada e saida: " + pes.ESaida);
                            Console.WriteLine("Ultimo Registro: " + registro.DataHoraRegistro);

                            Console.WriteLine("--------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("Novo Registro: ");
                            Console.WriteLine();
                            Guid id = pes.Id;

                            Console.Write("Entrada ou saida: (e/s): ");
                            char status = char.Parse(Console.ReadLine());

                            if (status == 's')
                            {
                                if (pes.ESaida == 'e')
                                {
                                    Console.Write("Data/Hora de registro do ponto: ");

                                    registro.DataHoraRegistro = DateTimeOffset.Now;
                                    Console.WriteLine(registro.DataHoraRegistro);
                                    if (lista.Exists(x => x.Id == id))
                                        lista.FirstOrDefault(x => x.Id == id).Registros.Add(registro);
                                    pes.ESaida = status;
                                }
                                else
                                {
                                    Console.WriteLine("Você não pode registrar duas entradas e saidas no mesmo dia!");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Você não pode registrar duas entradas e saidas no mesmo dia!");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Seu nome ainda não existe no registro de pontos, faça o cadastro!");
                            Console.WriteLine();
                            Console.WriteLine("Cadastro: ");
                            Console.WriteLine();
                            Console.Write("Entrada ou saida: (e/s): ");



                            char status = char.Parse(Console.ReadLine());

                            while (status != 'e')
                            {
                                Console.WriteLine("Você precisa registrar uma entrada!");
                                Console.Write("Entrada ou saida: (e/s): ");
                                status = char.Parse(Console.ReadLine());
                            }

                            Console.Write("Nome completo do Colaborador: ");
                            string nome = Console.ReadLine();

                            Console.Write("Identificador do colaborador: ");
                            Guid id = Guid.NewGuid();
                            Console.WriteLine(id);


                            Console.Write("Data/Hora de registro do ponto: ");

                            DateTimeOffset data;
                            data = DateTimeOffset.Now;
                            Console.WriteLine(data);
                            registro.DataHoraRegistro = DateTimeOffset.Now;
                            lista.Add(new Pessoa(id, nome, status));
                            if (lista.Exists(x => x.Id == id))
                                lista.FirstOrDefault(x => x.Id == id).Registros.Add(registro);

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
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Ocorreu um erro : " + e.Message);
                Console.WriteLine();
            }

        }
    }
}