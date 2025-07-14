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

        private List<Mensaje> _mensajesLista = new List<Mensaje>();
        public List<Mensaje> MensajesLista
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
            txtTitulo.InnerHtml = $"<h4>{propiedad.Titulo}</h4>";
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

            if (!propiedad.AptoCredito)
            {
                creditoPropiedad.Visible = false;
            }

            precioCompleto.InnerText = $"{propiedad.Moneda} {propiedad.Precio}";
            expensasPropiedad.InnerText = $"Expensas: {propiedad.Moneda} {propiedad.Expensas} ";

            fechaPublicacionPropiedad.InnerText = $"Publicado el {propiedad.FechaPublicacion.ToString("dd/MM/yyyy")}";

            if (propiedad.Ambientes == 1)
            {
                cantAmbientes.InnerText = $"{propiedad.Ambientes} Ambiente";
            }
            else if (propiedad.Ambientes > 1)
            {
                cantAmbientes.InnerText = $"{propiedad.Ambientes} Ambientes";
            }

            superficieTot.InnerText = $"Sup. Total {propiedad.Sup_m2_Total} Mts2";

            superCub.InnerText = $"Sup. Cubierta {propiedad.Sup_m2_Cubierto} Mts2";

            if (!propiedad.ConPatio)
            {
                divPatio.Visible = false;
            }

            antigue.InnerText = $"{propiedad.AnosAntiguedad} Años de antiguedad";
            tituloPropiedad.InnerText = $"{propiedad.Tipo} en {propiedad.TipoOperacion} en {propiedad.Localidad}";
            descripcionPropiedad.InnerText = $"{propiedad.Descripcion}";

            whatsappPropietario.InnerText = $"{propiedad.WhatsApp}";

            var botonWp = FindControl("botonWp") as Button;
            if (botonWp != null)
            {
                botonWp.OnClientClick = $"window.open('https://wa.me/{propiedad.WhatsApp}', '_blank'); return false;";
            }

            int idUsuario = propiedad.IdUsuario;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = usuarioNegocio.ObtenerPorId(idUsuario);
            nombrePropietario.InnerText = $"Anunciante {usuario.Nombre} {usuario.Apellido}";
            whatsappPropietario.InnerText = $"{propiedad.WhatsApp}";


            txtAsunto.Text = $"Consulta sobre {propiedad.Tipo} en {propiedad.Direccion}";
            txtMensaje.Text = $"Estoy interesado/a en la propiedad ubicada en {propiedad.Direccion}. Por favor, envíeme más información.\nSaludos cordiales!";
        }

        private void CargarImagenes(int idPropiedad)
        {
            try
            {
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
                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'La propiedad especificada no existe.', 'error');", true);
                    return;
                }

                bool recibirCopia = checkRecibirCopia.Checked;

                EmailService emailservice = new EmailService();
                emailservice.armarCorreoContactar(
                    txtNombreApellido.Text,
                    txtTelefono.Text,
                    txtAsunto.Text,
                    txtEmail.Text,
                    txtMensaje.Text,
                    propiedad.Email,
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
                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null || string.IsNullOrEmpty(propiedad.WhatsApp))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'No hay número de WhatsApp asociado.', 'error');", true);
                    return;
                }

                string numeroWhatsApp = FormatWhatsAppNumber(propiedad.WhatsApp);

                if (string.IsNullOrEmpty(numeroWhatsApp))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                        "Swal.fire('Error', 'Número de WhatsApp no válido.', 'error');", true);
                    return;
                }

                string nombre = txtNombreApellido.Text;
                string telefono = txtTelefono.Text;
                string mensaje = txtMensaje.Text;

                string mensajeCodificado = WebUtility.UrlEncode(
                    $"Hola! Soy {nombre}.\n" +
                    $"{mensaje}");

                string whatsappUrl = $"https://wa.me/{numeroWhatsApp}?text={mensajeCodificado}";

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
                if (Session["usuario"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError","Swal.fire('Error', 'Debe iniciar sesión para enviar mensajes.', 'error');", true);
                    return;
                }

                if (!int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError","Swal.fire('Error', 'Propiedad no válida.', 'error');", true);
                    return;
                }

                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad == null)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError", "Swal.fire('Error', 'La propiedad especificada no existe.', 'error');", true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMensajeConsulta.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError", "Swal.fire('Error', 'El mensaje no puede estar vacío.', 'error');", true);
                    return;
                }

                Usuario usuarioActual = (Usuario)Session["usuario"];

                Mensaje nuevoMensaje = new Mensaje
                {
                    IdUsuario = usuarioActual.IdUsuario,
                    NombreUsuario = $"{usuarioActual.Nombre} {usuarioActual.Apellido}",
                    IdPropiedad = idPropiedad,
                    Mensaj = txtMensajeConsulta.Text.Trim(),
                    FechaDePublicacion = DateTime.Now
                };

                MensajeNegocio mensajeNegocio = new MensajeNegocio();
                mensajeNegocio.agregarMensaje(nuevoMensaje);

                txtMensajeConsulta.Text = string.Empty;

                MensajesLista = mensajeNegocio.listar(idPropiedad);
                rptMensajes.DataSource = MensajesLista;
                rptMensajes.DataBind();

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

                    Usuario usuarioSesion = (Usuario)Session["usuario"];
                    if (usuarioSesion == null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showError", "Swal.fire('Error', 'Inicia sesión primero.', 'error');", true);
                        return;
                    }

                    MensajeNegocio mensajeNegocio = new MensajeNegocio();
                    Mensaje mensaje = mensajeNegocio.ObtenerMensajePorId(idMensaje);

                    if (mensaje == null)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showError",
                            "Swal.fire('Error', 'El mensaje no existe o ya fue eliminado.', 'error');", true);
                        return;
                    }

                    if (usuarioSesion.IdUsuario != mensaje.IdUsuario)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showError", "Swal.fire('Error', 'No tenes permiso para borrar.', 'error');", true);
                        return;
                    }

                    var ultimoMensaje = mensajeNegocio.listar(idPropiedad).Where(m => m.IdUsuario == usuarioSesion.IdUsuario).OrderByDescending(m => m.FechaDePublicacion).FirstOrDefault();

                    if (ultimoMensaje == null || ultimoMensaje.IdMensaje != idMensaje)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showError", "Swal.fire('Error', 'Solo podess borrar tu último mensaje.', 'error');", true);
                        return;
                    }

                    mensajeNegocio.eliminarMensaje(idMensaje);

                    MensajesLista = mensajeNegocio.listar(idPropiedad);
                    rptMensajes.DataSource = MensajesLista;
                    rptMensajes.DataBind();

                    ScriptManager.RegisterStartupScript(this, GetType(), "showSuccess", "Swal.fire('Éxito', 'Mensaje eliminado correctamente.', 'success');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showError", $"Swal.fire('Error', 'No se pudo eliminar el mensaje: {HttpUtility.JavaScriptStringEncode(ex.Message)}', 'error');", true);
                }
            }
        }
    }
}
