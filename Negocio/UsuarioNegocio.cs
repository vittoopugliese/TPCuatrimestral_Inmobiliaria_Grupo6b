using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            BaseDeDatos db = new BaseDeDatos();
            try
            {
                db.setearConsulta("SELECT IdUsuario, Nombre, Email FROM Usuario ORDER BY Nombre");
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)db.Lector["IdUsuario"];
                    usuario.Nombre = db.Lector["Nombre"].ToString();
                    usuario.Email = db.Lector["Email"].ToString();
                    usuario.Apellido = db.Lector["Apellido"].ToString();
                    usuario.Contrasena = db.Lector["Contrasena"].ToString();
                    usuario.Telefono = db.Lector["Telefono"].ToString();
                    usuario.Direccion = db.Lector["Direccion"].ToString();
                    usuario.Localidad = db.Lector["Localidad"].ToString();
                    usuario.IdProvincia = (int)db.Lector["IdProvincia"];
                    usuario.IdRol = (int)db.Lector["IdRol"];
                    usuarios.Add(usuario);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar usuarios: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }
            return usuarios;
        }

        public int insertarNuevo(Usuario nuevo)
        {
            BaseDeDatos db = new BaseDeDatos();


            try
            {
                db.setearProcedimiento("SP_RegistrarUsuario");
                db.setearParametro("@Email", nuevo.Email);
                db.setearParametro("@Contrasena", nuevo.Contrasena);
                return db.ejecutarAccionScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public bool Loguear(Usuario usuario)
        {
            BaseDeDatos bd = new BaseDeDatos();

            try
            {
                bd.setearConsulta("SELECT IdUsuario, Email, Contrasena, IdRol, Nombre, Apellido, Telefono FROM Usuario WHERE Email = @Email AND Contrasena = @Contrasena");
                bd.setearParametro("@Email", usuario.Email);
                bd.setearParametro("@Contrasena", usuario.Contrasena);
                bd.ejecutarLectura();

                if (bd.Lector.Read())
                {
                    usuario.IdUsuario = (int)bd.Lector["IdUsuario"];
                    usuario.Email = (string)bd.Lector["Email"];
                    usuario.IdRol = (int)bd.Lector["IdRol"];
                    usuario.Contrasena = (string)bd.Lector["Contrasena"];
                    usuario.Nombre = bd.Lector["Nombre"].ToString();
                    usuario.Apellido = bd.Lector["Apellido"].ToString();
                    usuario.Telefono = bd.Lector["Telefono"].ToString();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar loguear al usuario", ex);
            }
            finally
            {
                bd.cerrarConexion();
            }
        }

        public Usuario BuscarPorEmail(string email)
        {
            Usuario usuario = null;
            BaseDeDatos datos = new BaseDeDatos();

            try
            {
                datos.setearConsulta("SELECT IdUsuario, Email, Contrasena, IdRol, Nombre, Apellido, Telefono FROM Usuario WHERE Email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Contrasena = (string)datos.Lector["Contrasena"];
                    usuario.IdRol = (int)datos.Lector["IdRol"];
                    usuario.Nombre = datos.Lector["Nombre"].ToString();
                    usuario.Apellido = datos.Lector["Apellido"].ToString();
                    usuario.Telefono = datos.Lector["Telefono"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return usuario;
        }

        public Usuario ActualizarPerfil(Usuario usuario)
        {
            BaseDeDatos db = new BaseDeDatos();
            try
            {
                db.setearProcedimiento("SP_ActualizarPerfil");
                db.setearParametro("@IdUsuario", usuario.IdUsuario);
                db.setearParametro("@Nombre", usuario.Nombre);
                db.setearParametro("@Apellido", usuario.Apellido);
                db.setearParametro("@Contrasena", usuario.Contrasena);
                db.setearParametro("@Telefono", usuario.Telefono);
                db.setearParametro("@Direccion", usuario.Direccion);
                db.setearParametro("@Localidad", usuario.Localidad);
                db.setearParametro("@IdProvincia", usuario.IdProvincia);
                db.setearParametro("@IdRol", usuario.IdRol);
                db.ejecutarAccion();
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        private Usuario MapearUsuario(SqlDataReader lector)
        {
            Usuario usuario = new Usuario();

            usuario.IdUsuario = lector["IdUsuario"] != DBNull.Value ? (int)lector["IdUsuario"] : 0;
            usuario.Nombre = lector["Nombre"] != DBNull.Value ? lector["Nombre"].ToString() : "";
            usuario.Apellido = lector["Apellido"] != DBNull.Value ? lector["Apellido"].ToString() : "";
            usuario.Email = lector["Email"] != DBNull.Value ? lector["Email"].ToString() : "";
            usuario.Contrasena = lector["Contrasena"] != DBNull.Value ? lector["Contrasena"].ToString() : "";
            usuario.Telefono = lector["Telefono"] != DBNull.Value ? lector["Telefono"].ToString() : "";
            usuario.Direccion = lector["Direccion"] != DBNull.Value ? lector["Direccion"].ToString() : "";
            usuario.Localidad = lector["Localidad"] != DBNull.Value ? lector["Localidad"].ToString() : "";
            usuario.IdProvincia = lector["IdProvincia"] != DBNull.Value ? (int)lector["IdProvincia"] : 0;
            usuario.IdRol = lector["IdRol"] != DBNull.Value ? (int)lector["IdRol"] : 0;

            return usuario;
        }

        public Usuario ObtenerPorId(int id)
        {
            BaseDeDatos db = new BaseDeDatos();
            Usuario usuario = new Usuario();

            try
            {
                db.setearConsulta("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario");
                db.setearParametro("@IdUsuario", id);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    usuario = MapearUsuario(db.Lector); // Pasamos el lector activo
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener usuario por ID", ex);
            }
            finally
            {
                db.cerrarConexion();
            }

            return usuario;
        }


    }
}
