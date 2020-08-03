using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Dony.Entidades;

namespace Dony.Servicios
{
    class ServicioCliente
    {
        static List<Cliente> ListaCliente = new List<Cliente>();
        static List<Cliente> ListaCliente10 = new List<Cliente>();


        public void AgregarCliente(Cliente cliente, string id)
        {
            if (BuscarCliente(id) == -1) {
                ListaCliente.Add(cliente);
                StreamReader sr = new StreamReader(@"cliente.txt");
                var infoanterior = sr.ReadLine();
                sr.Close();
                StreamWriter sw = new StreamWriter(@"cliente.txt");
                sw.Write(infoanterior + " Cedula " + cliente.IdCliente + " Nombre " + cliente.NombreCliente + " Telefono " + cliente.telefonoCliente + " Direccion " + cliente.direccionCliente, Environment.NewLine);
                sw.Write(infoanterior + " ");
                sw.Close();
            }
            else
            {
                Console.WriteLine("Ya se encuentra registrado");
            }
        }
        public void MostrarCliente(string id)
        {
            BuscarCliente(id);

            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.IdCliente.Equals(id)) Console.WriteLine("ID: " + cliente.IdCliente + " El nombre es: " + cliente.NombreCliente + " La dirección es: " + cliente.direccionCliente + " El telefono: " + cliente.telefonoCliente);
            }
        }

        public int BuscarCliente(string id)
        {
            int respuesta = -1;
            foreach (Cliente cliente in ListaCliente)
            {
                if (cliente.IdCliente.Equals(id)) respuesta = ListaCliente.IndexOf(cliente);
            }
            return respuesta;
        }



        public void ModificarCliente(string id, Cliente cliente)
        {
            int pos = BuscarCliente(id);
            ListaCliente.RemoveAt(pos);
            ListaCliente.Insert(pos, cliente);
        }
        public void EliminarCliente(string id)
        {
            int pos = BuscarCliente(id);
            ListaCliente.RemoveAt(pos);
            Console.WriteLine("Se eliminó con exito");
        }
        
        public void MenuCliente()
        {
            bool Salir = false;
            do
            {
                Console.WriteLine("1.Agregar, 2. Buscar por cedula 3. Modificar 4.Eliminar");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Ingresa cedula");
                        string CedulaCliente = Console.ReadLine();
                        Console.WriteLine("Ingresa nombre");
                        string NombreCliente = Console.ReadLine();
                        Console.WriteLine("Ingresa Dirección");
                        string direccionCliente = Console.ReadLine();
                        Console.WriteLine("Ingresa Telefono");
                        string telefonoCliente = Console.ReadLine();
                        Cliente cliente = new Cliente(CedulaCliente, NombreCliente, direccionCliente, telefonoCliente);
                        AgregarCliente(cliente, CedulaCliente);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese id");
                        string id = Console.ReadLine();
                        if (BuscarCliente(id) >= 0) MostrarCliente(id);
                        else Console.WriteLine("Cliente no encontrado");

                        break;
                    case 3:
                        Console.WriteLine("Ingresa el id");
                        id = Console.ReadLine();
                        if (BuscarCliente(id) >= 0)
                        {
                            Console.WriteLine("Ingresa nombre");
                            NombreCliente = Console.ReadLine();
                            Console.WriteLine("Ingresa Dirección");
                            direccionCliente = Console.ReadLine();
                            Console.WriteLine("Ingresa Telefono");
                            telefonoCliente = Console.ReadLine();
                            Cliente cliente1 = new Cliente(id, NombreCliente, direccionCliente, telefonoCliente);
                            ModificarCliente(id, cliente1);
                        }
                        else Console.WriteLine("Cliente no encontrado");
                        break;
                    case 4:
                        Console.WriteLine("Ingresa el id");
                        id = Console.ReadLine();
                        if (BuscarCliente(id) >= 0) EliminarCliente(id);
                        else Console.WriteLine("Cliente no encontrado");
                        break;
                    case 5:
                        Salir = true;
                        break;


                }
            } while (Salir != true);

        }
        public int ObtenerTamaño()
        {
            return ListaCliente.Count;
        }
        public void RecorrerLista()
        {
            foreach (Cliente cliente in ListaCliente)
            {
                Console.WriteLine("ID: " + cliente.IdCliente + " El nombre es: " + cliente.NombreCliente + " La dirección es: " + cliente.direccionCliente + " El telefono: " + cliente.telefonoCliente);
            }
        }
        
        public void Validad10()
        {
            foreach (Cliente cliente10 in ListaCliente10)
            {
                foreach (Cliente cliente in ListaCliente)
                {

                    if (cliente10.IdCliente.Equals(cliente.IdCliente))
                    {
                        StreamReader sr = new StreamReader(@"cliente.txt");
                        var infoanterior = sr.ReadLine();
                        sr.Close();
                        StreamWriter sw = new StreamWriter(@"cliente.txt");
                        sw.Write(infoanterior + " Cedula " + cliente.IdCliente + " Nombre " + cliente.NombreCliente + " Telefono " + cliente.telefonoCliente + " Direccion " + cliente.direccionCliente, Environment.NewLine);

                        sw.Close();
                    }

                }
            }
        }
        public void AgregarCliente10(Cliente cliente, string id)
        {
            if (BuscarCliente(id) == -1)
            {
                ListaCliente.Add(cliente);
                ListaCliente10.Add(cliente);
            }
            else
            {
                Console.WriteLine("Ya se encuentra registrado");
            }
        }
    } 
    }

