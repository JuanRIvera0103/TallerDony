using System;
using System.Collections.Generic;
using System.Text;
using Dony.Entidades;


namespace Dony.Servicios
{
    class ServicioProducto
    {
        List<Producto> listaProducto = new List<Producto>();
        
        public void agregarProducto(Producto producto)
        {
            listaProducto.Add(producto);
        }

        public void mostrarProducto()
        {
            foreach (Producto producto in listaProducto)
            {
                Console.WriteLine("Codigo: " + producto.codigo + "El nombre es: " + producto.nombre);
            }
        }
    }
}
