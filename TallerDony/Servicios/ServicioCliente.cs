using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TallerDony.Clases;
using TallerDony.Servicios;

namespace TallerDony.Servicios
{
    class ServicioCliente
    {
        List<Cliente> ListaCliente = new List<Cliente>();
        
        public void AgregarCliente(Cliente cliente)
        { 
            ListaCliente.Add(cliente);
            StreamReader sr = new StreamReader(@"cliente.txt");
            var infoanterior = sr.ReadLine();
            sr.Close();
            StreamWriter sw = new StreamWriter(@"cliente.txt");
            sw.WriteLine(infoanterior+"Cedula " +cliente.IdCliente+" Nombre "+cliente.NombreCliente+" Telefono "+cliente.telefonoCliente+" Direccion "+cliente.direccionCliente);            
            sw.Close();
        }
        public void MostrarCliente(int id)
        {
            BuscarCliente(id);
            
            foreach(Cliente cliente in ListaCliente )
            {
                if (cliente.IdCliente == id) Console.WriteLine("ID: "+cliente.IdCliente+" El nombre es: "+cliente.NombreCliente+" La dirección es: "+cliente.direccionCliente+" El telefono: "+cliente.telefonoCliente);
            }
        }
        
        public int BuscarCliente(int id)
        {
            int respuesta=-1;
            foreach (Cliente cliente in ListaCliente)
            {
              if(cliente.IdCliente == id) respuesta = ListaCliente.IndexOf(cliente); 
            }
            return respuesta;
        }        

        public void ModificarCliente(int id, Cliente cliente)
        {
           int pos = BuscarCliente(id);
            ListaCliente.RemoveAt(pos);
            ListaCliente.Insert(pos, cliente);
        }
        public void EliminarCliente(int id)
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
                Console.WriteLine("------------------------ Menu Clientes ------------------------");
                Console.WriteLine("1.Agregar Cliente");
                Console.WriteLine("2.Buscar Cliente por cedula");
                Console.WriteLine("3.Modificar Cliente");
                Console.WriteLine("4.Eliminar un Cliente");
                Console.WriteLine("5.Salir");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Ingrese le numero según la opción que desea solicitar: ");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Ingresa cedula");
                        int CedulaCliente = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresa nombre");
                        string NombreCliente = Console.ReadLine();
                        Console.WriteLine("Ingresa Dirección");
                        string direccionCliente = Console.ReadLine();
                        Console.WriteLine("Ingresa Telefono");
                        string telefonoCliente = Console.ReadLine();
                        Cliente cliente = new Cliente(CedulaCliente, NombreCliente, direccionCliente, telefonoCliente);
                        AgregarCliente(cliente);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese id");
                        int id = int.Parse(Console.ReadLine());
                        if (BuscarCliente(id) >= 0) MostrarCliente(id);
                        else Console.WriteLine("Cliente no encontrado");

                        break;
                    case 3:
                        Console.WriteLine("Ingresa el id");
                        id = int.Parse(Console.ReadLine());
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
                        id = int.Parse(Console.ReadLine());
                        if (BuscarCliente(id) >= 0) EliminarCliente(id);
                        else Console.WriteLine("Cliente no encontrado");
                        break;
                    case 5:
                        Salir = true;
                        ; break;
                    default: Console.WriteLine("Opción ingresada no es valida");
                        ;break;
                }
            } while (Salir != true);

        }

    }
}
