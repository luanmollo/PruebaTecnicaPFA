using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class SocioContactoNegocio
    {
       
        public int Agregar(SocioContacto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.ConfigurarConsulta("insert into tbl_Socio_Contacto(Mail, Telefonos) OUTPUT Inserted.ID values(@Mail, @Telefonos)");
                datos.ConfigurarParametros("@Mail", nuevo.Mail);
                datos.ConfigurarParametros("@Telefonos", nuevo.Telefono);

                return datos.EjecutarAccion(); //id del nuevo registro

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

        public void Modificar(SocioContacto contacto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("update tbl_Socio_Contacto set Mail = @Mail, Telefonos = @Telefonos where Id = @Id");
                datos.ConfigurarParametros("@Id", contacto.Id);
                datos.ConfigurarParametros("@Mail", contacto.Mail);
                datos.ConfigurarParametros("@Telefonos", contacto.Telefono);

                datos.EjecutarAccion();

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
