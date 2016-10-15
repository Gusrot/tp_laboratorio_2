using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    using Clase_12_Library_2;

    public class Camion:Vehiculo
    {

        /// <summary>
        /// Constructor que pasa los datos recibidos del camion al constructor base
        /// </summary>
        /// <param name="marca"> marca del camion </param>
        /// <param name="patente"> patente del camion </param>
        /// <param name="color"> color del camion </param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 8;
            }
            set { }
        }

        /// <summary>
        /// Metodo sobrecargado que retorna un string con los datos del camion
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
