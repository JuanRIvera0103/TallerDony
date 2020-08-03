using System;
using System.Collections.Generic;
using System.Text;

namespace TallerDony.Clases
{
    class Config
    {
     public string Nombre_empresa { get; set; }

        public Config(string nombre)
        {
            this.Nombre_empresa = nombre;
        }
    }
}
