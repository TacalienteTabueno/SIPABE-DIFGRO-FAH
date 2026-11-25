using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIPABE_DIFGRO_FAH
{
    

    public partial class FormAgregarApoyoBeneficiario : Form
    {
        
        BeneficiarioItem beneficiario;

        public FormAgregarApoyoBeneficiario(/*object[] datosBeneficiario*/ BeneficiarioItem beneficiario)
        {
            InitializeComponent();
            btnRegresarMenu.Text = "BACK TO MENU";
            this.beneficiario = beneficiario;
            obtenerEstadoCivil();
            obtenerVulnerabilidad();
            //obtenerVulnerabilidad();
            rellenarCampos();
            
        }

        public void rellenarCampos()
        {
            //Campos de la curp
            txtCurp.Text = beneficiario.id_curp_beneficiario;
            txtNombres.Text = beneficiario.nombre_beneficiario;
            txtApellidoPaterno.Text = beneficiario.primer_apellido_beneficiario;
            txtApellidoMaterno.Text = beneficiario.segundo_apellido_beneficiario;
            txtFechaNacimiento.Text = beneficiario.fecha_nacimiento.HasValue ? beneficiario.fecha_nacimiento.Value.ToString("dd/MM/yyyy") : string.Empty;
            txtEntidadNacimiento.Text = beneficiario.nom_ent_fed_nac;
            txtEntidadRegistro.Text = beneficiario.cve_ent_fed_reg;
            txtSexo.Text = beneficiario.sexo;

            //Campos de la persona
            if (!string.IsNullOrWhiteSpace(beneficiario.cve_civil))
            {
                comboEstadoCivil.SelectedValue = beneficiario.cve_civil.Trim(); // quita espacios si en SQL Server es char(n)
            }
            else
            {
                comboEstadoCivil.SelectedIndex = 0; // vuelve a "Seleccione..."
            }

            string vulnerabilidadBuscada = beneficiario.vulnerabilidad?.Trim() ?? string.Empty;
            comboVulnerabilidad.SelectedIndex = 0; // "-- Seleccione --" por defecto

            if (!string.IsNullOrWhiteSpace(vulnerabilidadBuscada))
            {
                for (int i = 0; i < comboVulnerabilidad.Items.Count; i++)
                {
                    if (comboVulnerabilidad.Items[i] is VulnerabilidadItem item &&
                        string.Equals(item.Descripcion?.Trim(), vulnerabilidadBuscada, StringComparison.OrdinalIgnoreCase))
                    {
                        comboVulnerabilidad.SelectedIndex = i;
                        break;
                    }
                }
            }
           
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            //VALIDACIONES DE QUE SI NO ESTÁ COMPLETO EL REGISTRO NO DEJA REGRESAR
            //Y TODO EL DESMADRE QUE ALGUNA VEZ HICE EN ACCESS
            MenuPrincipalForm principalForm = new MenuPrincipalForm();
            principalForm.Show();
            this.Dispose();
        }
            
        public void obtenerEstadoCivil()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                String query = "SELECT cve_estado_civil, estado_civil FROM Cat_Estado_Civil";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Crear lista
                            List<EstadoCivilItem> listaEstados = new List<EstadoCivilItem>();

                            // Agregar elemento por defecto
                            listaEstados.Add(new EstadoCivilItem { Clave = "", Descripcion = "-- Seleccione --" });

                            // Recorrer y agregar a la lista
                            while (reader.Read())
                            {
                                listaEstados.Add(new EstadoCivilItem
                                {
                                    Clave = reader["cve_estado_civil"].ToString(),
                                    Descripcion = reader["estado_civil"].ToString()
                                });
                            }

                            // Asignar al ComboBox
                            comboEstadoCivil.DataSource = null; // Limpiar
                            comboEstadoCivil.DataSource = listaEstados;
                            comboEstadoCivil.DisplayMember = "Descripcion";
                            comboEstadoCivil.ValueMember = "Clave";

                            // Seleccionar el primero
                            if (comboEstadoCivil.Items.Count > 0)
                            {
                                comboEstadoCivil.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar estados civiles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerVulnerabilidad()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                String query = "SELECT Tipo_Vulnerabilidad FROM Cat_Vulnerabilidad";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<VulnerabilidadItem> listaVulnerabilidades = new List<VulnerabilidadItem>();

                            // Agregar elemento por defecto
                            listaVulnerabilidades.Add(new VulnerabilidadItem { Descripcion = "-- Seleccione --" });

                            // Recorrer y agregar a la lista
                            while (reader.Read())
                            {
                                listaVulnerabilidades.Add(new VulnerabilidadItem
                                {
                                    Descripcion = reader["Tipo_Vulnerabilidad"].ToString()
                                });
                            }

                            // Asignar al ComboBox
                            comboVulnerabilidad.DataSource = null;
                            comboVulnerabilidad.DataSource = listaVulnerabilidades;
                            comboVulnerabilidad.DisplayMember = "Descripcion";
                            // ⚠️ NO uses ValueMember porque no hay clave

                            if (comboVulnerabilidad.Items.Count > 0)
                            {
                                comboVulnerabilidad.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar vulnerabilidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
