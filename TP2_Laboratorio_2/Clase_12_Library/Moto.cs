using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Clase_12_Library
{
    using Clase_12_Library_2;

    public class Moto:Vehiculo
    {

        /// <summary>
        /// Constructor que pasa los datos de la moto al constructor base
        /// </summary>
        /// <param name="marca"> marca de la moto </param>
        /// <param name="patente"> patente de la moto </param>
        /// <param name="color"> color de la moto </param>
        public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 2;
            }
            set { }
        }

        /// <summary>
        /// Metodo sobrecargado que devuelve un string con los datos de la moto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
