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
    public partial class frmPagosSocios : Form
    {
        private List<PagosSocio> listaPagos;
        public frmPagosSocios()
        {
            InitializeComponent();
        }

        private void frmPagosSocios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            PagosSocioNegocio negocio = new PagosSocioNegocio();

            try
            {
                listaPagos = negocio.Listar();
                dgvPagosSocios.DataSource = listaPagos;
                dgvPagosSocios.Columns["Id"].Visible = false;
                dgvPagosSocios.Columns["Socio"].Visible = false;
                dgvPagosSocios.Columns["Monto"].Visible = false;
                dgvPagosSocios.RowHeadersVisible = false;

                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
