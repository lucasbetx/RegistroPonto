using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPonto
{
    class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<Registro> Registros { get; set; } = new List<Registro>();
        public char ESaida { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(Guid id, string nome, char eSaida)
        {
            Id = id;
            Nome = nome;
            ESaida = eSaida;
            Registros = new List<Registro>();
        }

        public void GravaTxt(string nome)
        {
            var path = @"C:\Users\Computador\Desktop\RegistroPonto.txt";

            var dateFormat = "yyyy-MM-dd";

            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine("-----------------------------------------------------------------");

                streamWriter.WriteLine("Nome: " + nome);

                var myList = new List<DateTimeOffset>();

                foreach (Registro registro in Registros)
                {
                    myList.Add(registro.DataHoraRegistro);
                }

                var firstItem = myList.ElementAt(0);
                var secondItem = myList.ElementAt(1);

                streamWriter.WriteLine("Data de Registro - Entrada: " + firstItem.ToString(dateFormat));
                streamWriter.WriteLine("Data de Registro - Saida: " + firstItem.ToString(dateFormat));

                TimeSpan horasTrabalhadas = secondItem - firstItem;

                streamWriter.WriteLine("Horas Trabalhadas: " + horasTrabalhadas.ToString("hh\\:mm\\:ss")) ;

                streamWriter.WriteLine("-----------------------------------------------------------------");

                streamWriter.WriteLine();
            }
        }
    }
}
