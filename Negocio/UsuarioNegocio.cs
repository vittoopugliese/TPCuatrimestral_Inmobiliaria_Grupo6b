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
    }
}
