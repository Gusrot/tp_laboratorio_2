using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<String>
    {
        /// <summary>
        /// Metodo que guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="archivo">String que indica donde guardar.</param>
        /// <param name="datos">String que contiene lo que se va a guardar.</param>
        /// <returns>Devuelve true si se pudo guardar, lanza una excepcion en caso contrario.</returns>
        public bool Guardar(string archivo, string datos)
        {          
            try
            {
                using (StreamWriter escritor = new StreamWriter(archivo, true))
                {
                    escritor.WriteLine(datos.ToString());
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Metodo que lee un archivo de texto.
        /// </summary>
        /// <param name="archivo">String con la ruta de donde se va a leer.</param>
        /// <param name="datos">String que indica donde se va a guardar lo leido.</param>
        /// <returns>Devuelve true si se pudo leer, lanza una excepcion en caso contrario.</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader lector = new StreamReader(archivo))
                {
                    datos = lector.ReadToEnd();
                    return true;
                }
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
            }
        }
    }
}
