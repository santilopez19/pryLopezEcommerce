using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryLopezEcommerce
{
    internal class clsCategoria
    {
        public string Nombre { get; set; }
        public List<clsProducto> Productos { get; set; }

        public clsCategoria(string nombre)
        {
            Nombre = nombre;
            Productos = new List<clsProducto>();
        }
    }
}
