using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ejemplo11.Models;
using ejemplo11.DAL;

namespace ejemplo11.CN
{
    public class CN_Encuesta
    {
        private Encuestas objCapaDato = new Encuestas();

        public List<Encuesta> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<Encuesta> Find(int ID)
        {
            return objCapaDato.Find(ID);
        }

        public int Registrar(Encuesta obj, out string Mensaje)
        {

            Mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre de la encuesta no puede estar vacio.";
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

        public bool Editar(Encuesta obj, out string mensaje)
        {
            mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                mensaje = "El nombre de la encuesta no puede estar vacio.";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Editar(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string mensaje)
        {
            return objCapaDato.Eliminar(id, out mensaje);
        }

    }
}