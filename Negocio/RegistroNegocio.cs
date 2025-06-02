using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class RegistroNegocio
    {
        //metodo para el drop down list de las provincias en pantalla Registro
        public List<KeyValuePair<int, string>> ObtenerProvincias()
        {
            List<KeyValuePair<int, string>> listaProvincias = new List<KeyValuePair<int, string>>();
            BaseDeDatos db = new BaseDeDatos();

            try
            {
                db.setearConsulta("SELECT IdProvincia, Nombre FROM Provincia ORDER BY Nombre");
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    listaProvincias.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(db.Lector["IdProvincia"]),
                        db.Lector["Nombre"].ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, contacte al administrador: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }
            return listaProvincias;
        }

        //metodo para el drop down list de los roles en pantalla Registro
        public List<KeyValuePair<int, string>> ObtenerRoles()
        {
            List<KeyValuePair<int, string>> listaRoles = new List<KeyValuePair<int, string>>();
            BaseDeDatos db = new BaseDeDatos();

            try
            {
                db.setearConsulta("SELECT IdRol, Descripcion FROM Rol ORDER BY Descripcion");
                db.ejecutarLectura();

                while (db.Lector.Read())
                {
                    listaRoles.Add(new KeyValuePair<int, string>(
                        Convert.ToInt32(db.Lector["IdRol"]),
                        db.Lector["Descripcion"].ToString()
                    ));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, contacte al administrador: " + ex.Message);
            }
            finally
            {
                db.cerrarConexion();
            }

            return listaRoles;
        }
    }
}