using supermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace supermercado.Servicios
{
    class FacturaDetalle
    {
        List<Detalle> Listadetalle = new List<Detalle>();

        public void AgregarDetalle(Detalle detalle)
        {
            detalle.IdDetalle = Listadetalle.Count + 1;
            Listadetalle.Add(detalle);
           
        }
        public void Mostrardetalle(int id)
        {
            Buscardetalle(id);

            foreach (Detalle detalle in Listadetalle)
            {
                if (detalle.IdDetalle == id) Console.WriteLine("ID: " + detalle.IdDetalle + " El nombre es: " + detalle.Nombre + " La cantidad comprada es: " + detalle.Cantidad + " El precio es: " + detalle.Precio);
            }
        }

        public int Buscardetalle(int id)
        {
            int respuesta = -1;
            foreach (Detalle detalle in Listadetalle)
            {
                if (detalle.IdDetalle == id) respuesta = Listadetalle.IndexOf(detalle);
            }
            return respuesta;
        }




        public void EliminarDetalle(int id)
        {
            int pos = Buscardetalle(id);
            Listadetalle.RemoveAt(pos);
            Console.WriteLine("Se eliminó con exito");
        }
        public void Menudetalle()
        {
            bool Salir = false;
            do
            {
                Console.WriteLine("1.Agregar");
                Console.WriteLine("2. Buscar por cedula ");
                Console.WriteLine("3. Modificar ");
                Console.WriteLine("4.Eliminar");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Ingresa el nombre del producto");
                        string Nombre = Console.ReadLine();
                        Console.WriteLine("ingrese la cantidad");
                        int Cantidad = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingresa Precio");
                        double Precio = double.Parse(Console.ReadLine());
                        Detalle detalle = new Detalle(Nombre, Cantidad, Precio);
                        AgregarDetalle(detalle);
                        break;

                    case 2:
                        Console.WriteLine("Ingrese id");
                        int id = int.Parse(Console.ReadLine());
                        if (Buscardetalle(id) >= 0) Mostrardetalle(id);
                        else Console.WriteLine("Detalle no encontrado");

                        break;
                    case 4:
                        Console.WriteLine("Ingresa el id");
                        id = int.Parse(Console.ReadLine());
                        if (Buscardetalle(id) >= 0) EliminarDetalle(id);
                        else Console.WriteLine("Detalle no encontrado");
                        break;
                    case 5:
                        Salir = true;
                        break;


                }
            } while (Salir != true);




        }
    }
}