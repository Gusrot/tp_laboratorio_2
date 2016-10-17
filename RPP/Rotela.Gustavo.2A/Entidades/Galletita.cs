using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita:Producto
    {
        protected float _peso;
        protected static bool DeConsumo;

        #region Propiedades

        /// <summary>
        /// Propiedad que calcula el coste de fabricacion del producto.
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get { return this.Precio * 0.33f; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que inicializa el atributo DeConsumo en falso.
        /// </summary>
        static Galletita()
        {
            DeConsumo = false;
        }

        /// <summary>
        /// Constructor que inicializa el atributo peso y pasa el resto al constructor base.
        /// </summary>
        /// <param name="codigoBarra">Codigo de barra de la galletita</param>
        /// <param name="precio">Precio de la galletita</param>
        /// <param name="marca">Marca de la galletita</param>
        /// <param name="peso">Peso de la galletita</param>
        public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso):base(codigoBarra, marca, precio)
        {
            this._peso = peso;
        }

        #endregion

        #region Metodos     

        /// <summary>
        /// Devuelve un string con los datos de la galletita
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        private string MostrarGalletita(Galletita g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + g.Marca);
            sb.AppendLine("CODIGO DE BARRAS: " + g._codigoBarra);
            sb.AppendLine("PRECIO: " + g.Precio);
            sb.AppendLine("PESO: " + g._peso);

            return sb.ToString();
        }

        #endregion

        #region Sobrecarga

        public override string Consumir()
        {
            return "Comestible";
        }

        /// <summary>
        /// Sobrecarga que hace publico los datos de la galletita.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGalletita(this);
        }

        #endregion
    }
}
