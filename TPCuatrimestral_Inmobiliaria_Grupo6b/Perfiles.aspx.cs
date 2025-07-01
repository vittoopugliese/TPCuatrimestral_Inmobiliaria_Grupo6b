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
    public partial class Perfiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProvincias();
                CargarRoles();
            }

            if (Session["Email"] != null)
            {
                TextBoxCorreo.Text = Session["Email"].ToString();
                TextBoxContra.Attributes["value"] = Session["Contrasena"].ToString();
                DropDownListRol.SelectedValue = Session["IdRol"].ToString();
            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }

        private void CargarProvincias()
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();
            List<KeyValuePair<int, string>> provincias = negocio.ObtenerProvincias();
            DropDownListProvincia.Items.Clear();

            ListItem itemIndicador = new ListItem("Selecciona", "");
            itemIndicador.Attributes.Add("disabled", "disabled");
            itemIndicador.Selected = false;
            DropDownListProvincia.Items.Add(itemIndicador);
            
            foreach (var provincia in provincias)
            {
                if (provincia.Key != 24)
                {
                    DropDownListProvincia.Items.Add(new ListItem(provincia.Value, provincia.Key.ToString()));
                }
            }
        }

        private void CargarRoles()
        {
            RolNegocio negocio = new RolNegocio();
            List<KeyValuePair<int, string>> roles = negocio.ObtenerRoles();
            DropDownListRol.Items.Clear();

            ListItem itemIndicador = new ListItem("Selecciona", "");
            itemIndicador.Attributes.Add("disabled", "disabled");
            DropDownListRol.Items.Add(itemIndicador);

            foreach (var rol in roles)
            {
                if (rol.Key != 2)
                {
                    DropDownListRol.Items.Add(new ListItem(rol.Value, rol.Key.ToString()));
                }   
            }
        }

        protected void ButtonActualizar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario.IdUsuario = Convert.ToInt32(Session["IdUsuario"]);
                usuario.Nombre = TextBoxNombre.Text;
                usuario.Apellido = TextBoxApellido.Text;
                usuario.Contrasena = TextBoxContra.Text;
                usuario.Telefono = TextBoxTelefono.Text;
                usuario.Direccion = TextBoxDireccion.Text;
                usuario.Localidad = TextBoxLocalidad.Text;
                if (!string.IsNullOrWhiteSpace(DropDownListProvincia.SelectedValue) && DropDownListProvincia.SelectedValue != "-1")
                {
                    usuario.IdProvincia = Convert.ToInt32(DropDownListProvincia.SelectedValue);
                }
                else
                {
                    usuario.IdProvincia = 24;
                }
                usuario.IdRol = Convert.ToInt32(DropDownListRol.SelectedValue);
                negocio.ActualizarPerfil(usuario);
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                LabelMensaje.Text = "Error al actualizar el perfil: " + ex.Message;
                LabelMensaje.CssClass = "alert alert-danger";
                LabelMensaje.Visible = true;
            }
        }
    }
}