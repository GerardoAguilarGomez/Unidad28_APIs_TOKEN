using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API1.Controllers;

namespace API1
{
    public class Suministra
    {
        public int Codigo_pieza { get; set; }
        public string Id_proveedor { get; set; }
        public int Precio { get; set; }

        public virtual Proveedor Provee { get; set; }
        public virtual Pieza Pie { get; set; }
    }
}
