using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina:Producto
    {
        private ETipoHarina _tipo;
        protected static bool DeConsumo;

        #region Propiedades

        /// <summary>
        /// Propiedad que devuelve el costo de produccion de la harina.
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get { return this.Precio * 0.6f; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que inicializa el atributo DeConsumo en verdadero.
        /// </summary>
        static Harina()
        {
            DeConsumo = true;
        }

        /// <summary>
        /// Constructor que inicializa el tipo de harina y pasa el resto al constructor base.
        /// </summary>
        /// <param name="codigo">Codigo de barra de la harina</param>
        /// <param name="precio">Precio de la harina</param>
        /// <param name="marca">Marca de la harina</param>
        /// <param name="tipo">Tipo de harina</param>
        public Harina(int codigo, float precio, EMarcaProducto marca, ETipoHarina tipo):base(codigo, marca, precio)
        {
            this._tipo = tipo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que devuelve todos los datos de la harina
        /// </summary>
        /// <returns></returns>
        private string MostrarHarina()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + this.Marca);
            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoBarra);
            sb.AppendLine("PRECIO: " + this._precio);
            sb.AppendLine("TIPO: " + this._tipo);

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga que hace publico los datos de la harina.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarHarina();
        }

        #endregion

        #region Enumeradores

        public enum ETipoHarina
        {
            CuatroCeros,
            Integral
        }

        #endregion
    }


}
