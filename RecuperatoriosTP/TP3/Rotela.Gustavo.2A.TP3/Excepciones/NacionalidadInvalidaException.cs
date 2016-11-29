using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NacionalidadInvalidaException() : 
            this("La nacionalidad no se condice con el numero de DNI")
        {

        }

        /// <summary>
        /// Constructor que recibe un mensaje y se lo envia al base.
        /// </summary>
        /// <param name="message">Mensaje de tipo string.</param>
        public NacionalidadInvalidaException(string message) : 
            base(message)
        {

        }
    
    }
}
