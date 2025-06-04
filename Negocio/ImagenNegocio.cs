using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenNegocio
    {

        public List<Imagenes> listar()
        {
            List<Imagenes> lista = new List<Imagenes>();
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Descripcion, Url FROM IMAGENES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagenes img = new Imagenes();
                    img.idImagen = (int)datos.Lector["Id"];
                    img.nombreImagen = (string)datos.Lector["nombreImagen"];
                    img.idPropiedadImagen = (int)datos.Lector["idPropiedadImagen"];
                    lista.Add(img);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
