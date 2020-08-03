using TallerDony.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace TallerDony.Servicios
{
    class ServicioConfig
    {
        public void Leer10Clientes()
        {
            StreamReader sr = new StreamReader(@"Cliente10.txt");
            ServicioCliente servicioCliente = new ServicioCliente();
            string input = "";
            while (input != null)
            {
                input = sr.ReadLine();
                if (input != null)
                {
                    List<String> elements = input.Split(',').ToList();
                    string cedula = elements[0];
                    string nombre = elements[1];
                    string direccion = elements[2];
                    string telefono = elements[3];
                    Cliente cliente = new Cliente(cedula, nombre, direccion, telefono);
                    servicioCliente.AgregarCliente10(cliente, cedula);
                    elements.Clear();
                }

            }
            servicioCliente.Validad10();
        }
        public void Leer10Productos()
        {
            StreamReader sr = new StreamReader(@"Productos10.txt");
            ServicioProducto servicioProducto = new ServicioProducto();
            string input = "";
            while (input != null)
            {
                input = sr.ReadLine();
                if (input != null)
                {
                    List<String> elements = input.Split(',').ToList();
                    string codigo = elements[0];
                    string nombre = elements[1];
                    string preciof = elements[2];
                    string cantidadf = elements[3];
                    int precio = int.Parse(preciof);
                    int cantidad = int.Parse(cantidadf);
                    Producto producto = new Producto(codigo, nombre, precio, cantidad);
                    servicioProducto.Agregarproducto10(producto, codigo);
                    elements.Clear();
                }

            }
            sr.Close();
            servicioProducto.ValidadProducto10();
            
        }
    }
}
