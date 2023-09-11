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
    public class Usuarios
    {
        string cn = ConfigurationManager.ConnectionStrings["DBSISTEMAstring"].ToString();

        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    oIdDepartamento = new Departamento() { ID = Convert.ToInt32(dr["IdDepartamento"]), nombre = dr["nombre"].ToString() },
                                    oIdRol = new tipo_usuario() { ID = Convert.ToInt32(dr["IdRol"]), nombret = dr["nombret"].ToString() },
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellido_paterno = dr["Apellido_paterno"].ToString(),
                                    Apellido_materno = dr["Apellido_materno"].ToString(),
                                    Telefono = dr["Telefono"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Status = Convert.ToBoolean(dr["Status"])
                                });
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Usuario>();

            }
            return lista;
        }


        public int Registrar(Usuario obj, out string mensaje)
        {
            int idautogenerado = 0;
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("IdDepartamento", obj.oIdDepartamento.ID);
                    cmd.Parameters.AddWithValue("IdRol", obj.oIdRol.ID);
                    cmd.Parameters.AddWithValue("Apellido_paterno", obj.Apellido_paterno);
                    cmd.Parameters.AddWithValue("Apellido_materno", obj.Apellido_materno);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Status", obj.Status);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    //mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                mensaje = ex.Message;
            }
            return idautogenerado;
        }

        public bool Editar(Usuario obj, out string mensaje)
        {
            bool resultado = false; //Debe ir false
            mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("IdDepartamento", obj.oIdDepartamento.ID);
                    cmd.Parameters.AddWithValue("IdRol", obj.oIdRol.ID);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellido_paterno", obj.Apellido_paterno);
                    cmd.Parameters.AddWithValue("Apellido_materno", obj.Apellido_materno);
                    cmd.Parameters.AddWithValue("Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Status", obj.Status);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    //mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje = ex.Message;
            }
            return resultado;
        }

        public bool Eliminar(int id, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", id);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    resultado = Convert.ToBoolean(cmd.Parameters["@Resultado"].Value);
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

        public int LoginUsuario(string Usuario, string Clave)
        {
            int respuesta = 0;
            string mensaje = string.Empty;
            using (SqlConnection oConexion = new SqlConnection(cn))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_LoginUsuario", oConexion);
                    cmd.Parameters.AddWithValue("Correo", Usuario);
                    cmd.Parameters.AddWithValue("Clave", Clave);
                    cmd.Parameters.Add("IdUsuario", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["IdUsuario"].Value);

                }

                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }
            return respuesta;
        }



        //public List<Usuario> Find(Usuario ID)
        //{
        //    List<Usuario> lista = new List<Usuario>();

        //    using (SqlConnection oconexion = new SqlConnection(cn))
        //    {
        //        SqlCommand cmd = oconexion.CreateCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "sp_ObtenerUsuarioID";
        //        cmd.Parameters.AddWithValue("@Nombre", ID);
        //        cmd.Parameters.AddWithValue("@Correo", ID);
        //        SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
        //        DataTable DT = new DataTable();

        //        oconexion.Open();
        //        sqlDA.Fill(DT);
        //        oconexion.Close();

        //        foreach (DataRow dr in DT.Rows)
        //        {
        //            lista.Add(
        //                new Usuario()
        //                {
        //                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
        //                    //oIdDepartamento = new Departamento() { ID = Convert.ToInt32(dr["IdDepartamento"]), nombre = dr["nombre"].ToString() },
        //                    //oIdRol = new tipo_usuario() { ID = Convert.ToInt32(dr["IdRol"]), nombret = dr["nombret"].ToString() },
        //                    Nombres = dr["Nombres"].ToString(),
        //                    Apellido_paterno = dr["Apellido_paterno"].ToString(),
        //                    Apellido_materno = dr["Apellido_materno"].ToString(),
        //                    Telefono = dr["Telefono"].ToString(),
        //                    Correo = dr["Correo"].ToString()
        //                });
        //        }
        //    }
        //    return lista;
        //}

        public List<Usuario> Find(Usuario ID)
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioID", oconexion);

                cmd.Parameters.AddWithValue("Nombres", ID.Nombres);
                cmd.Parameters.AddWithValue("IdDepartamento", ID.oIdDepartamento.ID);
                cmd.Parameters.AddWithValue("IdRol", ID.oIdRol.ID);
                cmd.Parameters.AddWithValue("Apellido_paterno", ID.Apellido_paterno);
                cmd.Parameters.AddWithValue("Apellido_materno", ID.Apellido_materno);
                cmd.Parameters.AddWithValue("Telefono", ID.Telefono);
                cmd.Parameters.AddWithValue("Correo", ID.Correo);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDA = new SqlDataAdapter(cmd);
                DataTable DT = new DataTable();

                oconexion.Open();
                sqlDA.Fill(DT);
                oconexion.Close();

                foreach (DataRow dr in DT.Rows)
                {
                    lista.Add(
                        new Usuario()
                        {
                            Nombres = dr["Nombres"].ToString(),
                            oIdDepartamento = new Departamento() { ID = Convert.ToInt32(dr["IdDepartamento"]), nombre = dr["nombre"].ToString() },
                            oIdRol = new tipo_usuario() { ID = Convert.ToInt32(dr["IdRol"]), nombret = dr["nombret"].ToString() },
                            Apellido_paterno = dr["Apellido_paterno"].ToString(),
                            Apellido_materno = dr["Apellido_materno"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                }
            }
            return lista;
        }

    }
}