using Dony.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Dony.Servicios
{
    class Config
    {
        public void MenuConfig()
        {
            bool salir = false;
            do
            {
                Console.WriteLine("------------------------ Menu Configuración ------------------------");
                Console.WriteLine("1.Agregar 10 productos");
                Console.WriteLine("2.Agregar 10 clientes");
                
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Leer10Productos();
                        ; break;
                    case 2:
                        Leer10Clientes();
                        ; break;
                }
                } while (salir != true) ;
                Console.Clear();
            }
        public void Leer10Clientes()
        {
            StreamReader sr = new StreamReader(@"Cliente10.txt");
            ServicioCliente servicioCliente = new ServicioCliente();
            string input = "";
            while (input != null) { 
            input = sr.ReadLine();
            if (input != null) { 
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
            
            sr.Close();
            servicioCliente.ValidadCliente10();
        }
        public void Leer10Productos()
        {
            StreamReader sr = new StreamReader(@"Productos10.txt");
            ServicioProducto servicioproducto = new ServicioProducto();
            string input = "";
            while (input != null)
            {
                input = sr.ReadLine();
                if (input != null)
                {
                    List<String> elements = input.Split(',').ToList();
                    string codigo = elements[0];
                    string nombre = elements[1];
                    int precio = int.Parse(elements[2]);
                    int cantidad = int.Parse(elements[3]);
                    Producto producto = new Producto(codigo, nombre, precio, cantidad);
                    servicioproducto.Agregarproducto10(producto, codigo);
                    elements.Clear();
                }

            }

            sr.Close();
            servicioproducto.ValidadCliente10();
        }
    }
}
   

