using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        private List<Mensajes> _mensajesLista = new List<Mensajes>();
        public List<Mensajes> MensajesLista
        {
            get { return _mensajesLista; }
            set { _mensajesLista = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idPropiedad))
            {
                CargarPropiedad(idPropiedad);

                MensajeNegocio mensajeNegocio = new MensajeNegocio();
                MensajesLista = mensajeNegocio.listar(idPropiedad);

                if (!IsPostBack)
                {
                    rptMensajes.DataSource = MensajesLista;
                    rptMensajes.DataBind();
                }

                CargarImagenes(idPropiedad);
            }

            if (!IsPostBack && Session["usuario"] != null)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                txtNombreApellido.Text = $"{usuario.Nombre} {usuario.Apellido}";
                txtTelefono.Text = usuario.Telefono;
                txtEmail.Text = usuario.Email;

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
            txtTitulo.InnerHtml = $"<h4>{propiedad.Titulo}</h4>";


            direccionPropiedad.InnerHtml = $"<span class='fa-solid fa-location-dot' style='margin-right: 10px'></span>{propiedad.Direccion}, {propiedad.Localidad}";

            //baño
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

            //cochera
            if (propiedad.Cochera)
            {
                cocheraPropiedad.InnerHtml = "Cochera";
            }
            else
            {
                colCochera.Visible = false;
            }

            //dormitorios
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

            //balcon
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
            superficieTot.InnerText = $"Sup. Total {propiedad.Sup_m2_Total} Mts2";

            //Superficie Cubierta
            superCub.InnerText = $"Sup. Cubierta {propiedad.Sup_m2_Cubierto} Mts2";

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

            // Mostrar información del propietario
            nombrePropietario.InnerText = $"{propiedad.TipoDueno}";
            whatsappPropietario.InnerText = $"{propiedad.WhatsApp}";


            // Establecer asunto por defecto (esto puede quedarse aquí)
            txtAsunto.Text = $"Consulta sobre {propiedad.Tipo} en {propiedad.Direccion}";

            // Mensaje predefinido (esto puede quedarse aquí)
            txtMensaje.Text = $"Estoy interesado/a en la propiedad ubicada en {propiedad.Direccion}. Por favor, envíeme más información.\nSaludos cordiales!";


        }

        private void CargarImagenes(int idPropiedad)
        {
            try
            {
                // Limpiar el carrousel antes de agregar nuevas imágenes
                carouselInner.Controls.Clear();

                string rutaImagenes = "/Images/";
                string rutaFisica = Server.MapPath(rutaImagenes);

                if (!Directory.Exists(rutaFisica))
                {
                    Directory.CreateDirectory(rutaFisica);
                }

                var imagenes = Directory.GetFiles(rutaFisica, $"{idPropiedad}-*.jpeg")
                                      .Select(Path.GetFileName)
                                      .OrderBy(f => f)
                                      .ToList();

                if (imagenes.Any())
                {
                    bool first = true;
                    foreach (string imagen in imagenes)
                    {
                        HtmlGenericControl divItem = new HtmlGenericControl("div");
                        divItem.Attributes["class"] = first ? "carousel-item active" : "carousel-item";
                        first = false;

                        string rutaCompleta = $"{rutaImagenes}{imagen}";

                        Image img = new Image();
                        img.ImageUrl = rutaCompleta;
                        img.Width = Unit.Percentage(100);
                        img.CssClass = "rounded";
                        img.AlternateText = "Imagen de la propiedad";
                        img.Style["max-height"] = "500px";
                        img.Style["object-fit"] = "cover";

                        divItem.Controls.Add(img);
                        carouselInner.Controls.Add(divItem);
                    }
                }
                else
                {
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
                System.Diagnostics.Debug.WriteLine($"Error al cargar imágenes para propiedad {idPropiedad}: {ex}");
                ScriptManager.RegisterStartupScript(this, GetType(), "showImageError",
                    $"console.error('Error al cargar imágenes: {ex.Message}');", true);
            }
        }

        

        protected void btnContactar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar ID de propiedad
                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                // 2. Obtener la propiedad y el usuario propietario
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'La propiedad especificada no existe.', 'error');", true);
                    return;
                }

                // 3. Obtener el estado del checkbox
                bool recibirCopia = checkRecibirCopia.Checked;

                // 4. Enviar el correo
                EmailService emailservice = new EmailService();
                emailservice.armarCorreoContactar(
                    txtNombreApellido.Text,
                    txtTelefono.Text,
                    txtAsunto.Text,
                    txtEmail.Text, // Email del cliente
                    txtMensaje.Text,
                    propiedad.Email, // Email del propietario
                    recibirCopia
                );

                emailservice.enviarCorreo();

                ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess",
                    "Swal.fire('Éxito', 'Mensaje enviado correctamente" +
                    (recibirCopia ? " (se envió copia a tu email)" : "") +
                    "', 'success');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                    $"Swal.fire('Error', 'No se pudo enviar el mensaje: {HttpUtility.JavaScriptStringEncode(ex.Message)}', 'error');", true);
            }
        }

        protected void botonWp_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtener ID de propiedad
                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                // 2. Obtener datos de la propiedad
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null || string.IsNullOrEmpty(propiedad.WhatsApp))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'No hay número de WhatsApp asociado.', 'error');", true);
                    return;
                }

                // 3. Formatear número de WhatsApp correctamente
                string numeroWhatsApp = FormatWhatsAppNumber(propiedad.WhatsApp);

                if (string.IsNullOrEmpty(numeroWhatsApp))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Número de WhatsApp no válido.', 'error');", true);
                    return;
                }

                // 4. Obtener datos del formulario
                string nombre = txtNombreApellido.Text;
                string telefono = txtTelefono.Text;
                string mensaje = txtMensaje.Text;

                // 5. Crear mensaje para WhatsApp
                string mensajeCodificado = WebUtility.UrlEncode(
                    $"Hola! Soy {nombre}.\n" +
                    $"{mensaje}");

                // 6. Crear URL de WhatsApp
                string whatsappUrl = $"https://wa.me/{numeroWhatsApp}?text={mensajeCodificado}";

                // 7. Abrir WhatsApp
                string script = $"window.open('{whatsappUrl}', '_blank');";
                ClientScript.RegisterStartupScript(this.GetType(), "openWhatsApp", script, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                    $"Swal.fire('Error', 'Error al abrir WhatsApp: {HttpUtility.JavaScriptStringEncode(ex.Message)}', 'error');", true);
            }
        }

        private string FormatWhatsAppNumber(string rawNumber)
        {
            try
            {
                // Eliminar todo excepto dígitos
                string digitsOnly = new string(rawNumber.Where(char.IsDigit).ToArray());

                // Si empieza con 0, reemplazar por código de país (ej: 54 para Argentina)
                if (digitsOnly.StartsWith("0") && digitsOnly.Length > 1)
                {
                    digitsOnly = "54" + digitsOnly.Substring(1);
                }
                // Si no tiene código de país, agregar (asumiendo Argentina)
                else if (!digitsOnly.StartsWith("911") && !digitsOnly.StartsWith("54") && digitsOnly.Length == 10)
                {
                    digitsOnly = "54" + digitsOnly;
                }

                return digitsOnly;
            }
            catch
            {
                return string.Empty;
            }
        }
        protected void btnEnviarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar sesión de usuario
                if (Session["usuario"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Debe iniciar sesión para enviar mensajes.', 'error');", true);
                    return;
                }

                // 2. Validar ID de propiedad
                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                // 3. Verificar que la propiedad existe
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'La propiedad especificada no existe.', 'error');", true);
                    return;
                }

                // 4. Validar mensaje no vacío
                if (string.IsNullOrWhiteSpace(txtMensajeConsulta.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'El mensaje no puede estar vacío.', 'error');", true);
                    return;
                }

                // 5. Obtener usuario actual
                Usuario usuarioActual = (Usuario)Session["usuario"];

                // 6. Crear y configurar el mensaje
                Mensajes nuevoMensaje = new Mensajes
                {
                    IdUsuario = usuarioActual.IdUsuario,
                    NombreUsuario = $"{usuarioActual.Nombre} {usuarioActual.Apellido}",
                    IdPropiedad = idPropiedad,
                    Mensaje = txtMensajeConsulta.Text.Trim(),
                    FechaDePublicacion = DateTime.Now
                };

                // 7. Enviar el mensaje
                MensajeNegocio mensajeNegocio = new MensajeNegocio();
                mensajeNegocio.agregarMensaje(nuevoMensaje);

                // 8. Actualizar la visualización
                txtMensajeConsulta.Text = string.Empty;

                // Actualizar la lista de mensajes y el Repeater
                MensajesLista = mensajeNegocio.listar(idPropiedad);
                rptMensajes.DataSource = MensajesLista;
                rptMensajes.DataBind();

                // 9. Mostrar confirmación
                ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess",
                    "Swal.fire('Éxito', 'Mensaje enviado correctamente.', 'success');", true);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.InnerException != null ?
                    ex.InnerException.Message : ex.Message;

                ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                    $@"Swal.fire({{
                title: 'Error',
                html: 'No se pudo enviar el mensaje:<br/><strong>{HttpUtility.JavaScriptStringEncode(errorMessage)}</strong>',
                icon: 'error'
            }});", true);
            }
        }

        protected void rptMensajes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                try
                {
                    int idMensaje = Convert.ToInt32(e.CommandArgument);
                    int idPropiedad = Convert.ToInt32(Request.QueryString["id"]);

                    MensajeNegocio mensajeNegocio = new MensajeNegocio();
                    mensajeNegocio.eliminarMensaje(idMensaje);

                    // Actualizar la lista y el repeater
                    MensajesLista = mensajeNegocio.listar(idPropiedad);
                    rptMensajes.DataSource = MensajesLista;
                    rptMensajes.DataBind();

                    ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess",
                        "Swal.fire('Éxito', 'Mensaje eliminado correctamente.', 'success');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        $"Swal.fire('Error', 'No se pudo eliminar el mensaje: {HttpUtility.JavaScriptStringEncode(ex.Message)}', 'error');", true);
                }
            }
        }
    }
}
