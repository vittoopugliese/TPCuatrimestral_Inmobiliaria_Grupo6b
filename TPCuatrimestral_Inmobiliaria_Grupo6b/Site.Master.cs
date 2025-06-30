using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login || Page is _Default || Page is ResultadosBusqueda || Page is InmuebleSeleccionado))
            {
                if (!Seguridad.sesionIniciada(Session["usuario"]))
                {
                    Response.Redirect("Login.aspx");
                }
            }

            if (!(Page is Login || Page is _Default || Page is Registro || Page is Perfiles || Page is ResultadosBusqueda || Page is Favoritos || Page is InmuebleSeleccionado || Page is Error || Page is RecuperoContrasena))
            {
                if (!(Seguridad.EsPropietario(Session["usuario"])))
                {
                    Session.Add("error", "No tiene permisos para acceder a esta sección.");
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }
}