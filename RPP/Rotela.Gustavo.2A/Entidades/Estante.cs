using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Entidades
{
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class Estante
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        #region Propiedades

        /// <summary>
        /// Propiedad de solo lectura que devuelve el valor total del estante.
        /// </summary>
        public float ValorEstanteTotal
        {
            get { return this.GetValorEstante(); }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor privado que inicializa la lista.
        /// </summary>
        private Estante()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Constructor que inicializa el atributo capacidad.
        /// </summary>
        /// <param name="capacidad">Define de que tamaño es el estante</param>
        public Estante(sbyte capacidad):this()
        {
            this._capacidad = capacidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve la lista de productos.
        /// </summary>
        /// <returns></returns>
        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        /// <summary>
        /// Metodo que devuelve el valor total del estante.
        /// </summary>
        /// <returns></returns>
        private float GetValorEstante()
        {
            return this.GetValorEstante(Producto.ETipoProducto.Todos);
        }

        /// <summary>
        /// Metodo que devuelve el valor de un determinado tipo de Producto del estante.
        /// </summary>
        /// <param name="tipo">el tipo de producto al que se le quiere calcular el valor</param>
        /// <returns></returns>
        public float GetValorEstante(Producto.ETipoProducto tipo)
        {
            float aux=0;

            foreach (Producto item in this.GetProductos())
            {
                switch(tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (item is Galletita)
                            aux += item.Precio;
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (item is Gaseosa)
                            aux += item.Precio;
                        break;
                    case Producto.ETipoProducto.Harina:
                        if (item is Harina)
                            aux += item.Precio;
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (item is Jugo)
                            aux += item.Precio;
                        break;
                    case Producto.ETipoProducto.Todos:
                            aux += item.Precio;
                        break;
                }
            }
            return aux;
        }
        
        /// <summary>
        /// Retorna un string con los datos del estante.
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAPACIDAD: " + e._capacidad.ToString());
            foreach (Producto item in e._productos)
            {
                sb.AppendLine((string)item);
            }

            return sb.ToString();
        }

        #endregion

        #region Sobrecarga de operadores

        public static bool operator ==(Estante e, Producto prod)
        {
            return e._productos.Contains(prod);
        }

        public static bool operator !=(Estante e, Producto prod)
        { return !(e == prod); }

        public static bool operator +(Estante e, Producto prod)
        {
            if (e != prod && e._productos.Count < e._capacidad)
            {
                e._productos.Add(prod);
                return true;
            }

            return false;
        }

        public static Estante operator -(Estante e, Producto prod)
        {
            if (e == prod)
                e.GetProductos().Remove(prod);
            return e;
        }

        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            for (int i = 0; i < e.GetProductos().Count; i++)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (e.GetProductos()[i] is Galletita)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (e.GetProductos()[i] is Gaseosa)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (e.GetProductos()[i] is Jugo)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Todos:
                        e.GetProductos().Clear();
                        break;
                    default:
                        break;
                }
            }
            return e;
        }

        #endregion

        #region Puntos extras

        /// <summary>
        /// Metodo estatico que genera un archivo txt que almacena los datos del estante en el tiempo.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="info">String indicando que estante es</param>
        public static void GuardarEstante(Estante e,string info)
        {
            DateTime date = DateTime.Now;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(info + " (" + date.ToString() + ")");
            sb.AppendLine("\r\nValor del estante: " + e.ValorEstanteTotal);
            sb.AppendLine("\r\nCapacidad: " + e._capacidad.ToString());
            sb.AppendLine("\nCantidad de productos: " + e._productos.Count);
            sb.AppendLine("\r\n" + MostrarEstante(e));
            
            if (System.IO.File.Exists(@"C:\Users\gustavo\Desktop\Prueba\Estantes.txt"))
                System.IO.File.AppendAllText(@"C:\Users\gustavo\Desktop\Prueba\Estantes.txt", sb.ToString());
            else
                System.IO.File.WriteAllText(@"C:\Users\gustavo\Desktop\Prueba\Estantes.txt", sb.ToString());
        }

        /// <summary>
        /// Genera un archivo xml que almacena los datos del estante.
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <param name="info1"></param>
        /// <param name="info2"></param>
        public static void SerializarEstante(Estante e1,Estante e2, string info1, string info2)
        {
            System.Xml.Serialization.XmlSerializer xml = new System.Xml.Serialization.XmlSerializer(info1.GetType());
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\gustavo\Desktop\Prueba\Serializacion.xml");

            DateTime date = DateTime.Now;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(info1 + " (" + date.ToString() + ")");
            sb.AppendLine("\r\nValor del estante: " + e1.ValorEstanteTotal);
            sb.AppendLine("\r\nCapacidad: " + e1._capacidad.ToString());
            sb.AppendLine("\nCantidad de productos: " + e1._productos.Count);
            sb.AppendLine("\r\n" + MostrarEstante(e1));
            sb.AppendLine(info2 + " (" + date.ToString() + ")");
            sb.AppendLine("\r\nValor del estante: " + e2.ValorEstanteTotal);
            sb.AppendLine("\r\nCapacidad: " + e2._capacidad.ToString());
            sb.AppendLine("\nCantidad de productos: " + e2._productos.Count);
            sb.AppendLine("\r\n" + MostrarEstante(e2));

            xml.Serialize(file, sb.ToString());
            file.Close();
        }

        /// <summary>
        /// Lee el archivo xml y lo escribe en consola.
        /// </summary>
        public static void DeserializarEstante()
        {
            XmlTextReader lector = new XmlTextReader(@"C:\Users\gustavo\Desktop\Prueba\Serializacion.xml");
            while (lector.Read())
            {
                switch (lector.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<" + lector.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(lector.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + lector.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            Console.ReadLine();
        }

        #endregion
    }
}
