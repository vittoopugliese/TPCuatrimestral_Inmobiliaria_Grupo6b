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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario = new Usuario(TextBoxCorreo.Text, TextBoxContra.Text);
                if (UsuarioNegocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);

                    Session["Email"] = usuario.Email;
                    Session["IdRol"] = usuario.IdRol;
                    Session["contrasena"] = usuario.Contrasena;
                    Session["IdUsuario"] = usuario.IdUsuario;


                    if (Session["urlGuardada"] != null)
                    {
                        string urlGuardada = Session["urlGuardada"].ToString();
                        Session.Remove("urlGuardada"); // Limpiar la URL guardada
                        Response.Redirect(urlGuardada, false); // Redirigir a la URL guardada
                    }
                    else
                    {
                        LabelMensaje.Text = @"
                        <div class='alert alert-success alert-dismissible fade show' role='alert'>
                            ¡Login exitoso!
                            <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close' onclick=""window.location.href='Default.aspx';""></button>
                        </div>";
                        LabelMensaje.Visible = true;
                    }
                }
                else
                {
                    // si el email es incorrecto lo manda al Login, ESC para volver
                    LabelMensaje.Text = @"
                    <div class='alert alert-danger alert-dismissible fade show' role='alert'>
                        Usuario o contraseña incorrecto.
                        <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close' onclick=""window.location.href='Registro.aspx';""></button>
                    </div>";
                    LabelMensaje.Visible = true;
                }



            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }

        }
    }
}