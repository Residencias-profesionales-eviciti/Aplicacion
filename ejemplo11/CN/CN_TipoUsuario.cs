using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ejemplo11.Models;
using ejemplo11.DAL;

namespace ejemplo11.CN
{
    public class CN_TipoUsuario
    {
        private TipoUsuario objCapaDato = new TipoUsuario();

            public List<tipo_usuario> Listar()
            {
                return objCapaDato.Listar();
            }
    }
}