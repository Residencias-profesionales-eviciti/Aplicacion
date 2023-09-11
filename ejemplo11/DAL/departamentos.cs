
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
    public class departamentos
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();

        public List<Departamento> Listar()
        {
            List<Departamento> lista = new List<Departamento>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerDepartamentos", oconexion);

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Departamento()
                                {
                                    ID = Convert.ToInt32(dr["ID"]),
                                    nombre = dr["nombre"].ToString(),
                                    Status = Convert.ToBoolean(dr["Status"])
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Departamento>();

            }
            return lista;
        }


        public int Registrar(Departamento obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarDepartamento", oconexion);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("Status", obj.Status);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Departamento obj, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarDepartamento", oconexion);
                    cmd.Parameters.AddWithValue("ID", obj.ID);
                    cmd.Parameters.AddWithValue("nombre", obj.nombre);
                    cmd.Parameters.AddWithValue("Status", obj.Status);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    //mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int ID, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarDepartamento", oconexion);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public List<Departamento> Find(int ID)
        {
            List<Departamento> lista = new List<Departamento>();

            using (SqlConnection oconexion = new SqlConnection(cn))
            {
                SqlCommand cmd = oconexion.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ObtenerDepartamentoID";
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();

                oconexion.Open();
                sqlDA.Fill(DT);
                oconexion.Close();

                foreach (DataRow dr in DT.Rows)
                {
                    lista.Add(
                        new Departamento()
                        {
                            nombre = dr["nombre"].ToString(),
                            Status = Convert.ToBoolean(dr["Status"])
                        });
                }
            }
            return lista;
        }


    }
}