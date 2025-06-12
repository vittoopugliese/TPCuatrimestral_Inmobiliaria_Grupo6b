using System;
using System.Data;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class BaseDeDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public BaseDeDatos() 
        {
            try
            {
                // ACA deben cambiar su nombre de Server, el que les dice en SQL Server Management Studio... tambien en App.config con el mismo string
                //string connectionString = "Server=DESKTOP-SMALGP3;Initial Catalog=Inmobiliaria_TPC;Integrated Security=True;";
                string connectionString = "Server=.\\SQLEXPRESS;Initial Catalog=Inmobiliaria_TPC;Integrated Security=True;";
                conexion = new SqlConnection(connectionString);
                comando = new SqlCommand();
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar conexión: " + ex.Message);
            }
        }

        public void agregarParametro(string nombre, object valor)
        {
            if (comando == null)
                throw new Exception("Primero debe configurar la consulta con setearConsulta");

            // Manejo de valores nulos
            if (valor == null)
            {
                comando.Parameters.AddWithValue(nombre, DBNull.Value);
            }
            else
            {
                // Conversión especial para booleanos (bit en SQL)
                if (valor is bool)
                {
                    comando.Parameters.AddWithValue(nombre, (bool)valor ? 1 : 0);
                }
                else
                {
                    comando.Parameters.AddWithValue(nombre, valor);
                }
            }
        }

        public void setearConsulta(string consulta)
        {
            comando.Parameters.Clear();
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            try
            {
                if (conexion.State != ConnectionState.Open) conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar lectura: " + ex.Message);
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor ?? DBNull.Value);
        }

        public void ejecutarAccion()
        {
            try
            {
                if (conexion.State != ConnectionState.Open) conexion.Open();
                comando.ExecuteNonQuery();
            } catch (Exception ex) {
                throw new Exception("Error al ejecutar acción: " + ex.Message);
            }
        }

        public void cerrarConexion()
        {
            if (lector != null && !lector.IsClosed) lector.Close();
            if (conexion.State == ConnectionState.Open) conexion.Close();
        }
    }
}