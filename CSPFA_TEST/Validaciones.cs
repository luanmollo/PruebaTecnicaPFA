using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba
{
    public static class Validaciones
    {
        public static bool validarSeleccionFila(DataGridView dgv)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("No hay un socio seleccionado.");
                return true;
            }
            
            return false;
        }

        public static bool ValidarSoloNumeros(string cadena)
        {
            foreach (char c in cadena)
            {
                if (!(char.IsNumber(c)))
                    return false;
            }

            return true;
        }
    }
}
