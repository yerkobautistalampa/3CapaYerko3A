using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

using AccesoDatos;
using Entidades;
using System.Data;

namespace LogicaNegocios
{
    public class Services
    {
        public Services() { }

        #region METODOS Y ESTRUCTURAS  PRIBADAS
        private Dictionary<string, byte> dicCargo = new Dictionary<string, byte>
        {
            {"Sistemas", 0 },
            {"Rector", 1 },
            {"Dir. Academico", 2 },
            {"Dir. Administrativo", 3 },
            {"Secretaria (0)", 4 },
            {"Auxiliar", 5 },
            {"Docente", 6 },
        };
        #endregion

        public int login(string usu, string pas)
        {
            if (usu != "" && pas != "")
            {
                Manager objManager = new Manager();
                //para poder usar los metodos publicos del manager de acceso de datos
                pas = encriptarSha256(pas);
                int? resultado = objManager.obtieneCiUsuaruio(usu, pas);
                if (resultado == null)
                    throw new Exception("Usuario NO registrado");
                else
                    return Convert.ToInt32(resultado);
            }
            else
                throw new Exception("Usuario o Contraseña no validos!!!");
        }
        public string NombreCompleto(int ci)
        { Manager objManager = new Manager();
            return objManager.obtieneNombreCompleto(ci);
        }
        public string obtieneCargo(int ci)
        {
            Manager objManager = new Manager();
            byte nivel = objManager.obtieneNivel(ci);

            foreach (string key in dicCargo.Keys)
                if (dicCargo[key] == nivel)
                    return key.ToString();
            return null;
        }
        public List<string> ListaCargos()
        {
            List<string> lista = new List<string>();
            foreach (string key in dicCargo.Keys)
                lista.Add(key.ToString());
            lista.Reverse();
            return lista;

        }
        //agregar nuevo docente
        public bool agregardocente(ClassDocente objDocente)
        {
            //desglosar al objeto persona
            ClassPersona p = new ClassPersona();
            p.ci = objDocente.ci;
            p.nombre = objDocente.nombre;
            p.paterno = objDocente.paterno;
            p.materno = objDocente.materno;
            p.direccion = objDocente.direccion;
            p.celular = objDocente.celular;
            p.correo = objDocente.correo;
            p.genero = objDocente.genero;
            p.fechaNacimiento = objDocente.fechaNacimiento;
            p.ultimoUsuario = objDocente.ultimoUsuario;

            //desglosando para el objeto auth
            ClassAuth a = new ClassAuth();
            a.ciPersona = objDocente.ci;
            a.usuario = generarUsuario(p);
            a.contrasena = encriptarSha256(p.ci.ToString());
            a.nivel = 6;
            a.ultimoUsuario = objDocente.ultimoUsuario;

            Manager objManager = new Manager();
            if (objManager.insertarPersona(p))
                if (objManager.insertarAuth(a))
                    if (objManager.insertarDocente(objDocente))
                        return true;
                    else throw new Exception("ERROR al insertar docente!!!");
                else throw new Exception("ERROR al insertar auth!!!");
            else throw new Exception("Docente ya registrado!!!");
        }

