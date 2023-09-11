using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ejemplo11.DAL;
using ejemplo11.Models;

namespace ejemplo11.CN
{
    public class CN_Reporte
    {
        private Reporte objCapaDato = new Reporte();

        public Dashboard VerDashboard()
        {
            return objCapaDato.VerDashboard();
        }
    }
}