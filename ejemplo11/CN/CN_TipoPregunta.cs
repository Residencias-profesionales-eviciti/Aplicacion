using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ejemplo11.Models;
using ejemplo11.DAL;

namespace ejemplo11.CN
{
    public class CN_TipoPregunta
    {

        private TipoPreguntas objCapaDato = new TipoPreguntas();

        public List<Tipo_Pregunta> Listar()
        {
            return objCapaDato.Listar();
        }

    }
}