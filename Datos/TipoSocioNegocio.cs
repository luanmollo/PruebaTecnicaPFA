using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TipoSocioNegocio
    {
        public List<TipoSocio> Listar()
        {
            List<TipoSocio> lista = new List<TipoSocio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("select Id, Nombre from tbl_Tipo_Socio");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoSocio aux = new TipoSocio();

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
