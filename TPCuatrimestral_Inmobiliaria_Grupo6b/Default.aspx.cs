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
    public partial class _Default : Page
    {
        private PropiedadNegocio propiedadesNegocio;

        private List<Propiedad> propiedadesDestacadas;
        private List<Propiedad> propiedadesMasVistas;
        private List<int> idsPropiedadesFavoritas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();

                idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos();

                propiedadesDestacadas = propiedadesNegocio.listarDestacadas();
                rptPropiedadesDestacadas.DataSource = (propiedadesDestacadas?.Count > 0) ? propiedadesDestacadas : null;
                rptPropiedadesDestacadas.DataBind();

                propiedadesMasVistas = propiedadesNegocio.listarMasVistas();
                rptPropiedadesMasVistas.DataSource = (propiedadesMasVistas?.Count > 0) ? propiedadesMasVistas : null;
                rptPropiedadesMasVistas.DataBind();
            }

        }

        protected void ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AlternarFavorito")
            {
                try
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    PropiedadNegocio propiedadesNegocio = new PropiedadNegocio();
                    propiedadesNegocio.alternarPropiedadDeFavoritos(idPropiedad);
                    // sin la recarga, no se actualiza el marcado de corazon de favorito...
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error",
                        "alert('Error: " + ex.Message + "');", true);
                }
            }
        }

        public bool EsFavorito(object idPropiedad)
        {
            if (idPropiedad == null) return false;

            int id;
            if (int.TryParse(idPropiedad.ToString(), out id))
            {
                if (idsPropiedadesFavoritas == null)
                {
                    propiedadesNegocio = propiedadesNegocio ?? new PropiedadNegocio();
                    idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos();
                }

                return idsPropiedadesFavoritas != null && idsPropiedadesFavoritas.Contains(id);
            }

            return false;
        }
    }
}