using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SIPABE_DIFGRO_FAH
{
    

    public partial class FormAgregarApoyoBeneficiario : Form
    {
        object[] datosBeneficiario;

        public FormAgregarApoyoBeneficiario(object[] datosBeneficiario)
        {
            InitializeComponent();
            btnRegresarMenu.Text = "Regresar al menú";
            this.datosBeneficiario = datosBeneficiario;
            obtenerEstadoCivil();
            //obtenerVulnerabilidad();
            rellenarCampos();
        }

        public void rellenarCampos()
        {
            txtCurp.Text = datosBeneficiario[0].ToString();
            txtNombres.Text = datosBeneficiario[3].ToString();
            txtApellidoPaterno.Text = datosBeneficiario[4].ToString();
            txtApellidoMaterno.Text = datosBeneficiario[5].ToString();
            txtFechaNacimiento.Text = Convert.ToDateTime(datosBeneficiario[7]).ToString("dd/MM/yyyy");
            txtEntidadNacimiento.Text = datosBeneficiario[8].ToString();
            txtEntidadRegistro.Text = datosBeneficiario[9].ToString();
            txtSexo.Text = datosBeneficiario[10].ToString();
            comboEstadoCivil.SelectedValue = datosBeneficiario[13].ToString();

            
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            //VALIDACIONES DE QUE SI NO ESTÁ COMPLETO EL REGISTRO NO DEJA REGRESAR
            //Y TODO EL DESMADRE QUE ALGUNA VEZ HICE EN ACCESS
            MenuPrincipalForm principalForm = new MenuPrincipalForm();
            principalForm.Show();
            this.Dispose();
        }

        /*
        public void obtenerEstadoCivil()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                String query = "SELECT cve_estado_civil, estado_civil from Cat_Estado_Civil";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboEstadoCivil.Items.Clear();

                            // Opcional: Agregar un elemento por defecto
                            comboEstadoCivil.Items.Add("-- Seleccione --");

                            // Recorrer los resultados y agregarlos al ComboBox
                            while (reader.Read())
                            {
                                // Crear un objeto para guardar ambos valores
                                var item = new
                                {
                                    Value = reader["cve_estado_civil"].ToString(),
                                    Text = reader["estado_civil"].ToString()
                                };

                                // Agregar al ComboBox
                                comboEstadoCivil.Items.Add(item);
                            }

                            // Configurar DisplayMember y ValueMember
                            comboEstadoCivil.DisplayMember = "Text";
                            comboEstadoCivil.ValueMember = "Value";

                            // Seleccionar el primer elemento (el de "-- Seleccione --")
                            if (comboEstadoCivil.Items.Count > 0)
                            {
                                comboEstadoCivil.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex) { }
                }
            }
        }
        */
    
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
