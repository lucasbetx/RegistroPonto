using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistroPonto.Enumerable;

namespace RegistroPonto
{
    class Pessoa
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }

        public List<Registro> Registros { get; set; } = new List<Registro>();

        public EntradaSaida ESaida { get; set; }

        public Pessoa()
        {

        }


        public Pessoa(Guid id, string nome, EntradaSaida eSaida)
        {
            Id = id;
            Nome = nome;
            ESaida = eSaida;
            Registros = new List<Registro>();
        }

        public Pessoa(EntradaSaida eSaida)
        {
            ESaida = eSaida;
            Registros = new List<Registro>();
        }

        public void AddRegistro(Registro registro)
        {
            Registros.Add(registro);
        }

        public void RemoveRegistro(Registro registro)
        {
            Registros.Remove(registro);
        }

    }
}
