using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #region Constructores


        /// <summary>
        /// Constructor por defecto para poder serializar.
        /// </summary>
        public Instructor()
        {

        }

        /// <summary>
        /// Constructor estatico que inicializa el atributo random.
        /// </summary>
        static Instructor()
        {
            _random = new Random();
        }

        /// <summary>
        /// Constructor que instancia la clase del dia y llama dos veces al metodo randomClases.
        /// </summary>
        /// <param name="id">Identificacion del instructor.</param>
        /// <param name="nombre">Nombre del instructor.</param>
        /// <param name="apellido">Apellido del instructor.</param>
        /// <param name="dni">Documento del instructor.</param>
        /// <param name="nacionalidad">Nacionalidad del instructor.</param>
        public Instructor(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad):base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();

            this._randomClases();
            this._randomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que genera un numero random utilizados para generar las clases del instructor.
        /// </summary>
        private void _randomClases()
        {
            int random = _random.Next(0, 4);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)random);
        }

        /// <summary>
        /// Muestra los datos del instructor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con las clases que da el instructor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASE DEL DIA: ");

            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Compara si el instructor no da la clase.
        /// </summary>
        /// <param name="i">Instructor.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Devuelve true si el instructor no da la clase.</returns>
        public static bool operator !=(Instructor i, Gimnasio.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Compara si el instructor da la clase.
        /// </summary>
        /// <param name="i">Instructor.</param>
        /// <param name="clase">Clase.</param>
        /// <returns>Devuelve true si el instructor da la clase.</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases clase)
        {
            foreach (Gimnasio.EClases Eclase in i._clasesDelDia)
            {
                if (Eclase == clase)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga que hace publico el metodo MostrarDatos.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

    }
}
