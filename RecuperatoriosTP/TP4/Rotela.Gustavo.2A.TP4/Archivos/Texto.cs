using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _ruta;

        /// <summary>
        /// Constructor que inicializa el atributo _ruta.
        /// </summary>
        /// <param name="archivo">Constiene la ruta del archivo</param>
        public Texto(string archivo)
        {
            this._ruta = archivo;
        }

        /// <summary>
        /// Metodo que guarda en un txt.
        /// </summary>
        /// <param name="datos">Contiene el historial a guardar.</param>
        /// <returns>Devuelve true si pudo guardar.</returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor;

                escritor = new StreamWriter(this._ruta, true);
                escritor.WriteLine(datos);

                escritor.Close();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo que lee desde un txt.
        /// </summary>
        /// <param name="datos">El historial a leer.</param>
        /// <returns>Devuelve true si pudo leer.</returns>
        public bool leer(out List<string> datos)
        {
            datos = new List<string>();

            try
            {
                using (StreamReader lector = new StreamReader(this._ruta))
                {
                    while (lector.EndOfStream==false)
                    {
                        datos.Add(lector.ReadLine());
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
