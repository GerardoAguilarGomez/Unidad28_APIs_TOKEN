using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2
{
    public class Asignado
    {
        public string Cientifico { get; set; }
        public string Proyecto { get; set; }

        public virtual Cientifico Cienti { get; set; }
        public virtual Poryecto Proyec { get; set; }
    }
}
