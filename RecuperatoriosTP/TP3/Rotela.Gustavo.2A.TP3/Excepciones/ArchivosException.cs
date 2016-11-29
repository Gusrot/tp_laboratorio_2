using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <param name="innerException">Tipo de excepcion</param>
        public ArchivosException(Exception e) : 
            base("No se pudo guardar el archivo", e.InnerException)
        {

        }
    }
}
