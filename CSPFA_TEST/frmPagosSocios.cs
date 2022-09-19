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
        private double totalPagosMes;
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
                listaPagos = negocio.ListarTotal();
                dgvPagosSocios.DataSource = listaPagos;
                dgvPagosSocios.Columns["Id"].Visible = false;
                dgvPagosSocios.Columns["Socio"].Visible = false;
                dgvPagosSocios.Columns["Fecha"].Visible = false;
                dgvPagosSocios.Columns["Monto"].Visible = false;
                dgvPagosSocios.Columns["MontoFinal"].Visible = false;
                dgvPagosSocios.RowHeadersVisible = false;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void dgvPagosSocios_SelectionChanged(object sender, EventArgs e)
        {
            PagosSocioNegocio negocio = new PagosSocioNegocio();

            try
            {
                PagosSocio pagosSocio = (PagosSocio)dgvPagosSocios.CurrentRow.DataBoundItem;
                txtSocio.Text = pagosSocio.NombreSocio;

                List<PagosSocio> listaPagosSocio = negocio.ListarPagos(pagosSocio.Socio.Id);

                totalPagosMes = 0;

                foreach (PagosSocio ps in listaPagosSocio)
                {
                    if((ps.Socio.Id == pagosSocio.Socio.Id) && (ps.Fecha.Month == DateTime.Now.Month) && (ps.Fecha.Year == DateTime.Now.Year))
                    {
                        totalPagosMes += ps.MontoFinal;
                    }
                }

                txtPagosRealizadosMes.Text = totalPagosMes.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnVerPagosSocio_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarSeleccionFila(dgvPagosSocios))
                return;

            PagosSocio seleccionado = (PagosSocio)dgvPagosSocios.CurrentRow.DataBoundItem;

            frmTotalPagosSocio frmTotalPagosSocio = new frmTotalPagosSocio(seleccionado.Socio);
            frmTotalPagosSocio.ShowDialog();
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            MenuInicio menuInicio = new MenuInicio();
            menuInicio.Show();
            this.Close();
        }
    }
}
