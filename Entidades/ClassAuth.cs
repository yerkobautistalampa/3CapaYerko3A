using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClassAuth : ClassPersona
    {
        public int ciPersona { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public byte nivel { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int ultimoUsuario { get; set; }
    }
}
