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
            // este cambio lo comento para que no genere problemas a mis compañeos, es basicamente
            // un cambio que implica un permiso para ingresar basado en el rol de usuario

            //if (Session["usuario"] == null)
            //{
            //    Session["urlGuardada"] = "PublicarInmueble.aspx"; // Guardar la URL actual para redirigir después del login
            //    Session.Add("Error", "Debe iniciar sesión para acceder a esta página.");
            //    Response.Redirect("Login.aspx", false);

               
            //}
            //else if (Session["IdRol"] == null || (int)Session["IdRol"] != 1)
            //{
            //    Session.Add("Error", "No tiene permisos para acceder a esta página.");
            //    Response.Redirect("Error.aspx", false);
            //}
        }

        protected void btnGuardarPublicacion_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("InmuebleSeleccionado.aspx");
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