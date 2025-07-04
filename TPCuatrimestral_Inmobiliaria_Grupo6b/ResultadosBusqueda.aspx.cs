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
                CargarProvincias();

                if (Session["Provincia"] != null && Session["Tipo"] != null)
                {
                    string provincia = Session["Provincia"].ToString();
                    string tipo = Session["Tipo"].ToString();

                    AplicarFiltrosBusquedaInicial(provincia, tipo);

                    Session.Remove("Provincia");
                    Session.Remove("Tipo");
                }
                else
                {
                    CargarPropiedades();
                }
            }
        }

        private void AplicarFiltrosBusquedaInicial(string provincia, string tipo)
        {
            try
            {
                int? idProvincia = null;
                foreach (ListItem item in ddlProvincia.Items)
                {
                    if (item.Text.ToLower().Contains(provincia.ToLower()) && item.Value != "0")
                    {
                        idProvincia = Convert.ToInt32(item.Value);
                        ddlProvincia.SelectedValue = item.Value;
                        break;
                    }
                }

                // Configurar tipo de operación - convertir valores del dropdown a valores de BD
                string tipoOperacionBD = tipo == "Comprar" ? "Venta" : "Alquiler";
                ddlOperacion.SelectedValue = tipoOperacionBD;

                // busqueda con filtros
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.buscarConFiltros(idProvincia, tipoOperacionBD, null, null, null);
                idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos(Session["IdUsuario"] as int?);

                BindearPropiedades(propiedades);
            }
            catch (Exception)
            {
                CargarPropiedades();
            }
        }


        private void CargarPropiedades()
        {
            propiedadesNegocio = new PropiedadNegocio();
            propiedades = propiedadesNegocio.listar();
            idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos(Session["IdUsuario"] as int?);
            BindearPropiedades(propiedades);
        }

        private void BindearPropiedades(List<Propiedad> propiedades)
        {
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
            ProvinciaNegocio ProvinciaNegocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = ProvinciaNegocio.ObtenerProvincias();
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Add(new ListItem("Todas las provincias", "0"));
            foreach (var provincia in provincias)
            {
                ddlProvincia.Items.Add(new ListItem(provincia.Value, provincia.Key.ToString()));
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                // primero agarro los valores de los filtros
                int? idProvincia = null;
                if (!string.IsNullOrEmpty(ddlProvincia.SelectedValue) && ddlProvincia.SelectedValue != "0") idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);

                string tipoOperacion = ddlOperacion.SelectedValue;
                string tipoInmueble = ddlTipoInmueble.SelectedValue;

                decimal? precioMin = null;
                decimal? precioMax = null;

                if (!string.IsNullOrEmpty(ddlPrecio.SelectedValue))
                {
                    string[] rangoPrecio = ddlPrecio.SelectedValue.Split('-');
                    if (rangoPrecio.Length == 2)
                    {
                        precioMin = Convert.ToDecimal(rangoPrecio[0]);
                        precioMax = Convert.ToDecimal(rangoPrecio[1]);
                    }
                }

                // realizo la busqueda y bindeo el array de propiedades
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.buscarConFiltros(idProvincia, tipoOperacion, tipoInmueble, precioMin, precioMax);
                idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos(Session["IdUsuario"] as int?);
                BindearPropiedades(propiedades);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Error al aplicar filtros: " + ex.Message + "');", true);
            }
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            ddlProvincia.SelectedIndex = 0;
            ddlOperacion.SelectedIndex = 0;
            ddlTipoInmueble.SelectedIndex = 0;
            ddlPrecio.SelectedIndex = 0;
            CargarPropiedades();
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Error: " + ex.Message + "');", true);
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
                    idsPropiedadesFavoritas = propiedadesNegocio.obtenerIdPropiedadesEnFavoritos(Session["IdUsuario"] as int?);
                }

                return idsPropiedadesFavoritas != null && idsPropiedadesFavoritas.Contains(id);
            }

            return false;
        }
    }
}