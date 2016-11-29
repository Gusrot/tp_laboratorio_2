using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        /// <summary>
        /// Constructor que inicializa el formulario.
        /// </summary>
        public frmWebBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que carga el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        /// <summary>
        /// Metodo que muestra el progreso de descarga.
        /// </summary>
        /// <param name="progreso">Int que contiene el progreso de descarga</param>
        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }

        /// <summary>
        /// Metodo que indica que se termino de descargar.
        /// </summary>
        /// <param name="html">String que contiene el codigo html de la pagina.</param>
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        /// <summary>
        /// Funcion que comienza a descargar la pagina pasada por el textBox cuando le damos click al boton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                Thread hilo;
                Uri web;
                Descargador descargador;

                if (!(Uri.TryCreate(this.txtUrl.Text, UriKind.Absolute, out web)))
                {
                    txtUrl.Text = "http://" + txtUrl.Text;
                    web = new Uri(txtUrl.Text);
                }

                descargador = new Descargador(web);

                descargador.PorcentajeDescarga += this.ProgresoDescarga;
                descargador.DescargaFinalizada += this.FinDescarga;

                hilo = new Thread(new ThreadStart(descargador.IniciarDescarga));
                hilo.Start();
            }
            catch (Exception ex)
            {
                this.rtxtHtmlCode.Text = ex.Message;
            }
            finally
            {
                this.archivos.guardar(this.txtUrl.Text);
            }
        }

        /// <summary>
        /// Metodo que muestra el historial de las paginas visitadas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistorial historial = new frmHistorial();
            historial.ShowDialog();
        }
    }
}
