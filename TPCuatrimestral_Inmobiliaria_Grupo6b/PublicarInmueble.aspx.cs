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

                string tipoOpe = selectTipoOperacion.Value;
                string tipoProp = selectTipoPropiedad.Value;
                string direccion = inputdireccion.Value;
                string localidad = inputlocalidad.Value;
                string provincia = selectProvincia.Value;
                string titulo = texttitulo.Value;
                string tipoDueno = txtTipoDueno.Value;
                string email = inputEmail.Value;
                string descripcion = txtDescripcion.Value;

                bool balcon = inputBalcon.Checked;
                bool patio = inputPatio.Checked;
                bool cochera = inputCochera.Checked;

                int whatsapp;
                int.TryParse(txtWhatsapp.Text, out whatsapp);

                int cantAmbientes;
                int.TryParse(txtcantAmbientes.Text, out cantAmbientes);

                int anosDeAntiguedad;
                int.TryParse(textanosAntiguedad.Text, out anosDeAntiguedad);

                int precio;
                int.TryParse(txtPrecio.Text, out precio);

                int banos;
                int.TryParse(txtCantBanos.Text, out banos);

                int dormitorios;
                int.TryParse(inputCantDormitorios.Text, out dormitorios);

                //alert para texto
                if (!string.IsNullOrEmpty(descripcion))
                {
                    string script = $"alert('{descripcion.Replace("'", "\\'")}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "alert('El valor es null');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                }

                //alert para bool
                if (cochera)
                {
                    string script = "alert('Tiene cochera');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    string script = "alert('No tiene cochera');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }

                //alert para int
                string msj5 = $"alert('{whatsapp},{cantAmbientes},{anosDeAntiguedad},{precio},{banos},{dormitorios}');";
                ClientScript.RegisterStartupScript(this.GetType(), "alertExito", msj5, true);

                string ruta = Server.MapPath("./pictures/");
                
                List<Imagenes> imagenesSubidas = new List<Imagenes>(); // Lista para guardar los nombres
                Propiedad propiedad = new Propiedad();
                //propiedad.IdPropiedad = 5; //prueba del id de la propiedad para el nombre de la imagen
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
                //Response.Redirect("InmuebleSeleccionado.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}