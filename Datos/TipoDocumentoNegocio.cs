using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TipoDocumentoNegocio
    {
        public List<TipoDocumento> Listar()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("select Id, Nombre from tbl_Tipo_Documento");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoDocumento aux = new TipoDocumento();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
