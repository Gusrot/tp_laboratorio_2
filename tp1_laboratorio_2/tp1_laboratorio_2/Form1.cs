using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp1_laboratorio_2
{
    public partial class Form1 : Form
    {
        public Numero numero1;
        public Numero numero2;
        public string operador;
        public double calcular;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// carga el valor seleccionado en la combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.operador = comboBox1.Text;
        }

        /// <summary>
        /// carga el valor pasado en la primer caja de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.numero1 = new Numero(this.textBox1.Text);
        }

        /// <summary>
        /// carga el valor ingresado en la segunda caja de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.numero2 = new Numero(this.textBox2.Text);
        }

        /// <summary>
        /// limpia todos los cuadros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CC_Click(object sender, EventArgs e)
        {
            this.comboBox1.Text = string.Empty;
            this.label1.Text = string.Empty;
            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        /// <summary>
        /// calula y da mensaje de error en caso de division por 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Calculadora calculadora = new Calculadora();
            calcular = calculadora.operar(this.numero1, this.numero2, this.operador);

            if (this.operador == "/" && this.numero1.getNumero() == 0 && this.numero2.getNumero() == 0)
                this.label1.Text = "Resultado indefinido";
            else if (this.operador == "/" && this.numero2.getNumero() == 0)
                this.label1.Text = "Error, no se puede dividir por 0";
            else
                this.label1.Text = calcular.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
