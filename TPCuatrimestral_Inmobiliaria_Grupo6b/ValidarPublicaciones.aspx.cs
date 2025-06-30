using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class ValidarPublicaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRevisiones();
            }
        }

        private void CargarRevisiones()
        {
            // Acá deberías usar tu capa de negocio para traer los datos
            var negocio = new AdminNegocio(); // asumido
            GridRevisiones.DataSource = negocio.ListarRevisionesPendientes(); // método que ejecuta la consulta SQL
            GridRevisiones.DataBind();
        }

        protected void GridRevisiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridRevisiones.Rows[index];
            int idRevision = Convert.ToInt32(GridRevisiones.DataKeys[index]["IdRevision"]);
            int idPropiedad = Convert.ToInt32(GridRevisiones.DataKeys[index]["IdPropiedad"]);

            if (e.CommandName == "Ver")
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                var propiedad = propiedadNegocio.ObtenerPorId(idPropiedad);

                LabelTitulo.Text = propiedad.Titulo;
                LabelTipoOperacion.Text = propiedad.TipoOperacion;
                LabelTipo.Text = propiedad.Tipo;
                LabelDireccion.Text = propiedad.Direccion;
                LabelLocalidad.Text = propiedad.Localidad;
                LabelProvincia.Text = propiedad.IdProvincia.ToString();
                LabelAmbientes.Text = propiedad.Ambientes.ToString();
                LabelAntiguedad.Text = propiedad.AnosAntiguedad.ToString();
                LabelPrecio.Text = $"{propiedad.Precio} {propiedad.Moneda}";
                LabelExpensas.Text = propiedad.Expensas.ToString();
                LabelSupCubierta.Text = propiedad.Sup_m2_Cubierto.ToString();
                LabelSupTotal.Text = propiedad.Sup_m2_Total.ToString();
                LabelDormitorios.Text = propiedad.Dormitorios.ToString();
                LabelBanos.Text = propiedad.Baños.ToString();
                LabelDescripcion.Text = propiedad.Descripcion;

                PanelDetalle.Visible = true;
            }
            else if (e.CommandName == "Revisar")
            {
                var negocio = new AdminNegocio();
                negocio.MarcarComoRevisado(idRevision);
                CargarRevisiones(); // refrescar la grilla
                PanelDetalle.Visible = false;
            }

            else if (e.CommandName == "Rechazar")
            {

                HiddenIdRevision.Value = idRevision.ToString();
                PanelRechazo.Visible = true;
                PanelDetalle.Visible = false;
            }
        }

        protected void btnConfirmarRechazo_Click(object sender, EventArgs e)
        {
            int idRevision = int.Parse(HiddenIdRevision.Value);
            string observacion = txtObservacion.Text.Trim();

            if (!string.IsNullOrEmpty(observacion))
            {
                AdminNegocio adminNegocio = new AdminNegocio();
                adminNegocio.RechazarRevision(idRevision, observacion);

                CargarRevisiones(); // refresca la grilla
                PanelRechazo.Visible = false;
                txtObservacion.Text = "";
            }
            else
            {
                // Podés mostrar un mensaje si querés que sea obligatorio
                ScriptManager.RegisterStartupScript(this, GetType(), "alerta", "alert('Por favor, escribí una observación.');", true);
            }
        }
    }
}