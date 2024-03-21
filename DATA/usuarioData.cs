using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi2.Models;

namespace WebApi2.DATA
{
    public class usuarioData
    {

        public static bool Registrar(usuario oUsuario)
        {
            using(SqlConnection oConexion = new SqlConnection (Conexion.RutaConexion))
            {

                SqlCommand  cmd = new SqlCommand ("u_registrar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }

        public static bool Modificar(usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.RutaConexion))
            {

                SqlCommand cmd = new SqlCommand("u_modificar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("@id", oUsuario.Id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }

        public static List<usuario> Listar()
        {
            List<usuario> oListaUsuario = new List<usuario>();

            using (SqlConnection oConexion = new SqlConnection (Conexion.RutaConexion))
            {
                SqlCommand cmd = new SqlCommand("u_listar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new usuario()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["nombre"].ToString (),
                                Correo= dr["correo"].ToString (),
                                Fecha_registro= Convert.ToDateTime (  dr["Fecha_registro"].ToString ())
                            }) ;
                        }
                    }
                    return oListaUsuario;
                }
                catch (Exception ex)
                {

                    return oListaUsuario;
                }
            }
        }



        public static usuario  obtener(int id)
        {
            usuario oUsuario = new usuario();

            using (SqlConnection oConexion = new SqlConnection(Conexion.RutaConexion))
            {
                SqlCommand cmd = new SqlCommand("u_obtener", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("id", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUsuario = new usuario()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Nombre = dr["nombre"].ToString(),
                                Correo = dr["correo"].ToString(),
                                Fecha_registro = Convert.ToDateTime(dr["Fecha_registro"].ToString())
                            };
                        }
                    }
                    return oUsuario;
                }
                catch (Exception ex)
                {

                    return oUsuario;
                }
            }
        }





        public static bool eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.RutaConexion))
            {

                SqlCommand cmd = new SqlCommand("u_eliminar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }


    }
}