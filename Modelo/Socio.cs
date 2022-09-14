using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Socio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        [DisplayName("Tipo de Documento")]
        public TipoDocumento TipoDocumento { get; set; }
        public string Documento { get; set; }
        [DisplayName("Tipo de Socio")]
        public TipoSocio TipoSocio { get; set; }
        [DisplayName("Fecha de Alta")]
        public DateTime FechaAlta { get; set; }
        public SocioContacto Contacto { get; set; }
        


    }
}
