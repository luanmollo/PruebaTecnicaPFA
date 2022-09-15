using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prueba
{
    public partial class MenuInicio : Form
    {
        public MenuInicio()
        {
            InitializeComponent();
        }

        private void btnABMSocios_Click(object sender, EventArgs e)
        {
            frmAdmSocios frmAdmSocios = new frmAdmSocios();
            frmAdmSocios.Show();
            this.Close();

        }

        private void btnPagosSocios_Click(object sender, EventArgs e)
        {
            frmPagosSocios frmPagosSocios = new frmPagosSocios();
            frmPagosSocios.Show();
            this.Close();
        }
    }
}
