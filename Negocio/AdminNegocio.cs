using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class AdminNegocio
    {
        public List<RevisionPublicacion> ListarRevisionesPendientes()
        {
            List<RevisionPublicacion> lista = new List<RevisionPublicacion>();
            BaseDeDatos datos = new BaseDeDatos();

            try
            {
                string consulta = @"
                    SELECT 
                        rp.IdRevision,
                        rp.IdPropiedad,
                        rp.IdUsuario,
                        rp.FechaAccion,
                        rp.TipoAccion,
                        rp.EstadoRevision,
                        rp.ObservacionesAdmin,
                        p.Titulo,
                        p.Ubicacion,
                        p.Precio,
                        p.Moneda,
                        pr.Nombre AS Provincia,
                        u.Nombre + ' ' + u.Apellido AS Propietario
                    FROM RevisionPublicaciones rp
                    INNER JOIN Propiedad p ON rp.IdPropiedad = p.IdPropiedad
                    INNER JOIN Usuario u ON rp.IdUsuario = u.IdUsuario
                    INNER JOIN Provincia pr ON p.IdProvincia = pr.IdProvincia
                    WHERE rp.EstadoRevision = 'Pendiente'
                    ORDER BY rp.FechaAccion DESC";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    RevisionPublicacion revision = new RevisionPublicacion
                    {
                        IdRevision = (int)datos.Lector["IdRevision"],
                        IdPropiedad = (int)datos.Lector["IdPropiedad"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        FechaAccion = (DateTime)datos.Lector["FechaAccion"],
                        TipoAccion = datos.Lector["TipoAccion"].ToString(),
                        EstadoRevision = datos.Lector["EstadoRevision"].ToString(),
                        ObservacionesAdmin = datos.Lector["ObservacionesAdmin"] != DBNull.Value ? datos.Lector["ObservacionesAdmin"].ToString() : null,
                    };

                    lista.Add(revision);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar revisiones pendientes: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void MarcarComoRevisado(int idRevision)
        {
            BaseDeDatos datos = new BaseDeDatos();

            try
            {
                string consulta = "UPDATE RevisionPublicaciones SET EstadoRevision = 'Revisado' WHERE IdRevision = @idRevision";
                datos.setearConsulta(consulta);
                datos.setearParametro("@idRevision", idRevision);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al marcar como revisado: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void RechazarRevision(int idRevision, string observaciones)
        {
            BaseDeDatos datos = new BaseDeDatos();

            try
            {
                string consulta = @"
                UPDATE RevisionPublicaciones 
                SET EstadoRevision = 'Rechazado', ObservacionesAdmin = @observaciones 
                WHERE IdRevision = @idRevision";

                datos.setearConsulta(consulta);
                datos.setearParametro("@idRevision", idRevision);
                datos.setearParametro("@observaciones", observaciones);
                datos.ejecutarAccion();

                string consultaActualizarPropiedad = @"
                UPDATE Propiedad
                SET Eliminada = 1 
                WHERE IdPropiedad = (SELECT IdPropiedad FROM RevisionPublicaciones WHERE IdRevision = @idRevision)";
                datos.setearConsulta(consultaActualizarPropiedad);
                datos.setearParametro("@idRevision", idRevision);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al rechazar la revisión: " + ex.Message);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
