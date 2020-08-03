using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TallerDony.Servicios
{
    class ServicioReporte
    {
        public void menuReportes()
        {
            bool salir = false;
            int opcion;
            do
            {
                Console.WriteLine("------------------------ Menu Informes ------------------------");
                Console.WriteLine("1.Reporte de Clientes");
                Console.WriteLine("2.Reporte de Productos");
                Console.WriteLine("3.Reporte de Facturas");           
                Console.WriteLine("4.Salir");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ingrese el numero según la opción que desea solicitar: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        reporteCliente();
                        ; break;
                    case 2:
                        reporteProductos();
                        ; break;
                    case 3:
                        reporteFacturas();
                        ; break;
                    case 4:
                        salir = true;
                        ; break;                    
                    default:
                        Console.WriteLine("Opción ingresada no es valida");
                        ; break;
                }
            } while (salir != true);
            Console.Clear();
        }

        private void reporteCliente()
        {
            StreamReader srt = new StreamReader(@"cliente.txt");
            var infoanterior = srt.ReadLine();
            srt.Close();
            Console.WriteLine(infoanterior);
        }

        private void reporteProductos()
        {
            StreamReader srp = new StreamReader(@"productos.txt");
            var infoanterior = srp.ReadLine();
            srp.Close();
            Console.WriteLine(infoanterior);
        }
        private void reporteFacturas()
        {
            StreamReader srp = new StreamReader(@"facturas.txt");
            var infoanterior = srp.ReadLine();
            srp.Close();
            Console.WriteLine(infoanterior);
        }
    }
}
