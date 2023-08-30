using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAdministración.Models
{
    public class User
    {

        public int id { get; set; }
        public string usuario { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string segundoApellido { get; set; }
        public int idDepartamento { get; set; }
        public int idCargo { get; set; }
    }
}