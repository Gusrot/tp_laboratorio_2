using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void FinDescargaFinalizada(string html);
    public delegate void PorcentajeDeDescarga(int porcentaje);

    public class Descargador
    {
        public event FinDescargaFinalizada DescargaFinalizada;
        public event PorcentajeDeDescarga PorcentajeDescarga;
        private string html;
        private Uri direccion;

        /// <summary>
        /// Consctructor que inicializa los atributos html y direccion.
        /// </summary>
        /// <param name="direccion">Direccion de la pagina web</param>
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        /// <summary>
        /// Metodo que inicia la descarga desde la direccion antes pasada.
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();

                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Metodo que lanza un evento que actualiza el porcentaje de descarga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.PorcentajeDescarga(e.ProgressPercentage);
        }

        /// <summary>
        /// Metodo que lanza un evento que posee el codigo descargado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.DescargaFinalizada(e.Result);
        }
    }
}
