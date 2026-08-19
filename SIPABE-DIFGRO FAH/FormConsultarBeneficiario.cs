using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIPABE_DIFGRO_FAH
{
    public partial class FormConsultarBeneficiario : Form
    {
        public FormConsultarBeneficiario()
        {
            InitializeComponent();
        }

        private void txtCurpBeneficiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir teclas de control (Backspace, Enter, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo letras y números
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // Cancela la entrada
                MessageBox.Show("Solo se permiten letras y números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // También limitar a 18 caracteres
        private void txtCurpBeneficiario_TextChanged(object sender, EventArgs e)
        {
            if (txtCurpBeneficiario.Text.Length > 18)
            {
                txtCurpBeneficiario.Text = txtCurpBeneficiario.Text.Substring(0, 18);
                txtCurpBeneficiario.SelectionStart = txtCurpBeneficiario.Text.Length;
                MessageBox.Show("Máximo 18 caracteres permitidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCurpBeneficiario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }
    }
}
