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
    public partial class FormMenuUsuarioEncontrado : LostForm
    {
        private readonly Color ColorVinoPrincipal = Color.FromArgb(105, 28, 50);   // #691C32
        private readonly Color ColorBeige = Color.FromArgb(245, 235, 215); // #F5EBD7
        private readonly Color ColorDorado = Color.FromArgb(197, 160, 89);  // #C5A059
       
        /*public FormMenuUsuarioEncontrado()
        {
            InitializeComponent();
        }*/

        private object[] datosBeneficiarioGlobal;

        public FormMenuUsuarioEncontrado(object[] datosBeneficiario)
        {
            InitializeComponent();

            this.Text = string.Empty;
            this.Image = null;
            this.ShowIcon = false;
            this.BackColor = ColorVinoPrincipal;
            this.HeaderColor = ColorVinoPrincipal;
            this.BorderColor = ColorDorado;

            ConfigurarDiseñoUsuarioEncontrado();

            this.datosBeneficiarioGlobal = datosBeneficiario;

            // Aquí puedes usar los datos para llenar los controles
            lblCurp.Text = datosBeneficiario[0].ToString();
            lblNombreCompleto.Text = datosBeneficiario[3].ToString() + " " + datosBeneficiario[4].ToString() + " " + datosBeneficiario[5].ToString();
        }

        private void ConfigurarDiseñoUsuarioEncontrado()
        {

            void AlinearAlCentro(Label lbl, int posY, Font fuente, Color colorTexto, string texto = null)
            {
                if (lbl == null) return;

                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Location = new Point(0, posY);
                lbl.Size = new Size(this.ClientSize.Width, 38);
                lbl.Font = fuente;
                lbl.ForeColor = colorTexto;
                lbl.BackColor = Color.Transparent;
                if (texto != null) lbl.Text = texto;
            }

            // 1. TÍTULO PRINCIPAL (label1)
            AlinearAlCentro(this.label1, 45, new Font("Segoe UI", 22f, FontStyle.Bold), ColorBeige, "BENEFICIARIO EXISTENTE");

            // 2. CURP
            AlinearAlCentro(this.lblCurp, 95, new Font("Segoe UI", 20f, FontStyle.Bold), ColorDorado);

            // 3. NOMBRE COMPLETO
            AlinearAlCentro(this.lblNombreCompleto, 145, new Font("Segoe UI", 20f, FontStyle.Bold), ColorBeige);

            // 4. SUBTÍTULO DE INSTRUCCIÓN (label2)
            AlinearAlCentro(this.label2, 205, new Font("Segoe UI", 12f, FontStyle.Bold), ColorDorado, "ELIJA UNA OPCIÓN PARA CONTINUAR");

            // 5. CENTRADO Y POSICIÓN INFERIOR DE LOS 3 BOTONES
            int anchoBoton = 240;
            int altoBoton = 60;
            int separacion = 20;
            int posYBotones = 285; // Altura inferior equilibrada

            int anchoTotalGrupo = (anchoBoton * 3) + (separacion * 2);
            int posXInicio = (this.ClientSize.Width - anchoTotalGrupo) / 2;

            if (this.btnAgregar != null)
            {
                EstilizarBoton(this.btnAgregar, "AGREGAR APOYO", posXInicio, posYBotones, anchoBoton, altoBoton);
            }

            if (this.btnConsultarHistorial != null)
            {
                EstilizarBoton(this.btnConsultarHistorial, "CONSULTAR HISTORIAL", posXInicio + anchoBoton + separacion, posYBotones, anchoBoton, altoBoton);
            }

            if (this.btnRegresar != null)
            {
                EstilizarBoton(this.btnRegresar, "REGRESAR", posXInicio + ((anchoBoton + separacion) * 2), posYBotones, anchoBoton, altoBoton);
            }

        }

        private void EstilizarBoton(HopeButton btn, string texto, int x, int y, int ancho, int alto)
        {
            btn.Text = texto;
            btn.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            btn.Size = new Size(ancho, alto);
            btn.Location = new Point(x, y);
            btn.PrimaryColor = ColorBeige;
            btn.TextColor = ColorVinoPrincipal;
            btn.BorderColor = ColorDorado;
            btn.HoverTextColor = ColorDorado;
            btn.Cursor = Cursors.Hand;

            // Mantiene el color beige en hover
            btn.MouseEnter += (s, e) => { btn.PrimaryColor = ColorBeige; };
            btn.MouseLeave += (s, e) => { btn.PrimaryColor = ColorBeige; };
        }

       
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            ConsultarBeneficiario formConsultarBeneficiario = new ConsultarBeneficiario();
            formConsultarBeneficiario.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormAgregarApoyoBeneficiario formAgregarApoyoBeneficiario = new FormAgregarApoyoBeneficiario(this.datosBeneficiarioGlobal);
            formAgregarApoyoBeneficiario.Show();
            this.Close();
        }

        private void lblNombreCompleto_Click(object sender, EventArgs e)
        {

        }
    }
}
