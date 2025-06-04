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
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadesNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarDestacadas();

                if (propiedades != null && propiedades.Count > 0)
                {
                    rptPropiedades.DataSource = propiedades;
                    rptPropiedades.DataBind();
                }
                else
                {
                    rptPropiedades.DataSource = null;
                    rptPropiedades.DataBind();
                }
            }

        }
    }
}