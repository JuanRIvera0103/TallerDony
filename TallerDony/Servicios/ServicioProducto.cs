using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TallerDony.Clases;
using TallerDony.Servicios;

namespace TallerDony.Servicios
{
    class ServicioProducto
    {
        int opcion, cantidad, precio;
        string nombre, codigo;
        public void menuProductos()
        {
            bool salir = false;
            do
            {
                Console.WriteLine("------------------------ Menu Productos ------------------------");
                Console.WriteLine("1.Agregar producto");
                Console.WriteLine("2.Buscar producto");
                Console.WriteLine("3.Modificar producto");
                Console.WriteLine("4.Eliminar un producto");
                Console.WriteLine("5.Salir");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ingrese le numero según la opción que desea solicitar: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        bool codigovalido;
                        do
                        {
                            Console.WriteLine("Digite el código: ");
                            codigo = Console.ReadLine();
                            if (verificarCodigo(codigo)) codigovalido = true;
                            else
                            {
                                codigovalido = false;
                                Console.WriteLine("El código ingresado ya existe");
                            }
                        } while (codigovalido == false);

                        Console.WriteLine("Digite el nombre: ");
                        nombre = Console.ReadLine();
                        try
                        {
                            Console.WriteLine("Digite el precio: ");
                            precio = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No se agregó el precio");
                            precio = 0;
                        }
                        try
                        {
                            Console.WriteLine("Digite la cantidad: ");
                            cantidad = int.Parse(Console.ReadLine());
                            
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("No se agregó la cantidad");
                            cantidad = 0;
                        }
                        if (precio > 0 || cantidad > 0) { 
                        Producto producto = new Producto(codigo, nombre, precio, cantidad);

                        agregarProducto(producto);
                        }
                         else Console.WriteLine("No se agregó el producto");
                        ; break;
                    case 2:
                        Console.WriteLine("Ingrese el código del producto que desea buscar: ");
                        codigo = Console.ReadLine();
                        buscarProducto(codigo);
                        ; break;
                    case 3:
                        Console.WriteLine("Ingrese el código del producto que desea modificar: ");
                        codigo = Console.ReadLine();
                        modificarProducto(codigo);
                        ; break;
                    case 4:
                        Console.WriteLine("Ingrese el código del producto que desea eliminar: ");
                        codigo = Console.ReadLine();
                        eliminarProducto(codigo);
                        ; break;
                    case 5:
                        salir = true;
                        ; break;
                    default:
                        Console.WriteLine("Opción ingresada no es valida");
                        ; break;
                }
            } while (salir != true);
            Console.Clear();
        }

        static List<Producto> listaProductos = new List<Producto>();
        static List<Producto> listaProductos10 = new List<Producto>();
        private void agregarProducto(Producto producto)
        {
            listaProductos.Add(producto);

            StreamReader srp = new StreamReader(@"productos.txt");

            var infoanterior = srp.ReadLine();
            srp.Close();
            StreamWriter swp = new StreamWriter(@"productos.txt");

            swp.WriteLine(infoanterior + " Código: " + producto.codigo + " Nombre: " + producto.nombre + " Precio: " + producto.precio + " Cantidad: " + producto.cantidad);
            swp.Close();
        }

        public int buscarProducto(string codigo)
        {
            int respuesta = -1;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo.Equals(codigo))
                {
                    Console.WriteLine("Código: " + producto.codigo + " Nombre: " + producto.nombre + " Precio: " + producto.precio + " Cantidad: " + producto.cantidad);
                    respuesta = listaProductos.IndexOf(producto);
                }
            }
            return respuesta;
        }


        private void modificarProducto(string codigo)
        {
            int posicion = -1;
            posicion = buscarProducto(codigo);
            if (posicion != -1)
            {
                int respuesta = 0;
                Console.WriteLine("¿Estas seguro que deseas modificar el producto? ( 1.Si / 2.No )");
                try
                {
                    respuesta = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    respuesta = 0;
                    Console.WriteLine("Escriba 1 para Sí o 2 para No");
                }
                if (respuesta == 1)
                {
                    listaProductos.RemoveAt(posicion);
                    bool codigovalido;
                    Console.WriteLine("Ingrese los datos para actualizar");
                    do
                    {
                        Console.WriteLine("Digite el codigo: ");
                        codigo = Console.ReadLine();
                        if (verificarCodigo(codigo)) codigovalido = true;
                        else
                        {
                            codigovalido = false;
                            Console.WriteLine("El código ingresado ya existe");
                        }
                    } while (codigovalido == false);
                    Console.WriteLine("Digite el nombre: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Digite el precio: ");
                    precio = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite la cantidad: ");
                    cantidad = int.Parse(Console.ReadLine());

                    Producto producto = new Producto(codigo, nombre, precio, cantidad);

                    listaProductos.Insert(posicion, producto);
                }
            }
        }

        private void eliminarProducto(string codigo)
        {
            int posicion = -1;
            posicion = buscarProducto(codigo);
            if (posicion != -1)
            {
                int respuesta = 0;
                Console.WriteLine("¿Estas seguro que deseas eliminar el producto? ( 1.Si / 2.No )");
                try
                {
                    respuesta = int.Parse(Console.ReadLine());
                }
                catch(Exception)
                {
                    respuesta = 0;
                    Console.WriteLine("Escriba 1 para Sí o 2 para No");
                }
                if (respuesta == 1) listaProductos.RemoveAt(posicion); 
            }
        }

        public int cantidadProducto(string codigo)
        {
            int cantidad = 0;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo == codigo) cantidad = producto.cantidad;
            }
            return cantidad;
        }

        public int precioProducto(string codigo)
        {
            int precio = 0;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo == codigo) precio = producto.precio;
            }
            return precio;
        }

        public void reducirCantidad(int posicion, string codigo, int cantidadvendida)
        {

            foreach (Producto productos in listaProductos)
            {
                if (productos.codigo == codigo)
                {
                    codigo = productos.codigo;
                    nombre = productos.nombre;
                    precio = productos.precio;
                    cantidad = productos.cantidad - cantidadvendida;
                }
            }

            listaProductos.RemoveAt(posicion);

            Producto producto = new Producto(codigo, nombre, precio, cantidad);

            listaProductos.Insert(posicion, producto);
        }

        private bool verificarCodigo(string codigo)
        {
            bool valido = true;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo == codigo) valido = false;
            }

            return valido;
        }
        public void ValidadProducto10()
        {
            foreach (Producto producto10 in listaProductos10)
            {
                foreach (Producto producto in listaProductos)
                {

                    if (producto10.codigo.Equals(producto.codigo))
                    {
                        StreamReader sr = new StreamReader(@"productos.txt");
                        var infoanterior = sr.ReadLine();
                        sr.Close();
                        StreamWriter sw = new StreamWriter(@"productos.txt");
                        sw.Write(infoanterior + " Código " + producto.codigo + " Nombre " + producto.nombre + " Precio " + producto.precio + " Cantidad " + producto.cantidad, Environment.NewLine);

                        sw.Close();
                    }

                }
            }
        }
        public void Agregarproducto10(Producto producto, string id)
        {
            if (buscarProducto(id) == -1)
            {
                listaProductos.Add(producto);
                listaProductos10.Add(producto);
            }
            else
            {
                Console.WriteLine("Ya se encuentra registrado");
            }
        }
    }


}
