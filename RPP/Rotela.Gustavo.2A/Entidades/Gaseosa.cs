using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa:Producto
    {
        private float _litros;
        protected static bool DeConsumo;

        #region Propiedades

        /// <summary>
        /// Propiedad que devuelve el coste de produccion de la gaseosa.
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return this.Precio * 0.42f; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que inicializa el atributo DeConsumo en verdadero.
        /// </summary>
        static Gaseosa()
        {
            DeConsumo = true;
        }

        /// <summary>
        /// Constructor que inicializa el atributo litros y pasa el resto al constructor base.
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="litros"></param>
        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros):base(codigoBarra, marca, precio)
        {
            this._litros = litros;
        }

        /// <summary>
        /// Constructor que saca los datos de otro producto y se lo pasa al otro constructor
        /// de esta clase junto con el atributo litros.
        /// </summary>
        /// <param name="p">Otro producto al que se le sacan los datos</param>
        /// <param name="litros">Litros que contiene la gaseosa</param>
        public Gaseosa(Producto p, float litros):this((int)p, p.Precio, p.Marca, litros) { }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que devuelve un string con los datos de la gaseosa
        /// </summary>
        /// <returns></returns>
        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Marca: " + this.Marca);
            sb.AppendLine("Codigo de barras: " + this._codigoBarra);
            sb.AppendLine("Precio: " + this.Precio);
            sb.AppendLine("Litros: " + this._litros);

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        public override string Consumir()
        {
            return "Bebible";
        }

        /// <summary>
        /// Sobrecarga que hace publico los datos de la gaseosa.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGaseosa();
        }

        #endregion
    }
}
