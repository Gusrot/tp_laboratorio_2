using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public abstract class Producto
    {
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        #region Propiedades

        /// <summary>
        /// Propiedad abstracta. 
        /// </summary>
        public abstract float CalcularCostoDeProduccion
        {
            get;
        }
        
        /// <summary>
        /// Propiedad que devuelve la marca del producto.
        /// </summary>
        public EMarcaProducto Marca
        {
            get { return this._marca; }
        }

        /// <summary>
        /// Propiedad que devuelve el precio del producto.
        /// </summary>
        public float Precio
        {
            get { return this._precio; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor que carga los atributos del producto.
        /// </summary>
        /// <param name="codigoBarra">Codigo de barra del producto</param>
        /// <param name="marca">Marca del producto</param>
        /// <param name="precio">Precio del producto</param>
        public Producto(int codigoBarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigoBarra;
            this._marca = marca;
            this._precio = precio;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo virtual que devuelve un string
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir()
        {
              return "Parte de una mezcla";
        }     

        /// <summary>
        /// Metodo que devuelve un string con todos los datos del producto
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string MostrarProducto(Producto p)
        {
            return p.ToString();
        }

        #endregion

        #region Sobrecargas de operadores

        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if (prodUno is Producto && prodDos is Producto && prodUno._codigoBarra == prodDos._codigoBarra && prodUno._marca == prodDos._marca)
                return true;
            return false;
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }

        public static bool operator ==(Producto prod, EMarcaProducto marca)
        {
            if (prod.Marca == marca)
                return true;
            return false;
        }

        public static bool operator !=(Producto prod, EMarcaProducto marca)
        {
            return !(prod == marca);
        }

        public static explicit operator int(Producto p)
        {
            return p._codigoBarra;
        }

        public static implicit operator string(Producto p)
        {
            string producto = p.MostrarProducto(p);

            return producto;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        #endregion

        #region Enumeradores

        public enum ETipoProducto
        {
            Galletita,
            Jugo,
            Harina,
            Gaseosa,
            Todos
        }

        public enum EMarcaProducto
        {
            Favorita,
            Pitusas,
            Diversión,
            Naranjú,
            Swift
        }

        #endregion
    } 
}
