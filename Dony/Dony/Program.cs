using System;
using System.Collections.Generic;
using System.Text;
using Dony.Entidades;
using Dony.Servicios;

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
                Console.WriteLine("3.Menu Ventas");
                Console.WriteLine("4.Menu Informes");
                Console.WriteLine("5.Generar 10 clientes y 10 productos");
                Console.WriteLine("6.Salir");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("Ingrese le numero según la opción que desea solicitar: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();
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
                    //case 3:                                                
                    //    ServicioVenta servicioventa = new ServicioVenta();                            
                    //    servicioventa.menuVenta();
                    //    ; break;
                    case 4:
                        ServicioReporte servicioreporte = new ServicioReporte();
                        servicioreporte.menuReportes();
                        ; break;
                    case 5:
                        Config config = new Config();
                        config.Leer10Clientes();
                        ;break;

                    case 6:
                        salir = true;
                        ;break;
                }
            } while (salir != true);
                                    
        }
    }
}
