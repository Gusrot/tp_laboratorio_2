using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #region Propiedades

        /// <summary>
        /// Propiedad que muestra, escribe y valida el apellido de la persona.
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad que muestra, escribe y valida el nombre de la persona en formato int.
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this._nacionalidad, value); }
        }

        /// <summary>
        /// Propiedad que muestra y escribe la nacionalidad de la persona.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        /// <summary>
        /// Propiedad que muestra, escribe y valida el nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        /// <summary>
        /// Propiedad que muestra, escribe y valida el dni de la persona en formato string.
        /// </summary>
        public string StringToDNI
        {
            get { return this._dni.ToString(); }
            set { this._dni = this.ValidarDni(this._nacionalidad,value); }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto para poder serializar.
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor que inicializa el nombre, apellido y nacionalidad de la persona.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido,ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que inicializa el dni con un entero.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona(entero).</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, int dni , ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que inicializa el dni con un string.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        /// <param name="apellido">Apellido de la persona.</param>
        /// <param name="dni">Dni de la persona(string).</param>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion  

        #region Metodos

        /// <summary>
        /// Metodo que muestra los datos de una persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);          
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que valida el dni(int) con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Dni de la persona.</param>
        /// <returns>Devuelve el dni si se condice con la persona, genera excepcion en caso contrario.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino)
            {
                if(dato <= 0 || dato >= 90000000)
                    throw new NacionalidadInvalidaException();

                return dato;
            }
            else
            {
                if(dato < 90000000)               
                    throw new NacionalidadInvalidaException();

                return dato;              
            }        
        }

        /// <summary>
        /// Metodo que valida el dni(string) con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">Dni de la persona.</param>
        /// <returns>Devuelve el dni si se condice con la persona, genera excepcion en caso contrario.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return this.ValidarDni(nacionalidad, int.Parse(dato));
        }

        /// <summary>
        /// Metodo que valida que el nombre y apellido de la persona sea correcto.
        /// </summary>
        /// <param name="dato">Nombre o apellido de la persona.</param>
        /// <returns>Devuelve el nombre de la persona, genera excepcion en caso contrario.</returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (char.IsDigit(dato[i]))
                {
                    throw new Exception("Nombre invalido");
                }
            }

            return dato;
        }

        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
