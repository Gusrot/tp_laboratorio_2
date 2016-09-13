using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp1_laboratorio_2
{
    public class Numero
    {
        private double _numero;

        /// <summary>
        /// inicializa en 0
        /// </summary>
        public Numero() : this(0) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this._numero = numero;
        }

        /// <summary>
        /// llama a la funcion set pasando como parametro un string
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        /// <summary>
        /// devuelve el valor numero
        /// </summary>
        /// <returns></returns>
        public double getNumero()
        {
            return this._numero;
        }

        /// <summary>
        /// llama a la funcion validar y carga el valor al atributo
        /// </summary>
        /// <param name="numero"></param>
        private void setNumero(string numero)
        {
            this._numero = validarNumero(numero);
        }

        /// <summary>
        /// parsea a entero el string pasado, y si no se puede, devuelve 0
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns></returns>
        private double validarNumero(string numeroString)
        {
            double numero;

            if (double.TryParse(numeroString, out numero))
                return numero;

            return 0;
        }

        public static double operator +(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1._numero + numero2._numero;
            return resultado;
        }

        public static double operator -(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1._numero - numero2._numero;
            return resultado;
        }

        public static double operator *(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1._numero * numero2._numero;
            return resultado;
        }

        public static double operator /(Numero numero1, Numero numero2)
        {
            double resultado;
            resultado = numero1._numero / numero2._numero;
            return resultado;
        }
    }
}
