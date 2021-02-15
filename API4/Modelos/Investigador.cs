using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4
{
    public class Investigador
    {
        public string Dni { get; set; }
        public string NomApels { get; set; }
        public int Facultad { get; set; }
        public Facultad Facul { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
