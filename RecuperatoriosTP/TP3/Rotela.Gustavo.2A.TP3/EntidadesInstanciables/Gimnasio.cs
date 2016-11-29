using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        #region Propiedades

        /// <summary>
        /// Propiedad que devuelve la jornada especifica pedida.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public Jornada this[int jornada]
        {
            get { return this._jornada[jornada]; }
        }

        /// <summary>
        /// Propiedad que devuelve la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }

        }

        /// <summary>
        /// Propiedad que devuelve la lista de instructores.
        /// </summary>
        public List<Instructor> Instructores
        {
            get { return this._instructores; }

        }
        /// <summary>
        /// Propiedad que devuelve la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this._jornada; }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto que instancia las listas de la clase.
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que serializa el gimnasio en un archivo xml.
        /// </summary>
        /// <param name="gim">Gimnasio a serializar.</param>
        /// <returns>Devuelve true si pudo serializar.</returns>
        public static bool Guardar(Gimnasio gim)
        {

            Archivos.Xml<Gimnasio> escritor = new Archivos.Xml<Gimnasio>();

            try
            {              
                escritor.Guardar("Gimnasio.xml", gim);
            }
            catch (Exception exc)
            {
                throw new ArchivosException(exc);
            }
            return true;
        }

        /// <summary>
        /// Metodo que devuelve un string con todos los datos de la jornada.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA:");

            foreach (Jornada jornada in gim._jornada)
            {
                sb.AppendLine(jornada.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga que hace visible al metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga que compara si un alumno ya esta en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="a">Alumno.</param>
        /// <returns>Devuelve true si el alumno ya se encuetra en el gimnasio,</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == a)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga que compara si un alumno no esta en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="a">Alumno.</param>
        /// <returns>Devuelve true si el alumno no se encuetra en el gimnasio,</returns>
        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Compara si un instructor da la clase.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Devuelve true si al menos un instructor esta dando la clase.</returns>
        public static Instructor operator ==(Gimnasio g, EClases clase)
        {
            foreach (Instructor instructor in g._instructores)
            {
                if (instructor == clase)
                    return instructor;
            }

            throw new SinInstructorException();
        }

        /// <summary>
        /// Compara si ningun instructor da la clase
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Devuelve true si ningun instructor esta dando la clase.</returns>
        public static Instructor operator !=(Gimnasio g, EClases clase)
        {
            foreach (Instructor i in g._instructores)
            {
                if (i != clase)
                    return i;
            }
        
            throw new SinInstructorException();
        }

        /// <summary>
        /// Compara si el instructor esta en el gimnasio
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>Devuelve true si el instructor esta en el gimnasio</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            for (int indice = 0; indice < g._instructores.Count; indice++)
            {
                if (g._instructores[indice] == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Compara si el instructor no esta en el gimnasio
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="i">Instructor.</param>
        /// <returns>Devuelve true si el instructor no esta en el gimnasio</returns>
        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega un alumno al gimnasio si este no se encuentra.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="a">Alumno.</param>
        /// <returns>Devuelve el gimnasio con el alumno agregado.</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();
            else
                g._alumnos.Add(a);

            return g;
        }

        /// <summary>
        /// Agrega una nueva jornada al gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Devuelve el gimnasio con la jornada agregada.</returns>
        public static Gimnasio operator +(Gimnasio g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, (g == clase));

            foreach (Alumno item in g._alumnos)
            {
                if (item == clase)
                {
                    jornada += item;
                }
            }

            g._jornada.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agrega un instructor al gimnasio si este no se encuentra.
        /// </summary>
        /// <param name="g">Gimnasio.</param>
        /// <param name="i">instructor.</param>
        /// <returns>Devuelve el gimnasio con el instructor agregado.</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
            {
                g._instructores.Add(i);
            }
            return g;
        }

        #endregion

        public enum EClases
        {
            Natacion,
            Pilates,
            CrossFit,
            Yoga
        }
    }
}
