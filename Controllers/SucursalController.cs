using apiXamarin.Clases;
using apiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace apiXamarin.Controllers
{
    public class SucursalController : ApiController
    {
        // GET api/values
        public IEnumerable<SucursalCLS> Get()
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            return bd.Sucursal.Where(p => p.BHABILITADO == 1).Select(p => new SucursalCLS
            {
                iidsucursal = p.IIDSUCURSAL,
                nombre= p.NOMBRE,
                telefono=p.TELEFONO,
                direccion=p.DIRECCION,
                email =p.EMAIL,
                fechaapertura=(DateTime)p.FECHAAPERTURA
            });
        }



        // POST api/values
        public int Post([FromBody] SucursalCLS oSucursalCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;

            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oSucursalCLS.iidsucursal == 0)
                {
                    Sucursal oSucursal = new Sucursal();
                    oSucursal.NOMBRE = oSucursalCLS.nombre;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaapertura;
                    //salga en el listado
                    oSucursal.BHABILITADO = 1;
                    bd.Sucursal.Add(oSucursal);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                    int id = oSucursalCLS.iidsucursal;
                    Sucursal oSucursal = bd.Sucursal.Where(p => p.IIDSUCURSAL == id).First();
                    oSucursal.NOMBRE = oSucursalCLS.nombre;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaapertura;
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
        // DELETE api/values/5
        public int Delete(int id)
        {
            //error
            int rpta = 0;
            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                Sucursal oSucursal = bd.Sucursal.Where(p => p.IIDSUCURSAL == id).First();
                //deshabilito
                oSucursal.BHABILITADO = 0;
                rpta = bd.SaveChanges();

            }
            catch (Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }
    }
}
