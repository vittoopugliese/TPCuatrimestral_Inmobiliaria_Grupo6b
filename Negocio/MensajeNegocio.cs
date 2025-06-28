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
        public List<Mensajes> listar(int idPropiedad)
        {
            List<Mensajes> lista = new List<Mensajes>();
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta(@"SELECT M.IdMensaje, M.IdPropiedad, M.IdUsuario, 
                                    M.Mensaje, M.FechaDePublicacion, U.Nombre AS NombreUsuario
                             FROM MENSAJES M
                             INNER JOIN USUARIOS U ON U.IdUsuario = M.IdUsuario
                             WHERE M.IdPropiedad = @IdPropiedad
                             ORDER BY M.FechaDePublicacion DESC");

                datos.agregarParametro("@IdPropiedad", idPropiedad);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mensajes mensaje = new Mensajes();
                    mensaje.IdMensaje = (int)datos.Lector["IdMensaje"];
                    mensaje.IdPropiedad = (int)datos.Lector["IdPropiedad"];
                    mensaje.IdUsuario = (int)datos.Lector["IdUsuario"];
                    mensaje.Mensaje = (string)datos.Lector["Mensaje"];
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

        public void agregarMensaje(Mensajes nuevoMensaje)
        {
            BaseDeDatos datos = new BaseDeDatos();
            try
            {

                // 2. Insertar el mensaje
                datos.setearConsulta(@"INSERT INTO Mensajes 
                            (IdPropiedad, IdUsuario, NombreUsuario, Mensaje, FechaDePublicacion) 
                            VALUES 
                            (@IdPropiedad, @IdUsuario, @NombreUsuario, @Mensaje, @FechaDePublicacion)");

                datos.agregarParametro("@IdPropiedad", nuevoMensaje.IdPropiedad);
                datos.agregarParametro("@IdUsuario", nuevoMensaje.IdUsuario);
                datos.agregarParametro("@NombreUsuario", nuevoMensaje.NombreUsuario);
                datos.agregarParametro("@Mensaje", nuevoMensaje.Mensaje);
                datos.agregarParametro("@FechaDePublicacion", nuevoMensaje.FechaDePublicacion);

                datos.ejecutarAccion();
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
                datos.setearConsulta("DELETE FROM Mensajes WHERE IdMensaje = @IdMensaje");
                datos.agregarParametro("@IdMensaje", idMensaje);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el mensaje: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Mensajes CargarMensajes(int idMensaje)
        {
            BaseDeDatos datos = new BaseDeDatos();
            try
            {
                datos.setearConsulta(@"SELECT M.IdMensaje, M.IdPropiedad, M.IdUsuario, 
                             M.NombreUsuario, M.Mensaje, M.FechaDePublicacion
                             FROM Mensajes M
                             WHERE M.IdMensaje = @IdMensaje");

                datos.agregarParametro("@IdMensaje", idMensaje);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Mensajes mensaje = new Mensajes
                    {
                        IdMensaje = (int)datos.Lector["IdMensaje"],
                        IdPropiedad = (int)datos.Lector["IdPropiedad"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        NombreUsuario = datos.Lector["NombreUsuario"].ToString(),
                        Mensaje = datos.Lector["Mensaje"].ToString(),
                        FechaDePublicacion = (DateTime)datos.Lector["FechaDePublicacion"]
                    };
                    return mensaje;
                }
                else
                {
                    throw new Exception("No se encontró el mensaje con el ID especificado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el mensaje: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
