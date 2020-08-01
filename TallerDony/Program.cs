using System;
using System.Collections.Generic;
using System.Text;
using TallerDony.Clases;
using TallerDony.Servicios;

namespace TallerDony
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            int opcion = 0;
            Console.WriteLine("Bienvenido a la empresa TC#");
            do
            {
                Console.WriteLine("------------------------ Menu de TC# ------------------------");
                Console.WriteLine("1.Menu Clientes");
                Console.WriteLine("2.Menu Productos");
                Console.WriteLine("3.Menu Informes");
                Console.WriteLine("4.Salir");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Ingrese le numero según la opción que desea solicitar: ");
                opcion = int.Parse(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                        ServicioCliente serviciocliente = new ServicioCliente();
                        serviciocliente.MenuCliente();
                        ;break;
                    case 2:
                        ServicioProducto servicioproducto = new ServicioProducto();
                        servicioproducto.menuProductos();
                        ; break;
                    case 3:
                        ServicioReporte servicioreporte = new ServicioReporte();
                        servicioreporte.menuReportes();
                        ; break;
                    case 4:
                        salir = true;
                        ;break;
                }
            } while (salir != true);
                                    
        }
    }
}
