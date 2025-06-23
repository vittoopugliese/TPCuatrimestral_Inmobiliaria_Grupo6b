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

                if (id == 0) {
                    LabelMensaje.Text = @"
                    <div class='alert alert-danger alert-dismissible fade show' role='alert'>
                        El correo ingresado ya está registrado.
                        <a href='Login.aspx' class='btn btn-link'>Login</a>
                        <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>
                    </div>";
                    LabelMensaje.Visible = true;
                    return;
                }
                emailService.armarCorreoRegistro(usuario.Email);
                emailService.enviarCorreo();

                LabelMensaje.Text = @"
                <div class='alert alert-success alert-dismissible fade show' role='alert'>
                    ¡Registro exitoso! Por favor, revisá tu correo para confirmar tu registro.
                    <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close' onclick=""window.location.href='Default.aspx';""></button>
                </div>";
                LabelMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }


        }
    }


}