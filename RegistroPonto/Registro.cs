using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroPonto
{
    class Registro
    {
        public DateTimeOffset DataHoraRegistro { get; set; }

        public Registro()
        {

        }

        public Registro(DateTimeOffset dataHoraRegistro)
        {
            DataHoraRegistro = dataHoraRegistro;
        }
    }
}
