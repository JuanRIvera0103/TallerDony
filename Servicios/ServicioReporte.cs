using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dony.Servicios
{
    class ServicioReporte
    {
        public void InformeCliente()
        {
            StreamReader srt = new StreamReader(@"cliente.txt");
            var infoanterior = srt.ReadLine();
            srt.Close();
            Console.WriteLine(infoanterior);
        }
    }
}
