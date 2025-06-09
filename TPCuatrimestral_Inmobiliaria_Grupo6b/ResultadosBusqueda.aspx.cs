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
    public partial class ResultadosBusqueda : System.Web.UI.Page
    {
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadesNegocio;
        private List<int> idsPropiedadesFavoritas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPropiedades();
                CargarProvincias();
            }
        }
        private void CargarPropiedades()
        {
            propiedadesNegocio = new PropiedadNegocio();
            propiedades = propiedadesNegocio.listar();

            idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos();

            if (propiedades != null && propiedades.Count > 0)
            {
                rptPropiedades.DataSource = propiedades;
                rptPropiedades.DataBind();
                lblResultadosCount.Text = propiedades.Count.ToString();
                pnlSinResultados.Visible = false;
            }
            else
            {
                pnlSinResultados.Visible = true;
                rptPropiedades.DataSource = null;
                rptPropiedades.DataBind();
                lblResultadosCount.Text = "0";
            }
        }


        private void CargarProvincias()
        {
            RegistroNegocio registroNegocio = new RegistroNegocio();
            List<KeyValuePair<int, string>> provincias = registroNegocio.ObtenerProvincias();

            ddlProvincia.Items.Clear();

            foreach (var provincia in provincias)
            {
                ddlProvincia.Items.Add(new ListItem(provincia.Value, provincia.Key.ToString()));
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
        }

        protected void rptPropiedades_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AlternarFavorito")
            {
                try
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    PropiedadNegocio negocio = new PropiedadNegocio();
                    negocio.alternarPropiedadDeFavoritos(idPropiedad);
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