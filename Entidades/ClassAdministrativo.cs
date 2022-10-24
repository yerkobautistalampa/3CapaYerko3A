using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClassAdministrativo: ClassPersona
    {
        public int ciPersona { get; set; }
        public string cargo { get; set; }
        public int item { get; set; }
        public string profecion { get; set; }
    }
}
