using ejemplo11.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo11.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public Departamento oIdDepartamento { get; set; }
        public tipo_usuario oIdRol { get; set; }
        public string Nombres { get; set; }
        public string Apellido_paterno { get; set; }
        public string Apellido_materno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public bool Status { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}