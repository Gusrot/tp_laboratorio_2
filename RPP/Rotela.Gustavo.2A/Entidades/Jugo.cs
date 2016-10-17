using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo:Producto
    {
        protected ESaborJugo _sabor;
        protected static bool DeConsumo;

        #region Propiedades

        /// <summary>
        /// Propiedad que devuelve el costo de produccion del jugo
        /// </summary>
        public override float CalcularCostoDeProducto
        {
            get { return this.Precio * 0.4f; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que inicializa el atributo DeConsumo en verdadero.
        /// </summary>
        static Jugo()
        {
            DeConsumo = true;
        }

        /// <summary>
        /// Constructor que inicializa el atributo sabor y el resto lo pasa al constructor base.
        /// </summary>
        /// <param name="codigoBarra">Codigo de barra del jugo</param>
        /// <param name="precio">Precio del jugo</param>
        /// <param name="marca">Marca del jugo</param>
        /// <param name="sabor">Sabor del jugo</param>
        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor):base(codigoBarra, marca, precio)
        {
            this._sabor = sabor;
        }

        #endregion

        #region Metodos       

        /// <summary>
        /// Metodo que devuelve un string con todos los datos del jugo.
        /// </summary>
        /// <returns></returns>
        public string MostrarJugo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MARCA: " + this.Marca);
            sb.AppendLine("CODIGO DE BARRAS: " + this._codigoBarra);
            sb.AppendLine("PRECIO: " + this.Precio);
            sb.AppendLine("SABOR: " + this._sabor);

            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga que hace publico los datos del jugo.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarJugo();
        }

        public override string Consumir()
        {
            return "Bebible";
        }

        #endregion

        #region Enumeradores

        public enum ESaborJugo
        {
            Pasable,
            Asqueroso,
            Rico
        }

        #endregion
    }
}
