using ProyectoAdministración.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoAdministración.Data
{
    public class UsersStore
    {

        public static bool Registrar(User usuarioTemp)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_insertar_users", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuarioTemp.usuario);
                cmd.Parameters.AddWithValue("@primerNombre", usuarioTemp.primerNombre);
                cmd.Parameters.AddWithValue("@segundoNombre", usuarioTemp.segundoNombre);
                cmd.Parameters.AddWithValue("@segundoApellido", usuarioTemp.segundoApellido);
                cmd.Parameters.AddWithValue("@idDepartamento", usuarioTemp.idDepartamento);
                cmd.Parameters.AddWithValue("@idCargo", usuarioTemp.idCargo);

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

        public static bool Modificar(User usuarioTemp)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_actualizar_users", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuarioTemp.usuario);
                cmd.Parameters.AddWithValue("@primerNombre", usuarioTemp.primerNombre);
                cmd.Parameters.AddWithValue("@segundoNombre", usuarioTemp.segundoNombre);
                cmd.Parameters.AddWithValue("@segundoApellido", usuarioTemp.segundoApellido);
                cmd.Parameters.AddWithValue("@idDepartamento", usuarioTemp.idDepartamento);
                cmd.Parameters.AddWithValue("@idCargo", usuarioTemp.idCargo);
                cmd.Parameters.AddWithValue("@id", usuarioTemp.id);

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

        public static List<User> Listar()
        {
            List<User> oListaUsuario = new List<User>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_users", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new User()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                usuario = dr["usuario"].ToString(),
                                primerNombre = dr["primerNombre"].ToString(),
                                segundoNombre = dr["segundoNombre"].ToString(),
                                segundoApellido = dr["segundoApellido"].ToString(),
                                idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                idCargo = Convert.ToInt32(dr["idCargo"])
                            });
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

        public static List<User> ListarByDepartamentos(int departamento)
        {
            List<User> oListaUsuario = new List<User>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_users_by_departamento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_departamento", departamento);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new User()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                usuario = dr["usuario"].ToString(),
                                primerNombre = dr["primerNombre"].ToString(),
                                segundoNombre = dr["segundoNombre"].ToString(),
                                segundoApellido = dr["segundoApellido"].ToString(),
                                idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                idCargo = Convert.ToInt32(dr["idCargo"])
                            });
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


        public static List<User> ListarByDepartamentoAndCargo(int departamento,int cargo)
        {
            List<User> oListaUsuario = new List<User>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_users", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_departamento", departamento);
                cmd.Parameters.AddWithValue("@id_cargo", cargo);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new User()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                usuario = dr["usuario"].ToString(),
                                primerNombre = dr["primerNombre"].ToString(),
                                segundoNombre = dr["segundoNombre"].ToString(),
                                segundoApellido = dr["segundoApellido"].ToString(),
                                idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                idCargo = Convert.ToInt32(dr["idCargo"])
                            });
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
        public static User Obtener(int idusuario)
        {
            User usuarioTemp = new User();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", idusuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            usuarioTemp = new User()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                usuario = dr["usuario"].ToString(),
                                primerNombre = dr["primerNombre"].ToString(),
                                segundoNombre = dr["segundoNombre"].ToString(),
                                segundoApellido = dr["segundoApellido"].ToString(),
                                idDepartamento = Convert.ToInt32(dr["idDepartamento"]),
                                idCargo = Convert.ToInt32(dr["idCargo"])
                            };
                        }

                    }



                    return usuarioTemp;
                }
                catch (Exception ex)
                {
                    return usuarioTemp;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_eliminar_users", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
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