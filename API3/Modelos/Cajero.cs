using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API3
{
    public class Cajero
    {

        public Cajero()
        {
            Ventas = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
