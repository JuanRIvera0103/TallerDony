using System;
using System.Collections.Generic;
using System.Text;

namespace TallerDony.Clases
{
    class Producto
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public int cantidad { get; set; }

        public Producto(int codigo, string nombre, int precio, int cantidad)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
        }
        public Producto()
        {
        }
    }
}
