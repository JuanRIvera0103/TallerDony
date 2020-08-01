using System;
using System.Collections.Generic;
using System.Text;

namespace supermercado.Entidades
{
    class Factura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public string Fecha { get; set; }
        public int productos { get; set; }

    }
}
