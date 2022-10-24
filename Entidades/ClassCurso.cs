using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClassCurso
    {
        public string carrera { get; set; }
        public string nombre { get; set; }
        public string modalidad { get; set; }
        public DateTime fechaInicio { get; set; }
        public string turno { get; set; }
        public string horario { get; set; }
        public string duracion { get; set; }
        public string dias { get; set; }
        public short cargaHoraria { get; set; }
        public double costo { get; set; }
        public int ciDocente { get; set; }
        public bool estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int ultimoUsuario { get; set; }

    }
}
