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
    public partial class MenuPrincipalForm : Form
    {
        public MenuPrincipalForm()
        {
            InitializeComponent();

            // Usamos StartPosition para que las ventanas siempre aparezcan centradas en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MenuPrincipalForm_Load(object sender, EventArgs e)
        {
            // Mostramos quién inició sesión
            TxtUsuarioActual.Text = "Capturista actual: " + LoginForm.NombreCapturistaActual;
        }

        private void BtnCapturaQR_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos la nueva ventana de captura
            Registrar formCaptura = new Registrar();
            formCaptura.StartPosition = FormStartPosition.CenterScreen;

            // 2. Ocultamos el Menú Principal
            this.Hide();

            // 3. EL TRUCO DE MAGIA: Le decimos a la ventana de captura que, 
            // cuando se cierre, vuelva a mostrar este Menú Principal.
            formCaptura.FormClosed += (s, args) => this.Show();

            // 4. Mostramos la ventana de captura
            formCaptura.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Si el usuario hace clic en "Cerrar Sesión" o en la "X" roja de la ventana,
            // cerramos este formulario. (Esto hará que la aplicación se cierre por completo
            // gracias a la configuración que le dimos en el LoginForm).
            this.Close();
        }

        private void MenuPrincipalForm_Load_1(object sender, EventArgs e)
        {

        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos la nueva ventana de captura
            Consultar1 formConsulta = new Consultar1();
            formConsulta.StartPosition = FormStartPosition.CenterScreen;

            // 2. Ocultamos el Menú Principal
            this.Hide();

            // 3. EL TRUCO DE MAGIA: Le decimos a la ventana de captura que, 
            // cuando se cierre, vuelva a mostrar este Menú Principal.
            //formConsulta.FormClosed += (s, args) => this.Show();

            // 4. Mostramos la ventana de captura
            formConsulta.Show();
        }
    }
}