using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo11.Models
{
    public class Encuesta
    {
        public int IdEncuesta { get; set; }
        public Usuario oIdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_cierre { get; set; }
        public bool Status { get; set; }

    }
}