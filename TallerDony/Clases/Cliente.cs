﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TallerDony.Clases
{
    class Cliente
    {
        public string IdCliente { get; set; }
        public string NombreCliente { get; set;}
        public string direccionCliente { get; set;}
        public string telefonoCliente { get; set;}
        public Cliente(string id, string nombre, string direccion, string telefono)
        {
            this.IdCliente = id;
            this.NombreCliente = nombre;
            this.direccionCliente = direccion;
            this.telefonoCliente = telefono;
        }

    }
}
