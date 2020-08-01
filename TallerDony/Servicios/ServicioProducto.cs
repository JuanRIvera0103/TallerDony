﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TallerDony.Clases;
using TallerDony.Servicios;

namespace TallerDony.Servicios
{
    class ServicioProducto
    {
        bool salir = false;
        int opcion, cantidad, codigo;
        string nombre;
        double precio;
        public void menuProductos()
        {            
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
                        do {                            
                            Console.WriteLine("Dijite el codigo: ");
                            codigo = int.Parse(Console.ReadLine());
                            if (verificarCodigo(codigo)) codigovalido = true;
                            else {
                                codigovalido = false;
                                Console.WriteLine("El codigo ingresado ya existe");
                            }
                        } while (codigovalido == false);
                        Console.WriteLine("Dijite el nombre: ");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Dijite el precio: ");
                        precio = double.Parse(Console.ReadLine());
                        Console.WriteLine("Dijite la cantidad: ");
                        cantidad = int.Parse(Console.ReadLine());

                        Producto producto = new Producto(codigo, nombre, precio, cantidad);

                        agregarProducto(producto);

                        ; break;
                    case 2:
                        Console.WriteLine("Ingrese el codigo del producto que desea buscar: ");
                        codigo = int.Parse(Console.ReadLine());
                        buscarProducto(codigo);
                        ;break;
                    case 3:
                        Console.WriteLine("Ingrese el codigo del producto que desea modificar: ");
                        codigo = int.Parse(Console.ReadLine());
                        modificarProducto(codigo);
                        ; break;
                    case 4:
                        Console.WriteLine("Ingrese el codigo del producto que desea eliminar: ");
                        codigo = int.Parse(Console.ReadLine());
                        eliminarProducto(codigo);
                        ; break;                  
                    case 5:
                        salir = true;
                        ; break;
                    default: Console.WriteLine("Opción ingresada no es valida");
                        ;break;
                }
            } while (salir != true);
        }

        private List<Producto> listaProductos = new List<Producto>();

        private void agregarProducto(Producto producto)
        {
            listaProductos.Add(producto);

            StreamReader srp = new StreamReader(@"productos.txt");

            var infoanterior = srp.ReadLine();
            srp.Close();
            StreamWriter swp = new StreamWriter(@"productos.txt");
            swp.WriteLine("Codigo: " + producto.codigo + " Nombre: " + producto.nombre + " Precio: " + producto.precio + " Cantidad: " + producto.cantidad);
            swp.Close();
        }

        private int buscarProducto(int codigo)
        {
            int respuesta = -1;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo == codigo)
                {
                    Console.WriteLine("Codigo: " + producto.codigo + " Nombre: " + producto.nombre + " Precio: " + producto.precio + " Cantidad: " + producto.cantidad);
                    respuesta = listaProductos.IndexOf(producto);
                }
            }
            return respuesta;
        }

        private void modificarProducto(int codigo)
        {
            int posicion = -1;
            posicion = buscarProducto(codigo);
            if (posicion != -1)
            {
                int respuesta = 0;
                Console.WriteLine("¿Estas seguro que deseas modificar el producto? ( 1.Si / 2.No )");
                respuesta = int.Parse(Console.ReadLine());
                if (respuesta == 1)
                {
                    listaProductos.RemoveAt(posicion);
                    bool codigovalido;
                    Console.WriteLine("Ingrese los datos para actualizar");
                    do
                    {
                        Console.WriteLine("Dijite el codigo: ");
                        codigo = int.Parse(Console.ReadLine());
                        if (verificarCodigo(codigo)) codigovalido = true;
                        else
                        {
                            codigovalido = false;
                            Console.WriteLine("El codigo ingresado ya existe");
                        }
                    } while (codigovalido == false);                    
                    Console.WriteLine("Dijite el nombre: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Dijite el precio: ");
                    precio = double.Parse(Console.ReadLine());
                    Console.WriteLine("Dijite la cantidad: ");
                    cantidad = int.Parse(Console.ReadLine());

                    Producto producto = new Producto(codigo, nombre, precio, cantidad);

                    listaProductos.Insert(posicion, producto);
                }
            }
            else Console.WriteLine("No se encontró el producto");
        }

        private void eliminarProducto(int codigo)
        {
            int posicion = -1;
            posicion = buscarProducto(codigo);
            if(posicion != -1)
            {
                int respuesta = 0;
                Console.WriteLine("¿Estas seguro que deseas eliminar el producto? ( 1.Si / 2.No )");
                respuesta = int.Parse(Console.ReadLine());

                if (respuesta == 1) listaProductos.RemoveAt(posicion); ;
            }
            else Console.WriteLine("No se encontró el producto");                        
            
        }

        private bool verificarCodigo(int codigo)
        {
            bool valido = true;
            foreach (Producto producto in listaProductos)
            {
                if (producto.codigo == codigo) valido = false;
            }

            return valido;
        }


    }
}