using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class PublicacionesEliminadas : System.Web.UI.Page
    {
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadesNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!(Seguridad.EsPropietario(Session["usuario"])))
            {
                Session.Add("error", "No tiene permisos para acceder a esta sección.");
                Response.Redirect("Error.aspx");
            }

            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarEliminadas();
                // no hace falta revisar las imagenes de la carpeta ya que solo se muestra la minatura
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            if (propiedadesNegocio == null)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarEliminadas();
            }

            if (propiedades != null && propiedades.Count > 0)
            {
                rptPropiedades.DataSource = propiedades;
                rptPropiedades.DataBind();
                pnlSinPropiedades.Visible = false;
            }
            else
            {
                pnlSinPropiedades.Visible = true;
                rptPropiedades.DataSource = null;
                rptPropiedades.DataBind();
            }
        }

        protected void lnkOpcionesPublicacion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();

                if (e.CommandName == "deseliminar")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    propiedadNegocio.reactivarPropiedadPorId(idPropiedad);
                    CargarDatos();  
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showerror",
                    $"alert('Error al cambiar la publicacion eliminada: {ex.Message}');", true);
            }
        }
    }
}