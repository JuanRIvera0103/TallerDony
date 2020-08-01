using System;
using System.Collections.Generic;
using System.Text;

namespace supermercado.Entidades
{
    class Detalle
    {
        public int IdDetalle { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }

        public Detalle( string nombre, int cantidad, double precio)
        {
         
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }

    }
}
