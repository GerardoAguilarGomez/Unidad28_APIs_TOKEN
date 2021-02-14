using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API3
{
    public class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public virtual Cajero Caje { get; set; }
        public virtual Maquina Maqui { get; set; }
        public virtual Producto Produc { get; set; }

    }
}
