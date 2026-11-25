using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace SIPABE_DIFGRO_FAH
{
    public partial class FormAgregarApoyoBeneficiario : Form
    {
        private readonly object[] datosBeneficiario;
        private bool cargandoInicial = true; // Bandera para evitar disparos prematuros de eventos
        private System.Windows.Forms.Timer _timerFiltro;

        SolicitudItem solicitudItem;

        //List<SolicitudItem> solicitudItem;
        public FormAgregarApoyoBeneficiario(object[] datosBeneficiario)
        {
            InitializeComponent();
            solicitudItem = new SolicitudItem();  //---INICIALIZACIÓN DEL ARREGLO
            solicitudItem.ID_Curp_Beneficiario = datosBeneficiario[0].ToString();
            //solicitudItem = new List<SolicitudItem>();
            btnRegresarMenu.Text = "REGRESAR AL MENÚ";
            this.datosBeneficiario = datosBeneficiario;
            txtTipoApoyo.Enabled = false;




            // 1. Cargar todos los catálogos base
            obtenerEstadoCivil();
            obtenerVulnerabilidad();
            obtenerIndigena();
            obtenerDiscapacidad();
            obtenerAfrodescendiente();
            obtenerMigrante();

            comboEscuelas.DropDownStyle = ComboBoxStyle.DropDown; // permite escribir
            comboEscuelas.AutoCompleteMode = AutoCompleteMode.None; // control manual del filtro
            comboEscuelas.TextUpdate += comboEscuelas_TextUpdate;

            cargarEscuelas(); // carga inicial (sin filtro)

            //---------------
            obtenerIndependencias();

            //------
            obtenerEntidades();
            obtenerTipoBenficiario();
            // 2. Inicializar comboTipoDiscapacidad bloqueado
            comboTipoDiscapacidad.Enabled = false;
            comboTipoDiscapacidad.DataSource = null;

            // 3. Rellenar campos con los datos recibidos
            rellenarCampos();

            // 4. Manejar específicamente discapacidad y tipo de discapacidad
            ConfigurarDiscapacidadInicial();

            // Permitir que los eventos del usuario operen normalmente
            cargandoInicial = false;
        }

        public void rellenarCampos()
        {
            if (datosBeneficiario == null) return;

            txtCurp.Text = datosBeneficiario.Length > 0 ? datosBeneficiario[0]?.ToString() ?? "" : "";
            txtNombres.Text = datosBeneficiario.Length > 3 ? datosBeneficiario[3]?.ToString() ?? "" : "";
            txtApellidoPaterno.Text = datosBeneficiario.Length > 4 ? datosBeneficiario[4]?.ToString() ?? "" : "";
            txtApellidoMaterno.Text = datosBeneficiario.Length > 5 ? datosBeneficiario[5]?.ToString() ?? "" : "";

            if (datosBeneficiario.Length > 7 && datosBeneficiario[7] != null && !string.IsNullOrWhiteSpace(datosBeneficiario[7].ToString()))
            {
                if (DateTime.TryParse(datosBeneficiario[7].ToString(), out DateTime fechaNac))
                {
                    txtFechaNacimiento.Text = fechaNac.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtFechaNacimiento.Text = datosBeneficiario[7].ToString();
                }
            }

            txtEntidadNacimiento.Text = datosBeneficiario.Length > 8 ? datosBeneficiario[8]?.ToString() ?? "" : "";
            txtEntidadRegistro.Text = datosBeneficiario.Length > 9 ? datosBeneficiario[9]?.ToString() ?? "" : "";
            txtSexo.Text = datosBeneficiario.Length > 10 ? datosBeneficiario[10]?.ToString() ?? "" : "";

            // INDÍGENA
            string claveIndigena = datosBeneficiario.Length > 12 ? datosBeneficiario[12]?.ToString() ?? "" : "";
            SeleccionarItemCombo(comboIndigena, claveIndigena);

            // ESTADO CIVIL
            if (datosBeneficiario.Length > 13 && datosBeneficiario[13] != null)
            {
                comboEstadoCivil.SelectedValue = datosBeneficiario[13].ToString();
                if (comboEstadoCivil.SelectedIndex == -1 && comboEstadoCivil.Items.Count > 0)
                {
                    comboEstadoCivil.SelectedIndex = 0;
                }
            }

            // AFRODESCENDIENTE
            string claveAfrodescendiente = datosBeneficiario.Length > 14 ? datosBeneficiario[14]?.ToString() ?? "" : "";
            SeleccionarItemCombo(comboAfrodescendiente, claveAfrodescendiente);

            // MIGRANTE
            string claveMigrante = datosBeneficiario.Length > 15 ? datosBeneficiario[15]?.ToString() ?? "" : "";
            SeleccionarItemCombo(comboMigrante, claveMigrante);

            // VULNERABILIDAD
            string claveVulnerabilidad = datosBeneficiario.Length > 16 ? datosBeneficiario[16]?.ToString() ?? "" : "";
            SeleccionarItemCombo(comboVulnerabilidad, claveVulnerabilidad);
        }

        private void ConfigurarDiscapacidadInicial()
        {
            string claveDiscapacidad = datosBeneficiario != null && datosBeneficiario.Length > 11
                ? datosBeneficiario[11]?.ToString()?.Trim() ?? ""
                : "";

            // Seleccionar "SI" o "NO" en comboDiscapacidad
            bool encontrado = false;
            foreach (var item in comboDiscapacidad.Items)
            {
                if (item is DiscapacidadItem discItem && discItem.Clave.Equals(claveDiscapacidad, StringComparison.OrdinalIgnoreCase))
                {
                    comboDiscapacidad.SelectedItem = discItem;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado && comboDiscapacidad.Items.Count > 0)
            {
                comboDiscapacidad.SelectedIndex = 0;
            }

            // Si tiene "SI", activar catálogo y precargar valor si existe
            if (claveDiscapacidad.Equals("SI", StringComparison.OrdinalIgnoreCase))
            {
                comboTipoDiscapacidad.Enabled = true;
                obtenerTipoDiscapacidad();

                string tipoGuardado = datosBeneficiario != null && datosBeneficiario.Length > 17
                    ? datosBeneficiario[17]?.ToString()?.Trim() ?? ""
                    : "";

                if (!string.IsNullOrEmpty(tipoGuardado))
                {
                    bool tipoEncontrado = false;
                    foreach (var it in comboTipoDiscapacidad.Items)
                    {
                        if (it is TipoDiscapacidadItem tItem &&
                           (tItem.Clave.Equals(tipoGuardado, StringComparison.OrdinalIgnoreCase) ||
                            tItem.Descripcion.Equals(tipoGuardado, StringComparison.OrdinalIgnoreCase)))
                        {
                            comboTipoDiscapacidad.SelectedItem = tItem;
                            tipoEncontrado = true;
                            break;
                        }
                    }

                    if (!tipoEncontrado && comboTipoDiscapacidad.Items.Count > 0)
                    {
                        comboTipoDiscapacidad.SelectedIndex = 0;
                    }
                }
                else if (comboTipoDiscapacidad.Items.Count > 0)
                {
                    comboTipoDiscapacidad.SelectedIndex = 0;
                }
            }
            else
            {
                comboTipoDiscapacidad.Enabled = false;
                comboTipoDiscapacidad.DataSource = null;
            }
        }

        private void SeleccionarItemCombo(ComboBox combo, string valor)
        {
            bool match = false;
            foreach (var item in combo.Items)
            {
                string itemVal = "";
                if (item is IndigenaItem ind) itemVal = ind.Clave;
                else if (item is AfrodescendienteItem afro) itemVal = afro.Clave;
                else if (item is MigranteItem mig) itemVal = mig.Clave;
                else if (item is VulnerabilidadItem vul) itemVal = vul.Clave;

                if (!string.IsNullOrEmpty(itemVal) && itemVal.Equals(valor, StringComparison.OrdinalIgnoreCase))
                {
                    combo.SelectedItem = item;
                    match = true;
                    break;
                }
            }

            if (!match && combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        private void comboDiscapacidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return; // Evitar disparar mientras se construyen los datos del formulario

            try
            {
                if (comboDiscapacidad.SelectedItem is DiscapacidadItem itemSeleccionado &&
                    itemSeleccionado.Clave.Trim().Equals("SI", StringComparison.OrdinalIgnoreCase))
                {
                    comboTipoDiscapacidad.Enabled = true;
                    obtenerTipoDiscapacidad();

                    // Si trae valor en el arreglo, seleccionarlo; si no, queda en "-- Seleccione --"
                    string claveTipo = datosBeneficiario != null && datosBeneficiario.Length > 17
                        ? datosBeneficiario[17]?.ToString()?.Trim() ?? ""
                        : "";

                    bool seleccionado = false;
                    if (!string.IsNullOrEmpty(claveTipo))
                    {
                        foreach (var it in comboTipoDiscapacidad.Items)
                        {
                            if (it is TipoDiscapacidadItem tItem &&
                               (tItem.Clave.Equals(claveTipo, StringComparison.OrdinalIgnoreCase) ||
                                tItem.Descripcion.Equals(claveTipo, StringComparison.OrdinalIgnoreCase)))
                            {
                                comboTipoDiscapacidad.SelectedItem = tItem;
                                seleccionado = true;
                                break;
                            }
                        }
                    }

                    if (!seleccionado && comboTipoDiscapacidad.Items.Count > 0)
                    {
                        comboTipoDiscapacidad.SelectedIndex = 0;
                    }
                }
                else
                {
                    comboTipoDiscapacidad.Enabled = false;
                    comboTipoDiscapacidad.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresarMenu_Click(object sender, EventArgs e)
        {
            MenuPrincipalForm principalForm = new MenuPrincipalForm();
            principalForm.Show();
            this.Close();
        }

        public void obtenerEstadoCivil()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT cve_estado_civil, estado_civil FROM Cat_Estado_Civil";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<EstadoCivilItem> listaEstados = new List<EstadoCivilItem>
                            {
                                new EstadoCivilItem { Clave = "", Descripcion = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaEstados.Add(new EstadoCivilItem
                                {
                                    Clave = reader["cve_estado_civil"].ToString(),
                                    Descripcion = reader["estado_civil"].ToString()
                                });
                            }

                            comboEstadoCivil.DataSource = null;
                            comboEstadoCivil.DisplayMember = "Descripcion";
                            comboEstadoCivil.ValueMember = "Clave";
                            comboEstadoCivil.DataSource = listaEstados;

                            if (comboEstadoCivil.Items.Count > 0) comboEstadoCivil.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar estados civiles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerDiscapacidad()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Id_Discapacidad FROM Cat_Discapacidad";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<DiscapacidadItem> listaDiscapacidad = new List<DiscapacidadItem>
                            {
                                new DiscapacidadItem { Clave = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaDiscapacidad.Add(new DiscapacidadItem
                                {
                                    Clave = reader["Id_Discapacidad"].ToString()
                                });
                            }

                            comboDiscapacidad.DataSource = null;
                            comboDiscapacidad.DisplayMember = "Clave";
                            comboDiscapacidad.ValueMember = "Clave";
                            comboDiscapacidad.DataSource = listaDiscapacidad;

                            if (comboDiscapacidad.Items.Count > 0) comboDiscapacidad.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar discapacidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerIndigena()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Id_Indigena FROM Cat_Indigena";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<IndigenaItem> listaIndigena = new List<IndigenaItem>
                            {
                                new IndigenaItem { Clave = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaIndigena.Add(new IndigenaItem
                                {
                                    Clave = reader["Id_Indigena"].ToString()
                                });
                            }

                            comboIndigena.DataSource = null;
                            comboIndigena.DisplayMember = "Clave";
                            comboIndigena.ValueMember = "Clave";
                            comboIndigena.DataSource = listaIndigena;

                            if (comboIndigena.Items.Count > 0) comboIndigena.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar indígenas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerVulnerabilidad()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Tipo_Vulnerabilidad FROM Cat_Vulnerabilidad";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<VulnerabilidadItem> listaVulnerabilidad = new List<VulnerabilidadItem>
                            {
                                new VulnerabilidadItem { Clave = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaVulnerabilidad.Add(new VulnerabilidadItem
                                {
                                    Clave = reader["Tipo_Vulnerabilidad"].ToString()
                                });
                            }

                            comboVulnerabilidad.DataSource = null;
                            comboVulnerabilidad.DisplayMember = "Clave";
                            comboVulnerabilidad.ValueMember = "Clave";
                            comboVulnerabilidad.DataSource = listaVulnerabilidad;

                            if (comboVulnerabilidad.Items.Count > 0) comboVulnerabilidad.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar vulnerabilidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerAfrodescendiente()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Id_Afrodescendiente FROM Cat_Afrodescendiente";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<AfrodescendienteItem> listaAfrodescendiente = new List<AfrodescendienteItem>
                            {
                                new AfrodescendienteItem { Clave = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaAfrodescendiente.Add(new AfrodescendienteItem
                                {
                                    Clave = reader["Id_Afrodescendiente"].ToString()
                                });
                            }

                            comboAfrodescendiente.DataSource = null;
                            comboAfrodescendiente.DisplayMember = "Clave";
                            comboAfrodescendiente.ValueMember = "Clave";
                            comboAfrodescendiente.DataSource = listaAfrodescendiente;

                            if (comboAfrodescendiente.Items.Count > 0) comboAfrodescendiente.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar afrodescendientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerMigrante()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Id_Migrante FROM Cat_Migrante";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<MigranteItem> listaMigrante = new List<MigranteItem>
                            {
                                new MigranteItem { Clave = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaMigrante.Add(new MigranteItem
                                {
                                    Clave = reader["Id_Migrante"].ToString()
                                });
                            }

                            comboMigrante.DataSource = null;
                            comboMigrante.DisplayMember = "Clave";
                            comboMigrante.ValueMember = "Clave";
                            comboMigrante.DataSource = listaMigrante;

                            if (comboMigrante.Items.Count > 0) comboMigrante.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar migrantes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerTipoDiscapacidad()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Id_Discapacidad, Tipo_Discapacidad FROM Cat_Tipo_Discapacidad";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<TipoDiscapacidadItem> listaTiposDiscapacidad = new List<TipoDiscapacidadItem>
                            {
                                new TipoDiscapacidadItem { Clave = "", Descripcion = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaTiposDiscapacidad.Add(new TipoDiscapacidadItem
                                {
                                    Clave = reader["Id_Discapacidad"].ToString(),
                                    Descripcion = reader["Tipo_Discapacidad"].ToString()
                                });
                            }

                            comboTipoDiscapacidad.DataSource = null;
                            comboTipoDiscapacidad.DisplayMember = "Descripcion";
                            comboTipoDiscapacidad.ValueMember = "Clave";
                            comboTipoDiscapacidad.DataSource = listaTiposDiscapacidad;

                            if (comboTipoDiscapacidad.Items.Count > 0)
                            {
                                comboTipoDiscapacidad.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar tipos de discapacidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboInstitucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar que se ejecute durante la carga inicial
            if (cargandoInicial) return;

            try
            {
                // Obtener el ID de la institución seleccionada
                if (comboInstitucion.SelectedItem is InstitucionItem itemSeleccionado)
                {
                    // Validar que no sea el item por defecto
                    if (!string.IsNullOrEmpty(itemSeleccionado.ID_Institucion))
                    {
                        int idInstitucion = Convert.ToInt32(itemSeleccionado.ID_Institucion);

                        solicitudItem.Institucion = itemSeleccionado.Cve_Institucion;

                        // Cargar direcciones
                        obtenerDirecciones(idInstitucion);
                    }
                    else
                    {
                        // Si seleccionó "-- Seleccione --", limpiar todo
                        //LimpiarCombosDependientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar institución: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar que se ejecute durante la carga inicial
            if (cargandoInicial) return;

            try
            {
                // Obtener la dirección seleccionada
                if (comboDireccion.SelectedItem is DireccionItem itemSeleccionado)
                {
                    // Validar que no sea el item por defecto (ID_Direccion no esté vacío y no sea "0")
                    if (!string.IsNullOrEmpty(itemSeleccionado.ID_Direccion) && itemSeleccionado.ID_Direccion != "0")
                    {
                        int idDireccion = Convert.ToInt32(itemSeleccionado.ID_Direccion);

                        solicitudItem.Direccion = itemSeleccionado.Nombre_Direccion;
                        //Console.WriteLine(solicitudItem.ID_Curp_Beneficiario + " - " + solicitudItem.Institucion + " - " + solicitudItem.Direccion);

                        // Cargar ejercicios fiscales
                        obtenerEjerciciosFiscales(idDireccion);
                    }
                    else
                    {
                        // Si seleccionó "-- Seleccione --", limpiar todo
                        //LimpiarCombosDependientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar dirección: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboEjercicioFiscal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar que se ejecute durante la carga inicial
            if (cargandoInicial) return;

            try
            {
                // Obtener la dirección seleccionada
                if (comboEjercicioFiscal.SelectedItem is EjercicioFiscalItem itemSeleccionado)
                {
                    // Validar que no sea el item por defecto (ID_Direccion no esté vacío y no sea "0")
                    if (!string.IsNullOrEmpty(itemSeleccionado.ID_Ejercicio) && itemSeleccionado.ID_Ejercicio != "0")
                    {
                        int idEjercicio = Convert.ToInt32(itemSeleccionado.ID_Ejercicio);

                        solicitudItem.Ejercicio_Fiscal = itemSeleccionado.Nombre_Ejercicio;

                        // Cargar ejercicios fiscales
                        obtenerProgramas(idEjercicio);
                    }
                    else
                    {
                        // Si seleccionó "-- Seleccione --", limpiar todo
                        //LimpiarCombosDependientes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar ejercicio: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Evitar que se ejecute durante la carga inicial
            if (cargandoInicial) return;

            try
            {
                // Obtener la dirección seleccionada
                if (comboPrograma.SelectedItem is ProgramaItem itemSeleccionado)
                {
                    // Validar que no sea el item por defecto (ID_Direccion no esté vacío y no sea "0")
                    if (!string.IsNullOrEmpty(itemSeleccionado.ID_Programa) && itemSeleccionado.ID_Programa != "0")
                    {
                        int idPrograma = Convert.ToInt32(itemSeleccionado.ID_Programa);

                        solicitudItem.Programa = itemSeleccionado.Nombre_Programa;
                        solicitudItem.Fuent_Financiamiento = itemSeleccionado.Fuente_Financiamiento;
                        // Cargar ejercicios fiscales
                        obtenerApoyos(idPrograma);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar programas: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboApoyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                if (comboApoyo.SelectedItem is ApoyoItem itemSeleccionado)
                {
                    if (!string.IsNullOrEmpty(itemSeleccionado.ID_Apoyo) && itemSeleccionado.ID_Apoyo != "0")
                    {
                        int idApoyo = Convert.ToInt32(itemSeleccionado.ID_Apoyo);

                        solicitudItem.NOMBRE_APOYO = itemSeleccionado.Nombre_Apoyo;
                        txtTipoApoyo.Text = solicitudItem.Desc_Tipo_Beneficio = itemSeleccionado.Tipo_Beneficio;
                        solicitudItem.Cve_Programa = itemSeleccionado.Cve_Programa;
                        solicitudItem.Cve_Dependencia = itemSeleccionado.Cve_Dependencia;
                        solicitudItem.Cve_Intraprograma = itemSeleccionado.Cve_Intraprograma;
                        solicitudItem.Tipo_Beneficio_U_Med = itemSeleccionado.Tipo_Apoyo;
                        solicitudItem.Clave_Beneficio_DIF_Nacional = itemSeleccionado.Clave_Beneficio_Dif_Nacional;
                        solicitudItem.Fecha_Captura = DateTime.Now;

                        solicitudItem.Capturista = LoginForm.NombreCapturistaActual;

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar apoyo: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboEntidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                comboMunicipio.DataSource = null;
                comboMunicipio.Items.Clear();

                if (comboEntidad.SelectedItem is EntidadesItem entidadSeleccionada)
                {
                    if (!string.IsNullOrEmpty(entidadSeleccionada.Cve_Entidad)
                        && entidadSeleccionada.Cve_Entidad != "0")
                    {
                        solicitudItem.Cve_Ent_Fed = entidadSeleccionada.Cve_Entidad;
                        solicitudItem.Nom_Ent_Fed = entidadSeleccionada.Nombre_Entidad.ToString();

                        obtenerMunicipio(entidadSeleccionada.Cve_Entidad);
                    }
                    else
                    {
                        comboMunicipio.DataSource = null;
                        comboMunicipio.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar entidad: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                // Limpiamos el combo de localidades antes de recargar
                comboLocalidad.DataSource = null;
                comboLocalidad.Items.Clear();

                if (comboMunicipio.SelectedItem is MunicipiosItem municipioSeleccionado)
                {
                    if (!string.IsNullOrEmpty(municipioSeleccionado.Cve_Municipio)
                        && municipioSeleccionado.Cve_Municipio != "0")
                    {
                        solicitudItem.Cve_Municipio = municipioSeleccionado.Cve_Municipio;
                        solicitudItem.Nom_Municipio = municipioSeleccionado.Nombre_Municipio;

                        obtenerLocalidad(municipioSeleccionado.Cve_Municipio);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar municipio: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                if (comboLocalidad.SelectedItem is LocalidadesItem localidadSeleccionada)
                {
                    if (!string.IsNullOrEmpty(localidadSeleccionada.Cve_Localidad_ID)
                        && localidadSeleccionada.Cve_Localidad_ID != "0")
                    {
                        solicitudItem.Cve_Localidad = localidadSeleccionada.Cve_Localidad;
                        solicitudItem.Cve_Localidad_ID = localidadSeleccionada.Cve_Localidad_ID;
                        solicitudItem.Nom_Localidad = localidadSeleccionada.Nombre_Localidad;
                        solicitudItem.Region_Apoyo = localidadSeleccionada.Region;
                        solicitudItem.Fecha_Solicitud = dateFechaEntrega.Value.ToLocalTime();
                        solicitudItem.Fecha_Solicitud_Invert = obtenerFechaInvertida(dateFechaEntrega.Value);
                        solicitudItem.Cantidad_Apoyo = Convert.ToDecimal(txtCantidadApoyo.Text);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar localidad: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal obtenerFechaInvertida(DateTime fechaOriginal)
        {
            return decimal.Parse(fechaOriginal.ToString("yyyyMMdd"));
        }

        private void LimpiarCombosDependientes()
        {
            // Limpiar direcciones
            comboDireccion.DataSource = null;
            comboDireccion.Items.Clear();

            // Limpiar ejercicios fiscales
            comboEjercicioFiscal.DataSource = null;
            comboEjercicioFiscal.Items.Clear();

            // Limpiar programas
            comboPrograma.DataSource = null;
            comboPrograma.Items.Clear();

            // Limpiar apoyos
            comboApoyo.DataSource = null;
            comboApoyo.Items.Clear();
        }

        public void obtenerIndependencias()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT ID_Institucion, Cve_Institucion, Institucion FROM Cat_Instituciones";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<InstitucionItem> listaInsitucion = new List<InstitucionItem>
                            {
                                new InstitucionItem { ID_Institucion = "", Cve_Institucion = "", Institucion = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaInsitucion.Add(new InstitucionItem
                                {
                                    ID_Institucion = reader["ID_Institucion"].ToString(),
                                    Cve_Institucion = reader["Cve_Institucion"].ToString(),
                                    Institucion = reader["Institucion"].ToString()
                                });
                            }

                            comboInstitucion.DataSource = null;
                            comboInstitucion.DisplayMember = "Institucion";
                            comboInstitucion.ValueMember = "ID_Institucion";
                            comboInstitucion.DataSource = listaInsitucion;

                            if (comboInstitucion.Items.Count > 0)
                            {
                                comboInstitucion.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar instituciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void obtenerDirecciones(int idInstitucion)
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                // ✅ Agregar ID_Institucion al SELECT
                string query = "SELECT ID_Direccion, Nombre_Direccion, ID_Institucion FROM Cat_Direcciones WHERE ID_Institucion = @idInstitucion";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@idInstitucion", idInstitucion);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<DireccionItem> listaDirecciones = new List<DireccionItem>
                    {
                        new DireccionItem { ID_Direccion = "0", Nombre_Direccion = "-- Seleccione --", ID_Institucion = idInstitucion.ToString() }
                    };

                            while (reader.Read())
                            {
                                listaDirecciones.Add(new DireccionItem
                                {
                                    ID_Direccion = reader["ID_Direccion"].ToString(),
                                    Nombre_Direccion = reader["Nombre_Direccion"].ToString(),
                                    ID_Institucion = reader["ID_Institucion"].ToString()
                                });
                            }

                            comboDireccion.DataSource = null;
                            comboDireccion.DisplayMember = "Nombre_Direccion";
                            comboDireccion.ValueMember = "ID_Direccion";
                            comboDireccion.DataSource = listaDirecciones;

                            if (comboDireccion.Items.Count > 0)
                            {
                                comboDireccion.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar direcciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerEjerciciosFiscales(int idDireccion)
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                // ✅ Agregar ID_Direccion al SELECT
                string query = "SELECT ID_Ejercicio, Nombre_Ejercicio, ID_Direccion FROM Cat_Ejercicios WHERE ID_Direccion = @idDireccion";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@idDireccion", idDireccion);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<EjercicioFiscalItem> listaEjercicios = new List<EjercicioFiscalItem>
                    {
                        new EjercicioFiscalItem { ID_Ejercicio = "0", Nombre_Ejercicio = "-- Seleccione --", ID_Direccion = idDireccion.ToString() }
                    };

                            while (reader.Read())
                            {
                                listaEjercicios.Add(new EjercicioFiscalItem
                                {
                                    ID_Ejercicio = reader["ID_Ejercicio"].ToString(),
                                    Nombre_Ejercicio = reader["Nombre_Ejercicio"].ToString(),
                                    ID_Direccion = reader["ID_Direccion"].ToString()
                                });
                            }

                            comboEjercicioFiscal.DataSource = null;
                            comboEjercicioFiscal.DisplayMember = "Nombre_Ejercicio";
                            comboEjercicioFiscal.ValueMember = "ID_Ejercicio";
                            comboEjercicioFiscal.DataSource = listaEjercicios;

                            if (comboEjercicioFiscal.Items.Count > 0)
                            {
                                comboEjercicioFiscal.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar ejercicios fiscales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerProgramas(int idEjercicioFiscal)
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT ID_Programa, Nombre_Programa, Fuente_Financiamiento, ID_Ejercicio FROM Cat_Programas WHERE ID_Ejercicio = @idEjercicioFiscal";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@idEjercicioFiscal", idEjercicioFiscal);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<ProgramaItem> listaProgramas = new List<ProgramaItem>
                    {
                        new ProgramaItem { ID_Programa = "0", Nombre_Programa= "-- Seleccione --", Fuente_Financiamiento = "",ID_Ejercicio = idEjercicioFiscal.ToString() }
                    };

                            while (reader.Read())
                            {
                                listaProgramas.Add(new ProgramaItem
                                {
                                    ID_Programa = reader["ID_Programa"].ToString(),
                                    Nombre_Programa = reader["Nombre_Programa"].ToString(),
                                    Fuente_Financiamiento = reader["Fuente_Financiamiento"].ToString(),
                                    ID_Ejercicio = reader["ID_Ejercicio"].ToString()
                                });
                            }

                            comboPrograma.DataSource = null;
                            comboPrograma.DisplayMember = "Nombre_Programa";
                            comboPrograma.ValueMember = "ID_Programa";
                            comboPrograma.DataSource = listaProgramas;

                            if (comboPrograma.Items.Count > 0)
                            {
                                comboPrograma.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar programas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerApoyos(int idPrograma) // Cambié el parámetro para que coincida con el filtro de la consulta
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT ID_Apoyo, Nombre_Apoyo, Tipo_Beneficio, Cve_Programa, Cve_Dependencia, Cve_Intraprograma, Tipo_Apoyo, Clave_Beneficio_Dif_Nacional, ID_Programa FROM Cat_Apoyos WHERE ID_Programa = @idPrograma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        // Asignamos el parámetro
                        cmd.Parameters.AddWithValue("@idPrograma", idPrograma);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Inicializamos la lista con el elemento por defecto
                            List<ApoyoItem> listaApoyos = new List<ApoyoItem>
                    {
                        new ApoyoItem
                        {
                            ID_Apoyo = "0",
                            Nombre_Apoyo = "-- Seleccione --",
                            Tipo_Beneficio = "",
                            Cve_Programa = "",
                            Cve_Dependencia = "",
                            Cve_Intraprograma = "",
                            Tipo_Apoyo = "",
                            Clave_Beneficio_Dif_Nacional = "",
                            ID_Programa = idPrograma.ToString()
                        }
                    };

                            // Leemos los registros
                            while (reader.Read())
                            {
                                listaApoyos.Add(new ApoyoItem
                                {
                                    ID_Apoyo = reader["ID_Apoyo"].ToString(),
                                    Nombre_Apoyo = reader["Nombre_Apoyo"].ToString(),
                                    Tipo_Beneficio = reader["Tipo_Beneficio"].ToString(),
                                    Cve_Programa = reader["Cve_Programa"].ToString(),
                                    Cve_Dependencia = reader["Cve_Dependencia"].ToString(),
                                    Cve_Intraprograma = reader["Cve_Intraprograma"].ToString(),
                                    Tipo_Apoyo = reader["Tipo_Apoyo"].ToString(),
                                    Clave_Beneficio_Dif_Nacional = reader["Clave_Beneficio_Dif_Nacional"].ToString(),
                                    ID_Programa = reader["ID_Programa"].ToString()
                                });
                            }

                            // Asignamos al ComboBox (cambia "comboApoyo" por el nombre real de tu control)
                            comboApoyo.DataSource = null;
                            comboApoyo.DisplayMember = "Nombre_Apoyo"; // Lo que ve el usuario
                            comboApoyo.ValueMember = "ID_Apoyo";       // El valor interno que se guarda
                            comboApoyo.DataSource = listaApoyos;

                            if (comboApoyo.Items.Count > 0)
                            {
                                comboApoyo.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar apoyos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void obtenerEntidades()
        {
            string query = "SELECT Cve_Entidad, Nombre_Entidad FROM Cat_Entidades ORDER BY Nombre_Entidad";

            try
            {
                using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    // Lista con el elemento por defecto
                    List<EntidadesItem> entidades = new List<EntidadesItem>
            {
                new EntidadesItem
                {
                    Cve_Entidad = "0",
                    Nombre_Entidad = "-- Seleccione --"
                }
            };

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            entidades.Add(new EntidadesItem
                            {
                                Cve_Entidad = reader["Cve_Entidad"].ToString(),
                                Nombre_Entidad = reader["Nombre_Entidad"].ToString()
                            });
                        }
                    }

                    // Asignamos al ComboBox
                    comboEntidad.DataSource = null;
                    comboEntidad.DisplayMember = "Nombre_Entidad";
                    comboEntidad.ValueMember = "Cve_Entidad";
                    comboEntidad.DataSource = entidades;

                    if (comboEntidad.Items.Count > 0)
                        comboEntidad.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar entidades: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void obtenerMunicipio(string Cve_Entidad)
        {
            string query = @"SELECT Cve_Municipio, Nombre_Municipio, Cve_Entidad 
                     FROM Cat_Municipios 
                     WHERE Cve_Entidad = @Cve_Entidad 
                     ORDER BY Nombre_Municipio";

            try
            {
                using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cve_Entidad", Cve_Entidad);
                    conn.Open();

                    // Lista con el elemento por defecto
                    List<MunicipiosItem> municipios = new List<MunicipiosItem>
            {
                new MunicipiosItem
                {
                    Cve_Municipio    = "0",
                    Nombre_Municipio = "-- Seleccione --",
                    Cve_Entidad      = Cve_Entidad
                }
            };

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            municipios.Add(new MunicipiosItem
                            {
                                Cve_Municipio = reader["Cve_Municipio"].ToString(),
                                Nombre_Municipio = reader["Nombre_Municipio"].ToString(),
                                Cve_Entidad = reader["Cve_Entidad"].ToString()
                            });
                        }
                    }

                    // Asignamos al ComboBox
                    comboMunicipio.DataSource = null;
                    comboMunicipio.DisplayMember = "Nombre_Municipio";
                    comboMunicipio.ValueMember = "Cve_Municipio";
                    comboMunicipio.DataSource = municipios;

                    if (comboMunicipio.Items.Count > 0)
                        comboMunicipio.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar municipios: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void obtenerLocalidad(string Cve_Municipio)
        {
            string query = @"SELECT Cve_Localidad_ID, Cve_Localidad, Region, 
                            Nombre_Localidad, Cve_Municipio 
                     FROM Cat_Localidades 
                     WHERE Cve_Municipio = @Cve_Municipio 
                     ORDER BY Nombre_Localidad";

            try
            {
                using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Cve_Municipio", Cve_Municipio);
                    conn.Open();

                    // Lista con el elemento por defecto
                    List<LocalidadesItem> localidades = new List<LocalidadesItem>
            {
                new LocalidadesItem
                {
                    Cve_Localidad_ID = "0",
                    Cve_Localidad    = "0",
                    Region           = "",
                    Nombre_Localidad = "-- Seleccione --",
                    Cve_Municipio    = Cve_Municipio
                }
            };

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            localidades.Add(new LocalidadesItem
                            {
                                Cve_Localidad_ID = reader["Cve_Localidad_ID"].ToString(),
                                Cve_Localidad = reader["Cve_Localidad"].ToString(),
                                Region = reader["Region"].ToString(),
                                Nombre_Localidad = reader["Nombre_Localidad"].ToString(),
                                Cve_Municipio = reader["Cve_Municipio"].ToString()
                            });
                        }
                    }

                    // Asignamos al ComboBox
                    comboLocalidad.DataSource = null;
                    comboLocalidad.DisplayMember = "Nombre_Localidad";
                    comboLocalidad.ValueMember = "Cve_Localidad_ID";
                    comboLocalidad.DataSource = localidades;

                    if (comboLocalidad.Items.Count > 0)
                        comboLocalidad.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar localidades: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidadApoyo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir teclas de control como Backspace o combinaciones (Ctrl+C, Ctrl+V, etc.)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir dígitos y punto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquea cualquier otro carácter
                return;
            }

            // Evitar más de un punto decimal
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }
            // Simular cómo quedaría el texto si se acepta la tecla pulsada
            string textoActual = textBox.Text;
            int seleccionInicio = textBox.SelectionStart;
            int seleccionLongitud = textBox.SelectionLength;

            // Quitar el texto que el usuario tenga seleccionado e insertar el nuevo carácter
            string textoSimulado = textoActual.Remove(seleccionInicio, seleccionLongitud)

                                              .Insert(seleccionInicio, e.KeyChar.ToString());

            // Separar parte entera y decimal
            string[] partes = textoSimulado.Split('.');

            // Validar máximo 16 dígitos enteros antes del punto
            if (partes[0].Length > 16)
            {
                e.Handled = true;
                return;
            }

            // Validar máximo 2 dígitos decimales después del punto
            if (partes.Length > 1 && partes[1].Length > 2)
            {
                e.Handled = true;
                return;
            }
        }

        private void txtGradoEscuela_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            // Permitir teclas de control (Backspace, Delete, flechas, Ctrl+C, Ctrl+V, etc.)
            if (char.IsControl(e.KeyChar))
                return;

            // Solo dígitos
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Simular el texto resultante tras aceptar la tecla
            string textoActual = textBox.Text;
            int seleccionInicio = textBox.SelectionStart;
            int seleccionLongitud = textBox.SelectionLength;

            string textoSimulado = textoActual
                .Remove(seleccionInicio, seleccionLongitud)
                .Insert(seleccionInicio, e.KeyChar.ToString());

            // Máximo 2 caracteres
            if (textoSimulado.Length > 2)
            {
                e.Handled = true;
            }
        }






        public void obtenerTipoBenficiario() {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = "SELECT Tipo_Beneficiario, Desc_Beneficiario FROM Tipo_Beneficiario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<TipoBeneficiarioItem> listaTiposBeneficiario = new List<TipoBeneficiarioItem>
                            {
                                new TipoBeneficiarioItem { Clave = "", Descripcion = "-- Seleccione --" }
                            };

                            while (reader.Read())
                            {
                                listaTiposBeneficiario.Add(new TipoBeneficiarioItem
                                {
                                    Clave = reader["Tipo_Beneficiario"].ToString(),
                                    Descripcion = reader["Desc_Beneficiario"].ToString()
                                });
                            }

                            comboTipoBeneficiario.DataSource = null;
                            comboTipoBeneficiario.DisplayMember = "Descripcion";
                            comboTipoBeneficiario.ValueMember = "Clave";
                            comboTipoBeneficiario.DataSource = listaTiposBeneficiario;

                            if (comboTipoBeneficiario.Items.Count > 0)
                            {
                                comboTipoBeneficiario.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar tipos de discapacidad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboTipoBeneficiario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                if (comboTipoBeneficiario.SelectedItem is TipoBeneficiarioItem tipoBeneficiarioSeleccionado)
                {
                    if (!string.IsNullOrEmpty(tipoBeneficiarioSeleccionado.Clave)
                && !string.IsNullOrEmpty(tipoBeneficiarioSeleccionado.Descripcion))
                    {
                        solicitudItem.Cve_Tipo_Beneficiario = tipoBeneficiarioSeleccionado.Clave;
                    }
                }

                //Console.WriteLine(solicitudItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar localidad: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (!validacionCampos())
            {
                MessageBox.Show($"Error al agregar apoyo, complete los campos obligatorios.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                solicitudItem.Estado_Solicitud = "PENDIENTE te amo PINCHE FANY ALV";
                solicitudItem.Grado_Escuela = txtGradoEscuela.Text;

                SolicitudItem.registrarSolicitud(solicitudItem);

            }
        }

        public bool validacionCampos()
        {
            bool esValido = true;

            // Validar que los ComboBox tengan un valor seleccionado válido
            if (comboInstitucion.SelectedIndex == -1 || comboInstitucion.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboInstitucion.Text))
                esValido = false;

            if (comboDireccion.SelectedIndex == -1 || comboDireccion.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboDireccion.Text))
                esValido = false;

            if (comboEjercicioFiscal.SelectedIndex == -1 || comboEjercicioFiscal.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboEjercicioFiscal.Text))
                esValido = false;

            if (comboPrograma.SelectedIndex == -1 || comboPrograma.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboPrograma.Text))
                esValido = false;

            if (comboApoyo.SelectedIndex == -1 || comboApoyo.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboApoyo.Text))
                esValido = false;

            if (comboEntidad.SelectedIndex == -1 || comboEntidad.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboEntidad.Text))
                esValido = false;

            if (comboMunicipio.SelectedIndex == -1 || comboMunicipio.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboMunicipio.Text))
                esValido = false;

            if (comboLocalidad.SelectedIndex == -1 || comboLocalidad.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboLocalidad.Text))
                esValido = false;

            if (comboTipoBeneficiario.SelectedIndex == -1 || comboTipoBeneficiario.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboTipoBeneficiario.Text))
                esValido = false;

            if (comboEscuelas.SelectedIndex == -1 || comboEscuelas.Text == "-- Seleccione --" || string.IsNullOrWhiteSpace(comboEscuelas.Text))
                esValido = false;

            // Si comboEscuelas tiene un valor seleccionado, txtGradoEscuela debe tener un valor
            if (!string.IsNullOrWhiteSpace(comboEscuelas.Text) && comboEscuelas.Text != "-- Seleccione --")
            {
                if (string.IsNullOrWhiteSpace(txtGradoEscuela.Text))
                    esValido = false;
            }

            // Validar que txtTipoApoyo y txtCantidadApoyo tengan un valor
            if (string.IsNullOrWhiteSpace(txtTipoApoyo.Text))
                esValido = false;

            if (string.IsNullOrWhiteSpace(txtCantidadApoyo.Text))
                esValido = false;

            return esValido;
        }

        public void cargarEscuelas()
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = @"SELECT TOP(5) CCT, TIPO_CT, NOMBRE_ESCUELA, TURNO, STA_DES,
                                CLAVE_MUNICIPIO, NOMBRE_MUNICIPIO,
                                CLAVE_LOCALIDAD, NOMBRE_LOCALIDAD,
                                TIPO, NIVEL, SUBNIVEL
                         FROM Cat_Escuelas";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<EscuelasItem> listaEscuelas = new List<EscuelasItem>
                    {
                        new EscuelasItem() // El "-- Seleccione --" lo genera TextoMostrar
                    };

                            while (reader.Read())
                            {
                                listaEscuelas.Add(new EscuelasItem
                                {
                                    CCT = reader["CCT"].ToString(),
                                    TIPO_CT = reader["TIPO_CT"].ToString(),
                                    NOMBRE_ESCUELA = reader["NOMBRE_ESCUELA"].ToString(),
                                    TURNO = reader["TURNO"].ToString(),
                                    STA_DES = reader["STA_DES"].ToString(),
                                    CLAVE_MUNICIPIO = reader["CLAVE_MUNICIPIO"].ToString(),
                                    NOMBRE_MUNICIPIO = reader["NOMBRE_MUNICIPIO"].ToString(),
                                    CLAVE_LOCALIDAD = reader["CLAVE_LOCALIDAD"].ToString(),
                                    NOMBRE_LOCALIDAD = reader["NOMBRE_LOCALIDAD"].ToString(),
                                    TIPO = reader["TIPO"].ToString(),
                                    NIVEL = reader["NIVEL"].ToString(),
                                    SUBNIVEL = reader["SUBNIVEL"].ToString()
                                });
                            }



                            comboEscuelas.DataSource = null;
                            comboEscuelas.DisplayMember = "TextoMostrar"; // 👈 muestra todos los campos
                            comboEscuelas.ValueMember = "CCT";          // 👈 valor único
                            comboEscuelas.DataSource = listaEscuelas;

                            if (comboEscuelas.Items.Count > 0)
                                comboEscuelas.SelectedIndex = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar escuelas: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void comboEscuelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cargandoInicial) return;

            try
            {
                if (solicitudItem == null)
                    solicitudItem = new SolicitudItem();

                // Caso: no hay selección válida → limpiar datos
                if (!(comboEscuelas.SelectedItem is EscuelasItem escuelaSeleccionada)
                    || string.IsNullOrEmpty(escuelaSeleccionada.CCT)
                    || escuelaSeleccionada.CCT == "0")
                {
                    LimpiarDatosEscuela();
                    return;
                }

                // Asignar datos de la escuela seleccionada
                solicitudItem.CCT = escuelaSeleccionada.CCT;
                solicitudItem.Nombre_Escuela = escuelaSeleccionada.NOMBRE_ESCUELA;
                solicitudItem.Turno_Escuela = escuelaSeleccionada.TURNO;
                solicitudItem.Municipio_Escuela = escuelaSeleccionada.NOMBRE_MUNICIPIO;
                solicitudItem.Localidad_Escuela = escuelaSeleccionada.NOMBRE_LOCALIDAD;
                solicitudItem.Tipo_Escuela = escuelaSeleccionada.TIPO;
                solicitudItem.Nivel_Escuela = escuelaSeleccionada.NIVEL;
                solicitudItem.Subnivel_Escuela = escuelaSeleccionada.SUBNIVEL;

                txtNombreEscuela.Text = escuelaSeleccionada.NOMBRE_ESCUELA;
                txtTurnoEscuela.Text = escuelaSeleccionada.TURNO;
                txtMunicipioEscuela.Text = escuelaSeleccionada.NOMBRE_MUNICIPIO;
                txtLocalidadEscuela.Text = escuelaSeleccionada.NOMBRE_LOCALIDAD;
                txtTipoEscuela.Text = escuelaSeleccionada.TIPO;
                txtNivelEscuela.Text = escuelaSeleccionada.NIVEL;
                txtSubnivelEscuela.Text = escuelaSeleccionada.SUBNIVEL;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar entidad: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDatosEscuela()
        {
            if (solicitudItem == null) return;
            solicitudItem.CCT = null;
            solicitudItem.Nombre_Escuela = null;
            solicitudItem.Turno_Escuela = null;
            solicitudItem.Municipio_Escuela = null;
            solicitudItem.Localidad_Escuela = null;
            solicitudItem.Tipo_Escuela = null;
            solicitudItem.Nivel_Escuela = null;
            solicitudItem.Subnivel_Escuela = null;
        }

        public void cargarEscuelas(string filtroCCT = "")
        {
            using (SqlConnection conn = new SqlConnection(LoginForm.CadenaDeConexionGlobal))
            {
                string query = @"SELECT TOP(5) CCT, TIPO_CT, NOMBRE_ESCUELA, TURNO, STA_DES,
                                CLAVE_MUNICIPIO, NOMBRE_MUNICIPIO,
                                CLAVE_LOCALIDAD, NOMBRE_LOCALIDAD,
                                TIPO, NIVEL, SUBNIVEL
                         FROM Cat_Escuelas
                         WHERE (@filtro = '' OR CCT LIKE @filtro + '%')
                         ORDER BY CCT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@filtro", SqlDbType.NVarChar, 50).Value = filtroCCT ?? "";

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<EscuelasItem> listaEscuelas = new List<EscuelasItem>();

                            while (reader.Read())
                            {
                                listaEscuelas.Add(new EscuelasItem
                                {
                                    CCT = reader["CCT"].ToString(),
                                    TIPO_CT = reader["TIPO_CT"].ToString(),
                                    NOMBRE_ESCUELA = reader["NOMBRE_ESCUELA"].ToString(),
                                    TURNO = reader["TURNO"].ToString(),
                                    STA_DES = reader["STA_DES"].ToString(),
                                    CLAVE_MUNICIPIO = reader["CLAVE_MUNICIPIO"].ToString(),
                                    NOMBRE_MUNICIPIO = reader["NOMBRE_MUNICIPIO"].ToString(),
                                    CLAVE_LOCALIDAD = reader["CLAVE_LOCALIDAD"].ToString(),
                                    NOMBRE_LOCALIDAD = reader["NOMBRE_LOCALIDAD"].ToString(),
                                    TIPO = reader["TIPO"].ToString(),
                                    NIVEL = reader["NIVEL"].ToString(),
                                    SUBNIVEL = reader["SUBNIVEL"].ToString()
                                });
                            }

                            // Guardamos texto actual para no perderlo al reasignar DataSource
                            string textoActual = comboEscuelas.Text;

                            comboEscuelas.DataSource = null;
                            comboEscuelas.DisplayMember = "TextoMostrar";
                            comboEscuelas.ValueMember = "CCT";
                            comboEscuelas.DataSource = listaEscuelas;

                            // Restauramos el texto que el usuario está escribiendo
                            comboEscuelas.Text = textoActual;
                            comboEscuelas.SelectionStart = comboEscuelas.Text.Length;
                            comboEscuelas.SelectionLength = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar escuelas: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    

    private void comboEscuelas_TextUpdate(object sender, EventArgs e)
        {
            if (_timerFiltro == null)
            {
                _timerFiltro = new System.Windows.Forms.Timer { Interval = 250 }; // 250 ms
                _timerFiltro.Tick += (s, ev) =>
                {
                    _timerFiltro.Stop();
                    cargarEscuelas(comboEscuelas.Text.Trim());
                };
            }

            _timerFiltro.Stop();
            _timerFiltro.Start();
        }
    }
}
