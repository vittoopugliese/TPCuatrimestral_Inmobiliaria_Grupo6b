using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPCuatrimestral_Inmobiliaria_Grupo6b
{
    public partial class PublicacionesUsuarios : System.Web.UI.Page
    {
        private List<Propiedad> propiedades;
        private PropiedadNegocio propiedadesNegocio;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarPublicacionesDelUsuario();
                CargarDatos();
                CargarNotificacionesEliminadas();
            }
        }

        private void CargarNotificacionesEliminadas()
        {
            try
            {
                if (Session["IdUsuario"] != null)
                {
                    int idUsuario = (int)Session["IdUsuario"];

                    // Obtener las propiedades eliminadas que no han sido "cerradas"
                    List<int> notificacionesCerradas = ObtenerNotificacionesCerradas();

                    PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                    List<Propiedad> propiedadesEliminadas = propiedadNegocio.ObtenerPropiedadesEliminadas(idUsuario);

                    var propiedadesAMostrar = propiedadesEliminadas.Where(p => !notificacionesCerradas.Contains(p.IdPropiedad)).ToList();

                    if (propiedadesAMostrar.Count > 0)
                    {
                        rptPropiedadesEliminadas.DataSource = propiedadesAMostrar;
                        rptPropiedadesEliminadas.DataBind();
                        pnlNotificaciones.Visible = true;
                    }
                    else
                    {
                        pnlNotificaciones.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                pnlNotificaciones.Visible = false;
            }
        }
        
        //notif cerradas de la sesion del usuario
        private List<int> ObtenerNotificacionesCerradas()
        {
            if (Session["NotificacionesCerradas"] == null)
            {
                Session["NotificacionesCerradas"] = new List<int>();
            }
            return (List<int>)Session["NotificacionesCerradas"];
        }

        private void AgregarNotificacionCerrada(int idPropiedad)
        {
            List<int> notificacionesCerradas = ObtenerNotificacionesCerradas();
            if (!notificacionesCerradas.Contains(idPropiedad))
            {
                notificacionesCerradas.Add(idPropiedad);
                Session["NotificacionesCerradas"] = notificacionesCerradas;
            }
        }

        protected void btnCerrarNotificacion_Command(object sender, CommandEventArgs e)
        {
            int idPropiedad = Convert.ToInt32(e.CommandArgument);
            AgregarNotificacionCerrada(idPropiedad);
            CargarNotificacionesEliminadas(); 
        }

        protected void btnCerrarTodasNotificaciones_Click(object sender, EventArgs e)
        {
            if (Session["IdUsuario"] != null)
            {
                int idUsuario = (int)Session["IdUsuario"];
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                List<Propiedad> propiedadesEliminadas = propiedadNegocio.ObtenerPropiedadesEliminadas(idUsuario);

                foreach (var propiedad in propiedadesEliminadas)
                {
                    AgregarNotificacionCerrada(propiedad.IdPropiedad);
                }

                CargarNotificacionesEliminadas(); 
            }
        }

        private void CargarDatos()
        {
            if (Session["usuario"] != null) lblEmailUsuario.Text = Session["Email"].ToString();

            if (propiedadesNegocio == null)
            {
                propiedadesNegocio = new PropiedadNegocio();
                propiedades = propiedadesNegocio.listarPublicacionesDelUsuario();
            }

            if (propiedades != null && propiedades.Count > 0)
            {
                foreach (var propiedad in propiedades) propiedad.ImagenUrl = ObtenerPrimeraImagen(propiedad.IdPropiedad);
                rptPropiedades.DataSource = propiedades;
                rptPropiedades.DataBind();
                lblPublicacionesActivas.Text = propiedades.Count.ToString();
                pnlSinPropiedades.Visible = false;
            }
            else
            {
                pnlSinPropiedades.Visible = true;
                rptPropiedades.DataSource = null;
                rptPropiedades.DataBind();
                lblPublicacionesActivas.Text = "0";
            }

        }

        private string ObtenerPrimeraImagen(int idPropiedad)
        {
            string rutaImagenes = Server.MapPath("./Images/");
            var primeraImagen = Directory.GetFiles(rutaImagenes, $"{idPropiedad}-*.jpeg").OrderBy(f => f).FirstOrDefault();
            if (primeraImagen != null) return "./Images/" + Path.GetFileName(primeraImagen);
            return "./Images/default.jpg";
        }

        protected void lnkOpcionesPublicacion_Command(object sender, CommandEventArgs e)
        {
            try
            {
                PropiedadNegocio propiedadNegocio = new PropiedadNegocio();
                
                if (e.CommandName == "alternarVisibilidad")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    bool resultado = propiedadNegocio.alternarVisibilidadDePropiedadExistente(idPropiedad);
                    CargarDatos();
                }
                if (e.CommandName == "eliminar")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    propiedadNegocio.eliminarPropiedadPorId(idPropiedad);
                    CargarDatos();
                }
                if (e.CommandName == "destacar")
                {
                    int idPropiedad = Convert.ToInt32(e.CommandArgument);
                    propiedadNegocio.destacarPropiedadPorId(idPropiedad);
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showerror",
                    $"alert('Error al editar la propiedad de la propiedad: {ex.Message}');", true);
            }
        }
    }
}