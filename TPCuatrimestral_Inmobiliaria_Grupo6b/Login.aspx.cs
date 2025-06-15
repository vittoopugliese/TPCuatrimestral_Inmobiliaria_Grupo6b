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
            LoginNegocio loginNegocio = new LoginNegocio();

            try
            {
                usuario = new Usuario(TextBoxCorreo.Text, TextBoxContra.Text);
                if (loginNegocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);

                    Session["usuario"] = usuario.Email; // Guardar el email del usuario en la sesión
                    Session["IdRol"] = usuario.IdRol; // Guardar el IdRol del usuario en la sesión
                    Session["contrasena"] = usuario.Contrasena; // Guardar la contraseña del usuario en la sesión   
                    Session["IdUsuario"] = usuario.IdUsuario; // Guardar el IdUsuario del usuario en la sesión


                    if (Session["urlGuardada"] != null)
                    {
                        string urlGuardada = Session["urlGuardada"].ToString();
                        Session.Remove("urlGuardada"); // Limpiar la URL guardada
                        Response.Redirect(urlGuardada, false); // Redirigir a la URL guardada
                    }
                    else
                    {
                        switch (usuario.IdRol)
                        {
                            case 1:
                                Response.Redirect("PublicarInmueble.aspx", false); // modificar luego
                                break;
                            case 2:
                                Response.Redirect("Default.aspx", false); // modificar luego
                                break;
                            case 3:
                                Response.Redirect("Default.aspx", false); // modificar luego
                                break;
                        }
                    }
                }
                else
                {
                    Session.Add("Error", "Correo o contraseña incorrectos.");
                    Response.Redirect("Error.aspx", false);
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