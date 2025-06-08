using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class LoginNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            BaseDeDatos bd = new BaseDeDatos();

            try
            {
                bd.setearConsulta("SELECT IdUsuario, Email, Contrasena, IdRol FROM Usuario WHERE Email = @Email AND Contrasena = @Contrasena");
                bd.setearParametro("@Email", usuario.Email);
                bd.setearParametro("@Contrasena", usuario.Contrasena);
                bd.ejecutarLectura();

                while (bd.Lector.Read())
                {
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
