using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2
{
    public class Cientifico
    {
        public Cientifico()
        {
            Asignados = new HashSet<Asignado>();
        }
        public string Dni { get; set; }
        public string NomApels {get;set;}

        public virtual ICollection<Asignado> Asignados { get; set; }
    }
}
