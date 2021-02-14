using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1
{
    public class Pieza
    {
        public Pieza()
        {
            Suministras = new HashSet<Suministra>();
        }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Suministra> Suministras { get; set; }
    }
}
