using System;
using System.Collections.Generic;
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

        public TimeSpan HorasTrabalhadas { get; set; }

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

        public void CalculaTempo(DateTimeOffset data, DateTimeOffset teste)
        {
            data.ToOffset(new TimeSpan());
            teste.ToOffset(new TimeSpan());
            HorasTrabalhadas = data - teste;
        }

    }
}
