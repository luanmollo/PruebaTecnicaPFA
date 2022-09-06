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
    public partial class frmAltaSocio : Form
    {
        private Socio socio = null;
        public frmAltaSocio()
        {
            InitializeComponent();
        }

        public frmAltaSocio(Socio socio)
        {
            InitializeComponent();
            this.socio = socio;
            Text = "Modificar Socio";
        }

        private void frmAltaSocio_Load(object sender, EventArgs e)
        {
            TipoDocumentoNegocio tipoDocumentoNegocio = new TipoDocumentoNegocio();
            TipoSocioNegocio tipoSocioNegocio = new TipoSocioNegocio();

            try
            {
                cboTipoDocumento.DataSource = tipoDocumentoNegocio.Listar();
                cboTipoSocio.DataSource = tipoSocioNegocio.Listar();

                if(socio != null)
                {
                    txtNombre.Text = socio.Nombre;
                    txtApellido.Text = socio.Apellido;
                    txtDireccion.Text = socio.Direccion;
                    cboTipoDocumento.SelectedValue = socio.TipoDocumento.Id;
                    txtDocumento.Text = socio.Documento;
                    cboTipoSocio.SelectedValue = socio.TipoSocio.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            SocioNegocio socioNegocio = new SocioNegocio();

            try
            {
                //validar alta

                if (socio == null)
                    socio = new Socio();

                socio.Nombre = txtNombre.Text;
                socio.Apellido = txtApellido.Text;
                socio.Direccion = txtDireccion.Text;
                socio.TipoDocumento = (TipoDocumento)cboTipoDocumento.SelectedItem;
                socio.Documento = txtDocumento.Text;
                socio.TipoSocio = (TipoSocio)cboTipoSocio.SelectedItem;

                if(socio.Id != 0)
                {
                    socioNegocio.Modificar(socio);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    socio.FechaAlta = DateTime.Now;
                    socioNegocio.Agregar(socio);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        
        }
            
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
