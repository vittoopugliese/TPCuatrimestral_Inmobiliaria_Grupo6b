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
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            lblNombreUsuario.Text = "Usuario Registrado";
            lblEmailUsuario.Text = "buenusuario@gmail.com";
            lblFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");

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


    }
}