using Microsoft.Data.SqlClient;
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
    public partial class ConsultarBeneficiario : LostForm
    {
        private readonly Color ColorVinoPrincipal = Color.FromArgb(105, 28, 50);   // #691C32
        private readonly Color ColorBeige = Color.FromArgb(245, 235, 215); // #F5EBD7
        private readonly Color ColorDorado = Color.FromArgb(197, 160, 89);  // #C5A059
        private readonly Color ColorBordeSuave = Color.FromArgb(210, 195, 175);

        private object[] datosBeneficiarioGlobal;

        public ConsultarBeneficiario()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            // Asegura el recentrado al lanzarse
            this.Load += (s, e) =>
            {
                this.CenterToScreen();
            };

            // 1. Configuración de LostForm
            this.Text = string.Empty;
            this.Image = null;
            this.ShowIcon = false;
            this.BackColor = ColorVinoPrincipal;
            this.HeaderColor = ColorVinoPrincipal;
            this.BorderColor = ColorDorado;

            // 2. Aplicar diseño y centrado
            ConfigurarDiseñoBusqueda();

            // 3. Foco directo a la caja para lectura inmediata del escáner
            this.Shown += (s, e) =>
            {
                if (this.txtCurpBeneficiario != null)
                {
                    this.ActiveControl = this.txtCurpBeneficiario;
                    this.txtCurpBeneficiario.Focus();
                }
            };
        }

        private void ConfigurarDiseñoBusqueda()
        {
            // 1. Título principal centrado
            if (this.label1 != null) // Ajusta al nombre de tu Label de título
            {
                this.label1.Text = "ESCANEE LA CURP DEL BENEFICIARIO";
                this.label1.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
                this.label1.ForeColor = ColorBeige;
                this.label1.BackColor = Color.Transparent;
                this.label1.AutoSize = true;

                this.label1.Location = new Point(
                    (this.ClientSize.Width - this.label1.PreferredWidth) / 2,
                    75
                );
            }

            // 2. Campo de búsqueda (HopeTextBox)
            int anchoCaja = 460;
            int altoCaja = 40;
            int posYCaja = 145;

            if (this.txtCurpBeneficiario != null)
            {
                foreach (Control c in this.txtCurpBeneficiario.Controls)
                {
                    if (c is TextBox txtInterno)
                    {
                        txtInterno.TextAlign = HorizontalAlignment.Center;
                    }
                }
                this.txtCurpBeneficiario.Size = new Size(anchoCaja, altoCaja);
                this.txtCurpBeneficiario.Location = new Point(
                    (this.ClientSize.Width - anchoCaja) / 2,
                    posYCaja
                );

                this.txtCurpBeneficiario.BackColor = ColorBeige;
                this.txtCurpBeneficiario.BaseColor = ColorBeige;
                this.txtCurpBeneficiario.BorderColorA = ColorDorado;
                this.txtCurpBeneficiario.BorderColorB = ColorBordeSuave;
                this.txtCurpBeneficiario.ForeColor = ColorVinoPrincipal;
                this.txtCurpBeneficiario.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
                this.txtCurpBeneficiario.Hint = string.Empty;
            }

            // 3. Botones CONSULTAR y REGRESAR
            int anchoBoton = 260;
            int altoBoton = 60;
            int separacionBotones = 30;
            int posYBotones = 220;

            int anchoGrupo = (anchoBoton * 2) + separacionBotones;
            int posXInicio = (this.ClientSize.Width - anchoGrupo) / 2;

            // Botón CONSULTAR
            if (this.btnConsultar != null)
            {
                this.btnConsultar.Text = "CONSULTAR";
                this.btnConsultar.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
                this.btnConsultar.Size = new Size(anchoBoton, altoBoton);
                this.btnConsultar.Location = new Point(posXInicio, posYBotones);
                this.btnConsultar.PrimaryColor = ColorBeige;
                this.btnConsultar.TextColor = ColorVinoPrincipal;
                this.btnConsultar.BorderColor = ColorDorado;
                this.btnConsultar.HoverTextColor = ColorDorado;
                this.btnConsultar.Cursor = Cursors.Hand;
            }

            // Botón REGRESAR
            if (this.btnRegresar != null)
            {
                this.btnRegresar.Text = "REGRESAR";
                this.btnRegresar.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
                this.btnRegresar.Size = new Size(anchoBoton, altoBoton);
                this.btnRegresar.Location = new Point(posXInicio + anchoBoton + separacionBotones, posYBotones);
                this.btnRegresar.PrimaryColor = ColorBeige;
                this.btnRegresar.TextColor = ColorVinoPrincipal;
                this.btnRegresar.BorderColor = ColorDorado;
                this.btnRegresar.HoverTextColor = ColorDorado;
                this.btnRegresar.Cursor = Cursors.Hand;
            }
        }

        // Manejo de ENTER y TAB al escanear
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter || keyData == Keys.Tab) &&
                (this.txtCurpBeneficiario != null && this.txtCurpBeneficiario.ContainsFocus))
            {
                // Dispara la acción del botón consultar al terminar de escanear
                btnConsultar_Click(this.btnConsultar, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
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

        private void txtCurpBeneficiario_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                metodoBusqueda();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipalForm menu = new MenuPrincipalForm();
            menu.Show();

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            metodoBusqueda();
        }

        private void buscarInformacionBeneficiario(String curpEvaluar)
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = @"SELECT TOP (1) 
                            [id_curp_beneficiario],
                            [QR_CURP],
                            [NADA],
                            [nombre_beneficiario],
                            [primer_apellido_beneficiario],
                            [segundo_apellido_beneficiario],
                            [fecha_nacimiento_invert],
                            [fecha_nacimiento],
                            [nom_ent_fed_nac],
                            [cve_ent_fed_reg],
                            [sexo],
                            [discapacidad],
                            [indigena],
                            [cve_civil],
                            [afrodescendiente],
                            [migrante],
                            [vulnerabilidad],
                            [tipo_discapacidad],
                            [tipo_vialidad],
                            [nom_vialidad],
                            [carretera],
                            [camino],
                            [num_ext_1],
                            [num_ext_2],
                            [num_ext_alf_1],
                            [num_int_num],
                            [num_int_alf],
                            [tipo_asen],
                            [nom_asen],
                            [cp],
                            [nom_loc],
                            [cve_loc],
                            [cve_loc_id],
                            [nom_mun],
                            [region],
                            [cve_mun],
                            [nom_ent],
                            [cve_ent],
                            [tipo_ref_1],
                            [nom_ref_1],
                            [tipo_ref_2],
                            [nom_ref_2],
                            [tipo_ref_3],
                            [nom_ref_3],
                            [descr_ubic],
                            [ID_ESCUELA],
                            [CCT],
                            [NOMBRE_ESCUELA],
                            [TURNO],
                            [MUNICIPIO],
                            [LOCALIDAD],
                            [TIPO],
                            [NIVEL],
                            [SUBNIVEL],
                            [GRADO],
                            [id_beneficiario],
                            [creador],
                            [fecha_registro_sipabe],
                            [validado_RENAPO],
                            [estatus_vital]
                        FROM [SIPABE_DIF_GR0].[dbo].[BENEFICIARIO]
                        WHERE id_curp_beneficiario = @dato";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@dato", curpEvaluar);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Crear un array con todos los campos
                                object[] datosBeneficiario = new object[reader.FieldCount];
                                reader.GetValues(datosBeneficiario);

                                // Guardar en una variable local (de clase)
                                this.datosBeneficiarioGlobal = datosBeneficiario;

                                FormMenuUsuarioEncontrado formMenu = new FormMenuUsuarioEncontrado(datosBeneficiario);
                                formMenu.StartPosition = FormStartPosition.CenterScreen;
                                formMenu.Show();

                                // También puedes mostrar el primer campo (CURP) como confirmación
                                // MessageBox.Show($"Beneficiario encontrado: {datosBeneficiario[0]}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // No se encontró el registro
                                MessageBox.Show("Beneficiario no encontrado. \n Debe registrarlo a continuación", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                Registrar formCaptura = new Registrar();
                                formCaptura.StartPosition = FormStartPosition.CenterScreen;
                                this.Hide(); // Oculta el Menú Principal en lugar de destruirlo
                                formCaptura.ShowDialog(); // Muestra el formulario de captura como modal
                                this.Show(); // Cuando se cierre el formulario de captura, vuelve a mostrar el Menú Principal

                            }
                        }

                        // Cerramos el buscador flotante
                        this.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error en la búsqueda: " + ex.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void metodoBusqueda()
        {
            if (txtCurpBeneficiario.Text.Length == 18)
            {
                //-----------------------------
                // AKI DEVO DE KOLOKAR UNA FUNZYON BOOLEANA QUE VERIFIQUE SI LA CURP CONTIENE LA ESTRUCTURA DE CURP
                // 4 PRIMEROS DIGITOS (LETRAS)
                // 6 DIGITOS MAS (SOLO NÚMEROS)
                // 1 DIGITO (H O M)
                // 2 DIGITOS DE LA CLAVE RENAPO, YA SABES, GR PA GUERRERO, SN PA SINALOA, BC PA BAJA CALIFORNIA, Y UN PEZCADO PA VERACRU´ XD
                //-----------------------------

                buscarInformacionBeneficiario(txtCurpBeneficiario.Text.Substring(0, 18));
            }
            else
            {
                MessageBox.Show("El campo de la curp debe tener 18 dígitos.\nAhorita solo tiene: " + txtCurpBeneficiario.Text.Length, "CURP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurpBeneficiario.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
