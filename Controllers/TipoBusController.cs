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
    public class TipoBusController : ApiController
    {
        // GET api/values
        public IEnumerable<TipoBusCLS> Get()
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            var listaTipoBus = (from p in bd.TipoBus
                                where p.BHABILITADO == 1
                                select new TipoBusCLS
                                {
                                    iidtipobus = p.IIDTIPOBUS,
                                    nombre = p.NOMBRE
                                }).ToList();
            return listaTipoBus;
        }


        // POST api/TipoBus
        public int Post([FromBody] TipoBusCLS oTipoBusCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;
            int id = oTipoBusCLS.iidtipobus;

            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oTipoBusCLS.iidtipobus == 0)
                {
                    TipoBus oTipoBus = new TipoBus();
                    oTipoBus.NOMBRE = oTipoBusCLS.nombre;
                    oTipoBus.DESCRIPCION = oTipoBusCLS.descripcion;
                    //salga en el listado
                    oTipoBus.BHABILITADO = 1;
                    bd.TipoBus.Add(oTipoBus);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                    TipoBus oTipoBus = bd.TipoBus.Where(p => p.IIDTIPOBUS == id).First();
                    oTipoBus.NOMBRE = oTipoBusCLS.nombre;
                    oTipoBus.DESCRIPCION = oTipoBusCLS.descripcion;
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
        public int Delete(int id)
        {
            //error
            int rpta = 0;
            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                TipoBus oTipoBus = bd.TipoBus.Where(p => p.IIDTIPOBUS == id).First();
                //deshabilito
                oTipoBus.BHABILITADO = 0;
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
