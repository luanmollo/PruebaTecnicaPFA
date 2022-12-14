using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector {
            get { return lector; }    
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=CYS160PC\\SQLEXPRESS; database=SOCIOS_DB; integrated security=true");
            comando = new SqlCommand();

        }

        public void ConfigurarConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int EjecutarAccion()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                //comando.ExecuteNonQuery();

                return Convert.ToInt32(comando.ExecuteScalar()); //devuelve el id del nuevo registro
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void ConfigurarParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void CerrarConexion()
        {
            if (lector != null)
                lector.Close();

            conexion.Close();
        }


    }
}
