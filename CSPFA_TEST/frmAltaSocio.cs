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
                cboTipoDocumento.ValueMember = "Id";
                cboTipoDocumento.DisplayMember = "Nombre";

                cboTipoSocio.DataSource = tipoSocioNegocio.Listar();
                cboTipoSocio.ValueMember = "Id";
                cboTipoSocio.DisplayMember = "Nombre";

                if (socio != null)
                {
                    txtNombre.Text = socio.Nombre;
                    txtApellido.Text = socio.Apellido;
                    txtDireccion.Text = socio.Direccion;
                    cboTipoDocumento.SelectedValue = socio.TipoDocumento.Id;
                    txtDocumento.Text = socio.Documento;
                    cboTipoSocio.SelectedValue = socio.TipoSocio.Id;
                    txtMail.Text = socio.Contacto.Mail;
                    txtTelefono.Text = socio.Contacto.Telefono;
                    
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
            SocioContactoNegocio contactoNegocio = new SocioContactoNegocio();

            try
            {
                if (ValidarAltaSocio())
                    return;

                if (socio == null)
                {
                    socio = new Socio();
                    socio.Contacto = new SocioContacto();
                }

                socio.Nombre = txtNombre.Text;
                socio.Apellido = txtApellido.Text;
                socio.Direccion = txtDireccion.Text;
                socio.TipoDocumento = (TipoDocumento)cboTipoDocumento.SelectedItem;
                socio.Documento = txtDocumento.Text;
                socio.TipoSocio = (TipoSocio)cboTipoSocio.SelectedItem;

                socio.Contacto.Mail = txtMail.Text;
                socio.Contacto.Telefono = txtTelefono.Text;

                if (socio.Id != 0)
                {
                    contactoNegocio.Modificar(socio.Contacto);
                    socioNegocio.Modificar(socio);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    socio.FechaAlta = DateTime.Now;
                    socio.Contacto.Id = contactoNegocio.Agregar(socio.Contacto);
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

        private bool ValidarAltaSocio()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDireccion.Text) || string.IsNullOrEmpty(txtDocumento.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("Debes completar todos los campos");
                return true;
            }

            if (!(Validaciones.ValidarSoloNumeros(txtTelefono.Text)))
            {
                MessageBox.Show("Debes ingresar sólo números en el campo 'Teléfono'");
                return true;
            }

            return false;
        }
    }
}
