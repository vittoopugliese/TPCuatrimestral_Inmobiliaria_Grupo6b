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
            (Titulo, IdUsuario, Direccion, Precio, Moneda, Descripcion, Tipo, TipoOperacion, 
             ImagenUrl, Localidad, TipoDueno, Email, WhatsApp, Ambientes, 
             Sup_m2_Cubierto, Sup_m2_Total, Dormitorios, [Baños], ConPatio, ConBalcon, AnosAntiguedad, 
             AptoCredito, Cochera, IdProvincia, Ubicacion) 
            VALUES 
            (@Titulo, @IdUsuario, @Direccion, @Precio, @Moneda, @Descripcion, @Tipo, @TipoOperacion, 
             @ImagenUrl, @Localidad, @TipoDueno, @Email, @WhatsApp, @Ambientes, 
             @Sup_m2_Cubierto, @Sup_m2_Total, @Dormitorios, @Baños, @ConPatio, @ConBalcon, @AnosAntiguedad, 
             @AptoCredito, @Cochera, @IdProvincia, @Ubicacion);
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
                db.agregarParametro("@Ubicacion", !string.IsNullOrEmpty(nueva.Ubicacion) ? nueva.Ubicacion : (object)DBNull.Value);
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
                db.agregarParametro("@Reservada", nueva.Reservada);
                db.agregarParametro("@IdProvincia", nueva.IdProvincia > 0 ? (object)nueva.IdProvincia : DBNull.Value);
                db.agregarParametro("@IdUsuario", nueva.IdUsuario > 0 ? (object)nueva.IdUsuario : DBNull.Value);


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
            // quizas no este tan bueno el metodo con la consulta desde un parametro
            // pero inicialmente puede darnos un poco de tiempo hasta pensar todos los filtros 

            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                db.setearConsulta(consulta);
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
                    propiedad.Tipo = db.Lector["Tipo"].ToString();
                    propiedad.Direccion = db.Lector["Direccion"].ToString();
                    propiedad.Localidad = db.Lector["Localidad"].ToString();
                    propiedad.IdProvincia = (int)db.Lector["IdProvincia"];
                    propiedad.AnosAntiguedad = (int)db.Lector["AnosAntiguedad"];
                    propiedad.AptoCredito = Convert.ToBoolean(db.Lector["AptoCredito"]);
                    propiedad.Reservada = Convert.ToBoolean(db.Lector["Reservada"]);
                    propiedad.Cochera = Convert.ToBoolean(db.Lector["Cochera"]);
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
            return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Visible = 1 AND Eliminada = 0");
        }

        // listarPorTipo: return ObtenerPropiedadesSegunConsultasYMapearlas($"SELECT * FROM PROPIEDAD WHERE IdTipo = {Tipo}");
        // listarPorProvincia: return ObtenerPropiedadesSegunConsultasYMapearlas($"SELECT * FROM PROPIEDAD WHERE IdProvincia = {idProvincia}");

        public List<Propiedad> listarDestacadas()
        {
            // las destacadas sera una opcion en la creacion de la propiedad, para que aca busque las que tengan esa prop en true
            return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Precio > 150000 AND Visible = 1 AND Eliminada = 0");
        }

        public List<Propiedad> listarMasVistas()
        {
            // remplazar luego cuando tengan vistas de verdad
            // return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Visitas > 10 AND Visible = 1");
            return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Precio > 150000 AND Visible = 1 AND Eliminada = 0");
        }

        public List<int> obtenerIdPropiedadesEnFavoritos()
        {
            int IdUsuario = 1; // REMPLAZAR por clase helper,  metodo de obtener user
            List<int> idsPropiedadesFavoritas = new List<int>();

            string consultaFavoritos = "SELECT IdPropiedad FROM FAVORITO WHERE IdUsuario = " + IdUsuario;
            db.setearConsulta(consultaFavoritos);

            db.ejecutarLectura();
            // quizas podriamos combinar estas dos request en una sola
            while (db.Lector.Read()) idsPropiedadesFavoritas.Add((int)db.Lector["IdPropiedad"]);

            db.cerrarConexion();

            return idsPropiedadesFavoritas;
        }

        public List<Propiedad> listarFavoritas()
        {
            try
            {
                List<int> idsPropiedadesFavoritas = obtenerIdPropiedadesEnFavoritos();

                if (idsPropiedadesFavoritas.Count == 0) return new List<Propiedad>();

                string idsString = string.Join(",", idsPropiedadesFavoritas);
                string consultaPropiedades = $"SELECT * FROM PROPIEDAD WHERE IdPropiedad IN ({idsString}) AND Visible = 1 AND Eliminada = 0";

                return ObtenerPropiedadesSegunConsultasYMapearlas(consultaPropiedades);
            }
            catch (Exception)
            {
                db.cerrarConexion();
                throw;
            }
        }

        public bool alternarPropiedadDeFavoritos(int IdPropiedad)
        {
            int IdUsuario = 1; // REMPLAZAR por clase helper,  metodo de obtener user
            try
            {
                string consulta = "SELECT COUNT(*) FROM FAVORITO WHERE IdPropiedad = @IdPropiedad AND IdUsuario = @IdUsuario";
                db.setearConsulta(consulta);
                db.setearParametro("@IdPropiedad", IdPropiedad);
                db.setearParametro("@IdUsuario", IdUsuario);
                db.ejecutarLectura();

                bool existeEnFavoritos = false;
                if (db.Lector.Read()) existeEnFavoritos = (int)db.Lector[0] > 0;

                db.cerrarConexion();

                BaseDeDatos dbEscritura = new BaseDeDatos();

                if (existeEnFavoritos)
                {
                    string consultaEliminar = "DELETE FROM FAVORITO WHERE IdPropiedad = @IdPropiedad AND IdUsuario = @IdUsuario";
                    dbEscritura.setearConsulta(consultaEliminar);
                }
                else
                {
                    string consultaAgregar = "INSERT INTO FAVORITO (IdPropiedad, IdUsuario) VALUES (@IdPropiedad, @IdUsuario)";
                    dbEscritura.setearConsulta(consultaAgregar);
                }

                dbEscritura.setearParametro("@IdPropiedad", IdPropiedad);
                dbEscritura.setearParametro("@IdUsuario", IdUsuario);
                dbEscritura.ejecutarAccion();
                db.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al alternar favorito: " + ex.Message);
            }
        }

        public bool alternarVisibilidadDePropiedadExistente(int IdPropiedad)
        {
            return true;
        }
    }
}