        //para encriptar
        private static string encriptarSha256(string x)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] s = null;
            StringBuilder sb = new StringBuilder();
            s = sha256.ComputeHash(encoding.GetBytes(x));
            for (int i = 0; i < s.Length; i++)
                sb.AppendFormat("{0:x2}", s[i]);
            return sb.ToString();
        }

        private string generarUsuario(ClassPersona objPersona)
        {
            string nombre = objPersona.nombre;
            var datos = (from c in nombre.Split(' ') select c.Substring(0, 1));
            nombre = "";
            foreach (string s in datos)
                nombre += s;
            string Apaterno = objPersona.paterno, Amaterno = objPersona.materno, ap = "";
            if (Apaterno != "")
                ap += Apaterno[0];
            if (Amaterno != "")
                ap += Amaterno[0];
            string usufecha = objPersona.fechaNacimiento.ToString("ddMMyyyy");
            return (ap + nombre).ToUpper() + "-" + usufecha[0] + usufecha[1] + usufecha[2] + usufecha[3] + usufecha[6] + usufecha[7];
        }

        private string generarUsuario2(ClassPersona objPersona)
        {
            string nombreUsuario;
            if (objPersona.paterno == "")
                nombreUsuario = objPersona.nombre.Substring(0, 1) + objPersona.materno.Substring(0, 1) + "-" + objPersona.fechaNacimiento.ToString().Substring(0, 2) + objPersona.fechaNacimiento.ToString().Substring(3, 2) + objPersona.fechaNacimiento.ToString().Substring(8, 2);
            else if (objPersona.materno == "")
                nombreUsuario = objPersona.nombre.Substring(0, 1) + objPersona.paterno.Substring(0, 1) + "-" + objPersona.fechaNacimiento.ToString().Substring(0, 2) + objPersona.fechaNacimiento.ToString().Substring(3, 2) + objPersona.fechaNacimiento.ToString().Substring(8, 2);
            else
                nombreUsuario = objPersona.nombre.Substring(0, 1) + objPersona.paterno.Substring(0, 1) + objPersona.materno.Substring(0, 1) + "-" + objPersona.fechaNacimiento.ToString().Substring(0, 2) + objPersona.fechaNacimiento.ToString().Substring(3, 2) + objPersona.fechaNacimiento.ToString().Substring(8, 2);
            return nombreUsuario.ToUpper();
        }

        public bool agregarEstudiante(ClassEstudiante objEstudiante)
        {
            //desglosar al objeto persona
            ClassPersona p = new ClassPersona();
            p.ci = objEstudiante.ci;
            p.nombre = objEstudiante.nombre;
            p.paterno = objEstudiante.paterno;
            p.materno = objEstudiante.materno;
            p.direccion = objEstudiante.direccion;
            p.celular = objEstudiante.celular;
            p.correo = objEstudiante.correo;
            p.genero = objEstudiante.genero;
            p.fechaNacimiento = objEstudiante.fechaNacimiento;
            p.ultimoUsuario = objEstudiante.ultimoUsuario;

            Manager objManager = new Manager();
            if (objManager.insertarPersona(p))
                if (objManager.insertarEstudiante(objEstudiante))
                    return true;
                else throw new Exception("ERROR al insertar estudiante!!!");
            else throw new Exception("estudiante ya registrado!!!");
        }

        public DataTable mostarDocentes()
        {
            Manager objManager = new Manager();
            return objManager.listarDocentes();
        }
        public DataTable mostarAdministradores()
        {
            Manager objManager = new Manager();
            return objManager.listarAdministradores();
        }
        public DataTable mostarAdministradores(string cargo)
        {
            Manager objManager = new Manager();
            return objManager.listarAdministradores(cargo);
        }
        public DataTable mostarEstudiantes()
        {
            Manager objManager = new Manager();
            return objManager.listarEstudiantes();
        }
        //mostrar docente segun ci
        public DataTable mostrarDocentes(int ci)
        {
            Manager objManager = new Manager();
            return objManager.listarDocentes(ci);
        }
        //agrgar nuevo administrador 
        public bool agregarAdministrativo(ClassAdministrativo objAdmi)
        {
            //desglosar al objeto persona
            ClassPersona p = new ClassPersona();
            p.ci = objAdmi.ci;
            p.nombre = objAdmi.nombre;
            p.paterno = objAdmi.paterno;
            p.materno = objAdmi.materno;
            p.direccion = objAdmi.direccion;
            p.celular = objAdmi.celular;
            p.correo = objAdmi.correo;
            p.genero = objAdmi.genero;
            p.fechaNacimiento = objAdmi.fechaNacimiento;
            p.ultimoUsuario = objAdmi.ultimoUsuario;

            //desglosando para el objeto auth
            ClassAuth a = new ClassAuth();
            a.ciPersona = objAdmi.ci;
            a.usuario = generarUsuario(p);
            a.contrasena = encriptarSha256(p.ci.ToString());
            string cargo = objAdmi.cargo;

            a.nivel = dicCargo[cargo];
            a.ultimoUsuario = objAdmi.ultimoUsuario;

            Manager objManager = new Manager();
            if (objManager.insertarPersona(p))
                if (objManager.insertarAuth(a))
                    if (objManager.insertarAdministrativo(objAdmi))
                        return true;
                    else throw new Exception("ERROR al insertar administrativo!!!");
                else throw new Exception("ERROR al insertar auth!!!");
            else throw new Exception("administrativo ya registrado!!!");
        }
        //agregar nuevo curso
        public bool agregarCurso(ClassCurso objCurso)
        {
            if (!objCurso.carrera.Equals("--seleccionar--"))
                if (objCurso.nombre.Length >= 2)
                    if (!string.IsNullOrEmpty(objCurso.dias))
                        if (objCurso.cargaHoraria > 0)
                        {
                            Manager objManager = new Manager();
                            if (objManager.insertarCurso(objCurso))
                                return true;
                            else
                                throw new Exception("Problemas al registrar en la BD.");
                        }
                        else throw new Exception("La carga horaria deve ser mayor a 0.");
                    else throw new Exception("Selecciones al menos un dia de clases.");
                else throw new Exception("Ingrese un nombre de curso valido.");
            else throw new Exception("Seleccione una carrera");
        }
        public DataTable mostarCursos()
        {
            Manager objManager = new Manager();
            return objManager.listarCurso();
        }
        public DataTable mostarCursos(string carrera)
        {
            Manager objManager = new Manager();
            return objManager.listarCurso(carrera);
        }
        //mostrar estudiantes segun ci
        public DataTable mostarEstudiantes(int ci)
        {
            Manager objManager = new Manager();
            return objManager.listarEstudiantes(ci);
        }
        //mostrar estudiantes del mes
        public DataTable mostrarEstudiantesInscritosMes()
        {
            Manager objManager = new Manager();
            return objManager.listarEstudiantesInscritosMes();
        }
        //mostrar cursos del mes
        public DataTable mostrarCursosMes(string carrera)
        {
            Manager objManager = new Manager();
            if (carrera.Equals("todos"))
                return objManager.listarCursosMes();
            else
                return objManager.listarCursosMes(carrera);
        }
        //agregar nueva inscripcion
        public bool agregarInscripcion(ClassInscripcion objInscripcion)
        {
            try
            {
                Manager objManager = new Manager();
                if (objManager.insertarInscripcion(objInscripcion))
                    return true;
                else
                    throw new Exception("Problemas al registrar en la BD.");
            }
            catch
            {
                throw new Exception("ingrese todos los datos necesarios.");
            }
        }
    }
}

/*
if (!objInscripcion.ciEstudiante.Equals(""))
                if (!objInscripcion.ciAdministrativo.Equals(""))
                    {
                        Manager objManager = new Manager();
                        if (objManager.insertarInscripcion(objInscripcion))
                            return true;
                        else
                            throw new Exception("Problemas al registrar en la BD.");
                    }
                else throw new Exception("Seleccione un curso");
            else throw new Exception("Seleccione una un estudiante");
*/
