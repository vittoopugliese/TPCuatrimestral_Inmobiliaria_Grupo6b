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
                System.Diagnostics.Debug.WriteLine("Iniciando guardado de publicación...");

                if (string.IsNullOrEmpty(selectProvincia.SelectedValue))
                {
                    throw new Exception("Debe seleccionar una provincia");
                }

                // Crear la propiedad (tu código existente)
                Propiedad nuevaPropiedad = new Propiedad
                {
                    // ... (tu código para crear la propiedad) ...
                };

                System.Diagnostics.Debug.WriteLine("Agregando propiedad a la base de datos...");
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                propiedadNegocio.agregar(nuevaPropiedad);
                System.Diagnostics.Debug.WriteLine($"Propiedad agregada con ID: {nuevaPropiedad.IdPropiedad}");

                // Guardar imágenes
                System.Diagnostics.Debug.WriteLine("Intentando guardar imágenes...");
                List<string> rutasImagenes = GuardarImagenes(nuevaPropiedad.IdPropiedad);
                System.Diagnostics.Debug.WriteLine($"Imágenes a guardar: {rutasImagenes.Count}");

                if (rutasImagenes.Any())
                {
                    System.Diagnostics.Debug.WriteLine("Actualizando imagen principal...");
                    nuevaPropiedad.ImagenUrl = rutasImagenes[0].Replace("~/", "");
                    propiedadNegocio.ActualizarImagenPrincipal(nuevaPropiedad.IdPropiedad, nuevaPropiedad.ImagenUrl);

                    System.Diagnostics.Debug.WriteLine("Guardando imágenes en base de datos...");
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    for (int i = 0; i < rutasImagenes.Count; i++)
                    {
                        Imagenes imagen = new Imagenes
                        {
                            IdPropiedad = nuevaPropiedad.IdPropiedad,
                            UrlImagen = rutasImagenes[i].Replace("~/", ""),
                            EsPortada = (i == 0)
                        };
                        imagenNegocio.Agregar(imagen);
                        System.Diagnostics.Debug.WriteLine($"Imagen {i + 1} guardada en BD: {imagen.UrlImagen}");
                    }
                }

                System.Diagnostics.Debug.WriteLine("Redirigiendo a PublicacionesUsuarios...");
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

        private List<string> GuardarImagenes(int idPropiedad)
        {
            var rutasImagenes = new List<string>();

            try
            {
                if (!agregarImagen.HasFiles)
                {
                    System.Diagnostics.Debug.WriteLine("No hay archivos adjuntos.");
                    return rutasImagenes;
                }

                string rutaCarpeta = Server.MapPath("~/Images/");

                // Verificar y crear directorio
                if (!Directory.Exists(rutaCarpeta))
                {
                    Directory.CreateDirectory(rutaCarpeta);
                    System.Diagnostics.Debug.WriteLine($"Directorio creado: {rutaCarpeta}");
                }

                System.Diagnostics.Debug.WriteLine($"Guardando imágenes para propiedad {idPropiedad}...");
                System.Diagnostics.Debug.WriteLine($"Número de archivos: {agregarImagen.PostedFiles.Count}");

                foreach (HttpPostedFile archivo in agregarImagen.PostedFiles)
                {
                    string extension = Path.GetExtension(archivo.FileName)?.ToLower();

                    if (extension == null || !(extension == ".jpg" || extension == ".jpeg" || extension == ".png"))
                    {
                        System.Diagnostics.Debug.WriteLine($"Archivo {archivo.FileName} con extensión no permitida: {extension}");
                        continue;
                    }

                    string nombreArchivo = $"{idPropiedad}-{Guid.NewGuid()}{extension}";
                    string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                    System.Diagnostics.Debug.WriteLine($"Guardando archivo: {rutaCompleta}");

                    archivo.SaveAs(rutaCompleta);
                    rutasImagenes.Add($"~/Images/{nombreArchivo}");
                    System.Diagnostics.Debug.WriteLine($"Archivo guardado correctamente: {nombreArchivo}");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error grave en GuardarImagenes: {ex.ToString()}");
                throw; // Relanzar la excepción para que sea manejada por el método llamador
            }

            return rutasImagenes;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}