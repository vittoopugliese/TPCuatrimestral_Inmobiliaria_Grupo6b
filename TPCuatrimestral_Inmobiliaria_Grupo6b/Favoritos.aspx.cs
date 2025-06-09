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
    public partial class Favoritos : System.Web.UI.Page
    {
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
        }

        private void CargarPropiedades()
        {
            propiedadNegocio = new PropiedadNegocio();
            propiedades = propiedadNegocio.listarFavoritas();

            if (propiedades != null && propiedades.Count > 0)
            {
                rptPropiedades.DataSource = propiedades;
                rptPropiedades.DataBind();
                pnlSinResultados.Visible = false;
            }
            else
            {
                pnlSinResultados.Visible = true;
                rptPropiedades.DataSource = null;
                rptPropiedades.DataBind();
            }
        }

        protected void rptPropiedades_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AlternarFavorito")
            {
                try
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    PropiedadNegocio negocio = new PropiedadNegocio();
                    bool favoritoAlternado = negocio.alternarPropiedadDeFavoritos(idPropiedad);

                    if (favoritoAlternado)
                    {
                        CargarPropiedades();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "error",
                            "alert('Error al eliminar de favoritos');", true);
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "error",
                        "alert('Error: " + ex.Message + "');", true);
                }
            }
        }
    }
}