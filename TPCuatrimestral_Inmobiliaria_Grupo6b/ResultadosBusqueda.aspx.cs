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
        private PropiedadNegocio propiedadNegocio;

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
            propiedadNegocio = new PropiedadNegocio();
            propiedades = propiedadNegocio.listar();

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
                lblResultadosCount.Text = "20";
            }
        }


        private void CargarProvincias()
        {
            RegistroNegocio registroNegocio = new RegistroNegocio();
            List<KeyValuePair<int, string>> provincias = registroNegocio.ObtenerProvincias();

            DropDownListProvincia.Items.Clear();
            DropDownListProvincia.Items.Add(new ListItem("Selecciona una provincia", ""));

            foreach (var provincia in provincias)
            {
                DropDownListProvincia.Items.Add(new ListItem(provincia.Value, provincia.Key.ToString()));
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
        }

        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            DropDownListProvincia.SelectedIndex = 0;
            ddlOperacion.SelectedIndex = 0;
            ddlTipoInmueble.SelectedIndex = 0;
            ddlPrecio.SelectedIndex = 0;
        }

    }
}