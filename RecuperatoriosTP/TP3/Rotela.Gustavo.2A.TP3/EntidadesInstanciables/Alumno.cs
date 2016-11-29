using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #region Constructores

        /// <summary>
        /// Constructor que instancia la clase que toma el alumno.
        /// </summary>
        /// <param name="id">Identificacion del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">Numero de documento del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">La clase que toma el alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que instancia el estado de cuenta del alumno.
        /// </summary>
        /// <param name="id">Identificacion del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">Numero de documento del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">La clase que toma el alumno.</param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma, EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Constructor por defecto para serializar.
        /// </summary>
        public Alumno()
        {

        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del alumno.
        /// </summary>
        /// <returns>Devuelve un string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");
            sb.AppendLine(this._estadoCuenta.ToString());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna un string con la clase que toma el alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._claseQueToma;
        }

        /// <summary>
        /// Hace publico al metodo ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga que indica si el alumno toma la clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            return (!(a != clase) && a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Sobrecarga si el alumno no toma la clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueToma == clase)
                return false;
            return true;
        }

        #endregion

        public enum EEstadoCuenta
        {
            Deudor,
            MesPrueba,
            AlDia
        }

    }
}
