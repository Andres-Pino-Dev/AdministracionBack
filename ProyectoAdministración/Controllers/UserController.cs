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
    [RoutePrefix("api/v1/usuarios")]
    public class UserController : ApiController
    {
        // GET api/<controller>

        [Route("")]
        public List<User> Get()
        {
            return UsersStore.Listar();
        }




        [HttpGet]
        [Route("find/{id}")]
        public List<User> Get(int id)
        {
            return UsersStore.ListarByDepartamentos(id);
        }


        [HttpGet]
        [Route("relacion/{idDep}/{idCargo}")]
        public List<User> GetDepAndCArgo(int idDep,  int idCargo)
        {
            return UsersStore.ListarByDepartamentoAndCargo(idDep, idCargo);
        }



        [HttpPost]
        [Route("save")]
        public bool Post([FromBody] User oUsuario)
        {
            return UsersStore.Registrar(oUsuario);
        }

        [HttpPut]
        [Route("update")]
        public bool Put([FromBody] User oUsuario)
        {
            return UsersStore.Modificar(oUsuario);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public bool Delete(int id)
        {
            return UsersStore.Eliminar(id);
        }
    }
}