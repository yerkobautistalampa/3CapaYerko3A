using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClassInscripcion
    {
        public int ciEstudiante { get; set; }
        public int ciAdministrativo { get; set; }
        public short codigoCurso { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int ultimoUsuario { get; set; }
    }
}
