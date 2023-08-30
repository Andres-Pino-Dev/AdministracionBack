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
    public class DepartamentoController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public List<Departamento> Get()
        {
            return DepartamentoCargoStore.ListarDepartamentos();
        }

        [HttpGet]
        [Route("api/user/departamento/{id}")]
        public List<User> Get(int idDepartamento)
        {
            return UsersStore.ListarByDepartamentos(idDepartamento);
        }


        // GET api/<controller>/5
        
        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}