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
        public List<PagosSocio> ListarTotal()
        {
            List<PagosSocio> lista = new List<PagosSocio>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("select s.Id IdSocio, s.Nombre, s.Apellido, ts.Nombre TipoSocio, sum(ps.MontoFinal) Total from tbl_Socio s left join tbl_Pagos_Socio ps on ps.IdSocio = s.Id left join tbl_Tipo_Socio ts on ts.Id = s.TipoSocioId group by s.Id, s.Nombre, s.Apellido, ts.Nombre");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    PagosSocio aux = new PagosSocio();

                    aux.Socio = new Socio();
                    aux.Socio.Id = (int)datos.Lector["IdSocio"];
                    aux.Socio.Nombre = (string)datos.Lector["Nombre"];
                    aux.Socio.Apellido = (string)datos.Lector["Apellido"];
                    aux.NombreSocio = (string)datos.Lector["Nombre"] + " " + (string)datos.Lector["Apellido"];
                    aux.TipoSocio = (string)datos.Lector["TipoSocio"];
                    //aux.Fecha = (DateTime)datos.Lector["Fecha"];

                    if (string.IsNullOrEmpty(datos.Lector["Total"].ToString()))
                        aux.MontoTotal = 0;
                    else
                        aux.MontoTotal = (double)datos.Lector["Total"];




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

        public List<PagosSocio> ListarPagos(int socioId)
        {
            List<PagosSocio> lista = new List<PagosSocio>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("select s.Id IdSocio, s.Nombre, Apellido, ts.Nombre TipoSocio, ps.Id IdPago, Monto, MontoFinal, Fecha from tbl_Socio s, tbl_Tipo_Socio ts, tbl_Pagos_Socio ps where s.Id = ps.IdSocio and s.TipoSocioId = ts.Id and s.Id = @IdSocio");
                datos.ConfigurarParametros("@IdSocio", socioId);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    PagosSocio aux = new PagosSocio();

                    aux.Id = (int)datos.Lector["IdPago"];
                    aux.NombreSocio = (string)datos.Lector["Nombre"] + " " + (string)datos.Lector["Apellido"];
                    aux.TipoSocio = (string)datos.Lector["TipoSocio"];
                    aux.Monto = (double)datos.Lector["Monto"];
                    aux.MontoFinal = (double)datos.Lector["MontoFinal"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];

                    aux.Socio = new Socio();
                    aux.Socio.Id = (int)datos.Lector["IdSocio"];
                   



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
