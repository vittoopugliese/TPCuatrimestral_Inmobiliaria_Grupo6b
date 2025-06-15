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
    public partial class PublicacionesUsuarios : System.Web.UI.Page
    {
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadesNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listar();

                // Obtener la primera imagen para cada propiedad
                foreach (var propiedad in propiedades)
                {
                    propiedad.ImagenUrl = ObtenerPrimeraImagen(propiedad.IdPropiedad);
                }

                CargarDatos();
            }
        }

        private string ObtenerPrimeraImagen(int idPropiedad)
        {
            string rutaImagenes = Server.MapPath("./Images/");
            var primeraImagen = Directory.GetFiles(rutaImagenes, $"{idPropiedad}-*.jpeg")
                                       .OrderBy(f => f)
                                       .FirstOrDefault();

            if (primeraImagen != null)
            {
                return "./Images/" + Path.GetFileName(primeraImagen);
            }

            // Imagen por defecto si no hay imágenes
            return "./Images/default.jpg";
        }

        private void CargarDatos()
        {
            lblNombreUsuario.Text = "Usuario Registrado";
            lblEmailUsuario.Text = "buenusuario@gmail.com";
            lblFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (propiedadesNegocio == null)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listar();
            }

            if (propiedades != null && propiedades.Count > 0)
            {
                rptPropiedades.DataSource = propiedades;
                rptPropiedades.DataBind();
                lblPublicacionesActivas.Text = propiedades.Count.ToString();
                pnlSinPropiedades.Visible = false;
            }
            else
            {
                pnlSinPropiedades.Visible = true;
                rptPropiedades.DataSource = null;
                rptPropiedades.DataBind();
                lblPublicacionesActivas.Text = "0";
            }
        }

        protected void lnkAlternarVisibilidad_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "alternarVisibilidad")
                {
                    int propiedadId = Convert.ToInt32(e.CommandArgument);
                    PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                    bool resultado = propiedadNegocio.alternarVisibilidadDePropiedadExistente(propiedadId); // falta implementacion
                    // recargar estados y propiedades, luego hacer metodo de .listarPublicacionesDeUsuario(IdUsuario)
                    propiedades = propiedadNegocio.listar();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showerror",
                    $"alert('Error al cambiar la visibilidad: {ex.Message}');", true);
            }
        }
    }
}