using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API3
{
    public class Maquina
    {
        public Maquina()
        {
            Ventas = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public int Piso { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
