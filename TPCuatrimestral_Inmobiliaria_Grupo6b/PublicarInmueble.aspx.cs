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
            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                Usuario usuario = (Usuario)Session["usuario"];
                inputEmail.Text = usuario.Email;

                // Cargar provincias
                ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                selectProvincia.DataSource = provinciaNegocio.listar();
                selectProvincia.DataTextField = "Nombre";
                selectProvincia.DataValueField = "IdProvincia";
                selectProvincia.DataBind();
                selectProvincia.Items.Insert(0, new ListItem("Seleccione Provincia...", ""));

                // Verificar si estamos editando
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    CargarPropiedadParaEditar(idPropiedad);
                    CargarImagenesPropiedad(idPropiedad);
                }
            }
        }

        private void CargarPropiedadParaEditar(int idPropiedad)
        {
            try
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                if (propiedad != null)
                {
                    texttitulo.Text = propiedad.Titulo;
                    ddlTipoOperacion.SelectedValue = propiedad.TipoOperacion;
                    selectTipoPropiedad.SelectedValue = propiedad.Tipo;
                    inputDireccion.Text = propiedad.Direccion;
                    inputLocalidad.Text = propiedad.Localidad;
                    selectProvincia.SelectedValue = propiedad.IdProvincia.ToString();
                    txtcantAmbientes.Text = propiedad.Ambientes.ToString();
                    textanosAntiguedad.Text = propiedad.AnosAntiguedad.ToString();
                    selectTipoMoneda.SelectedValue = propiedad.Moneda;
                    txtCantBanos.Text = propiedad.Baños.ToString();
                    inputCantDormitorios.Text = propiedad.Dormitorios.ToString();
                    txtPrecio.Text = propiedad.Precio.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    txtExpensas.Text = propiedad.Expensas.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    SupCubierta.Text = propiedad.Sup_m2_Cubierto.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    SupTotal.Text = propiedad.Sup_m2_Total.ToString(System.Globalization.CultureInfo.InvariantCulture);
                    txtWhatsapp.Text = propiedad.WhatsApp;
                    inputEmail.Text = propiedad.Email;
                    txtDescripcion.Text = propiedad.Descripcion;

                    inputBalcon.Checked = propiedad.ConBalcon;
                    inputPatio.Checked = propiedad.ConPatio;
                    inputCochera.Checked = propiedad.Cochera;
                    inputCredito.Checked = propiedad.AptoCredito;

                    btnGuardarPublicacion.Text = "Actualizar";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    $"alert('Error al cargar la propiedad: {ex.Message}');", true);
            }
        }

        protected void EliminarImagen_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string nombreArchivo = e.CommandArgument.ToString();
                string rutaCompleta = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo);

                if (File.Exists(rutaCompleta))
                {
                    File.Delete(rutaCompleta);

                    // Verificar si la imagen eliminada era la principal
                    PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                    int idPropiedad = Convert.ToInt32(Request.QueryString["id"]);
                    Propiedad propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                    if (propiedad.ImagenUrl == nombreArchivo)
                    {
                        propiedadNegocio.ActualizarImagenPrincipal(idPropiedad, Server.MapPath("~"));
                    }

                    CargarImagenesPropiedad(idPropiedad);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    $"alert('Error al eliminar la imagen: {ex.Message}');", true);
            }
        }

        private void CargarImagenesPropiedad(int idPropiedad)
        {
            try
            {
                string rutaFisicaImages = Server.MapPath("~/Images/");
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                var imagenes = propiedadNegocio.ObtenerImagenes(idPropiedad, rutaFisicaImages);

                rptImagenes.DataSource = imagenes;
                rptImagenes.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    $"alert('Error al cargar imágenes: {ex.Message}');", true);
            }
        }

        protected void btnGuardarPublicacion_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
                return;
            }

            // Validaciones (se mantienen igual)
            if (!ValidarCampos()) return;

            Usuario usuario = (Usuario)Session["usuario"];
            PropiedadNegocio propiedadNegocio = new PropiedadNegocio();

            try
            {
                Propiedad propiedad = MapearPropiedadDesdeFormulario(usuario.IdUsuario);

                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idPropiedad))
                {
                    propiedad.IdPropiedad = idPropiedad;
                    propiedadNegocio.Actualizar(propiedad);
                }
                else
                {
                    propiedadNegocio.agregar(propiedad);
                }

                // Procesar imágenes solo si se suben archivos nuevos
                if (agregarImagen.HasFiles)
                {
                    string rutaFisicaImages = Server.MapPath("./Images/");

                    foreach (HttpPostedFile archivo in agregarImagen.PostedFiles)
                    {
                        if (archivo.ContentLength > 0)
                        {
                            string extension = Path.GetExtension(archivo.FileName).ToLower();
                            string nombreArchivo = $"{propiedad.IdPropiedad}-{Guid.NewGuid()}{extension}";
                            archivo.SaveAs(Path.Combine(rutaFisicaImages, nombreArchivo));
                        }
                    }

                    // Actualizar imagen principal si es necesario
                    if (Request.QueryString["id"] == null) // Solo para nuevas propiedades
                    {
                        propiedadNegocio.ActualizarImagenPrincipal(propiedad.IdPropiedad, rutaFisicaImages);
                    }
                }

                Response.Redirect($"InmuebleSeleccionado.aspx?id={propiedad.IdPropiedad}", false);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    $"alert('Error al guardar la propiedad: {ex.Message}');", true);
            }
        }

        private bool ValidarCampos()
        {
            // Implementa tus validaciones aquí
            return true;
        }

        private Propiedad MapearPropiedadDesdeFormulario(int idUsuario)
        {
            return new Propiedad
            {
                IdUsuario = idUsuario,
                Titulo = texttitulo.Text,
                Direccion = inputDireccion.Text,
                Localidad = inputLocalidad.Text,
                IdProvincia = Convert.ToInt32(selectProvincia.SelectedValue),
                Ambientes = SafeConvertToInt(txtcantAmbientes.Text),
                AnosAntiguedad = SafeConvertToInt(textanosAntiguedad.Text),
                Sup_m2_Total = SafeConvertToDecimal(SupTotal.Text),
                Tipo = selectTipoPropiedad.Text,
                TipoOperacion = ddlTipoOperacion.Text,
                Precio = SafeConvertToDecimal(txtPrecio.Text),
                Expensas = SafeConvertToDecimal(txtExpensas.Text),
                Email = inputEmail.Text,
                WhatsApp = CleanPhoneNumber(txtWhatsapp.Text),
                Baños = SafeConvertToInt(txtCantBanos.Text),
                Dormitorios = SafeConvertToInt(inputCantDormitorios.Text),
                Sup_m2_Cubierto = SafeConvertToDecimal(SupCubierta.Text),
                Descripcion = txtDescripcion.Text,
                ConBalcon = inputBalcon.Checked,
                ConPatio = inputPatio.Checked,
                Cochera = inputCochera.Checked,
                AptoCredito = inputCredito.Checked,
                Moneda = selectTipoMoneda.Text,
                FechaPublicacion = DateTime.Now,
                ImagenUrl = "default.jpg"
            };
        }

        private int SafeConvertToInt(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            return int.TryParse(value, out int result) ? result : 0;
        }

        private decimal SafeConvertToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            value = value.Replace(",", ".");
            return decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal result) ? result : 0;
        }

        private string CleanPhoneNumber(string phone)
        {
            return string.IsNullOrEmpty(phone) ? "" : new string(phone.Where(char.IsDigit).ToArray());
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}