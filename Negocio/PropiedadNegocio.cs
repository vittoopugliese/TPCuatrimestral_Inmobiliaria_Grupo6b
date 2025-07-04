using System;
using System.Collections.Generic;
using System.IO;
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
            (Titulo, IdUsuario, Direccion, Precio, Moneda, Expensas, Descripcion, Tipo, TipoOperacion, 
             ImagenUrl, Localidad, TipoDueno, Email, WhatsApp, Ambientes, 
             Sup_m2_Cubierto, Sup_m2_Total, Dormitorios, [Baños], ConPatio, ConBalcon, AnosAntiguedad, 
             AptoCredito, Cochera, IdProvincia, Ubicacion) 
            VALUES 
            (@Titulo, @IdUsuario, @Direccion, @Precio, @Moneda, @Expensas, @Descripcion, @Tipo, @TipoOperacion, 
             @ImagenUrl, @Localidad, @TipoDueno, @Email, @WhatsApp, @Ambientes, 
             @Sup_m2_Cubierto, @Sup_m2_Total, @Dormitorios, @Baños, @ConPatio, @ConBalcon, @AnosAntiguedad, 
             @AptoCredito, @Cochera, @IdProvincia, @Ubicacion);
            SELECT SCOPE_IDENTITY()"); // Esto devuelve el ID insertado

                // Agregar todos los parámetros con manejo de nulos
                db.agregarParametro("@Titulo", !string.IsNullOrEmpty(nueva.Titulo) ? nueva.Titulo : (object)DBNull.Value);
                db.agregarParametro("@Direccion", !string.IsNullOrEmpty(nueva.Direccion) ? nueva.Direccion : (object)DBNull.Value);
                db.agregarParametro("@Precio", nueva.Precio);
                db.agregarParametro("@Expensas", nueva.Expensas);
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

        public List<string> ObtenerImagenes(int idPropiedad, string rutaFisicaImages)
        {
            List<string> imagenes = new List<string>();

            try
            {
                var archivos = Directory.GetFiles(rutaFisicaImages, $"{idPropiedad}-*.*");
                foreach (var archivo in archivos)
                {
                    imagenes.Add(Path.GetFileName(archivo));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener imágenes de la propiedad: " + ex.Message, ex);
            }

            return imagenes;
        }

        private Propiedad MapearPropiedad()
        {
            Propiedad propiedad = new Propiedad();

            propiedad.IdPropiedad = db.Lector["IdPropiedad"] != DBNull.Value ? (int)db.Lector["IdPropiedad"] : 0;
            propiedad.Descripcion = db.Lector["Descripcion"] != DBNull.Value ? db.Lector["Descripcion"].ToString() : "";
            propiedad.Ambientes = db.Lector["Ambientes"] != DBNull.Value ? (int)db.Lector["Ambientes"] : 0;
            propiedad.Dormitorios = db.Lector["Dormitorios"] != DBNull.Value ? (int)db.Lector["Dormitorios"] : 0;
            propiedad.Baños = db.Lector["Baños"] != DBNull.Value ? (int)db.Lector["Baños"] : 0;
            propiedad.ConPatio = db.Lector["ConPatio"] != DBNull.Value ? Convert.ToBoolean(db.Lector["ConPatio"]) : false;
            propiedad.ConBalcon = db.Lector["ConBalcon"] != DBNull.Value ? Convert.ToBoolean(db.Lector["ConBalcon"]) : false;
            propiedad.Tipo = db.Lector["Tipo"] != DBNull.Value ? db.Lector["Tipo"].ToString() : "";
            propiedad.Direccion = db.Lector["Direccion"] != DBNull.Value ? db.Lector["Direccion"].ToString() : "";
            propiedad.Localidad = db.Lector["Localidad"] != DBNull.Value ? db.Lector["Localidad"].ToString() : "";
            propiedad.IdProvincia = db.Lector["IdProvincia"] != DBNull.Value ? (int)db.Lector["IdProvincia"] : 0;
            propiedad.AnosAntiguedad = db.Lector["AnosAntiguedad"] != DBNull.Value ? (int)db.Lector["AnosAntiguedad"] : 0;
            propiedad.AptoCredito = db.Lector["AptoCredito"] != DBNull.Value ? Convert.ToBoolean(db.Lector["AptoCredito"]) : false;
            propiedad.Reservada = db.Lector["Reservada"] != DBNull.Value ? Convert.ToBoolean(db.Lector["Reservada"]) : false;
            propiedad.Cochera = db.Lector["Cochera"] != DBNull.Value ? Convert.ToBoolean(db.Lector["Cochera"]) : false;
            propiedad.IdUsuario = db.Lector["IdUsuario"] != DBNull.Value ? (int)db.Lector["IdUsuario"] : 0;
            propiedad.Titulo = db.Lector["Titulo"] != DBNull.Value ? db.Lector["Titulo"].ToString() : "";
            propiedad.Ubicacion = db.Lector["Ubicacion"] != DBNull.Value ? db.Lector["Ubicacion"].ToString() : "";
            propiedad.Precio = db.Lector["Precio"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Precio"]) : 0;
            propiedad.Expensas = db.Lector["Expensas"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Expensas"]) : 0;
            propiedad.Sup_m2_Total = db.Lector["Sup_m2_Total"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Sup_m2_Total"]) : 0;
            propiedad.Sup_m2_Cubierto = db.Lector["Sup_m2_Cubierto"] != DBNull.Value ? Convert.ToDecimal(db.Lector["Sup_m2_Cubierto"]) : 0;
            propiedad.Moneda = db.Lector["Moneda"] != DBNull.Value ? db.Lector["Moneda"].ToString() : "$";
            propiedad.TipoOperacion = db.Lector["TipoOperacion"] != DBNull.Value ? db.Lector["TipoOperacion"].ToString() : "";
            propiedad.ImagenUrl = db.Lector["ImagenUrl"] != DBNull.Value ? db.Lector["ImagenUrl"].ToString() : "default.jpg";
            propiedad.TipoDueno = db.Lector["TipoDueno"] != DBNull.Value ? db.Lector["TipoDueno"].ToString() : "";
            propiedad.Email = db.Lector["Email"] != DBNull.Value ? db.Lector["Email"].ToString() : "";
            propiedad.WhatsApp = db.Lector["WhatsApp"] != DBNull.Value ? db.Lector["WhatsApp"].ToString() : "";
            propiedad.Visitas = db.Lector["Visitas"] != DBNull.Value ? (int)db.Lector["Visitas"] : 0;
            propiedad.Visible = db.Lector["Visible"] != DBNull.Value ? Convert.ToBoolean(db.Lector["Visible"]) : true;
            propiedad.Eliminada = db.Lector["Eliminada"] != DBNull.Value ? Convert.ToBoolean(db.Lector["Eliminada"]) : false;
            propiedad.FechaPublicacion = db.Lector["FechaPublicacion"] != DBNull.Value ? Convert.ToDateTime(db.Lector["FechaPublicacion"]) : DateTime.MinValue;
            propiedad.FechaModificacion = db.Lector["FechaModificacion"] != DBNull.Value ? Convert.ToDateTime(db.Lector["FechaModificacion"]) : DateTime.MinValue;

            return propiedad;
        }

        private List<Propiedad> ObtenerPropiedadesSegunConsultasYMapearlas(string consulta)
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                db.setearConsulta(consulta);
                db.ejecutarLectura();
                while (db.Lector.Read()) propiedades.Add(MapearPropiedad());
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

        public bool Actualizar(Propiedad propiedad)
        {
            try
            {
                db.setearConsulta(@"UPDATE PROPIEDAD SET 
                    Titulo = @Titulo, 
                    Direccion = @Direccion, 
                    Precio = @Precio, 
                    Moneda = @Moneda, 
                    Expensas = @Expensas, 
                    Descripcion = @Descripcion, 
                    Tipo = @Tipo, 
                    TipoOperacion = @TipoOperacion, 
                    Localidad = @Localidad, 
                    TipoDueno = @TipoDueno, 
                    Email = @Email, 
                    WhatsApp = @WhatsApp, 
                    Ambientes = @Ambientes, 
                    Sup_m2_Cubierto = @Sup_m2_Cubierto, 
                    Sup_m2_Total = @Sup_m2_Total, 
                    Dormitorios = @Dormitorios, 
                    [Baños] = @Baños, 
                    ConPatio = @ConPatio, 
                    ConBalcon = @ConBalcon, 
                    AnosAntiguedad = @AnosAntiguedad, 
                    AptoCredito = @AptoCredito, 
                    Cochera = @Cochera, 
                    IdProvincia = @IdProvincia, 
                    Ubicacion = @Ubicacion,
                    FechaModificacion = GETDATE()
                    WHERE IdPropiedad = @IdPropiedad");

                db.agregarParametro("@IdPropiedad", propiedad.IdPropiedad);
                db.agregarParametro("@Titulo", !string.IsNullOrEmpty(propiedad.Titulo) ? propiedad.Titulo : (object)DBNull.Value);
                db.agregarParametro("@Direccion", !string.IsNullOrEmpty(propiedad.Direccion) ? propiedad.Direccion : (object)DBNull.Value);
                db.agregarParametro("@Precio", propiedad.Precio);
                db.agregarParametro("@Expensas", propiedad.Expensas);
                db.agregarParametro("@Moneda", !string.IsNullOrEmpty(propiedad.Moneda) ? propiedad.Moneda : "$");
                db.agregarParametro("@Descripcion", !string.IsNullOrEmpty(propiedad.Descripcion) ? propiedad.Descripcion : (object)DBNull.Value);
                db.agregarParametro("@Tipo", !string.IsNullOrEmpty(propiedad.Tipo) ? propiedad.Tipo : (object)DBNull.Value);
                db.agregarParametro("@TipoOperacion", !string.IsNullOrEmpty(propiedad.TipoOperacion) ? propiedad.TipoOperacion : (object)DBNull.Value);
                db.agregarParametro("@Localidad", !string.IsNullOrEmpty(propiedad.Localidad) ? propiedad.Localidad : (object)DBNull.Value);
                db.agregarParametro("@Ubicacion", !string.IsNullOrEmpty(propiedad.Ubicacion) ? propiedad.Ubicacion : (object)DBNull.Value);
                db.agregarParametro("@TipoDueno", !string.IsNullOrEmpty(propiedad.TipoDueno) ? propiedad.TipoDueno : (object)DBNull.Value);
                db.agregarParametro("@Email", !string.IsNullOrEmpty(propiedad.Email) ? propiedad.Email : (object)DBNull.Value);
                db.agregarParametro("@WhatsApp", !string.IsNullOrEmpty(propiedad.WhatsApp) ? propiedad.WhatsApp : (object)DBNull.Value);
                db.agregarParametro("@Ambientes", propiedad.Ambientes > 0 ? (object)propiedad.Ambientes : DBNull.Value);
                db.agregarParametro("@Sup_m2_Cubierto", propiedad.Sup_m2_Cubierto > 0 ? (object)propiedad.Sup_m2_Cubierto : DBNull.Value);
                db.agregarParametro("@Sup_m2_Total", propiedad.Sup_m2_Total > 0 ? (object)propiedad.Sup_m2_Total : DBNull.Value);
                db.agregarParametro("@Dormitorios", propiedad.Dormitorios > 0 ? (object)propiedad.Dormitorios : DBNull.Value);
                db.agregarParametro("@Baños", propiedad.Baños > 0 ? (object)propiedad.Baños : DBNull.Value);
                db.agregarParametro("@ConPatio", propiedad.ConPatio);
                db.agregarParametro("@ConBalcon", propiedad.ConBalcon);
                db.agregarParametro("@AnosAntiguedad", propiedad.AnosAntiguedad > 0 ? (object)propiedad.AnosAntiguedad : DBNull.Value);
                db.agregarParametro("@AptoCredito", propiedad.AptoCredito);
                db.agregarParametro("@Cochera", propiedad.Cochera);
                db.agregarParametro("@IdProvincia", propiedad.IdProvincia > 0 ? (object)propiedad.IdProvincia : DBNull.Value);

                db.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar propiedad: " + ex.Message, ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public void ActualizarImagenPrincipal(int idPropiedad, string rutaFisicaImages, string nombreArchivo = null)
        {
            try
            {
                // Si no se proporciona un nombre de archivo específico, buscar el primero que coincida
                if (string.IsNullOrEmpty(nombreArchivo))
                {
                    var archivos = Directory.GetFiles(rutaFisicaImages, $"{idPropiedad}-*.*")
                                          .OrderBy(f => f)
                                          .ToList();

                    if (archivos.Any())
                    {
                        nombreArchivo = Path.GetFileName(archivos.First());
                    }
                    else
                    {
                        nombreArchivo = "default.jpg";
                    }
                }

                db.setearConsulta("UPDATE Propiedad SET ImagenUrl = @ImagenUrl WHERE IdPropiedad = @IdPropiedad");
                db.agregarParametro("@ImagenUrl", nombreArchivo);
                db.agregarParametro("@IdPropiedad", idPropiedad);
                db.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar imagen principal: " + ex.Message, ex);
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

        public List<Propiedad> listarPublicacionesDelUsuario()
        {
            return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Eliminada = 0"); // muestro las NO visibles y las ELIMINADAS del usuario. TODO: agregar parametro USERID en listados // espeando a que se termine de crear el login completo
        }

        public List<Propiedad> listarEliminadas()
        {
            return ObtenerPropiedadesSegunConsultasYMapearlas("SELECT * FROM PROPIEDAD WHERE Eliminada = 1"); // user id
        }

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
            try
            {
                db.setearConsulta("SELECT Visible FROM PROPIEDAD WHERE IdPropiedad = @Id");
                db.agregarParametro("@Id", IdPropiedad);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    bool visibilidadActual = Convert.ToBoolean(db.Lector["Visible"]);

                    db.cerrarConexion();

                    db.setearConsulta("UPDATE PROPIEDAD SET Visible = @NuevoVisible WHERE IdPropiedad = @Id");
                    db.agregarParametro("@NuevoVisible", !visibilidadActual);
                    db.agregarParametro("@Id", IdPropiedad);
                    db.ejecutarAccion();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar visibilidad por ID", ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public bool eliminarPropiedadPorId(int IdPropiedad)
        {
            try
            { // si existe procedo a borrarla
                db.setearConsulta("SELECT IdPropiedad FROM PROPIEDAD WHERE IdPropiedad = @Id");
                db.agregarParametro("@Id", IdPropiedad);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    db.cerrarConexion();

                    db.setearConsulta("UPDATE PROPIEDAD SET Eliminada = 1, Visible = 0 WHERE IdPropiedad = @Id");
                    db.agregarParametro("@Id", IdPropiedad);
                    db.ejecutarAccion();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al marcar campo Eliminada de la propiedad", ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }
        public bool reactivarPropiedadPorId(int IdPropiedad)
        {
            try
            {
                db.setearConsulta("UPDATE PROPIEDAD SET Eliminada = 0, Visible = 1 WHERE IdPropiedad = @Id");
                db.agregarParametro("@Id", IdPropiedad);
                db.ejecutarAccion();
                db.cerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al reactivar propiedad", ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public List<Propiedad> buscarConFiltros(int? idProvincia, string tipoOperacion, string tipoInmueble, decimal? precioMin, decimal? precioMax)
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            string consulta = "SELECT * FROM PROPIEDAD WHERE Visible = 1 AND Eliminada = 0";
            // consulta inicial mas filtrado
            if (idProvincia.HasValue && idProvincia.Value > 0) consulta += " AND IdProvincia = @IdProvincia";
            if (!string.IsNullOrEmpty(tipoOperacion)) consulta += " AND TipoOperacion = @TipoOperacion";
            if (!string.IsNullOrEmpty(tipoInmueble)) consulta += " AND Tipo = @TipoInmueble";
            if (precioMin.HasValue) consulta += " AND Precio >= @PrecioMin";
            if (precioMax.HasValue && precioMax.Value < 999999999) consulta += " AND Precio <= @PrecioMax";

            try
            {
                db.setearConsulta(consulta);

                if (idProvincia.HasValue && idProvincia.Value > 0) db.agregarParametro("@IdProvincia", idProvincia.Value);
                if (!string.IsNullOrEmpty(tipoOperacion)) db.agregarParametro("@TipoOperacion", tipoOperacion);
                if (!string.IsNullOrEmpty(tipoInmueble)) db.agregarParametro("@TipoInmueble", tipoInmueble);
                if (precioMin.HasValue) db.agregarParametro("@PrecioMin", precioMin.Value);
                if (precioMax.HasValue && precioMax.Value < 999999999) db.agregarParametro("@PrecioMax", precioMax.Value);
                // ejecuto consulta y muestro resultados mapeados
                db.ejecutarLectura();
                while (db.Lector.Read()) propiedades.Add(MapearPropiedad());
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar propiedades con filtros: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }

            return propiedades;
        }

        public Propiedad ObtenerPorId(int id)
        {
            Propiedad propiedad = new Propiedad();

            try
            {
                db.setearConsulta("SELECT * FROM PROPIEDAD WHERE IdPropiedad = @Id");
                db.agregarParametro("@Id", id);
                db.ejecutarLectura();
                if (db.Lector.Read()) propiedad = MapearPropiedad();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener propiedad por ID", ex);
            }
            finally
            {
                db.cerrarConexion();
            }

            return propiedad;
        }

        public bool destacarPropiedadPorId(int IdPropiedad)
        {
            try
            { // traigo el valor si esta destacada o no, y guardo el contrario
                db.setearConsulta("SELECT Destacada FROM PROPIEDAD WHERE IdPropiedad = @Id");
                db.agregarParametro("@Id", IdPropiedad);
                db.ejecutarLectura();

                if (db.Lector.Read())
                {
                    bool destacadaActual = db.Lector["Destacada"] != DBNull.Value && Convert.ToBoolean(db.Lector["Destacada"]);

                    db.cerrarConexion();

                    db.setearConsulta("UPDATE PROPIEDAD SET Destacada = @NuevoDestacada WHERE IdPropiedad = @Id");
                    db.agregarParametro("@NuevoDestacada", !destacadaActual);
                    db.agregarParametro("@Id", IdPropiedad);
                    db.ejecutarAccion();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar estado de destacada", ex);
            }
            finally
            {
                db.cerrarConexion();
            }
        }

        public List<Propiedad> ObtenerPropiedadesEliminadas(int idUsuario)
        {
            List<Propiedad> propiedades = new List<Propiedad>();
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                string consulta = @"
                SELECT p.IdPropiedad, p.Titulo, p.Direccion, p.Localidad, p.TipoOperacion, p.Tipo, p.Precio, p.Moneda,
                       rv.ObservacionesAdmin, rv.FechaAccion
                FROM Propiedad p
                INNER JOIN RevisionPublicaciones rv ON p.IdPropiedad = rv.IdPropiedad
                WHERE p.IdUsuario = @idUsuario AND p.Eliminada = 1 AND rv.EstadoRevision = 'Rechazado'
                ORDER BY rv.FechaAccion DESC";

                datos.setearConsulta(consulta);
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Propiedad propiedad = new Propiedad();
                    propiedad.IdPropiedad = (int)datos.Lector["IdPropiedad"];
                    propiedad.Titulo = datos.Lector["Titulo"].ToString();
                    propiedad.Direccion = datos.Lector["Direccion"].ToString();
                    propiedad.Localidad = datos.Lector["Localidad"].ToString();
                    propiedad.TipoOperacion = datos.Lector["TipoOperacion"].ToString();
                    propiedad.Tipo = datos.Lector["Tipo"].ToString();
                    propiedad.Precio = (decimal)datos.Lector["Precio"];
                    propiedad.Moneda = datos.Lector["Moneda"].ToString();
                    propiedad.Descripcion = datos.Lector["ObservacionesAdmin"].ToString();
                    propiedades.Add(propiedad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener propiedades eliminadas: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
            return propiedades;
        }


    }
}