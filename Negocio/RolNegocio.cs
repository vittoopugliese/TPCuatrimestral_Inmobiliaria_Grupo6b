using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class RolNegocio
    {
        public List<KeyValuePair<int, string>> ObtenerRoles()
        {
            List<KeyValuePair<int, string>> listaRoles = new List<KeyValuePair<int, string>>();
            BaseDeDatos db = new BaseDeDatos();

            try
            {
                db.setearConsulta("SELECT IdRol, Descripcion FROM Rol ORDER BY Descripcion");
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    listaRoles.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(db.Lector["IdRol"]),
                        db.Lector["Descripcion"].ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, contacte al administrador: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }

            return listaRoles;
        }
    }
}

