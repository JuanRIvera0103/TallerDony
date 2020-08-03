using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TallerDony.Clases;
using TallerDony.Servicios;


namespace TallerDony.Servicios
{
    class ServicioDetalle
    {
        static List<Detalle> listaDetalle = new List<Detalle>();

        public void agregarDetalle(Detalle detalle)
        {
            listaDetalle.Add(detalle);

            StreamReader srd = new StreamReader(@"detallefactura.txt");

            var infoanterior = srd.ReadLine();
            srd.Close();
            StreamWriter swd = new StreamWriter(@"detallefactura.txt");
            swd.WriteLine(infoanterior+" Idfactura: " + detalle.idfactura + " Idproducto: " + detalle.idproducto + " Cantidad: " + detalle.cantidad + "Subtotal: "+ detalle.subtotal);
            swd.Close();
        }

        public void mostrarDetalle(int idfactura)
        {
            Console.WriteLine("Detalle Factura: ");
            foreach (Detalle detalle in listaDetalle)
            {
                if(detalle.idfactura == idfactura) Console.WriteLine(" Idfactura: " + detalle.idfactura + " Idproducto: " + detalle.idproducto + " Cantidad: " + detalle.cantidad + " Subtotal: " + detalle.subtotal);
            }
        }
    }
}
