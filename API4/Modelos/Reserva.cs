using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API4
{
    public class Reserva
    {
        public string Investigador { get; set; }
        public string Equipo { get; set; }

        public Investigador Inves { get; set; }
        public Equipo Equip { get; set; }
    }
}
