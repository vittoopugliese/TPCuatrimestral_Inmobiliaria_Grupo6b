using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Dominio;
using Negocio;
using static System.Net.Mime.MediaTypeNames;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class PublicarInmueble : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                // Cargar provincias si no están cargadas
                if (selectProvincia.Items.Count <= 1)
                {
                    ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                    selectProvincia.DataSource = provinciaNegocio.listar();
                    selectProvincia.DataTextField = "Nombre";
                    selectProvincia.DataValueField = "IdProvincia";
                    selectProvincia.DataBind();
                    selectProvincia.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Provincia...", ""));
                }
            }
        }

        protected void btnGuardarPublicacion_Click(object sender, EventArgs e)
        {
            //Validación de campos obligatorios
            if (string.IsNullOrEmpty(texttitulo.Text.Trim()) ||
                string.IsNullOrEmpty(inputDireccion.Text.Trim()) ||
                string.IsNullOrEmpty(inputLocalidad.Text.Trim()) ||
                selectProvincia.SelectedValue == "" ||
                string.IsNullOrEmpty(txtcantAmbientes.Text) ||
                string.IsNullOrEmpty(textanosAntiguedad.Text) ||
                string.IsNullOrEmpty(SupTotal.Text) ||
                selectTipoPropiedad.SelectedValue == "" ||
                ddlTipoOperacion.SelectedValue == "" ||
                string.IsNullOrEmpty(txtPrecio.Text.Trim()) ||
                string.IsNullOrEmpty(txtExpensas.Text.Trim()) ||
                string.IsNullOrEmpty(inputEmail.Text) ||
                string.IsNullOrEmpty(txtWhatsapp.Text) ||
                string.IsNullOrEmpty(txtCantBanos.Text) ||
                string.IsNullOrEmpty(inputCantDormitorios.Text) ||
                string.IsNullOrEmpty(SupCubierta.Text) ||
                selectTipoMoneda.SelectedValue == "" ||
                string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('Por favor complete todos los campos');", true);
                return;
            }

            //Validación para email
            var mailAddress = new System.Net.Mail.MailAddress(inputEmail.Text);
            if (mailAddress.Address != inputEmail.Text)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('El email ingresado no es válido.');", true);
                return;
            }

            //validación para valores enteros positivos
            if (SafeConvertToInt(txtcantAmbientes.Text) <= 0 ||
               SafeConvertToInt(textanosAntiguedad.Text) < 0 ||
               SafeConvertToDecimal(SupTotal.Text) <= 0 ||
               SafeConvertToDecimal(txtPrecio.Text) <= 0 ||
               SafeConvertToInt(txtCantBanos.Text) < 0 ||
               SafeConvertToInt(inputCantDormitorios.Text) < 0 ||
               SafeConvertToDecimal(SupCubierta.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('Por favor ingrese valores válidos para los campos numéricos (deben ser positivos).');", true);
                return;
            }

            // 5. Validación de imágenes
            if (agregarImagen.PostedFiles.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('Debe subir al menos una imagen.');", true);
                return;
            }

            PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
            try
            {

                //if (Session["IdUsuario"] == null)
                //{
                //    Response.Redirect("Login.aspx"); // Redirigir al login si no hay sesión
                //    return;
                //}
                // Primero creamos y llenamos el objeto propiedad
                Propiedad propiedad = new Propiedad();

                Session["IdUsuario"] = 2; // Simulamos un usuario logueado para pruebas, eliminar en producción

                // Mapeamos todos los campos del formulario
                propiedad.Titulo = texttitulo.Text;
                propiedad.Direccion = inputDireccion.Text;
                propiedad.Localidad = inputLocalidad.Text;
                propiedad.IdProvincia = Convert.ToInt32(selectProvincia.SelectedValue);
                propiedad.IdUsuario = 2;
                propiedad.Ambientes = SafeConvertToInt(txtcantAmbientes.Text);
                propiedad.AnosAntiguedad = SafeConvertToInt(textanosAntiguedad.Text);
                propiedad.Sup_m2_Total = SafeConvertToDecimal(SupTotal.Text);
                propiedad.Tipo = selectTipoPropiedad.Text;
                propiedad.TipoOperacion = ddlTipoOperacion.Text;
                propiedad.Precio = SafeConvertToDecimal(txtPrecio.Text);
                propiedad.Expensas = SafeConvertToDecimal(txtExpensas.Text);
                propiedad.Email = inputEmail.Text;
                propiedad.WhatsApp = CleanPhoneNumber(txtWhatsapp.Text);
                propiedad.Baños = SafeConvertToInt(txtCantBanos.Text);
                propiedad.Dormitorios = SafeConvertToInt(inputCantDormitorios.Text);
                propiedad.Sup_m2_Cubierto = SafeConvertToDecimal(SupCubierta.Text);
                propiedad.Descripcion = txtDescripcion.Text;
                propiedad.ConBalcon = inputBalcon.Checked;
                propiedad.ConPatio = inputPatio.Checked;
                propiedad.Cochera = inputCochera.Checked;
                propiedad.AptoCredito = inputCredito.Checked;
                propiedad.Moneda = selectTipoMoneda.Text;
                propiedad.FechaPublicacion = DateTime.Now;


                //// Primero guardamos la propiedad para obtener su ID
                //if (Session["IdUsuario"] != null)
                //{
                //    propiedad.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
                //}
                //else
                //{
                //    propiedad.IdUsuario = 2; // O lanzar una excepción si el usuario no está logueado
                //    throw new Exception("Usuario no logueado.");
                //}

                // Ahora procesamos las imágenes con el ID correcto
                propiedadNegocio.agregar(propiedad);

                string ruta = Server.MapPath("./Images/");
                List<string> nombresArchivos = new List<string>();

                foreach (HttpPostedFile archivo in agregarImagen.PostedFiles)
                {
                    if (archivo.ContentLength > 0)
                    {
                        string nombreArchivo = $"{propiedad.IdPropiedad}-{Guid.NewGuid()}.jpeg";
                        string rutaCompleta = Path.Combine(ruta, nombreArchivo);
                        archivo.SaveAs(rutaCompleta);
                        nombresArchivos.Add(nombreArchivo);
                    }
                }

                System.Diagnostics.Debug.WriteLine($"Imágenes guardadas para propiedad {propiedad.IdPropiedad}:");
                foreach (string nombre in nombresArchivos)
                {
                    System.Diagnostics.Debug.WriteLine(nombre);
                }

                // Si hay imágenes, actualizamos la primera como imagen principal
                if (nombresArchivos.Any())
                {
                    propiedadNegocio.ActualizarImagenPrincipal(propiedad.IdPropiedad, nombresArchivos.First());
                }

                Response.Redirect($"InmuebleSeleccionado.aspx?id={propiedad.IdPropiedad}", false);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex.ToString()}");
                ScriptManager.RegisterStartupScript(this, GetType(), "error",
                    $"alert('Error al publicar la propiedad: {ex.Message}');", true);
            }
        }

        // Métodos auxiliares para conversión segura
        private int SafeConvertToInt(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            if (int.TryParse(value, out int result))
                return result;
            return 0;
        }

        private decimal SafeConvertToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value)) return 0;
            value = value.Replace(",", ".");
            if (decimal.TryParse(value, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal result))
                return result;
            return 0;
        }

        private string CleanPhoneNumber(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "";
            return new string(phone.Where(char.IsDigit).ToArray());
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}