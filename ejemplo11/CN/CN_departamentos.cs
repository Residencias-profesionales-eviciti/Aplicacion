using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ejemplo11.Models;
using ejemplo11.DAL;

namespace ejemplo11.CN
{
    public class CN_departamentos
    {
        private departamentos objCapaDato = new departamentos();


        public List<Departamento> Listar()
        {
            return objCapaDato.Listar();
        }

        public List<Departamento> Find(int ID)
        {
            return objCapaDato.Find(ID);
        }


        public int Registrar(Departamento obj, out string mensaje)
        {

            mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDato.Registrar(obj, out mensaje);
            }

            else
            {
                return 0;
            }
        }


        public bool Editar(Departamento obj, out string mensaje)
        {
            mensaje = string.Empty;


            if (string.IsNullOrEmpty(obj.nombre) || string.IsNullOrWhiteSpace(obj.nombre))
            {
                mensaje = "El nombre del departamento no puede estar vacio.";
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

        public bool Eliminar(int ID, out string mensaje)
        {
            mensaje = "El departamento se eliminó correctamente";
            return objCapaDato.Eliminar(ID, out mensaje);
        }

    }
}