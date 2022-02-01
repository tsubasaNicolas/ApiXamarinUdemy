using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiXamarin.Clases;
using apiXamarin.Models;

namespace apiXamarin.Controllers
{
    public class EmpleadoController : ApiController
    {
        public IEnumerable<EmpleadoCLS> Get()
        {
            IEnumerable<EmpleadoCLS> lista = null;
            using (BDPasajeEntities bd=new BDPasajeEntities())
            {
                lista = (from empleado in bd.Empleado
                         join tipocontrato in bd.TipoContrato
                         on empleado.IIDTIPOCONTRATO equals tipocontrato.IIDTIPOCONTRATO
                         select new EmpleadoCLS
                         {
                             iidempleado = empleado.IIDEMPLEADO,
                             nombrecompleto = empleado.NOMBRE+" "+ empleado.APPATERNO+" "+ empleado.APMATERNO,
                             nombretipocontrato = tipocontrato.NOMBRE

                         }).ToList();
            }
            return lista;
        }

        // POST api/Empleado
        public int Post([FromBody] EmpleadoCLS oEmpleadoCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;

            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oEmpleadoCLS.iidempleado == 0)
                {
                    Empleado oEmpleado = new Empleado();
                    oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                    oEmpleado.APPATERNO = oEmpleadoCLS.appaterno;
                    oEmpleado.APMATERNO = oEmpleadoCLS.apmaterno;
                    oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidtipocontrato;
                    //salga en el listado
                    oEmpleado.BHABILITADO = 1;
                    bd.Empleado.Add(oEmpleado);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                    Empleado oEmpleado = bd.Empleado.Where(p => p.IIDEMPLEADO == oEmpleadoCLS.iidempleado).First();
                    oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                    oEmpleado.APPATERNO = oEmpleadoCLS.appaterno;
                    oEmpleado.APMATERNO = oEmpleadoCLS.apmaterno;
                    oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidtipocontrato;
                    bd.SaveChanges();
                    rpta = 1;
                }
            }
            catch (Exception ex)
            {
                rpta = 0;

            }
            return rpta;
        }

    }
}
