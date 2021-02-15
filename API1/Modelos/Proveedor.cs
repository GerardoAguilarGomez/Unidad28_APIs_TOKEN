using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1
{
    public class Proveedor
    {
        public Proveedor()
        {
            Suministras = new HashSet<Suministra>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministras { get; set; }

    }
}
