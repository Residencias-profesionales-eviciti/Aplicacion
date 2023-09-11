using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ejemplo11.Models;
using ejemplo11.DAL;
using System.Web.Services.Description;

namespace ejemplo11.CN
{
    public class CN_EncuestaPregunta
    {

        private EncuestaPreguntas objCapaDato = new EncuestaPreguntas();


        public List<EncuestaPregunta> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(EncuestaPregunta obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El titulo de la pregunta no puede estar vacio.";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }

            else
            {
                return 0;
            }
        }

        public bool Editar(EncuestaPregunta obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Titulo) || string.IsNullOrWhiteSpace(obj.Titulo))
            {
                Mensaje = "El nombre del departamento no puede estar vacio.";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

    }
}