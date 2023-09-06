using ProyectoAdministración.Data;
using ProyectoAdministración.Models;
using System;
using System.Collections;
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
       

        [Route("")]
        public IHttpActionResult Get()
        {
            try {

                return Ok(UsersStore.Listar());
            } catch (Exception ex) {
                return NotFound();
            }
           
        }




        [HttpGet]
        [Route("find/{id}")]
        public IHttpActionResult Get(int id)
        {
            var usuarios = UsersStore.ListarByDepartamentos(id);
            try { 
            
                if (usuarios ==null || usuarios.Count==0) {
                    return NotFound();
                } else {
                    return Ok(usuarios);
                }

            } catch (Exception ex) {

                return InternalServerError();

            }

        }


        [HttpGet]
        [Route("relacion/{idDep}/{idCargo}")]
        public IHttpActionResult GetDepAndCArgo(int idDep,  int idCargo)
        {   
            var usuarios= UsersStore.ListarByDepartamentoAndCargo(idDep, idCargo);


            try {
                if (usuarios == null || usuarios.Count == 0)
                {
                    return NotFound();
                }
                else {

                    return Ok(usuarios);
                }
            
            }
            catch (Exception ex) {

                return InternalServerError();
            }
            
        }



        [HttpPost]
        [Route("save")]
        public IHttpActionResult Post([FromBody] User oUsuario)
        {  
            
            try {
                if (UsersStore.Registrar(oUsuario))
                {
                    return Ok(oUsuario);
                }
                else {
                    return BadRequest("No se pudo guardar el archivo");
                }
            
            } catch (Exception ex) { }
            
            return InternalServerError();
        }

        [HttpPut]
        [Route("update")]
        public IHttpActionResult Put([FromBody] User oUsuario)
        {
            try
            {
                if (UsersStore.Registrar(oUsuario))
                {
                    return Ok(oUsuario);
                }
                else
                {
                    return BadRequest("No se pudo guardar el archivo");
                }

            }
            catch (Exception ex) { }

            return InternalServerError();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (UsersStore.Eliminar(id))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se pudo guardar el archivo");
                }

            }
            catch (Exception ex) { }

            return InternalServerError();
        }
    }
}