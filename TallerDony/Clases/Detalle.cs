﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TallerDony.Clases
{
    class Detalle
    {
        
        public int idfactura { get; set; }
        public string idproducto { get; set; }
        public int cantidad { get; set; }
        public int subtotal { get; set; }

        public Detalle(int idfactura, string idproducto, int cantidad, int subtotal)
        {
            
            this.idfactura = idfactura;
            this.idproducto = idproducto;
            this.cantidad = cantidad;
            this.subtotal = subtotal;
        }

    }
}
