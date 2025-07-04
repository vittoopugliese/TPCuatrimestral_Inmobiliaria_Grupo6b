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
            var negocio = new AdminNegocio();
            GridRevisiones.DataSource = negocio.ListarRevisionesPendientes();
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

                CargarRevisiones();
                PanelRechazo.Visible = false;
                txtObservacion.Text = "";
            }
            else
            {
                LabelMensaje.Text = @"
                    <div class='alert alert-danger alert-dismissible fade show' role='alert'>
                        Rechazo cancelado
                        <button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close' onclick=""window.location.href='Registro.aspx';""></button>
                    </div>";
                LabelMensaje.Visible = true;
            }
        }
    }
}