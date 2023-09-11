using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo11.Models
{
    public class Encuesta_Pregunta_Respuesta
    {
        public int IdEncuesta_pregunta_respuesta { get; set; }
        
        public int IdEncuesta_pregunta { get; set; }

        public string Respuesta { get; set; }
    }
}