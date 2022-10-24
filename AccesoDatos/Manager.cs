using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.SqlClient; //para trbajar con sqls server
using System.Data;

namespace AccesoDatos
{
    public class Manager
    {
        public Manager() { }

        #region Metodos Privados
        //cadena de conexion a la BD
        private SqlConnection conexion = new SqlConnection(@"Data Source =.; Initial Catalog = CursosDB; Integrated Security = True");
                                                            
        // verificar la ejecucion DDL y DML - Registros - Actualizacion - Eliminacion

        private bool trabajoDDLyDML(string vMensaje)
        {
            try
            {
                SqlCommand sql = new SqlCommand(vMensaje, conexion);
                conexion.Open();
                sql.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch(Exception)
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                return false;
            }
        }

        private object obtineDato(string vMensaje)
        {
            try
            {
                conexion.Open();
                SqlCommand carta = new SqlCommand(vMensaje, conexion);
                object x = new object();
                x = carta.ExecuteScalar();
                conexion.Close();
                return x;
            }
            catch
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                return null;
            }
        }

        private List<object> obtieneLista(string vMensaje)
        {
            try
            {
                conexion.Open();
                SqlCommand carta = new SqlCommand(vMensaje, conexion);
                SqlDataReader resuld = carta.ExecuteReader();

                List<object> lista = new List<object>();

                while(resuld.Read())
                {
                    lista.Add(resuld[0]);
                }
                conexion.Close();
                return lista;
            }
            catch
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                return null;
            }
        }
        
        private DataTable obtineTabla(string vMensaje)
        {
            try
            {
                DataTable tabla = new DataTable();
                SqlDataAdapter carta = new SqlDataAdapter(vMensaje, conexion);
                carta.Fill(tabla);
                return tabla;
            }
            catch 
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
                return null;

            }
        }  

        #endregion

        #region Metodos Publicos
        //int? puede aceptar null
        public int? obtieneCiUsuaruio(string usuario, string password)
        {
            string vConsulta = "select top(1) ci from Persona p, Auth a where p.ci = a.ciPersona and a.usuario like '"+usuario+"'and a.contrasena like '"+password+ "' and a.estado = 1";
            object vResultado = obtineDato(vConsulta);
            if (vResultado == null)
                return null;
            return Convert.ToInt32(vResultado); 
        }

        public string obtieneNombreCompleto(int ci)
        {
            string vConsulta = "select CONCAT(nombres,' ', paterno, ' ',materno) from Persona where ci = "+ci+"";
            string vResultado = obtineDato(vConsulta).ToString();
            if (vResultado == null)
                return null;
            return vResultado;
        }
        public byte obtieneNivel(int ci)
        {
            string vConsulta = "select nivel from Auth where ciPersona ="+ ci;
            object vResultado = obtineDato(vConsulta);
            return Convert.ToByte(vResultado);
        }
        //insertar persona
        public bool insertarPersona(ClassPersona objPersona)
        {
            string vConsulta = "set dateformat 'DMY' INSERT INTO Persona (ci, nombres, paterno, materno, direccion, celular, genero, fechaNacimiento, correo, estado, fechaCreacion, fechaModificacion, ultimoUsuario) VALUES("+objPersona.ci+", '"+objPersona.nombre+"', '"+objPersona.paterno+"', '"+objPersona.materno+"', '"+objPersona.direccion+"', "+objPersona.celular+", '"+objPersona.genero+"', '"+objPersona.fechaNacimiento+"', '"+objPersona.correo+"', 1, GETDATE(), GETDATE(), "+objPersona.ultimoUsuario+") ";
            return trabajoDDLyDML(vConsulta);
        }
        //insertar auth
        public bool insertarAuth(ClassAuth objAuth)
        {
            string vConsulta = "INSERT INTO Auth (ciPersona, usuario, contrasena, nivel, estado, fechaCreacion, fechaModificacion, ultimoUsuario) VALUES ("+objAuth.ciPersona+", '"+objAuth.usuario+"', '"+objAuth.contrasena+"', "+objAuth.nivel+", 1, GETDATE(), GETDATE(), "+objAuth.ultimoUsuario+")";
            return trabajoDDLyDML(vConsulta);
        }
        //insertar docente
        public bool insertarDocente(ClassDocente objDocente)
        {
            string vConsulta = "INSERT INTO Docente (ciPersona, item, profesion) VALUES (" + objDocente.ci + ", " + objDocente.item + ", '" + objDocente.profecion + "')";
            return trabajoDDLyDML(vConsulta);
        }
        //insertar administrativo
        public bool insertarAdministrativo(ClassAdministrativo objAdmi)
        {
            string vConsulta = "INSERT INTO Administrativo  (ciPersona, cargo, item, profesion) VALUES  ("+objAdmi.ciPersona+", '"+objAdmi.cargo+"', "+objAdmi.item+", '"+objAdmi.profecion+"')";
            return trabajoDDLyDML(vConsulta);
        }
        //insertar Estudiante
        public bool insertarEstudiante(ClassEstudiante objEstudiante)
        {
            string vConsulta = "INSERT INTO Estudiante (ciPersona) VALUES ("+objEstudiante.ci+")";
            return trabajoDDLyDML(vConsulta);
        }

        //listar docentes
        public DataTable listarDocentes()
        {
            string  vConsulta = "select ROW_NUMBER()OVER(ORDER BY p.paterno)as Nro, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Docentes, p.ci, p.celular, a.nivel, d.item, upper(d.profesion) as Profecion from Persona p inner join Auth a on p.ci = a.ciPersona inner join Docente d on d.ciPersona = p.ci where p.estado = 1 and a.estado = 1 and a.nivel = 6";
            return obtineTabla(vConsulta);
        }
        //listar docentes segun su ci
        public DataTable listarDocentes(int ci)
        {
            string vConsulta = "select d.ciPersona as 'C.I.', upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres)) as Docentes, p.celular as Celular, d.profesion as Profecion from Docente d inner join Persona p on p.ci = d.ciPersona where d.ciPersona  like '"+ci+"%' and p.estado = 1";
            return obtineTabla(vConsulta);
        }

        //listar administrador
        public DataTable listarAdministradores()
        {
            string vConsulta = "select ROW_NUMBER()OVER(ORDER BY p.paterno)as Nro, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Docentes, p.ci, p.celular, a.nivel, ad.item, upper(ad.profesion) as Profecion from Persona p inner join Auth a on p.ci = a.ciPersona inner join Administrativo ad on ad.ciPersona = p.ci where p.estado = 1 and a.estado = 1 and a.nivel != 6";
            return obtineTabla(vConsulta);
        }
        public DataTable listarAdministradores(string cargo)
        {
            string vConsulta = "select ROW_NUMBER()OVER(ORDER BY p.paterno)as Nro, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Docentes, p.ci, p.celular, a.nivel, ad.item, upper(ad.profesion) as Profecion from Persona p inner join Auth a on p.ci = a.ciPersona inner join Administrativo ad on ad.ciPersona = p.ci where p.estado = 1 and a.estado = 1 and ad.cargo = '"+cargo+ "' and a.nivel != 0; ";
            return obtineTabla(vConsulta);
        }
        //listar estudiantes
        public DataTable listarEstudiantes()
        {
            string vConsulta = "select ROW_NUMBER()OVER(ORDER BY p.paterno)as Nro, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Estudiantes, p.ci, p.celular from Persona p inner join Estudiante e on e.ciPersona = p.ci";
            return obtineTabla(vConsulta);
        }
        //listas estudiante por medio del ci
        public DataTable listarEstudiantes(int ci)
        {
            string vConsulta = "select e.ciPersona, upper(concat(p.paterno,' ', p.materno,' ', p.nombres)) as estudiante from Estudiante e inner join Persona p on e.ciPersona = p.ci where e.ciPersona like '" + ci + "%' and p.estado = 1; ";
            return obtineTabla(vConsulta);
        }
        //insertar Curso
        public bool insertarCurso(ClassCurso objCurso)
        {
            string vConsulta = "set dateformat 'DMY' INSERT INTO Curso(carrera, nombre, modalidad, fechaInicio, turno, horario, duracion, dias, cargaHoraria, costo, ciDocente, estado, fechaCreacion, fechaModificacion, ultimoUsuario) VALUES('"+objCurso.carrera+"', '"+objCurso.nombre+"', '"+objCurso.modalidad+"', '"+objCurso.fechaInicio+"', '"+objCurso.turno+"', '"+objCurso.horario+"', '"+objCurso.duracion+"', '"+objCurso.dias+"', "+objCurso.cargaHoraria+", "+objCurso.costo+", "+objCurso.ciDocente+", 1, GETDATE(), GETDATE(), "+objCurso.ultimoUsuario+"); ";
            return trabajoDDLyDML(vConsulta);
        }
        //listar Curso
        public DataTable listarCurso()
        {
            string vConsulta = "select ROW_NUMBER() OVER(ORDER BY c.fechaInicio asc)as Nro, c.carrera, c.nombre, c.fechaInicio,c.costo, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Docentes from Curso c inner join persona p on p.ci = c.ciDocente inner join Docente d on d.ciPersona = c.ciDocente where p.estado = 1  and c.estado = 1";
            return obtineTabla(vConsulta);
        }
        public DataTable listarCurso(string carrera)
        {
            string vConsulta = "select ROW_NUMBER() OVER(ORDER BY c.fechaInicio asc)as Nro, c.carrera, c.nombre, c.fechaInicio,c.costo, upper(CONCAT(p.paterno,' ', p.materno,' ', p.nombres))as Docentes from Curso c inner join persona p on p.ci = c.ciDocente inner join Docente d on d.ciPersona = c.ciDocente where p.estado = 1 and c.carrera='"+carrera+ "' and c.estado = 1;";
            return obtineTabla(vConsulta);
        }
        //listar cursos inscritos del mes
        public DataTable listarEstudiantesInscritosMes()
        {
            string vConsulta = "select ROW_NUMBER() OVER(ORDER BY i.fecha asc)as Nro, ciEstudiante as 'C.I.',upper(concat(p.paterno,' ', p.materno,' ', p.nombres)) as Estudiante, upper(c.nombre) as 'Curso', i.fecha as 'fecha de inscripcion' from Persona p inner join Inscripcion i on p.ci = i.ciEstudiante inner join Curso c on i.codigoCurso = c.codigoCurso where i.estado = 1 and i.fecha >= DATEADD(day, -30, GETDATE()); ";
            return obtineTabla(vConsulta);
        }
        //listar cursos del ultimo mes
        public DataTable listarCursosMes(string carrera)
        {
            string vConsulta = "select codigoCurso, nombre  from curso  where carrera = '"+ carrera + "' and fechaInicio >= DATEADD(DAY, -30, GETDATE()) ORDER BY nombre ASC;";
            return obtineTabla(vConsulta);
        }
        //listar todos cursos 
        public DataTable listarCursosMes()
        {
            string vConsulta = "select codigoCurso, nombre, fechaInicio from curso where fechaInicio >= DATEADD(DAY, -30, GETDATE()) ORDER BY nombre ASC; ";
            return obtineTabla(vConsulta);
        }
        public bool insertarInscripcion(ClassInscripcion objInscripcion)
        {
                string vConsulta = "set dateformat 'DMY' INSERT INTO Inscripcion(ciEstudiante, ciAdministrativo, codigoCurso, fecha, estado, fechaCreacion, fechaModificacion, ultimoUsuario) VALUES("+objInscripcion.ciEstudiante+", "+objInscripcion.ciAdministrativo+", "+objInscripcion.codigoCurso+", GETDATE(), 1, GETDATE(), GETDATE(),"+objInscripcion.ultimoUsuario+"); ";
                return trabajoDDLyDML(vConsulta);
        }
        #endregion
    }
}
