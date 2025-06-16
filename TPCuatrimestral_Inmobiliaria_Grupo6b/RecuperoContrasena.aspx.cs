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
    public partial class RecuperoContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            LoginNegocio loginNegocio = new LoginNegocio();
            Usuario usuario = loginNegocio.BuscarPorEmail(TextBoxCorreo.Text);

            if (usuario != null)
            {
                EmailService emailService = new EmailService();
                emailService.armarCorreo(TextBoxCorreo.Text, usuario.Contrasena);
                emailService.enviarCorreo();

                LabelMensaje.Text = "Se envió la contraseña a tu correo.";
                LabelMensaje.CssClass = "alert alert-success";
                LabelMensaje.Visible = true;

                Response.AddHeader("REFRESH", "3;URL=Login.aspx");
            }
            else
            {
                // Usando JS para dar funcionalidad al pop up del mensaje, se puede cerrar
                LabelMensaje.Text = "El correo no existe en nuestros registros <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>";
                LabelMensaje.CssClass = "alert alert-success alert-dismissible";
                LabelMensaje.Visible = true;
            }
        }
    }


}