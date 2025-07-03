using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MensajeNegocio
    {
        public List<Mensaje> listar(int idPropiedad)
        {
            List<Mensaje> lista = new List<Mensaje>();
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta(@"SELECT 
                               
                             IdMensaje,
                             IdPropiedad,
                             IdUsuario,
                             Mensaje,
                             FechaDePublicacion,
                             NombreUsuario
                             FROM Mensaje
                             WHERE IdPropiedad = @IdPropiedad
                             ORDER BY FechaDePublicacion DESC");

                datos.agregarParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mensaje mensaje = new Mensaje();
                    mensaje.IdMensaje = (int)datos.Lector["IdMensaje"];
                    mensaje.IdPropiedad = (int)datos.Lector["IdPropiedad"];
                    mensaje.IdUsuario = (int)datos.Lector["IdUsuario"];
                    mensaje.Mensaj = (string)datos.Lector["Mensaje"];
                    mensaje.FechaDePublicacion = (DateTime)datos.Lector["FechaDePublicacion"];

                    // Asignamos el nombre del usuario
                    if (datos.Lector["NombreUsuario"] != DBNull.Value)
                    {
                        mensaje.NombreUsuario = (string)datos.Lector["NombreUsuario"];
                    }
                    else
                    {
                        mensaje.NombreUsuario = "Usuario desconocido"; // Valor por defecto
                    }

                    lista.Add(mensaje);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar mensajes: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int agregarMensaje(Mensaje nuevoMensaje)
        {
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta(@"INSERT INTO Mensaje 
                    (IdPropiedad, IdUsuario, NombreUsuario, Mensaje, FechaDePublicacion) 
                    OUTPUT INSERTED.IdMensaje
                    VALUES 
                    (@IdPropiedad, @IdUsuario, @NombreUsuario, @Mensaje, @FechaDePublicacion)");

                datos.agregarParametro("@IdPropiedad", nuevoMensaje.IdPropiedad);
                datos.agregarParametro("@IdUsuario", nuevoMensaje.IdUsuario);
                datos.agregarParametro("@NombreUsuario", nuevoMensaje.NombreUsuario);
                datos.agregarParametro("@Mensaje", nuevoMensaje.Mensaj);
                datos.agregarParametro("@FechaDePublicacion", nuevoMensaje.FechaDePublicacion);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar mensaje: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarMensaje(int idMensaje)
        {
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                // Verificar primero si el mensaje existe
                datos.setearConsulta("SELECT COUNT(*) FROM Mensaje WHERE IdMensaje = @IdMensaje");
                datos.agregarParametro("@IdMensaje", idMensaje);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0] == 0)
                {
                    throw new Exception($"No existe un mensaje con ID {idMensaje}");
                }

                datos.cerrarConexion();

                // Eliminar el mensaje
                datos.setearConsulta("DELETE FROM Mensaje WHERE IdMensaje = @IdMensaje");
                datos.agregarParametro("@IdMensaje", idMensaje);

                // Ejecutar sin esperar retorno
                datos.ejecutarAccion();

                // Verificación opcional con nueva consulta
                datos.setearConsulta("SELECT COUNT(*) FROM Mensaje WHERE IdMensaje = @IdMensaje");
                datos.agregarParametro("@IdMensaje", idMensaje);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0] > 0)
                {
                    throw new Exception("El mensaje no fue eliminado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en eliminarMensaje: {ex.ToString()}");
                throw new Exception("Error al eliminar el mensaje: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Mensaje ObtenerMensajePorId(int idMensaje)
        {
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta(@"SELECT 
                            IdMensaje,
                            IdPropiedad,
                            IdUsuario,
                            Mensaje,
                            FechaDePublicacion,
                            NombreUsuario
                            FROM Mensaje
                            WHERE IdMensaje = @IdMensaje");

                datos.agregarParametro("@IdMensaje", idMensaje);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Mensaje mensaje = new Mensaje();
                    mensaje.IdMensaje = (int)datos.Lector["IdMensaje"];
                    mensaje.IdPropiedad = (int)datos.Lector["IdPropiedad"];
                    mensaje.IdUsuario = (int)datos.Lector["IdUsuario"];
                    mensaje.Mensaj = (string)datos.Lector["Mensaje"];
                    mensaje.FechaDePublicacion = (DateTime)datos.Lector["FechaDePublicacion"];
                    mensaje.NombreUsuario = datos.Lector["NombreUsuario"].ToString();

                    return mensaje;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener mensaje por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
