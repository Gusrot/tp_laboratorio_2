using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    public class Jornada
    {
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
        private List<Alumno> _alumnos;

        #region Propiedades 

        /// <summary>
        /// Propiedad que devuelve la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
        }

        /// <summary>
        /// Propiedad que devuelve la clase y la asigna.
        /// </summary>
        public Gimnasio.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; }
        }

        /// <summary>
        /// Propiedad que devuelve el instructor y lo asigna.
        /// </summary>
        public Instructor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto que instancia la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inicializa los atributos clases e instructor.
        /// </summary>
        /// <param name="clase">Clase</param>
        /// <param name="instructor">Instructor</param>
        public Jornada(Gimnasio.EClases clase, Instructor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion
       
        #region Metodos

        /// <summary>
        /// Metodo estatico que guarda los datos de una jornada en un archivo txt.
        /// </summary>
        /// <param name="jornada">Jornada</param>
        /// <returns>Devuelve true si pudo guardar en el archivo, lanza excepcion en caso contrario</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();

            try
            {
                texto.Guardar("Jornada.txt", jornada.ToString());
            }
            catch (Exception Exc)
            {
                throw new Excepciones.ArchivosException(Exc);
            }

            return true;
        }


        /// <summary>
        /// Metodo estatico que lee un archivo txt y lo imprime por pantalla
        /// </summary>
        /// <param name="datos">Objeto de tipo String</param>
        /// <returns>Devuelve true si pudo leer el archivo, lanza una excepcion en caso contrario</returns>
        public static bool Leer(out String datos)
        {
            Texto texto = new Texto();

            try
            {
                texto.Leer("Jornada.txt", out datos);
                
            }
            catch (Exception exc)
            {
                datos = "";
                throw new Excepciones.ArchivosException(exc);
            }

            return true;
        }

        #endregion

        #region Sobrecarga

        /// <summary>
        /// Sobrecarga que agrega un alumno a una jornada si este no se encuentra.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve la jornada con el alumno agregado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        /// <summary>
        /// Sobrecarga que compara si el alumno se encuentra en la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Devuelve true si el alumno se encuentra en la jornada.</returns>
        public static Boolean operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j._alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga que compara si el alumno no se encuentra en la jornada.
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns>Devuelve true si el alumno no se encuentra en la jornada</returns>
        public static Boolean operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga del toString.
        /// </summary>
        /// <returns>Devuelve un string con todos los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this._clase + " POR ");
            sb.AppendLine(this._instructor.ToString());
            sb.AppendLine("ALUMNOS: ");

            foreach (Alumno alumno in this._alumnos)
            {
                sb.Append(alumno.ToString());
            }

            sb.AppendLine("<------------------------------------------>");

            return sb.ToString();
        }

        #endregion
    }
}
