using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiXamarin.Clases
{
    public class BusCLS
    {
        //propiedades para el listado
        public int iidbus { get; set; }
        public string nombremarca { get; set; }
        public string nombretipobus { get; set; }
        public string nombremodelo { get; set; }
        public string nombresucursal { get; set; }
        public string placa { get; set; }

        //Adicionales

        public DateTime fechacompra { get;set; }
        public int numerofila { get; set; }
        public int numerocolumna { get; set; }
        public string descripcion { get; set; }
        public string observacion { get; set; }
        
        //propiedades para guardar datos

        public int iidsucursal { get; set; }

        public int iidmodelo { get; set; }

        public int iidmarca { get; set; }
        public int iidtipobus { get; set; }
    }
}