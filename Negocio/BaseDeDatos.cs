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
                string connectionString = "Server=DESKTOP-SMALGP3;Initial Catalog=CATALOGO_P3_DB;Integrated Security=True;";
                conexion = new SqlConnection(connectionString);
                comando = new SqlCommand();
                comando.Connection = conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar conexión: " + ex.Message);
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