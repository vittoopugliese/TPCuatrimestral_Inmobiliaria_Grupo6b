using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;


namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class Perfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                CargarRoles();
            }

        }

        private void CargarProvincias()
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = negocio.ObtenerProvincias();

            DropDownListProvincia.Items.Clear();
            DropDownListProvincia.Items.Add(new ListItem("Selecciona una provincia", ""));

            foreach (var provincia in provincias)
            {
                DropDownListProvincia.Items.Add(new ListItem(provincia.Value, provincia.Key.ToString()));
            }
        }

        private void CargarRoles()
        {
            RolNegocio negocio = new RolNegocio();
            List<KeyValuePair<int, string>> roles = negocio.ObtenerRoles();

            DropDownListRol.Items.Clear();
            DropDownListRol.Items.Add(new ListItem("Selecciona un rol", ""));

            foreach (var rol in roles)
            {
                DropDownListRol.Items.Add(new ListItem(rol.Value, rol.Key.ToString()));
            }
        }

    }
}