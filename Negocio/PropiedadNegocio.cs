using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Negocio
{
    public class PropiedadNegocio
    {
        private BaseDeDatos db;

        public PropiedadNegocio()
        {
            db = new BaseDeDatos();
        }

        public List<Propiedad> listar()
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                db.setearConsulta("SELECT * FROM PROPIEDAD");
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Propiedad propiedad = new Propiedad();

                    propiedad.IdPropiedad = (int)db.Lector["IdPropiedad"];
                    propiedad.Descripcion = db.Lector["Descripcion"].ToString();
                    propiedad.Ambientes = (int)db.Lector["Ambientes"];
                    propiedad.Sup_m2_Total = Convert.ToDecimal(db.Lector["Sup_m2_Total"]);
                    propiedad.Sup_m2_Cubierto = Convert.ToDecimal(db.Lector["Sup_m2_Cubierto"]);
                    propiedad.Dormitorios = (int)db.Lector["Dormitorios"];
                    propiedad.Baños = (int)db.Lector["Baños"];
                    propiedad.ConPatio = Convert.ToBoolean(db.Lector["ConPatio"]);
                    propiedad.ConBalcon = Convert.ToBoolean(db.Lector["ConBalcon"]);
                    propiedad.IdTipo = (int)db.Lector["IdTipo"];
                    propiedad.Direccion = db.Lector["Direccion"].ToString();
                    propiedad.Localidad = db.Lector["Localidad"].ToString();
                    propiedad.IdProvincia = (int)db.Lector["IdProvincia"];
                    propiedad.AnosAntiguedad = (int)db.Lector["AnosAntiguedad"];
                    propiedad.AptoCredito = Convert.ToBoolean(db.Lector["AptoCredito"]);
                    propiedad.Reservada = Convert.ToBoolean(db.Lector["Reservada"]);
                    propiedad.IdUsuario = (int)db.Lector["IdUsuario"];
                    propiedad.Titulo = db.Lector["Titulo"].ToString();
                    propiedad.Ubicacion = db.Lector["Ubicacion"].ToString();
                    propiedad.Precio = Convert.ToDecimal(db.Lector["Precio"]);
                    propiedad.Moneda = db.Lector["Moneda"].ToString();
                    propiedad.TipoOperacion = db.Lector["TipoOperacion"].ToString();
                    propiedad.ImagenUrl = db.Lector["ImagenUrl"].ToString();
                    propiedad.TipoDueno = db.Lector["TipoDueno"].ToString();
                    propiedad.Email = db.Lector["Email"].ToString();
                    propiedad.WhatsApp = db.Lector["WhatsApp"].ToString();
                    propiedad.Visitas = (int)db.Lector["Visitas"];
                    propiedad.Visible = Convert.ToBoolean(db.Lector["Visible"]);
                    propiedad.Eliminada = Convert.ToBoolean(db.Lector["Eliminada"]);
                    propiedad.FechaPublicacion = Convert.ToDateTime(db.Lector["FechaPublicacion"]);
                    propiedad.FechaModificacion = Convert.ToDateTime(db.Lector["FechaModificacion"]);

                    propiedades.Add(propiedad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar propiedades: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }

            return propiedades;
        }

        public List<Propiedad> listarDestacadas()
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                db.setearConsulta("SELECT * FROM PROPIEDAD");
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Propiedad propiedad = new Propiedad();

                    propiedad.IdPropiedad = (int)db.Lector["IdPropiedad"];
                    propiedad.Descripcion = db.Lector["Descripcion"].ToString();
                    propiedad.Ambientes = (int)db.Lector["Ambientes"];
                    propiedad.Sup_m2_Total = Convert.ToDecimal(db.Lector["Sup_m2_Total"]);
                    propiedad.Sup_m2_Cubierto = Convert.ToDecimal(db.Lector["Sup_m2_Cubierto"]);
                    propiedad.Dormitorios = (int)db.Lector["Dormitorios"];
                    propiedad.Baños = (int)db.Lector["Baños"];
                    propiedad.ConPatio = Convert.ToBoolean(db.Lector["ConPatio"]);
                    propiedad.ConBalcon = Convert.ToBoolean(db.Lector["ConBalcon"]);
                    propiedad.IdTipo = (int)db.Lector["IdTipo"];
                    propiedad.Direccion = db.Lector["Direccion"].ToString();
                    propiedad.Localidad = db.Lector["Localidad"].ToString();
                    propiedad.IdProvincia = (int)db.Lector["IdProvincia"];
                    propiedad.AnosAntiguedad = (int)db.Lector["AnosAntiguedad"];
                    propiedad.AptoCredito = Convert.ToBoolean(db.Lector["AptoCredito"]);
                    propiedad.Reservada = Convert.ToBoolean(db.Lector["Reservada"]);
                    propiedad.IdUsuario = (int)db.Lector["IdUsuario"];
                    propiedad.Titulo = db.Lector["Titulo"].ToString();
                    propiedad.Ubicacion = db.Lector["Ubicacion"].ToString();
                    propiedad.Precio = Convert.ToDecimal(db.Lector["Precio"]);
                    propiedad.Moneda = db.Lector["Moneda"].ToString();
                    propiedad.TipoOperacion = db.Lector["TipoOperacion"].ToString();
                    propiedad.ImagenUrl = db.Lector["ImagenUrl"].ToString();
                    propiedad.TipoDueno = db.Lector["TipoDueno"].ToString();
                    propiedad.Email = db.Lector["Email"].ToString();
                    propiedad.WhatsApp = db.Lector["WhatsApp"].ToString();
                    propiedad.Visitas = (int)db.Lector["Visitas"];
                    propiedad.Visible = Convert.ToBoolean(db.Lector["Visible"]);
                    propiedad.Eliminada = Convert.ToBoolean(db.Lector["Eliminada"]);
                    propiedad.FechaPublicacion = Convert.ToDateTime(db.Lector["FechaPublicacion"]);
                    propiedad.FechaModificacion = Convert.ToDateTime(db.Lector["FechaModificacion"]);

                    propiedades.Add(propiedad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar propiedades: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }

            return propiedades;
        }


    }
}