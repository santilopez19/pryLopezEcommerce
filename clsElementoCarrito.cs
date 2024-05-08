using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryLopezEcommerce
{
    internal class clsElementoCarrito
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public double Subtotal => Producto.Precio * Cantidad;

        public clsElementoCarrito(string producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }
    }
}
