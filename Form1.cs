using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryLopezEcommerce
{
    public partial class frmCompras : Form
    {
        private List<Producto> productosDisponibles = new List<Producto>();
        private Dictionary<string, List<Producto>> productosPorCategoria = new Dictionary<string, List<Producto>>();
        private List<clsElementoCarrito> carrito = new List<clsElementoCarrito>();
        public frmCompras()
        {
            InitializeComponent();
            InicializarProductos();
            // Llenar el combo box de categorías
            foreach (var categoria in productosPorCategoria.Keys)
            {
                cmbCategoria.Items.Add(categoria);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InicializarProductos()
        {
            // Crear y agregar productos a la lista productosDisponibles
            Producto producto1 = new Producto("Camiseta", "Ropa", 15.0);
            productosDisponibles.Add(producto1);

            Producto producto2 = new Producto("Pantalón", "Ropa", 25.0);
            productosDisponibles.Add(producto2);

            Producto producto3 = new Producto("Zapatillas", "Calzado", 50.0);
            productosDisponibles.Add(producto3);

            Producto producto4 = new Producto("Teléfono", "Electrónica", 300.0);
            productosDisponibles.Add(producto4);

            // Agrupar productos por categoría en el diccionario productosPorCategoria
            foreach (var producto in productosDisponibles)
            {
                if (!productosPorCategoria.ContainsKey(producto.Categoria))
                {
                    productosPorCategoria[producto.Categoria] = new List<Producto>();
                }
                productosPorCategoria[producto.Categoria].Add(producto);
            }
        }
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Llenar el combo box de productos según la categoría seleccionada
            cmbProducto.Items.Clear();
            string categoriaSeleccionada = cmbCategoria.SelectedItem.ToString();
            foreach (var producto in productosPorCategoria[categoriaSeleccionada])
            {
                cmbProducto.Items.Add(producto.Nombre);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener el producto seleccionado
            string nombreProducto = cmbProducto.SelectedItem.ToString();
            Producto productoSeleccionado = productosDisponibles.Find(p => p.Nombre == nombreProducto);

            // Obtener la cantidad
            int cantidad = (int)numCant.Value;

            // Agregar el producto al carrito
            carrito.Add(new clsElementoCarrito(productoSeleccionado, cantidad));

            // Actualizar el DataGridView del carrito
            ActualizarCarrito();

            // Calcular y mostrar el total de la compra
            CalcularTotalCompra();
        }
        private void ActualizarCarrito()
        {
            dgvCarrito.Rows.Clear();
            foreach (var elemento in carrito)
            {
                dgvCarrito.Rows.Add(elemento.Producto.Nombre, elemento.Cantidad, elemento.Subtotal);
            }
        }
        private void CalcularTotalCompra()
        {
            double total = 0;
            foreach (var elemento in carrito)
            {
                total += elemento.Subtotal;
            }
            lblTotalPagar.Text = total.ToString("C");
        }

    }
}
