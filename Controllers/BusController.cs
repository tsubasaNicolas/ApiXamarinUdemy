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
    public class BusController : ApiController
    {
        // GET api/values
        public IEnumerable<BusCLS> Get()
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            var listaBus = (from p in bd.Bus
                            join m in bd.Marca
                            on p.IIDMARCA equals m.IIDMARCA
                            join mo in bd.Modelo
                            on p.IIDMODELO equals mo.IIDMODELO
                            join su in bd.Sucursal
                            on p.IIDSUCURSAL equals su.IIDSUCURSAL
                            join tb in bd.TipoBus
                            on p.IIDTIPOBUS equals tb.IIDTIPOBUS
                               where p.BHABILITADO == 1
                               select new BusCLS
                               {
                                   iidbus = p.IIDBUS,
                                   placa = p.PLACA,
                                  nombremarca=m.NOMBRE,
                                  nombremodelo=mo.NOMBRE,
                                  nombresucursal=su.NOMBRE,
                                  nombretipobus=tb.NOMBRE

                               }).ToList();
            return listaBus;
        }

        // GET api/values/5
        public BusCLS Get(int id)
        {
            BDPasajeEntities bd = new BDPasajeEntities();
            var oBus = (from p in bd.Bus
                            join m in bd.Marca
                            on p.IIDMARCA equals m.IIDMARCA
                            join mo in bd.Modelo
                            on p.IIDMODELO equals mo.IIDMODELO
                            join su in bd.Sucursal
                            on p.IIDSUCURSAL equals su.IIDSUCURSAL
                            join tb in bd.TipoBus
                            on p.IIDTIPOBUS equals tb.IIDTIPOBUS
                            where p.BHABILITADO == 1 && p.IIDBUS==id
                            select new BusCLS
                            {
                                iidbus = p.IIDBUS,
                                placa = p.PLACA,
                                nombremarca = m.NOMBRE,
                                nombremodelo = mo.NOMBRE,
                                nombresucursal = su.NOMBRE,
                                nombretipobus = tb.NOMBRE,
                                numerofila = (int)p.NUMEROFILAS,
                                numerocolumna = (int)p.NUMEROCOLUMNAS,
                                fechacompra = (DateTime)p.FECHACOMPRA,
                                descripcion=p.DESCRIPCION,
                                observacion=p.OBSERVACION

                            }).First();
            return oBus;
        }

        // POST api/values
        public int Post([FromBody] BusCLS oBusCLS)
        {
            //error 
            //exito (rpta =1);
            int rpta = 0;

            try
            {
                int id = oBusCLS.iidbus;
                BDPasajeEntities bd = new BDPasajeEntities();
                //Insertar
                if (oBusCLS.iidbus == 0)
                {
                    Bus oBus = new Bus();
                    oBus.IIDSUCURSAL = oBusCLS.iidsucursal;
                    oBus.IIDTIPOBUS = oBusCLS.iidtipobus;
                    oBus.PLACA = oBusCLS.placa;
                    oBus.FECHACOMPRA = oBusCLS.fechacompra;
                    oBus.IIDMODELO = oBusCLS.iidmodelo;
                    oBus.NUMEROCOLUMNAS = oBusCLS.numerocolumna;
                    oBus.NUMEROFILAS = oBusCLS.numerofila;
                    oBus.DESCRIPCION = oBusCLS.descripcion;
                    oBus.OBSERVACION = oBusCLS.observacion;
                    oBus.IIDMARCA = oBusCLS.iidmarca;
                    //salga en el listado
                    oBus.BHABILITADO = 1;
                    bd.Bus.Add(oBus);
                    //1
                    rpta = bd.SaveChanges();
                }
                //Actualizar
                else
                {
                    Bus oBus = bd.Bus.Where(p => p.IIDBUS == id).First();
                    oBus.IIDSUCURSAL = oBusCLS.iidsucursal;
                    oBus.IIDTIPOBUS = oBusCLS.iidtipobus;
                    oBus.PLACA = oBusCLS.placa;
                    oBus.FECHACOMPRA = oBusCLS.fechacompra;
                    oBus.IIDMODELO = oBusCLS.iidmodelo;
                    oBus.NUMEROCOLUMNAS = oBusCLS.numerocolumna;
                    oBus.NUMEROFILAS = oBusCLS.numerofila;
                    oBus.DESCRIPCION = oBusCLS.descripcion;
                    oBus.OBSERVACION = oBusCLS.observacion;
                    oBus.IIDMARCA = oBusCLS.iidmarca;
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
                Bus oBus = bd.Bus.Where(p => p.IIDBUS == id).First();
                //deshabilito
                oBus.BHABILITADO = 0;
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
