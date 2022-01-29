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
    public class ModeloController : ApiController
    {
        // GET api/Modelo
        public IEnumerable<ModeloCLS> Get()
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            var listaModelo = (from p in bd.Modelo
                                where p.BHABILITADO == 1
                                select new ModeloCLS
                                {
                                    iidmodelo=p.IIDMODELO,
                                    nombre=p.NOMBRE,
                                    descripcion=p.DESCRIPCION
                                  
                                }).ToList();
            return listaModelo;
        }

        // POST api/Modelo
        public int Post([FromBody] ModeloCLS oModeloCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;

            try
            {
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oModeloCLS.iidmodelo == 0)
                {
                    Modelo oModelo = new Modelo();
                    oModelo.NOMBRE = oModeloCLS.nombre;
                    oModelo.DESCRIPCION = oModeloCLS.descripcion;
                    //salga en el listado
                    oModelo.BHABILITADO = 1;
                    bd.Modelo.Add(oModelo);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                    Modelo oModelo = bd.Modelo.Where(p => p.IIDMODELO == oModeloCLS.iidmodelo).First();
                    oModelo.NOMBRE = oModeloCLS.nombre;
                    oModelo.DESCRIPCION = oModeloCLS.descripcion;
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
                Modelo oModelo = bd.Modelo.Where(p => p.IIDMODELO == id).First();
                //deshabilito
                oModelo.BHABILITADO = 0;
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
