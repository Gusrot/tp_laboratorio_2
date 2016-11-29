using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo Guardar implementado de la interfaz IArchivo que serializa un objeto del tipo T en un archivo xml.
        /// </summary>
        /// <param name="archivo">String que contiene la ruta a donde se guardara el archivo.</param>
        /// <param name="datos">Objeto de tipo T, que indica el objeto que se va a serializar en xml.</param>
        /// <returns>Devuelve true si pudo serializar, genera una exception en caso contrario.</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializado = new XmlSerializer(typeof(T));
                    serializado.Serialize(escritor, datos);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
        /// <summary>
        /// Metodo Leer implementado de la intefaz IArchivo que lee desde un archivo xml.
        /// </summary>
        /// <param name="archivo">String con la ruta del archivo xml.</param>
        /// <param name="datos">Objeto de tipo T, que indica donde el objeto se va a deserializar.</param>
        /// <returns>Devuelve true si pudo deserializar, genera una excepcion en caso contrario.</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader lector = new XmlTextReader(archivo))
                {
                    XmlSerializer d = new XmlSerializer(typeof(T));
                    datos = (T)d.Deserialize(lector);
                    return true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
