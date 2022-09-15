using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PagosSocio
    {
        public int Id { get; set; }
        public Socio Socio { get; set; }
        [DisplayName("Nombre")]
        public string NombreSocio { get; set; }
        
        [DisplayName("Tipo de Socio")]
        public string TipoSocio { get; set; }

        public double Monto { get; set; }
        [DisplayName("Monto pagado")]
        public double MontoFinal { get; set; }
        public DateTime Fecha { get; set; }
        public double MontoTotal { get; set; }

    }
}
