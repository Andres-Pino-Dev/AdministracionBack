using ProyectoAdministración.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoAdministración.Data
{
    public class DepartamentoCargoStore
    {

        public static List<Departamento> ListarDepartamentos()
        {
            List<Departamento> oListaUsuario = new List<Departamento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_departamentos", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Departamento()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                codigo = dr["codigo"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                activo = dr["activo"].ToString(),
                                idUsuarioCreacion = dr["idUsuarioCreacion"].ToString(),
                               
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

        public static List<Departamento> ListarCargos()
        {
            List<Departamento> oListaUsuario = new List<Departamento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_listar_cargos", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Departamento()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                codigo = dr["codigo"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                activo = dr["activo"].ToString(),
                                idUsuarioCreacion = dr["idUsuarioCreacion"].ToString(),

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
    }
}