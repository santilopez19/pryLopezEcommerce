using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace pryLopezEcommerce
{
    internal class clsProducto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }

        public clsProducto(string nombre, double precio, string categoria, string descripcion)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            Descripcion = descripcion; 
        }
        public override string ToString()
        {
            return Nombre;

        }

    }
}
