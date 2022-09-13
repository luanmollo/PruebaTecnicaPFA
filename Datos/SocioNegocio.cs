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
                datos.ConfigurarConsulta("select s.Id, s.Nombre, Apellido, Direccion, TipoDocId, td.Nombre TipoDocumento, Documento, TipoSocioId, ts.Nombre TipoSocio, FechaAlta, ContactoId, sc.Mail Mail, sc.Telefonos Telefonos from tbl_Socio s, tbl_Socio_Contacto sc, tbl_Tipo_Documento td, tbl_Tipo_Socio ts where s.TipoDocId = td.Id and s.TipoSocioId = ts.Id and s.ContactoId = sc.Id");
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

                    aux.Contacto = new SocioContacto();
                    aux.Contacto.Id = (int)datos.Lector["ContactoId"];
                    aux.Contacto.Mail = (string)datos.Lector["Mail"];
                    aux.Contacto.Telefono = (string)datos.Lector["Telefonos"];

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

                datos.ConfigurarConsulta("insert into tbl_Socio(Nombre, Apellido, Direccion, TipoDocId, Documento, TipoSocioId, FechaAlta, ContactoId) values (@Nombre, @Apellido, @Direccion, @TipoDocId, @Documento, @TipoSocioId, @FechaAlta, @ContactoId)");
                datos.ConfigurarParametros("@Nombre", nuevo.Nombre);
                datos.ConfigurarParametros("@Apellido", nuevo.Apellido);
                datos.ConfigurarParametros("@Direccion", nuevo.Direccion);
                datos.ConfigurarParametros("@TipoDocId", nuevo.TipoDocumento.Id);
                datos.ConfigurarParametros("@Documento", nuevo.Documento);
                datos.ConfigurarParametros("@TipoSocioId", nuevo.TipoSocio.Id);
                datos.ConfigurarParametros("@FechaAlta", nuevo.FechaAlta);
                datos.ConfigurarParametros("@ContactoId", nuevo.Contacto.Id);

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

        public List<Socio> Filtrar(string tipoDocumento, string tipoSocio, string documento, string nombre)
        {
            List<Socio> lista = new List<Socio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select s.Id, s.Nombre, Apellido, Direccion, TipoDocId, td.Nombre TipoDocumento, Documento, TipoSocioId, ts.Nombre TipoSocio, FechaAlta, ContactoId, sc.Mail Mail, sc.Telefonos Telefonos from tbl_Socio s, tbl_Socio_Contacto sc, tbl_Tipo_Documento td, tbl_Tipo_Socio ts where s.TipoDocId = td.Id and s.TipoSocioId = ts.Id and s.ContactoId = sc.Id";

                switch (tipoDocumento)
                {
                    case "Dni":
                        consulta += " and td.Nombre like 'Dni'";
                        break;
                    case "Libreta de enrolamiento":
                        consulta += " and td.Nombre like 'Libreta de Enrolamiento'";
                        break;
                }

                switch (tipoSocio)
                {
                    case "Vitalicio":
                        consulta += " and ts.Nombre like 'Vitalicio'";
                        break;
                    case "Regular":
                        consulta += " and ts.Nombre like 'Regular'";
                        break;
                    case "No Socio":
                        consulta += " and ts.Nombre like 'No Socio'";
                        break;
                }

                consulta += " and Documento like '%" + documento + "%'" + " and s.Nombre like '%" + nombre + "%'";


                datos.ConfigurarConsulta(consulta);
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

                    aux.Contacto = new SocioContacto();
                    aux.Contacto.Id = (int)datos.Lector["ContactoId"];
                    aux.Contacto.Mail = (string)datos.Lector["Mail"];
                    aux.Contacto.Telefono = (string)datos.Lector["Telefonos"];

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
