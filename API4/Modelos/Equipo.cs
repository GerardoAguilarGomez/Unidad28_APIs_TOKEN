using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4
{
    public class Equipo
    {
        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int Facultad { get; set; }

        public Facultad Facul { get; set; }
        public ICollection<Reserva> Reservas { get; set; }
    }
}
