using Datos;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public partial class frmTotalPagosSocio : Form
    {
        private List<PagosSocio> listaPagos;
        private Socio socio;
        public frmTotalPagosSocio(Socio socio)
        {
            this.socio = socio;
            InitializeComponent();
        }

        private void frmTotalPagosSocio_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            lblSocio.Text = socio.Nombre.ToString() + " " + socio.Apellido.ToString();
        }

        private void CargarGrilla()
        {
            PagosSocioNegocio negocio = new PagosSocioNegocio();

            try
            {

                listaPagos = negocio.ListarPagos(socio.Id);
                dgvPagos.DataSource = listaPagos;
                dgvPagos.RowHeadersVisible = false;

                dgvPagos.Columns["Id"].Visible = false;
                dgvPagos.Columns["Socio"].Visible = false;
                dgvPagos.Columns["NombreSocio"].Visible = false;
                dgvPagos.Columns["TipoSocio"].Visible = false;
                dgvPagos.Columns["MontoTotal"].Visible = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

       
    }
}
