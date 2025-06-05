using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Win32;
using System.Web.UI.WebControls.WebParts;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class InmuebleSeleccionado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContactar_Click(object sender, EventArgs e)
        {
            string script = "alert('¡Mensaje enviado correctamente!');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }
        protected void botonWp_Click(object sender, EventArgs e)
        {
            string whatsappUrl = "https://wa.me/521234567890";

            string script = $"window.open('{whatsappUrl}', '_blank');";
            ClientScript.RegisterStartupScript(this.GetType(), "openWhatsApp", script, true);
        }

    }
}