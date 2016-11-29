using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {
        private int _identificador;

        #region Constructores

        /// <summary>
        /// Constructor por defecto para serializar.
        /// </summary>
        public PersonaGimnasio()
        {

        }

        /// <summary>
        /// Constructor que inicializa la identificacion de la persona.
        /// </summary>
        /// <param name="id">Identificacion de la persona.</param>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Documento de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public PersonaGimnasio(int id, string nombre, string apellido, string dni, Persona.ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo virtual que muestra los datos de la persona.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador.ToString());

            return sb.ToString();
        }

        /// <summary>
        /// Metodo abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga que compara si dos personas son iguales.
        /// </summary>
        /// <param name="pg1">Persona numero 1</param>
        /// <param name="pg2">Persona numero 2</param>
        /// <returns>Devuelve true si las dos persona son iguales</returns>
        public static bool operator ==(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if(pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador))
            {
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga que compara si dos personas son distintas.
        /// </summary>
        /// <param name="pg1">Persona numero 1</param>
        /// <param name="pg2">Persona numero 2</param>
        /// <returns>Devuelve true si las dos persona son distintas</returns>
        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// Sobrecarga que verifica si el objeto es igual al tipo de clase.
        /// </summary>
        /// <param name="obj">Objeto a comparar con el objeto actual.</param>
        /// <returns>Devuelve true si son iguales.</returns>
        public override bool Equals(object obj)
        {
            return (obj is PersonaGimnasio);
        }     

        #endregion
    }
}
