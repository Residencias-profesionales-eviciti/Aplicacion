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
    public class EncuestaPreguntas
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();

        public List<Encuesta_Pregunta> Listar()
        {
            List<Encuesta_Pregunta> lista = new List<Encuesta_Pregunta>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerEncuestaPregunta", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Encuesta_Pregunta()
                                {
                                    IdEncuesta_pregunta = Convert.ToInt32(dr["IdEncuesta_pregunta"]),
                                    oIdEncuesta = new Encuesta() { IdEncuesta = Convert.ToInt32(dr["IdEncuesta"]), Nombre = dr["Nombre"].ToString() },
                                    Titulo = dr["Titulo"].ToString(),
                                    Forma_Opcion = dr["Forma_Opcion"].ToString(),
                                    oIdTipo_pregunta = new Tipo_Pregunta() { ID = Convert.ToInt32(dr["IdTipo_pregunta"]), Descripcion = dr["Descripcion"].ToString() }    
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Encuesta_Pregunta>();

            }
            return lista;
        }


        public int Registrar(Encuesta_Pregunta obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEncuestaPregunta", oconexion);
                    cmd.Parameters.AddWithValue("Titulo", obj.Titulo);
                    cmd.Parameters.AddWithValue("IdTipo_pregunta", obj.oIdTipo_pregunta.ID);
                    cmd.Parameters.AddWithValue("IdEncuesta", obj.oIdEncuesta.IdEncuesta);

                    cmd.Parameters.AddWithValue("Forma_Opcion", obj.Forma_Opcion);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }

            return idautogenerado;

        }

        public bool Editar(Encuesta_Pregunta obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarEncuestaPregunta", oconexion);
                    cmd.Parameters.AddWithValue("Titulo", obj.Titulo);
                    //cmd.Parameters.AddWithValue("IdEncuesta", obj.oIdEncuesta.IdEncuesta);
                    cmd.Parameters.AddWithValue("Forma_Opcion", obj.Forma_Opcion);
                    

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }

            }
            catch(Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

    }
}