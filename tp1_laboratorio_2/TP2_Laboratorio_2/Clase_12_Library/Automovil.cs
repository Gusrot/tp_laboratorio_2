using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    using Clase_12_Library_2;

    public class Automovil:Vehiculo
    {
        /// <summary>
        /// Constructor que pasa los atributos recibidos al constructor base
        /// </summary>
        /// <param name="marca"> marca del automovil </param>
        /// <param name="patente"> patente del automovil </param>
        /// <param name="color"> color del automovil </param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        public override short CantidadRuedas
        {
            get
            {
                return 4;
            }
            set { }
        }

        /// <summary>
        /// Metodo sobrecargado que retorna un string con los datos del automovil
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
