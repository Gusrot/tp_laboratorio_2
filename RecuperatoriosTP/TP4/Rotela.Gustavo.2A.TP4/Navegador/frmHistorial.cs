using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        /// <summary>
        /// Constructor que inicializa el formulario.
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo que agrega al historial las paginas visitadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> historial;

            try
            {
                archivos.leer(out historial);
                this.lstHistorial.DataSource = historial;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
