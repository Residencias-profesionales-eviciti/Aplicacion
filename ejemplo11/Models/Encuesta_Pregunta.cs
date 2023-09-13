using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemplo11.Models
{
    public class Encuesta_Pregunta
    {
        public int IdEncuesta_pregunta { get; set; }
        public Encuesta oIdEncuesta { get; set; }

        //public int IdEncuesta { get; set; }

        public Tipo_Pregunta oIdTipo_pregunta { get; set; }

        public string Titulo { get; set; }
        public string Forma_Opcion { get; set; }

    }
}