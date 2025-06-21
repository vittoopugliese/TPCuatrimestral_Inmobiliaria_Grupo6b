using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class InmuebleSeleccionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    txtNombreApellido.Text = $"{usuario.Nombre} {usuario.Apellido}";
                    txtTelefono.Text = usuario.Telefono;
                    txtEmail.Text = usuario.Email;

                }

                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    CargarPropiedad(idPropiedad);
                }
                else
                {
                    // Mejor manejo de error que simplemente redirigir
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "alert('No se ha especificado una propiedad válida.'); window.location.href='Default.aspx';", true);
                }
                string script = @"
                     document.addEventListener('DOMContentLoaded', function() {
                    var myCarousel = document.querySelector('#carouselExampleControls');
                    var carousel = new bootstrap.Carousel(myCarousel, {
                        interval: false
                });

                setTimeout(function() {
                        carousel.cycle();
                    }, 5000);
                 });";

                ScriptManager.RegisterStartupScript(this, GetType(), "initCarousel", script, true);
            }
        }

        private void CargarPropiedad(int idPropiedad)
        {
            try
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad != null)
                {
                    // Cargar datos en los controles
                    CargarDatosPropiedad(propiedad);

                    // Cargar imágenes
                    CargarImagenes(propiedad.IdPropiedad);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "alert('La propiedad solicitada no existe.'); window.location.href='Default.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                    $"alert('Error al cargar la propiedad: {ex.Message}');", true);
            }
        }

        private void CargarDatosPropiedad(Propiedad propiedad)
        {
            //// Título

            direccionPropiedad.InnerHtml = $"<span class='fa-solid fa-location-dot' style='margin-right: 10px'></span>{propiedad.Direccion}, {propiedad.Localidad}";

            if (propiedad.Baños == 0)
            {
                banoPropiedad.InnerText = " Sin baño";
            }
            else if (propiedad.Baños > 1)
            {
                banoPropiedad.InnerText = $"{propiedad.Baños} baños";
            }
            else if (propiedad.Baños == 1)
            {
                banoPropiedad.InnerText = $"{propiedad.Baños} baño";

            }

            if (propiedad.Cochera)
            {
                cocheraPropiedad.InnerHtml = "Cochera";
            }
            else
            {
                colCochera.Visible = false;
            }


            if (propiedad.Dormitorios == 0)
            {
                dormitoriosPropiedad.InnerText = " Sin dormitorios";
            }
            else if (propiedad.Dormitorios > 1)
            {
                dormitoriosPropiedad.InnerText = $"{propiedad.Dormitorios} dormitorios";
            }
            else if (propiedad.Dormitorios == 1)
            {
                dormitoriosPropiedad.InnerText = $"{propiedad.Dormitorios} dormitorio";

            }

            if (propiedad.ConBalcon)
            {
                balconPropiedad.InnerHtml = "Balcón";
            }
            else
            {
                colBalcon.Visible = false;
            }
            //bool credito
            if (!propiedad.AptoCredito)
            {
                creditoPropiedad.Visible = false;
            }

            // Precio

            precioCompleto.InnerText = $"{propiedad.Moneda} {propiedad.Precio}";
            expensasPropiedad.InnerText = $"Expensas: {propiedad.Moneda} {propiedad.Expensas} ";

            // Fecha publicación
            fechaPublicacionPropiedad.InnerText = $"Publicado el {propiedad.FechaPublicacion.ToString("dd/MM/yyyy")}";

            //Cant. Ambientes
            if (propiedad.Ambientes == 1)
            {
                cantAmbientes.InnerText = $"{propiedad.Ambientes} Ambiente";
            }
            else if (propiedad.Ambientes > 1)
            {
                cantAmbientes.InnerText = $"{propiedad.Ambientes} Ambientes";
            }

            //Superficie Total
            superficieTot.InnerText = $"{propiedad.Sup_m2_Total} Mts2";

            //Superficie Cubierta
            superCub.InnerText = $"{propiedad.Sup_m2_Cubierto} Mts2";

            //bool patio
            if (!propiedad.ConPatio)
            {
                divPatio.Visible = false;
            }

            //Años de antiguedad
            antigue.InnerText = $"{propiedad.AnosAntiguedad} Años de antiguedad";

            // Descripción
            tituloPropiedad.InnerText = $"{propiedad.Tipo} en {propiedad.TipoOperacion} en {propiedad.Localidad}";
            descripcionPropiedad.InnerText = $"{propiedad.Descripcion}";

            whatsappPropietario.InnerText = $"{propiedad.WhatsApp}";

            // Configurar botón de WhatsApp
            var botonWp = FindControl("botonWp") as Button;
            if (botonWp != null)
            {
                botonWp.OnClientClick = $"window.open('https://wa.me/{propiedad.WhatsApp}', '_blank'); return false;";
            }

            var emailPropietario = FindControl("emailPropietario") as HtmlAnchor;
            if (emailPropietario != null)
            {
                emailPropietario.HRef = $"mailto:{propiedad.Email}";
                emailPropietario.InnerText = propiedad.Email;
            }

            // Mostrar información del propietario
            nombrePropietario.InnerText = $"{propiedad.TipoDueno}";
            whatsappPropietario.InnerText = $"{propiedad.WhatsApp}";

            if (emailPropietario != null)
            {
                emailPropietario.HRef = $"mailto:{propiedad.Email}?subject=Consulta sobre {propiedad.Tipo} en {propiedad.Direccion}";
                emailPropietario.InnerHtml = $"<i class='fa-solid fa-envelope' style='margin-right: 10px'></i>{propiedad.Email}";
            }

            // Establecer asunto por defecto (esto puede quedarse aquí)
            txtAsunto.Text = $"Consulta sobre {propiedad.Tipo} en {propiedad.Direccion}";

            // Mensaje predefinido (esto puede quedarse aquí)
            txtMensaje.Text = $"Hola! Estoy interesado/a en la propiedad ubicada en {propiedad.Direccion}. Por favor, envíeme más información.\nSaludos cordiales!";
        }

        private void CargarImagenes(int idPropiedad)
        {
            try
            {
                string rutaImagenes = "/Images/";
                string rutaFisica = Server.MapPath(rutaImagenes);

                if (!Directory.Exists(rutaFisica))
                {
                    Directory.CreateDirectory(rutaFisica);
                }

                // Modificar el patrón de búsqueda para incluir el GUID
                var imagenes = Directory.GetFiles(rutaFisica, $"{idPropiedad}-*.jpeg")
                                      .Select(Path.GetFileName)
                                      .OrderBy(f => f)  // Ordenar para consistencia
                                      .ToList();

                if (imagenes.Any())
                {
                    bool first = true;
                    foreach (string imagen in imagenes)
                    {
                        HtmlGenericControl divItem = new HtmlGenericControl("div");
                        divItem.Attributes["class"] = first ? "carousel-item active" : "carousel-item";
                        first = false;

                        // Asegurarse de que la ruta sea correcta
                        string rutaCompleta = $"{rutaImagenes}{imagen}";

                        Image img = new Image();
                        img.ImageUrl = rutaCompleta;
                        img.Width = Unit.Percentage(100);
                        img.CssClass = "rounded";
                        img.AlternateText = "Imagen de la propiedad";
                        img.Style["max-height"] = "500px"; // Ajustar altura máxima
                        img.Style["object-fit"] = "cover"; // Mantener proporciones

                        divItem.Controls.Add(img);
                        carouselInner.Controls.Add(divItem);
                    }
                }
                else
                {
                    // Imagen por defecto
                    HtmlGenericControl divItem = new HtmlGenericControl("div");
                    divItem.Attributes["class"] = "carousel-item active";

                    Image img = new Image();
                    img.ImageUrl = $"{rutaImagenes}default.jpg";
                    img.Width = Unit.Percentage(100);
                    img.CssClass = "rounded";
                    img.AlternateText = "Imagen por defecto";
                    img.Style["max-height"] = "500px";
                    img.Style["object-fit"] = "cover";

                    divItem.Controls.Add(img);
                    carouselInner.Controls.Add(divItem);
                }
            }
            catch (Exception ex)
            {
                // Registrar error más detallado
                System.Diagnostics.Debug.WriteLine($"Error al cargar imágenes para propiedad {idPropiedad}: {ex.ToString()}");

                // Mostrar mensaje al usuario
                ScriptManager.RegisterStartupScript(this, GetType(), "showImageError",
                    $"console.error('Error al cargar imágenes: {ex.Message}');", true);
            }
        }

        protected void btnContactar_Click(object sender, EventArgs e)
        {
            string script = "alert('¡Mensaje enviado correctamente!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        protected void botonWp_Click(object sender, EventArgs e)
        {

            try
            {
                // Obtener los datos del formulario
                string nombre = txtNombreApellido.Text;
                string telefono = txtTelefono.Text;
                string email = txtEmail.Text;
                string asunto = txtAsunto.Text;
                string mensaje = txtMensaje.Text;
                //bool recibirCopia = chkRecibirCopia.Checked;
                string whatsappUrl = "https://wa.me/521234567890";
                string script = $"window.open('{whatsappUrl}', '_blank');";
                ClientScript.RegisterStartupScript(this.GetType(), "openWhatsApp", script, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                 $"Swal.fire('Error', 'No se pudo enviar el mensaje: {ex.Message}', 'error');", true);
            }
        }
        protected void btnEnviarConsulta_Click(object sender, EventArgs e)
        {

        }
    }
}
