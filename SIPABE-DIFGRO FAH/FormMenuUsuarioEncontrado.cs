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
    public partial class FormMenuUsuarioEncontrado : Form
    {
        /*public FormMenuUsuarioEncontrado()
        {
            InitializeComponent();
        }*/

        private object[] datosBeneficiarioGlobal;

        public FormMenuUsuarioEncontrado(object[] datosBeneficiario)
        {
            InitializeComponent();
            this.datosBeneficiarioGlobal = datosBeneficiario;

            // Aquí puedes usar los datos para llenar los controles
            lblCurp.Text = datosBeneficiario[0].ToString();
            lblNombreCompleto.Text = datosBeneficiario[3].ToString() + " " + datosBeneficiario[4].ToString() + " " + datosBeneficiario[5].ToString();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormConsultarBeneficiario formConsultarBeneficiario = new FormConsultarBeneficiario();
            formConsultarBeneficiario.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarApoyoBeneficiario formAgregarApoyoBeneficiario = new FormAgregarApoyoBeneficiario(this.datosBeneficiarioGlobal);
            formAgregarApoyoBeneficiario.Show();
            this.Close();
        }
    }
}
