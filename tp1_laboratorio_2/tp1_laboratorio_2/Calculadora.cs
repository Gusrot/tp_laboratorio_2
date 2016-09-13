using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_laboratorio_2
{
    public class Calculadora
    {
        /// <summary>
        /// realiza la cuenta con los valores pasados
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public double operar(Numero numero1, Numero numero2, string operador)
        {
            switch (validadOperador(operador))
            {
                case "+":
                    return numero1 + numero2;
                case "-":
                    return numero1 - numero2;
                case "*":
                    return numero1 * numero2;
                case "/":
                    if (numero2.getNumero() != 0)
                        return numero1 / numero2;
                    return 0;
            }
            return 0;

        }

        /// <summary>
        /// valida y devuelve el operador
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        public string validadOperador(string operador)
        {
            switch (operador)
            {
                case "+":
                    return "+";
                case "-":
                    return "-";
                case "*":
                    return "*";
                case "/":
                    return "/";
            }
            return "+";
        }
    }
}
