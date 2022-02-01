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
    public class ModalidadContratoController : ApiController
    {
        public IEnumerable<ModalidadContratoCLS> Get()
        {
            using(BDPasajeEntities bd=new BDPasajeEntities())
            {
                return bd.TipoContrato.Where(p=>p.BHABILITADO ==1).Select(p=> new ModalidadContratoCLS
                {
                    iidmodalidadcontrato = p.IIDTIPOCONTRATO,
                    nombre = p.NOMBRE
                }).ToList();
            }

        }
    }
}
