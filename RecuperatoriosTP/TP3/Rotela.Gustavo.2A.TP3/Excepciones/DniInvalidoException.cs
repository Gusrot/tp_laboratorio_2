using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase = "Dni Invalido";

        /// <summary>
        /// Constructor que recibe un mensaje y una excepcion y se las envia al base.
        /// </summary>
        /// <param name="message">Objeto de tipo String</param>
        /// <param name="e">Objeto de tipo Exception</param>
        public DniInvalidoException(string message, Exception e) : base(mensajeBase + message, e)
        {

        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DniInvalidoException() : 
            base(mensajeBase)
        {

        }

        /// <summary>
        /// Constructor que recibe una exepcion y se la pasa al base junto a un mensaje.
        /// </summary>
        /// <param name="e">Objeto de tipo Exception</param>
        public DniInvalidoException(Exception e) : 
            base(mensajeBase, e)
        {

        }

        /// <summary>
        /// Constructor que recibe un mensaje.
        /// </summary>
        /// <param name="message">Un string que contiene un mensaje</param>
        public DniInvalidoException(string message) : this(message, null)
        {

        }
        
    }
}
