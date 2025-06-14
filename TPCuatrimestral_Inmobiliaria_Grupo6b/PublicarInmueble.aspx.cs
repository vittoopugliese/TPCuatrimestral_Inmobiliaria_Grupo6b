using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            try
            {
                // Primero creamos y llenamos el objeto propiedad
                Propiedad propiedad = new Propiedad();

                // Mapeamos todos los campos del formulario
                propiedad.Titulo = texttitulo.Value;
                propiedad.Direccion = inputdireccion.Value;
                propiedad.Localidad = inputlocalidad.Value;
                propiedad.IdProvincia = Convert.ToInt32(selectProvincia.SelectedValue);
                propiedad.Ambientes = SafeConvertToInt(txtcantAmbientes.Text);
                propiedad.AnosAntiguedad = SafeConvertToInt(textanosAntiguedad.Text);
                propiedad.Sup_m2_Total = SafeConvertToDecimal(SupTotal.Text);
                propiedad.Tipo = selectTipoPropiedad.Value;
                propiedad.TipoOperacion = selectTipoOperacion.Value;
                propiedad.Precio = SafeConvertToDecimal(txtPrecio.Value);
                propiedad.TipoDueno = txtTipoDueno.Value;
                propiedad.Email = inputEmail.Value;
                propiedad.WhatsApp = CleanPhoneNumber(txtWhatsapp.Value);
                propiedad.Baños = SafeConvertToInt(txtCantBanos.Text);
                propiedad.Dormitorios = SafeConvertToInt(inputCantDormitorios.Text);
                propiedad.Sup_m2_Cubierto = SafeConvertToDecimal(SupCubierta.Text);
                propiedad.Descripcion = txtDescripcion.Value;
                propiedad.ConBalcon = inputBalcon.Checked;
                propiedad.ConPatio = inputPatio.Checked;
                propiedad.Cochera = inputCochera.Checked;
                propiedad.AptoCredito = inputCredito.Checked;

                // Primero guardamos la propiedad para obtener su ID
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                propiedadNegocio.agregar(propiedad);

                // Ahora procesamos las imágenes con el ID correcto
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

                // Si hay imágenes, actualizamos la primera como imagen principal
                if (nombresArchivos.Any())
                {
                    propiedadNegocio.ActualizarImagenPrincipal(propiedad.IdPropiedad, nombresArchivos.First());
                }

                Response.Redirect("PublicacionesUsuarios.aspx", false);
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