using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ImagenNegocio
    {
        private BaseDeDatos db;

        public ImagenNegocio()
        {
            db = new BaseDeDatos();
        }

        public void Agregar(Imagenes imagen)
        {
            try
            {
                db.setearConsulta(@"INSERT INTO IMAGENES 
                              (IdPropiedad, UrlImagen, EsPortada) 
                              VALUES 
                              (@IdPropiedad, @UrlImagen, @EsPortada)");

                db.agregarParametro("@IdPropiedad", imagen.IdPropiedad);
                db.agregarParametro("@UrlImagen", imagen.UrlImagen);
                db.agregarParametro("@EsPortada", imagen.EsPortada);

                db.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar imagen: " + ex.Message, ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public List<Imagenes> ListarPorPropiedad(int idPropiedad)
        {
            List<Imagenes> imagenes = new List<Imagenes>();

            try
            {
                db.setearConsulta("SELECT * FROM IMAGENES WHERE IdPropiedad = @IdPropiedad");
                db.agregarParametro("@IdPropiedad", idPropiedad);
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Imagenes img = new Imagenes
                    {
                        Id = Convert.ToInt32(db.Lector["IdImagen"]),
                        IdPropiedad = Convert.ToInt32(db.Lector["IdPropiedad"]),
                        UrlImagen = db.Lector["UrlImagen"].ToString(),
                        EsPortada = Convert.ToBoolean(db.Lector["EsPortada"])
                    };
                    imagenes.Add(img);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar imágenes: " + ex.Message, ex);
            }
            finally
            {
                db.cerrarConexion();
            }

            return imagenes;
        }
    }
}
