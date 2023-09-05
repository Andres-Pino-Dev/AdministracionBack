using ProyectoAdministración.Data;
using ProyectoAdministración.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoAdministración.Controllers
{
    [RoutePrefix("api/v1")]
    public class CargoController : ApiController
    {
        [HttpGet]
        [Route("cargos")]
        public List<Departamento> Get()
        {
            return DepartamentoCargoStore.ListarCargos();
        }

    }
}