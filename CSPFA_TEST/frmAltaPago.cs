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
    public partial class frmAltaPago : Form
    {
        private Socio socio;
        public frmAltaPago(Socio socio)
        {
            this.socio = socio;
            InitializeComponent();
        }

        private void frmAltaPago_Load(object sender, EventArgs e)
        {
            try
            {
                txtSocio.Text = socio.Nombre + " " + socio.Apellido;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PagosSocioNegocio negocio = new PagosSocioNegocio();

            try
            {
                if (ValidarAltaPago())
                    return;

                PagosSocio pago = new PagosSocio();
                pago.Socio = socio;
                pago.TipoSocio = socio.TipoSocio.ToString();
                pago.Monto = double.Parse(txtMonto.Text);
                pago.Fecha = DateTime.Now;

                negocio.Agregar(pago);
                MessageBox.Show("Pago ingresado exitosamente");

                Close();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private bool ValidarAltaPago()
        {
            if (string.IsNullOrEmpty(txtMonto.Text))
            {
                MessageBox.Show("Debes ingresar un monto para cargar un pago");
                return true;
            }

            if (!(Validaciones.ValidarSoloNumeros(txtMonto.Text)))
            {
                MessageBox.Show("Debes ingresar solo números en el campo 'Monto'");
                return true;
            }


            return false;
        }
    }
}
