using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2
{
    public class Poryecto
    {
        public Poryecto()
        {
            Asignados = new HashSet<Asignado>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }
        public virtual ICollection<Asignado> Asignados { get; set; }
    }
}
