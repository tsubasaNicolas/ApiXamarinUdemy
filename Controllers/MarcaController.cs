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
    public class MarcaController : ApiController
    {
        // GET api/values
        public IEnumerable<MarcaCLS> Get()
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            return bd.Marca.Where(p=>p.BHABILITADO==1).Select(p=> new MarcaCLS
            { idmarca = p.IIDMARCA,
            nombre = p.NOMBRE,
            descripcion =p.DESCRIPCION} );
        }

        // POST api/values
        public int Post([FromBody] MarcaCLS oMarcaCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;

            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oMarcaCLS.idmarca == 0)
                {
                    Marca omarca = new Marca();
                    omarca.NOMBRE = oMarcaCLS.nombre;
                    omarca.DESCRIPCION = oMarcaCLS.descripcion;
                    //salga en el listado
                    omarca.BHABILITADO = 1;
                    bd.Marca.Add(omarca);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                 Marca oMarca = bd.Marca.Where(p => p.IIDMARCA == oMarcaCLS.idmarca).First();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                     bd.SaveChanges();
                    rpta = 1;
                }
            }
            catch(Exception ex)
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
                Marca omarca = bd.Marca.Where(p => p.IIDMARCA == id).First();
                //deshabilito
                omarca.BHABILITADO = 0;
               rpta = bd.SaveChanges();

            }
            catch(Exception ex)
            {
                rpta = 0;
            }
            return rpta;
        }
    }
}
