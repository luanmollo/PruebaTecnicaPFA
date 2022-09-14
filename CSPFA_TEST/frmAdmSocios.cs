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
    public partial class frmAdmSocios : Form
    {
        private List<Socio> listaSocios;
        public frmAdmSocios()
        {
            InitializeComponent();
        }

        private void frmAdmSocios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            TipoSocioNegocio tipoSocioNegocio = new TipoSocioNegocio();
            TipoDocumentoNegocio tipoDocumentoNegocio = new TipoDocumentoNegocio();

            cboTipoSocio.DataSource = tipoSocioNegocio.Listar();
            cboTipoSocio.SelectedIndex = -1;

            cboTipoDocumento.DataSource = tipoDocumentoNegocio.Listar();
            cboTipoDocumento.SelectedIndex = -1;
        }

        private void CargarGrilla()
        {
            SocioNegocio negocio = new SocioNegocio();

            try
            {
                listaSocios = negocio.Listar();
                dgvSocios.DataSource = listaSocios;
                dgvSocios.Columns["Id"].Visible = false;
                dgvSocios.Columns["Contacto"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvSocios.AutoResizeRows();
                dgvSocios.RowHeadersVisible = false;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaSocio alta = new frmAltaSocio();
            alta.ShowDialog();
            CargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarSeleccionFila(dgvSocios))
                return;

            Socio seleccionado;
            seleccionado = (Socio)dgvSocios.CurrentRow.DataBoundItem;
            

            frmAltaSocio modificar = new frmAltaSocio(seleccionado);
            modificar.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Validaciones.validarSeleccionFila(dgvSocios))
                return;

            Socio seleccionado;
            SocioNegocio socioNegocio = new SocioNegocio();
            SocioContactoNegocio contactoNegocio = new SocioContactoNegocio();

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar?", "¿Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                seleccionado = (Socio)dgvSocios.CurrentRow.DataBoundItem;
                socioNegocio.Eliminar(seleccionado.Id);
                contactoNegocio.Eliminar(seleccionado.Contacto.Id);
                CargarGrilla();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            SocioNegocio negocio = new SocioNegocio();

            try
            {
                string tipoSocio;
                string tipoDocumento;

                if (cboTipoSocio.SelectedIndex != -1)
                    tipoSocio = cboTipoSocio.SelectedItem.ToString();
                else
                    tipoSocio = "";

                if (cboTipoDocumento.SelectedIndex != -1)
                    tipoDocumento = cboTipoDocumento.SelectedItem.ToString();
                else
                    tipoDocumento = "";


                string nombre = txtNombre.Text;
                string documento = txtDocumento.Text;

                dgvSocios.DataSource = negocio.Filtrar(tipoDocumento, tipoSocio, documento, nombre);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void linklblLimpiarFiltros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cboTipoDocumento.SelectedIndex = -1;
            cboTipoSocio.SelectedIndex = -1;
            txtNombre.Text = "";
            txtDocumento.Text = "";

            CargarGrilla();
        }
    }
}
