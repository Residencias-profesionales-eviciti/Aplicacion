using ejemplo11.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ejemplo11.DAL
{
    public class TipoPreguntas
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();

        public List<Tipo_Pregunta> Listar()
        {
            List<Tipo_Pregunta> lista = new List<Tipo_Pregunta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerTipo_Pregunta", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Tipo_Pregunta()
                                {
                                    IdTipo_pregunta = Convert.ToInt32(dr["IdTipo_pregunta"]),
                                    Descripcion = dr["Descripcion"].ToString()
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Tipo_Pregunta>();

            }
            return lista;
        }

    }
}