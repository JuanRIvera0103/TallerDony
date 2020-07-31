using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dony.Entidades
{
    class Cliente
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set;}
        public string direccionCliente { get; set;}
        public string telefonoCliente { get; set;}
        public Cliente(int id, string nombre, string direccion, string telefono)
        {
            this.IdCliente = id;
            this.NombreCliente = nombre;
            this.direccionCliente = direccion;
            this.telefonoCliente = telefono;
        }

    }
}
