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
        private List<clsProducto> listaProductos = new List<clsProducto>();
        private Dictionary<clsProducto, int> carrito = new Dictionary<clsProducto, int>();
        private double totalCompra = 0.0;
        private List<clsCategoria> categorias = new List<clsCategoria>();

        public frmCompras()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosDePrueba();
            ConfigurarDataGridViewCarrito();
            InicializarCategorias();
            ActualizarComboBoxCategorias();
            ActualizarComboBoxProductos();
        }

        private void InicializarCategorias()
        {
            // Definir categorías y sus productos asociados
            clsCategoria categoria1 = new clsCategoria("Categoria 1");
            categoria1.Productos.Add(new clsProducto("Producto 1", 10.0, "Categoria 1", "Este es un producto increíble que te sorprenderá con su calidad y versatilidad."));
            categoria1.Productos.Add(new clsProducto("Producto 2", 20.0, "Categoria 2", "Descubre el poder de este producto innovador que transformará tu vida cotidiana."));

            clsCategoria categoria2 = new clsCategoria("Categoria 2");
            categoria2.Productos.Add(new clsProducto("Producto 3", 30.0, "Categoria 1", "Convierte cada momento en una experiencia inolvidable con este producto único en su clase."));
            categoria2.Productos.Add(new clsProducto("Producto 4", 40.0, "Categoria 2", "Descripción del Producto 4"));

            // Agregar categorías a la lista de categorías
            categorias.Add(categoria1);
            categorias.Add(categoria2);
        }

        private void ActualizarComboBoxCategorias()
        {
            cmbCategoria.DataSource = null;
            cmbCategoria.DataSource = categorias;
            cmbCategoria.DisplayMember = "Nombre";
        }

        private void ConfigurarDataGridViewCarrito()
        {
            dgvCarrito.Columns.Add("Nombre", "Nombre"); // Agregar columna para el nombre del producto
            dgvCarrito.Columns.Add("Cantidad", "Cantidad"); // Agregar columna para la cantidad
            dgvCarrito.Columns.Add("Subtotal", "Subtotal"); // Agregar columna para el subtotal
        }

        private void CargarDatosDePrueba()
        {
            listaProductos.Add(new clsProducto("Producto 1", 10.0, "Categoria 1", "Este es un producto increíble que te sorprenderá con su calidad y versatilidad."));
            listaProductos.Add(new clsProducto("Producto 2", 20.0, "Categoria 2", "Descubre el poder de este producto innovador que transformará tu vida cotidiana."));
            listaProductos.Add(new clsProducto("Producto 3", 30.0, "Categoria 1", "Convierte cada momento en una experiencia inolvidable con este producto único en su clase."));
        }

        private void ActualizarComboBoxProductos()
        {
            cmbProducto.DataSource = null;
            cmbProducto.DataSource = listaProductos;
            cmbProducto.DisplayMember = "Nombre";
        }

        private void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            clsProducto productoSeleccionado = cmbProducto.SelectedItem as clsProducto;
            int cantidad = (int)numCant.Value;

            if (productoSeleccionado != null && cantidad > 0)
            {
                if (carrito.ContainsKey(productoSeleccionado))
                {
                    carrito[productoSeleccionado] += cantidad;
                }
                else
                {
                    carrito.Add(productoSeleccionado, cantidad);
                }

                // Actualizar el DataGridView
                ActualizarDataGridViewCarrito();

                // Actualizar el total de la compra
                CalcularTotalCompra();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto y una cantidad válida.");
            }
        }

        private void ActualizarDataGridViewCarrito()
        {
            dgvCarrito.Rows.Clear();

            foreach (var kvp in carrito)
            {
                clsProducto producto = kvp.Key;
                int cantidad = kvp.Value;
                string[] row = { producto.Nombre, cantidad.ToString(), (producto.Precio * cantidad).ToString() };
                dgvCarrito.Rows.Add(row);
            }
        }

        private void CalcularTotalCompra()
        {
            totalCompra = 0.0;

            foreach (var kvp in carrito)
            {
                clsProducto producto = kvp.Key;
                int cantidad = kvp.Value;
                totalCompra += producto.Precio * cantidad;
            }

            lblTotalPagar.Text = totalCompra.ToString("C");
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsCategoria categoriaSeleccionada = cmbCategoria.SelectedItem as clsCategoria;
            if (categoriaSeleccionada != null)
            {
                cmbProducto.DataSource = null;
                cmbProducto.DataSource = categoriaSeleccionada.Productos;
                cmbProducto.DisplayMember = "Nombre";
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsProducto productoSeleccionado = cmbProducto.SelectedItem as clsProducto;
            if (productoSeleccionado != null)
            {
                // Actualizar la descripción con el nombre y precio del producto seleccionado
                lstDescripcion.Text = $" Producto: {productoSeleccionado.Nombre} - Precio: {productoSeleccionado.Precio.ToString("C")}";
            }
        }

    }
}
