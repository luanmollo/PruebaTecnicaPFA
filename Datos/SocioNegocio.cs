using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class SocioNegocio
    {
        public List<Socio> Listar()
        {
            List<Socio> lista = new List<Socio>();

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Socio aux = new Socio();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Direccion = (string)datos.Lector["Direccion"];
                    
                    aux.TipoDocumento = new TipoDocumento();
                    aux.TipoDocumento.Id = (int)datos.Lector["TipoDocId"];
                    aux.TipoDocumento.Nombre = (string)datos.Lector["TipoDocumento"];

                    aux.Documento = (string)datos.Lector["Documento"];

                    aux.TipoSocio = new TipoSocio();
                    aux.TipoSocio.Id = (int)datos.Lector["TipoSocioId"];
                    aux.TipoSocio.Nombre = (string)datos.Lector["TipoSocio"];

                    aux.FechaAlta = (DateTime)datos.Lector["FechaAlta"];

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

        public void Agregar(Socio nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("insert into tbl_Socio(Nombre, Apellido, Direccion, TipoDocId, Documento, TipoSocioId, FechaAlta) values (@Nombre, @Apellido, @Direccion, @TipoDocId, @Documento, @TipoSocioId, @FechaAlta))");
                datos.ConfigurarParametros("@Nombre", nuevo.Nombre);
                datos.ConfigurarParametros("@Apellido", nuevo.Apellido);
                datos.ConfigurarParametros("@Direccion", nuevo.Direccion);
                datos.ConfigurarParametros("@TipoDocId", nuevo.TipoDocumento.Id);
                datos.ConfigurarParametros("@Documento", nuevo.Documento);
                datos.ConfigurarParametros("@TipoSocioId", nuevo.TipoSocio.Id);
                datos.ConfigurarParametros("@FechaAlta", nuevo.FechaAlta);

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

        public void Modificar(Socio socio)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("update tbl_Socio set Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, TipoDocId = @TipoDocId, Documento = @Documento, TipoSocioId = @TipoSocioId, FechaAlta = @FechaAlta where Id = @Id");
                datos.ConfigurarParametros("@Id", socio.Id);
                datos.ConfigurarParametros("@Nombre", socio.Nombre);
                datos.ConfigurarParametros("@Apellido", socio.Apellido);
                datos.ConfigurarParametros("@Direccion", socio.Direccion);
                datos.ConfigurarParametros("@TipoDocId", socio.TipoDocumento.Id);
                datos.ConfigurarParametros("@Documento", socio.Documento);
                datos.ConfigurarParametros("@TipoSocioId", socio.TipoSocio.Id);
                datos.ConfigurarParametros("@FechaAlta", socio.FechaAlta);

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.ConfigurarConsulta("delete from tbl_Socio where id = @Id");
                datos.ConfigurarParametros("@Id", id);

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

        //public List<Socio> Filtrar(string tipoDocumento, string tipoSocio, string documento, string nombre)
        //{
        //    List<Socio> lista = new List<Socio>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        string consulta = ""; //añadir la consulta base

                
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        
    }
}
