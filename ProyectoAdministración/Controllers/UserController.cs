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
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            return UsersStore.Listar();
        }



        // GET api/<controller>/5
        public User Get(int id)
        {
            return UsersStore.Obtener(id);
        }


        
        public List<User> GetByDepartamentoAndCargo(int idDepartamento,int idCArgo)
        {
            return UsersStore.ListarByDepartamentoAndCargo(idDepartamento,idCArgo);
        }

        // POST api/<controller>
        public bool Post([FromBody] User oUsuario)
        {
            return UsersStore.Registrar(oUsuario);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] User oUsuario)
        {
            return UsersStore.Modificar(oUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return UsersStore.Eliminar(id);
        }
    }
}