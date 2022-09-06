﻿using Datos;
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
            cboTipoDocumento.DataSource = tipoDocumentoNegocio.Listar();
        }

        private void CargarGrilla()
        {
            SocioNegocio negocio = new SocioNegocio();

            try
            {
                listaSocios = negocio.Listar();
                dgvSocios.DataSource = listaSocios;
                //dgvSocios.Colums["Id"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
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
            //validar selección

            Socio seleccionado;
            seleccionado = (Socio)dgvSocios.CurrentRow.DataBoundItem;

            frmAltaSocio modificar = new frmAltaSocio(seleccionado);
            modificar.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //validar selección

            Socio seleccionado;
            SocioNegocio socioNegocio = new SocioNegocio();

            DialogResult respuesta = MessageBox.Show("¿Estás seguro de eliminar?", "¿Eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                seleccionado = (Socio)dgvSocios.CurrentRow.DataBoundItem;
                socioNegocio.Eliminar(seleccionado.Id);
                CargarGrilla();
            }
        }
    }
}