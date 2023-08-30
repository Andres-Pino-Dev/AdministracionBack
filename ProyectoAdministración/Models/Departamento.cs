using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAdministración.Models
{
    public class Departamento
    {

        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string activo { get; set; }
        public string idUsuarioCreacion { get; set; }
        
    }
}