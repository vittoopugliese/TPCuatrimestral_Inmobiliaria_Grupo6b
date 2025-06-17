using System;
using System.Collections.Generic;
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
                bd.setearConsulta("SELECT IdUsuario, Email, Contrasena, IdRol FROM Usuario WHERE Email = @Email AND Contrasena = @Contrasena");
                bd.setearParametro("@Email", usuario.Email);
                bd.setearParametro("@Contrasena", usuario.Contrasena);
                bd.ejecutarLectura();

                if (bd.Lector.Read())
                {
                    usuario.IdUsuario = (int)bd.Lector["IdUsuario"];
                    usuario.Email = (string)bd.Lector["Email"];
                    usuario.IdRol = (int)bd.Lector["IdRol"];
                    usuario.Contrasena = (string)bd.Lector["Contrasena"];
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
                datos.setearConsulta("SELECT IdUsuario, Email, Contrasena, IdRol FROM Usuario WHERE Email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.Email = (string)datos.Lector["Email"];
                    usuario.Contrasena = (string)datos.Lector["Contrasena"];
                    usuario.IdRol = (int)datos.Lector["IdRol"];
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
    }
}
