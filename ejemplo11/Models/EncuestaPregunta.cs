using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo11.Models
{
    public class EncuestaPregunta
    {
        public int IdEncuesta_pregunta { get; set; }
        public Encuesta oIdEncuesta { get; set; }

        //public int IdEncuesta { get; set; }

        public Tipo_Pregunta oIdTipo_pregunta { get; set; }

        public string Titulo { get; set; }
        public string Forma_respuesta { get; set; }

    }
}