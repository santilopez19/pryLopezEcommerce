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
        /*
         * en c# tengo q hacer un ecommerce 
         * donde tengo un combo box de categoria 
         * que se llama cmbCategoria y otro de productos que se llama 
         * cmbProductos un numeric que se llama numCant para la cantidad de
         * productos y un list que se llama lstDescripcion para la descripcion, abajo
         * tengo un boton  de agregar al carrito, que se llama btnAgregar. a lado 
         * tengo un data grid view que se llama dgvCarrito que es el carrito
         * donde tengo que ver los productos agregados, abajo tengo un 
         * lbl para mostrar el total del carrito  que se llama lblTotalCompra. 
         * Lo necesito hacer con clases, listas  y diccionarios.

         */
    }
}
