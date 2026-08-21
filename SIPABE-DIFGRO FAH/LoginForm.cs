using Microsoft.Data.SqlClient;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Util;
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
using System.Drawing.Drawing2D;

namespace SIPABE_DIFGRO_FAH
{
    public partial class LoginForm : LostForm
    {
        // Esta variable estática guardará la conexión activa validada para que 
        // los demas formularios funcionen sin pedir contraseña de nuevo.
        public static string CadenaDeConexionGlobal { get; private set; }

        
        // Cadena para conexion a Users
        public static string CadenaDeConexionUsers { get; private set; } = "Server=187.217.242.61;Database=Users;User Id=asdvsdGULIKFYUOhguoiasdfmyhoiñasfgisdmuoñbyu6511651;Password=jlkhsrggjhukhoiswrgguoidetuouoserfyuoiG54458578dfgsdf;Encrypt=True;TrustServerCertificate=True;";

        public static string NombreCapturistaActual { get; private set; }
        public static string UsuarioSQLActual { get; private set; }

        public LoginForm()
        {

            InitializeComponent();

              
            this.Image = null;
            this.ShowIcon = false;      // Oculta el ícono de la esquina
            this.Text = string.Empty;

                // 1. Fondos generales
                this.BackColor = Color.FromArgb(105, 28, 50); // #58111A
                this.ForeColor = Color.FromArgb(245, 235, 215); // Texto claro / marfil
                
                // 2. Configuración de HopeButton
                this.Btn_Login.PrimaryColor = Color.FromArgb(245, 235, 215);  // Beige base (#F5EBD7)
                this.Btn_Login.TextColor = Color.FromArgb(88, 17, 26);
                this.Btn_Login.BorderColor = Color.FromArgb(197, 160, 89);    // Borde dorado suave

            EstilizarTextBox(this.Txt_User, "Usuario");
            EstilizarTextBox(this.Txt_Pass, "Contraseña");
            EstilizarTextBox(this.TxtCapturistaNamae, "Otro dato");
            
            this.pictureBox1.Size = new Size(180, 180);
            this.pictureBox1.Location = new Point((this.ClientSize.Width - this.pictureBox1.Width) / 2, 50);
            // Aplica el círculo con fondo beige/marfil y borde dorado
            this.pictureBox1.BackColor = Color.FromArgb(245, 235, 215); // Beige #F5EBD7
            HacerPictureBoxCircular(this.pictureBox1, Color.FromArgb(197, 160, 89), 3); // Borde dorado de 3px
        
        }

