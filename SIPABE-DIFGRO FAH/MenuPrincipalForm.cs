using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;

namespace SIPABE_DIFGRO_FAH
{
    public partial class MenuPrincipalForm : LostForm
    {
        private readonly Color ColorVinoPrincipal = Color.FromArgb(105, 28, 50);  // #691C32
        private readonly Color ColorBeige = Color.FromArgb(245, 235, 215); // #F5EBD7
        private readonly Color ColorDorado = Color.FromArgb(197, 160, 89);  // #C5A059
        public MenuPrincipalForm()
        {
            InitializeComponent();

            // Usamos StartPosition para que las ventanas siempre aparezcan centradas en la pantalla
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Text = string.Empty;
            this.Image = null;
            this.ShowIcon = false;
            this.BackColor = ColorVinoPrincipal;
            this.HeaderColor = ColorVinoPrincipal;
            this.BorderColor = ColorDorado;

            ConfigurarDisenoMenu();

            if (this.btnConsultarBeneficiario != null)
            {
                this.btnConsultarBeneficiario.Click += btnConsultarBeneficiario_Click;
            }

            if (this.btnExit != null)
            {
                this.btnExit.Click += btnExit_Click;
            }
        }
        private void ConfigurarDisenoMenu()
        {
            if (this.pictureBox1 != null) 
            {
                int altoImagen = 75;      // Altura visible del banner
                int anchoImagen = 340;    // Ancho del banner

                this.pictureBox1.Size = new Size(anchoImagen, altoImagen);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                this.pictureBox1.BackColor = Color.Transparent;

                // Centrado horizontal exacto y margen superior cómodo
                this.pictureBox1.Location = new Point(
                    (this.ClientSize.Width - anchoImagen) / 2,
                    55 // Espacio debajo de la barra superior
                );
                this.pictureBox1.BringToFront();
            }

            // 1. Configurar y centrar el título
            if (this.label1 != null)
            {
                this.label1.Text = "BIENVENIDO A SIPABE";
                this.label1.Font = new Font("Segoe UI", 22f, FontStyle.Bold);
                this.label1.ForeColor = ColorBeige;
                this.label1.BackColor = Color.Transparent;
                this.label1.AutoSize = true;

                int posYTexto = (this.pictureBox1 != null) ? this.pictureBox1.Bottom + 18 : 140;

                this.label1.Location = new Point(
                    (this.ClientSize.Width - this.label1.PreferredWidth) / 2,
                    posYTexto
                );
                this.label1.BringToFront();
            }

            // 3. Posicionar botones CONSULTAR y SALIR
            int anchoBoton = 190;
            int altoBoton = 52;
            int separacionBotones = 30;
            int posYBotones = 230; // Bajamos los botones proporcionalmente

            int anchoGrupo = (anchoBoton * 2) + separacionBotones;
            int posXInicio = (this.ClientSize.Width - anchoGrupo) / 2;

            // Botón CONSULTAR
            if (this.btnConsultarBeneficiario != null)
            {
                this.btnConsultarBeneficiario.Text = "CONSULTAR";
                this.btnConsultarBeneficiario.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                this.btnConsultarBeneficiario.Size = new Size(anchoBoton, altoBoton);
                this.btnConsultarBeneficiario.Location = new Point(posXInicio, posYBotones);
                this.btnConsultarBeneficiario.PrimaryColor = ColorBeige;
                this.btnConsultarBeneficiario.TextColor = ColorVinoPrincipal;
                this.btnConsultarBeneficiario.BorderColor = ColorDorado;
                this.btnConsultarBeneficiario.HoverTextColor = ColorDorado;
                this.btnConsultarBeneficiario.Cursor = Cursors.Hand;
            }

            // Botón SALIR
            if (this.btnExit != null)
            {
                this.btnExit.Text = "SALIR";
                this.btnExit.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                this.btnExit.Size = new Size(anchoBoton, altoBoton);
                this.btnExit.Location = new Point(posXInicio + anchoBoton + separacionBotones, posYBotones);
                this.btnExit.PrimaryColor = ColorBeige;
                this.btnExit.TextColor = ColorVinoPrincipal;
                this.btnExit.BorderColor = ColorDorado;
                this.btnExit.HoverTextColor = ColorDorado;
                this.btnExit.Cursor = Cursors.Hand;
            }
        }
    


        

        private void BtnCapturaQR_Click(object sender, EventArgs e)
        {
            /*
            // 1. Instanciamos la nueva ventana de captura
            Registrar formCaptura = new Registrar();
            formCaptura.StartPosition = FormStartPosition.CenterScreen;

            // 2. Ocultamos el Menú Principal
            this.Hide();
            // 2. CERRAMOS COMPLETAMENTE LA VENTANA DE EL MENU PRINCIPAL
            //this.Dispose();

            // 3. EL TRUCO DE MAGIA: Le decimos a la ventana de captura que, 
            // cuando se cierre, vuelva a mostrar este Menú Principal.
            formCaptura.FormClosed += (s, args) => this.Show();

            // 4. Mostramos la ventana de captura
            formCaptura.Show(); 
            */

            Registrar formCaptura = new Registrar();
            formCaptura.StartPosition = FormStartPosition.CenterScreen;
            this.Hide(); // Oculta el Menú Principal en lugar de destruirlo
            formCaptura.Show(); // Muestra el formulario de captura como modal
            this.Show(); // Cuando se cierre el formulario de captura, vuelve a mostrar el Menú Principal
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
            formConsulta.Show();
            this.Show();
            // 4. Mostramos la ventana de captura
            //formConsulta.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de que deseas salir?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
    
            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnConsultarBeneficiario_Click(object sender, EventArgs e)
        {
            FormConsultarBeneficiario formConsultarBeneficiario = new FormConsultarBeneficiario();
            formConsultarBeneficiario.StartPosition = FormStartPosition.CenterScreen;
            //this.Hide();
            this.Close();
            formConsultarBeneficiario.Show();
            //this.Show();
        }
    }
}