using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TallerDony.Clases;
using TallerDony.Servicios;

namespace TallerDony.Servicios
{
    class ServicioVenta
    {
        int idfactura, cantidadproductos, opcion, total = 0, estado = 1;
        static DateTime dt = DateTime.Today;
        bool valido;
        string fecha, idcliente;
        static List<Factura> listaFactura = new List<Factura>();


        public void menuVenta()
        {
            bool salir = false;                        
            do
            {
                Console.WriteLine("------------------------ Menu Venta ------------------------");
                Console.WriteLine("1.Realizar venta");
                Console.WriteLine("2.Buscar Factura");
                Console.WriteLine("3.Deshabilitar Factura");
                Console.WriteLine("4.Salir");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ingrese le numero según la opción que desea solicitar: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese la cedula del cliente: ");
                        idcliente = Console.ReadLine();

                        ServicioCliente serviciocliente = new ServicioCliente();

                        if (serviciocliente.BuscarCliente(idcliente).Equals(1)) realizarVenta(idcliente);
                        else Console.WriteLine("No se encontró el cliente");
                        ; break;
                    case 2:
                        Console.Write("Ingrese el codigo del producto que desea buscar: ");
                        idfactura = int.Parse(Console.ReadLine());

                        if(buscarFactura(idfactura) > -1)
                        {
                            ServicioDetalle serviciodetalles = new ServicioDetalle();
                            serviciodetalles.mostrarDetalle(idfactura);
                        }                           
                        ; break;
                    case 3:
                        Console.Write("Ingrese el codigo de la factura que desea deshabilitar: ");
                        idfactura = int.Parse(Console.ReadLine());
                        int posicion = buscarFactura(idfactura);

                        if (posicion > -1)
                        {
                            Console.Write("¿Estas seguro de deshabilitar la factura? :");
                            string resp = Console.ReadLine();
                            if (resp.Equals("si"))
                            {
                                deshabilitarFactura(posicion, idfactura);
                                Console.WriteLine("Factura deshabilitada");
                            }                            
                        }
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
        private void agregarFactura(Factura factura)
        {
            listaFactura.Add(factura);

            StreamReader srp = new StreamReader(@"facturas.txt");

            var infoanterior = srp.ReadLine();
            srp.Close();
            StreamWriter swp = new StreamWriter(@"facturas.txt");
            swp.WriteLine(infoanterior+" Codigo:" + factura.idfactura + " idcliente:" + factura.idcliente + " fecha:" + factura.fecha + " Cantidad productos:" + factura.cantidadproductos + " Total:" + factura.total + " Estado:" + factura.estado);
            swp.Close();
        }

        private void realizarVenta(string idcliente)
        {
            fecha = String.Format("{0:d}", dt); ;
            string respuesta = "";            
            idfactura = obtenerIdfactura();
            do
            {
                ServicioProducto servicioproducto = new ServicioProducto();
                Producto producto = new Producto();
                Console.WriteLine("Ingrese el codigo del producto que desea llevar: ");
                string codigoproducto = Console.ReadLine();
                int posicion = servicioproducto.buscarProducto(codigoproducto);
                
                if (posicion > -1)
                {
                    Console.Write("Ingrese la cantidad que desea llevar; ");
                    int cantidad = int.Parse(Console.ReadLine());
                    int cantidadproductoseleccionado = servicioproducto.cantidadProducto(codigoproducto);
                    int precioproducto = servicioproducto.precioProducto(codigoproducto);
                    int subtotal = cantidad * precioproducto;

                    if ((cantidad > 0) && (cantidad <= cantidadproductoseleccionado))
                    {
                        cantidadproductos++;
                        Detalle detalle = new Detalle(idfactura, codigoproducto, cantidad, subtotal);

                        ServicioDetalle serviciodetalle = new ServicioDetalle();
                        serviciodetalle.agregarDetalle(detalle);

                        servicioproducto.reducirCantidad(posicion, codigoproducto, cantidad);
                        total = total + subtotal;
                    }
                    else Console.WriteLine("La cantidad ingrese es menor a cero o mayor a la cantidad del producto");
                }

                do
                {
                    Console.Write("Desea agregar otro producto: ");
                    respuesta = Console.ReadLine();

                    if ((respuesta.Equals("si")) || (respuesta.Equals("no"))) valido = true;
                    else
                    {
                        valido = false;
                        Console.WriteLine("Debe de ingresar si o no");
                    }
                } while (valido == false);

            } while (respuesta.Equals("si"));

            if (cantidadproductos > 0)
            {
                Factura factura = new Factura(idfactura, idcliente, fecha, cantidadproductos, total, estado);

                agregarFactura(factura);
            }
            else Console.WriteLine("La venta se cancelo porque no hay ningún producto");        
        }

        private int buscarFactura(int idfactura)
        {
            int respuesta = -1;
            foreach (Factura factura in listaFactura)
            {
                if (factura.idfactura == idfactura)
                {
                    if (factura.estado == 1)
                    {
                        Console.WriteLine("Codigo:" + factura.idfactura + " idcliente:" + factura.idcliente + " fecha:" + factura.fecha + " Cantidad productos:" + factura.cantidadproductos + " Total:" + factura.total + " Estado:" + estadoFactura(factura.estado));
                        respuesta = listaFactura.IndexOf(factura);
                    }
                    else Console.WriteLine("La factura esta deshabilitada");                    
                }
            }
            return respuesta;
        }
        private string estadoFactura(int estado)
        {
            if(estado == 1)
            {
                return "Habilitada";
            }
            else
            {
                return "Deshabilitada";
            }
        }

        public void deshabilitarFactura(int posicion, int idfactura)
        {

            foreach (Factura facturas in listaFactura)
            {
                if (facturas.idfactura == idfactura )
                {
                    idfactura = facturas.idfactura;
                    idcliente = facturas.idcliente;
                    fecha = facturas.fecha;
                    cantidadproductos = facturas.cantidadproductos;
                    total = facturas.total;
                    estado = facturas.estado;
                    if (estado == 1) estado = 2;
                }
            }

            listaFactura.RemoveAt(posicion);

            Factura factura = new Factura(idfactura, idcliente, fecha, cantidadproductos, total, estado);

            listaFactura.Insert(posicion, factura);
        }

        private int obtenerIdfactura()
        {
            return listaFactura.Count + 1;
        }
    }
}
