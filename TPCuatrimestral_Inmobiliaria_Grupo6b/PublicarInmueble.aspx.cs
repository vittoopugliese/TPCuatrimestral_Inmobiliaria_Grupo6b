using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class PublicarInmueble : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarPublicacion_Click(object sender, EventArgs e)
        {


            try
            {
             
                string ruta = Server.MapPath("./pictures/");
                List<Imagenes> imagenesSubidas = new List<Imagenes>(); // Lista para guardar los nombres
                Propiedad propiedad = new Propiedad();
                foreach (HttpPostedFile archivo in agregarImagen.PostedFiles)
                {
                
                    if (archivo.ContentLength > 0) // Verifica que el archivo no esté vacío
                    {
                        // Genera un nombre único para evitar sobreescrituras (ej: GUID + ID de propiedad)
                        
                        string nombreArchivo = $"{propiedad.IdPropiedad}-{Guid.NewGuid()}.jpeg";
                        
                        string rutaCompleta = Path.Combine(ruta, nombreArchivo);

                        archivo.SaveAs(rutaCompleta); // Guarda el archivo

                        // Agrega la imagen a la lista
                        imagenesSubidas.Add(new Imagenes
                        {
                            nombreImagen = nombreArchivo
                        });

                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}