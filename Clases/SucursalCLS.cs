using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiXamarin.Clases
{
    public class SucursalCLS
    {
        public int iidsucursal { get; set; }
        public string nombre { get; set; }

        public string direccion { get; set; }
        public string telefono { get; set; }

        public string email { get; set; }

        public DateTime fechaapertura { get; set; }
    }
}