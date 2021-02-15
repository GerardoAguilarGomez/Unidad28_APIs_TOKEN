using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4
{
    public class Facultad
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public ICollection<Equipo> Equipos {get;set;}
        public ICollection<Investigador> Investigadores { get; set; }
    }
}
