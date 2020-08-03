using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace TallerDony.Clases
{
    class Factura
    {
        public int idfactura { get; set; }
        public string idcliente { get; set; }
        public string fecha { get; set; }
        public int cantidadproductos { get; set; }
        public int total { get; set; }
        public int estado { get; set; }

        public Factura(int idfactura, string idcliente, string fecha, int cantidadproductos, int total, int estado)
        {
            this.idfactura = idfactura;
            this.idcliente = idcliente;
            this.fecha = fecha;
            this.cantidadproductos = cantidadproductos;
            this.total = total;
            this.estado = estado;
        }

    }
}
