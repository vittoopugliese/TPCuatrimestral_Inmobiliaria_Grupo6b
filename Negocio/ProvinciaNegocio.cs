using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listar()
        {
            List<Provincia> provincias = new List<Provincia>();
            BaseDeDatos db = new BaseDeDatos();
            try
            {
                db.setearConsulta("SELECT IdProvincia, Nombre FROM Provincia ORDER BY Nombre");
                db.ejecutarLectura();
                while (db.Lector.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.IdProvincia = (int)db.Lector["IdProvincia"];
                    provincia.Nombre = db.Lector["Nombre"].ToString();
                    provincias.Add(provincia);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar provincias: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }
            return provincias;
        }
    }
}
