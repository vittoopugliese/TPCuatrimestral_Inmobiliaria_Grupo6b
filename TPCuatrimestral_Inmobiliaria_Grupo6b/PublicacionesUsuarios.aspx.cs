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
                propiedades = propiedadesNegocio.listarPublicacionesDelUsuario();
                // no hace falta revisar las imagenes de la carpeta ya que solo se muestra la minatura
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            lblNombreUsuario.Text = "Usuario Registrado";
            lblEmailUsuario.Text = "buenusuario@gmail.com";
            lblFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (propiedadesNegocio == null)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarPublicacionesDelUsuario();
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

        protected void lnkOpcionesPublicacion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                
                if (e.CommandName == "alternarVisibilidad")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    bool resultado = propiedadNegocio.alternarVisibilidadDePropiedadExistente(idPropiedad);
                    CargarDatos();
                }
                if (e.CommandName == "eliminar")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    propiedadNegocio.eliminarPropiedadPorId(idPropiedad);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showerror",
                    $"alert('Error al editar la propiedad de la propiedad: {ex.Message}');", true);
            }
        }
    }
}