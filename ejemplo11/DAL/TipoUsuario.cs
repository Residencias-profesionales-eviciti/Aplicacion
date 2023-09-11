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
    public class TipoUsuario
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();
        public List<tipo_usuario> Listar()
        {
            List<tipo_usuario> lista = new List<tipo_usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerTipoUsuario", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new tipo_usuario()
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    nombret = dr["nombret"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<tipo_usuario>();

            }
            return lista;
        }

    }
}