        private void EstilizarTextBox(ReaLTaiizor.Controls.HopeTextBox txt, string placeholder)
        {
            if (txt == null) return;

            txt.BackColor = Color.FromArgb(245, 235, 215);      // Fondo Beige (#F5EBD7)
            txt.BaseColor = Color.FromArgb(245, 235, 215);      // Relleno interior Beige
            txt.BorderColorA = Color.FromArgb(197, 160, 89);     // Borde dorado (al enfocar)
            txt.BorderColorB = Color.FromArgb(215, 200, 180);    // Borde beige suave (en reposo)
            txt.ForeColor = Color.FromArgb(50, 8, 14);          // Texto en vino oscuro
            txt.Hint = placeholder;                             // Texto guía
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string usuario = Txt_User.Text.Trim();
            string password = Txt_Pass.Text.Trim();

            // La clasica de checar si esta vacio uno de los 2 campos del login
            //Campo usuario vacío
            if (string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                MessageBox.Show("El campo de usuario está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //campo password vacío
            else if (!string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("El campo de contraseña está vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //ambos campos vacíos
            else if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ambos campos están vacíos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lo de siempre, ya se lo saben, es como lo que hice en el modulo del access, es la cadena de conexion
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "187.217.242.61";
            builder.InitialCatalog = "SIPABE_DIF_GR0";
            builder.UserID = usuario;
            builder.Password = password;

            // Hay que probar si funciona correctamente el encriptado
            builder.Encrypt = true;
            builder.TrustServerCertificate = true;
            builder.ConnectTimeout = 10;

            string conexionsqlSipabe = builder.ConnectionString;

            // Intento de conexión
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionsqlSipabe))
                {
                    conexion.Open(); // Si las credenciales son malas (como ya saben quien), nos vamos al 'catch'

                    // Si salio chido seguimos con esto
                    CadenaDeConexionGlobal = conexionsqlSipabe;
                    UsuarioSQLActual = usuario; // Lo guardamos por si lo ocupamos en otros formularios

                    MessageBox.Show("¡Conexión exitosa!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Disparamos la auditoría silente, incognita, furtiva, oculta asi como quien dice tras bamabalinas antes de abrir el menú principal
                    RegistrarAuditoriaLogin(usuario);

                    // Abrir el menu principal ocultar el login y en teoria ya no se va a usar el formulario que guarda el nombre del usuario
                    MenuPrincipalForm varMenuPrincipalForm = new MenuPrincipalForm();
                    varMenuPrincipalForm.Show();
                    this.Hide();
                }
            }
            catch (SqlException ex)
            {
                // El error número 18456 es el estándar de SQL Server para "Login failed" segun, pero ya saben que siempre nos pasan cositas
                // asi que hay que revisar tambien esta parte y despues cambiarlo si es menester
                if (ex.Number == 18456)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, porfa checa si escribiste bien, con calma y cuidado TKM. Recuerda que tu no tienes enemigos, nadie tiene enemigos, nadie en este mundo merece ser herido", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otros errores (el servidor está apagado[casi no pasa verdad, luego ni me dejan sentarme y me reciben con esto], etocetora etocetora.)
                    MessageBox.Show("No se pudo conectar al servidor.\nDetalle: " + ex.Message, "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void Txt_User_Leave(object sender, EventArgs e)
        {
            string usuario = Txt_User.Text.Trim();

            if (string.IsNullOrEmpty(usuario))
            {
                TxtCapturistaNamae.Text = ""; // Va a recibir el valor del nombre del capturista
                return;
            }

            // Conexión a la base de users
            using (SqlConnection conn = new SqlConnection(CadenaDeConexionUsers))
            {
                // Usamos parametros (@usa) que reemplazan la concatenacion para evitar Inyección SQL
                // a la que le tiene miedo Haroluchis pero ya le dije que esta contemplado pero dice que no confia en mi
                string query = "SELECT namae FROM Users WHERE usa = @usa";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@usa", usuario);

                    try
                    {
                        conn.Open();

                        object resultado = cmd.ExecuteScalar();

                        if (resultado != null)
                        {
                            TxtCapturistaNamae.Text = resultado.ToString();
                            NombreCapturistaActual = resultado.ToString(); // Lo guardamos globalmente
                        }
                        else
                        {
                            TxtCapturistaNamae.Text = "";
                            MessageBox.Show("Usuario no reconocido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al buscar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void RegistrarAuditoriaLogin(string usuarioSQL)
        {
            // Cadena conexion auditora, hay que persinarse antes de iniciar para que funcione
            string strConnAudit = "Server=187.217.242.61;Database=AuditoLogins;User Id=hsrjeyj5yj5yjw5yjwrywjhu4y67224jw2j24yjqwr4yj;Password=jbjoLOJhoipsdhip534ergthjlgqebthqegth;Encrypt=True;TrustServerCertificate=True;";

            // Instanciamos el auditor para obtener IP, MAC, UUID y BIOS Serial(Creo que ya estoy exagerando con mi paranoia)

            AuditoriaSistema datosPC = new AuditoriaSistema();

            using (SqlConnection cnAudit = new SqlConnection(strConnAudit))
            {
                // consulta nueva con los nuevos campos de hardware e identidad en la nueva base de auditoria
                string query = @"INSERT INTO AuditoriaLogins3 
                        (UsuarioSQL, Equipo, UsuarioWindows, FechaHora, IPLocal, MACAddress, UUID_Hardware, SerialBIOS, Procesador, MemoriaRAM) 
                        VALUES 
                        (@UsuarioSQL, @Equipo, @UsuarioWindows, @FechaHora, @IP, @MAC, @UUID, @BIOS, @Procesador, @RAM)";

                using (SqlCommand cmd = new SqlCommand(query, cnAudit))
                {
                    // Datos que ya guardabamos en la auditoria
                    cmd.Parameters.AddWithValue("@UsuarioSQL", usuarioSQL);
                    cmd.Parameters.AddWithValue("@Equipo", datosPC.NombreEquipo);
                    cmd.Parameters.AddWithValue("@UsuarioWindows", datosPC.UsuarioWindows);
                    cmd.Parameters.AddWithValue("@FechaHora", DateTime.Now);

                    // Nuevos datos de hardware obtenidos por la clase AuditoriaSistema y con los que tengo que hacer cambios en la tabla de auditoria
                    // y agregar los nuevos campos, tambien barajeo la posibilidad de una base nueva e importar registros (>'.')><('.'<)
                    cmd.Parameters.AddWithValue("@IP", datosPC.IPLocal);
                    cmd.Parameters.AddWithValue("@MAC", datosPC.DireccionMAC);
                    cmd.Parameters.AddWithValue("@UUID", datosPC.UUID);
                    cmd.Parameters.AddWithValue("@BIOS", datosPC.SerialHardware);

                    // Nuevos datos que quiere Martinez aunque no creo que los usemos como el piensa
                    cmd.Parameters.AddWithValue("@Procesador", datosPC.Procesador);
                    cmd.Parameters.AddWithValue("@RAM", datosPC.MemoriaRAM);

                    try
                    {
                        cnAudit.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // Este mensaje para que al capturista le salte error si la auditoría falla, no se que tan bueno sea que se entere que registro
                        // Lo de menos es comentarlo despues para que el proceso sea invisible para el usuario d(OwO)b

                        MessageBox.Show("Error al registrar auditoría: " + ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void HacerPictureBoxCircular(PictureBox pb, Color colorBorde, int grosorBorde = 2, int margenInterno = 15)
        {
            int diametro = Math.Min(pb.Width, pb.Height);
            pb.Size = new Size(diametro, diametro);

            Image imgOriginal = pb.Image;
            pb.Image = null;

            // Máscara circular para el contenedor
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, diametro, diametro);
            pb.Region = new Region(path);

            pb.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                if (imgOriginal != null)
                {
                    // Espacio disponible dentro del círculo
                    float maxDim = diametro - ((margenInterno + grosorBorde) * 2);

                    // Calcular escala manteniendo la proporción exacta (Aspect Ratio)
                    float escala = Math.Min(maxDim / imgOriginal.Width, maxDim / imgOriginal.Height);
                    float nuevoAncho = imgOriginal.Width * escala;
                    float nuevoAlto = imgOriginal.Height * escala;

                    // Centrar perfectamente la imagen
                    float posX = (diametro - nuevoAncho) / 2f;
                    float posY = (diametro - nuevoAlto) / 2f;

                    e.Graphics.DrawImage(imgOriginal, posX, posY, nuevoAncho, nuevoAlto);
                }
            };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}