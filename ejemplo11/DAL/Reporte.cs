using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ejemplo11.Models;

namespace ejemplo11.DAL
{
    public class Reporte
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();
        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oconexion);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Dashboard()
                            {
                                TotalUsuario = Convert.ToInt32(dr["TotalUsuario"]),
                                TotalDepartamento = Convert.ToInt32(dr["TotalDepartamento"]),
                                TotalEncuesta = Convert.ToInt32(dr["TotalEncuesta"]),
                                TotalCuestionario = Convert.ToInt32(dr["TotalCuestionario"])
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Dashboard();

            }
            return objeto;
        }

    }
}