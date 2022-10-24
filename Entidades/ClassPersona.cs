using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClassPersona
    {
        public int ci { get; set; }
        public string nombre  { get; set; }
        public string materno { get; set; }
        public string paterno { get; set; }
        public string direccion { get; set; }
        public int celular { get; set; }
        public string correo { get; set; }
        public string genero { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public Boolean estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int ultimoUsuario { get; set; }
    }
}
