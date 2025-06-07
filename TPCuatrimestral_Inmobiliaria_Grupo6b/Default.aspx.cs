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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();

                propiedadesDestacadas = propiedadesNegocio.listarDestacadas();
                rptPropiedadesDestacadas.DataSource = (propiedadesDestacadas?.Count > 0) ? propiedadesDestacadas : null;
                rptPropiedadesDestacadas.DataBind();

                propiedadesMasVistas = propiedadesNegocio.listarMasVistas();
                rptPropiedadesMasVistas.DataSource = (propiedadesMasVistas?.Count > 0) ? propiedadesMasVistas : null;
                rptPropiedadesMasVistas.DataBind();
            }

        }
    }
}