using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();

                usuario.Email = TextBoxCorreo.Text;
                usuario.Contrasena = TextBoxContra.Text;
                int id = UsuarioNegocio.insertarNuevo(usuario);

                emailService.armarCorreoRegistro(usuario.Email);
                emailService.enviarCorreo();
                Response.Redirect("Default.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }


        }
    }


}