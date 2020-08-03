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
            servicioCliente.Validad10();
        }
    }
}
