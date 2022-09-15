using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PagosSocioNegocio
    {
        public List<PagosSocio> Listar()
        {
            List<PagosSocio> lista = new List<PagosSocio>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("select s.Id, s.Nombre, Apellido, ts.Nombre TipoSocio, ps.Id IdPagoSocio, ps.IdSocio, Monto, MontoFinal, Fecha from tbl_Socio s, tbl_Tipo_Socio ts, tbl_Pagos_Socio ps where s.Id = ps.IdSocio and s.TipoSocioId = ts.Id");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    PagosSocio aux = new PagosSocio();

                    aux.Id = (int)datos.Lector["IdPagoSocio"];
                    aux.Monto = (double)datos.Lector["Monto"];
                    aux.MontoFinal = (double)datos.Lector["MontoFinal"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

                    aux.Socio = new Socio();
                    aux.Socio.Id = (int)datos.Lector["Id"];
                    aux.NombreSocio = (string)datos.Lector["Nombre"] + " " + (string)datos.Lector["Apellido"];
                    aux.TipoSocio = (string)datos.Lector["TipoSocio"];

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

        public void Agregar(PagosSocio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                switch (nuevo.Socio.TipoSocio.Nombre)
                {
                    case ("Regular"):
                        nuevo.MontoFinal = nuevo.Monto * 0.80;
                        break;
                    case ("Vitalicio"):
                        nuevo.MontoFinal = nuevo.Monto * 0.50;
                        break;
                }

                datos.ConfigurarConsulta("insert into tbl_Pagos_Socio(Monto, MontoFinal, Fecha, IdSocio) values (@Monto, @MontoFinal, @Fecha, @IdSocio)");
                datos.ConfigurarParametros("@Monto", nuevo.Monto);
                datos.ConfigurarParametros("@MontoFinal", nuevo.MontoFinal);
                datos.ConfigurarParametros("@Fecha", nuevo.Fecha);
                datos.ConfigurarParametros("@IdSocio", nuevo.Socio.Id);

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
