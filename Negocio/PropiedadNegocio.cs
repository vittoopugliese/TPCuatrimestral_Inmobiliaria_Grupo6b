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

        public void agregar(Propiedad nueva)
        {
            try
            {
                db.setearConsulta(@"INSERT INTO PROPIEDAD 
            (Titulo, Direccion, Precio, Moneda, Descripcion, Tipo, TipoOperacion, 
             ImagenUrl, Localidad, TipoDueno, Email, WhatsApp, Ambientes, 
             Sup_m2_Cubierto, Sup_m2_Total, Dormitorios, [Baños], ConPatio, ConBalcon, AnosAntiguedad, 
             AptoCredito, Cochera, IdProvincia) 
            VALUES 
            (@Titulo, @Direccion, @Precio, @Moneda, @Descripcion, @Tipo, @TipoOperacion, 
             @ImagenUrl, @Localidad, @TipoDueno, @Email, @WhatsApp, @Ambientes, 
             @Sup_m2_Cubierto, @Sup_m2_Total, @Dormitorios, @Baños, @ConPatio, @ConBalcon, @AnosAntiguedad, 
             @AptoCredito, @Cochera, @IdProvincia);
            SELECT SCOPE_IDENTITY()"); // Esto devuelve el ID insertado

                // Agregar todos los parámetros con manejo de nulos
                db.agregarParametro("@Titulo", !string.IsNullOrEmpty(nueva.Titulo) ? nueva.Titulo : (object)DBNull.Value);
                db.agregarParametro("@Direccion", !string.IsNullOrEmpty(nueva.Direccion) ? nueva.Direccion : (object)DBNull.Value);
                db.agregarParametro("@Precio", nueva.Precio);
                db.agregarParametro("@Moneda", !string.IsNullOrEmpty(nueva.Moneda) ? nueva.Moneda : "$");
                db.agregarParametro("@Descripcion", !string.IsNullOrEmpty(nueva.Descripcion) ? nueva.Descripcion : (object)DBNull.Value);
                db.agregarParametro("@Tipo", !string.IsNullOrEmpty(nueva.Tipo) ? nueva.Tipo : (object)DBNull.Value);
                db.agregarParametro("@TipoOperacion", !string.IsNullOrEmpty(nueva.TipoOperacion) ? nueva.TipoOperacion : (object)DBNull.Value);
                db.agregarParametro("@ImagenUrl", !string.IsNullOrEmpty(nueva.ImagenUrl) ? nueva.ImagenUrl : "default.jpg");
                db.agregarParametro("@Localidad", !string.IsNullOrEmpty(nueva.Localidad) ? nueva.Localidad : (object)DBNull.Value);
                db.agregarParametro("@TipoDueno", !string.IsNullOrEmpty(nueva.TipoDueno) ? nueva.TipoDueno : (object)DBNull.Value);
                db.agregarParametro("@Email", !string.IsNullOrEmpty(nueva.Email) ? nueva.Email : (object)DBNull.Value);
                db.agregarParametro("@WhatsApp", !string.IsNullOrEmpty(nueva.WhatsApp) ? nueva.WhatsApp : (object)DBNull.Value);
                db.agregarParametro("@Ambientes", nueva.Ambientes > 0 ? (object)nueva.Ambientes : DBNull.Value);
                db.agregarParametro("@Sup_m2_Cubierto", nueva.Sup_m2_Cubierto > 0 ? (object)nueva.Sup_m2_Cubierto : DBNull.Value);
                db.agregarParametro("@Sup_m2_Total", nueva.Sup_m2_Total > 0 ? (object)nueva.Sup_m2_Total : DBNull.Value);
                db.agregarParametro("@Dormitorios", nueva.Dormitorios > 0 ? (object)nueva.Dormitorios : DBNull.Value);
                db.agregarParametro("@Baños", nueva.Baños > 0 ? (object)nueva.Baños : DBNull.Value);
                db.agregarParametro("@ConPatio", nueva.ConPatio);
                db.agregarParametro("@ConBalcon", nueva.ConBalcon);
                db.agregarParametro("@AnosAntiguedad", nueva.AnosAntiguedad > 0 ? (object)nueva.AnosAntiguedad : DBNull.Value);
                db.agregarParametro("@AptoCredito", nueva.AptoCredito);
                db.agregarParametro("@Cochera", nueva.Cochera);
                db.agregarParametro("@IdProvincia", nueva.IdProvincia > 0 ? (object)nueva.IdProvincia : DBNull.Value);

                db.ejecutarLectura(); // Ejecutamos lectura para obtener el ID

                if (db.Lector.Read())
                {
                    nueva.IdPropiedad = Convert.ToInt32(db.Lector[0]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar propiedad: " + ex.Message, ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        private List<Propiedad> ObtenerPropiedadesSegunConsultasYMapearlas(string consulta)
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                db.setearConsulta(consulta);
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    Propiedad propiedad = new Propiedad();

                    // Campos obligatorios (asegúrate que existen en tu tabla)
                    propiedad.IdPropiedad = Convert.ToInt32(db.Lector["IdPropiedad"]);
                    propiedad.Titulo = db.Lector["Titulo"].ToString();
                    propiedad.Direccion = db.Lector["Direccion"].ToString();
                    propiedad.Precio = Convert.ToDecimal(db.Lector["Precio"]);
                    propiedad.Moneda = db.Lector["Moneda"].ToString();
                    propiedad.Descripcion = db.Lector["Descripcion"].ToString();
                    propiedad.Tipo = db.Lector["Tipo"].ToString();
                    propiedad.TipoOperacion = db.Lector["TipoOperacion"].ToString();
                    propiedad.ImagenUrl = db.Lector["ImagenUrl"].ToString();
                    propiedad.Localidad = db.Lector["Localidad"].ToString();
                    propiedad.TipoDueno = db.Lector["TipoDueno"].ToString();
                    propiedad.Email = db.Lector["Email"].ToString();
                    propiedad.WhatsApp = db.Lector["WhatsApp"].ToString();

                    // Campos numéricos con verificación de nulos
                    propiedad.Ambientes = db.Lector["Ambientes"] != DBNull.Value ? Convert.ToInt32(db.Lector["Ambientes"]) : 0;
                    propiedad.Sup_m2_Total = db.Lector["Sup_m2_Total"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Sup_m2_Total"]) : 0;
                    propiedad.Sup_m2_Cubierto = db.Lector["Sup_m2_Cubierto"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Sup_m2_Cubierto"]) : 0;
                    propiedad.Dormitorios = db.Lector["Dormitorios"] != DBNull.Value ? Convert.ToInt32(db.Lector["Dormitorios"]) : 0;
                    propiedad.Baños = db.Lector["Baños"] != DBNull.Value ? Convert.ToInt32(db.Lector["Baños"]) : 0;
                    propiedad.AnosAntiguedad = db.Lector["AnosAntiguedad"] != DBNull.Value ? Convert.ToInt32(db.Lector["AnosAntiguedad"]) : 0;

                    // Campos booleanos
                    propiedad.ConPatio = db.Lector["ConPatio"] != DBNull.Value && Convert.ToBoolean(db.Lector["ConPatio"]);
                    propiedad.ConBalcon = db.Lector["ConBalcon"] != DBNull.Value && Convert.ToBoolean(db.Lector["ConBalcon"]);
                    propiedad.Cochera = db.Lector["Cochera"] != DBNull.Value && Convert.ToBoolean(db.Lector["Cochera"]);
                    propiedad.AptoCredito = db.Lector["AptoCredito"] != DBNull.Value && Convert.ToBoolean(db.Lector["AptoCredito"]);

                    // Campo opcional (comentado si no existe)
                    // propiedad.Ubicacion = db.Lector["Ubicacion"] != DBNull.Value ? db.Lector["Ubicacion"].ToString() : string.Empty;

                    // Provincia (descomenta si existe)
                    // propiedad.IdProvincia = db.Lector["IdProvincia"] != DBNull.Value ? Convert.ToInt32(db.Lector["IdProvincia"]) : 0;

                    propiedades.Add(propiedad);
                }
            }
            catch (Exception ex)
            {
                // Mejorar el mensaje de error para diagnóstico
                throw new Exception($"Error al mapear propiedades. Consulta: {consulta}. Error: {ex.Message}", ex);
            }
            finally
            {
                db.cerrarConexion();
            }

            return propiedades;
        }

        public int ObtenerUltimoIdInsertado()
        {
            try
            {
                db.setearConsulta("SELECT SCOPE_IDENTITY() AS LastId");
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    return Convert.ToInt32(db.Lector["LastId"]);
                }
                return 0;
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public void ActualizarImagenPrincipal(int idPropiedad, string imagenUrl)
        {
            try
            {
                db.setearConsulta("UPDATE Propiedad SET ImagenUrl = @ImagenUrl WHERE IdPropiedad = @IdPropiedad");
                db.agregarParametro("@ImagenUrl", imagenUrl);
                db.agregarParametro("@IdPropiedad", idPropiedad);
                db.ejecutarAccion();
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public List<Propiedad> listar()
        {
            return ObtenerPropiedadesSegunConsultasYMapearlas(
                "SELECT IdPropiedad, Titulo, Direccion, Precio, Moneda, Descripcion, " +
                "Tipo, TipoOperacion, ImagenUrl, Localidad, TipoDueno, Email, WhatsApp, " +
                "Ambientes, Sup_m2_Cubierto, Sup_m2_Total, Dormitorios, [Baños], " +
                "ConPatio, ConBalcon, AnosAntiguedad, AptoCredito, Cochera " +
                "FROM PROPIEDAD");
        }

        public List<Propiedad> listarDestacadas()
        {
            return ObtenerPropiedadesSegunConsultasYMapearlas(
                "SELECT IdPropiedad, Titulo, Direccion, Precio, Moneda, Descripcion, " +
                "Tipo, TipoOperacion, ImagenUrl, Localidad, TipoDueno, Email, WhatsApp, " +
                "Ambientes, Sup_m2_Cubierto, Sup_m2_Total, Dormitorios, [Baños], " +
                "ConPatio, ConBalcon, AnosAntiguedad, AptoCredito, Cochera " +
                "FROM PROPIEDAD WHERE Precio > 150000");
        }

        // listarPorTipo: return ObtenerPropiedadesSegunConsultasYMapearlas($"SELECT * FROM PROPIEDAD WHERE IdTipo = {idTipo}");
        // listarPorProvincia: return ObtenerPropiedadesSegunConsultasYMapearlas($"SELECT * FROM PROPIEDAD WHERE IdProvincia = {idProvincia}");
        // listarVisibles: return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Visible = 1 AND Eliminada = 0");

    }
}