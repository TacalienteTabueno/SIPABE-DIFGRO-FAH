using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SIPABE_DIFGRO_FAH
{
    public partial class LoginForm : Form
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
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string usuario = Txt_User.Text.Trim();
            string password = Txt_Pass.Text.Trim();

            // La clasica de checar si esta vacio uno de los 2 campos del login
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingresa usuario y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string conexionDePrueba = builder.ConnectionString;

            // Intento de conexión
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionDePrueba))
                {
                    conexion.Open(); // Si las credenciales son malas (como ya saben quien), nos vamos al 'catch'

                    // Si salio chido seguimos con esto
                    CadenaDeConexionGlobal = conexionDePrueba;
                    UsuarioSQLActual = usuario; // Lo guardamos por si lo ocupamos en otros formularios

                    MessageBox.Show("¡Conexión exitosa!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // CORRECCIÓN 2: Disparamos la auditoría silente antes de abrir el menú principal
                    RegistrarAuditoriaLogin(usuario);

                    // Abrir el menu principal ocultar el login
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
                    MessageBox.Show("Usuario o contraseña incorrectos, porfa checa si escribiste bien, con calma y cuidado TKM.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otros errores (el servidor está apagado[casi no pasa verdad, luego ni me dejan sentarme y me reciben con esto], etocetora etocetora.)
                    MessageBox.Show("No se pudo conectar al servidor.\nDetalle: " + ex.Message, "Error de Red", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            using (SqlConnection cnAudit = new SqlConnection(strConnAudit))
            {
                string query = "INSERT INTO AuditoriaLogins (UsuarioSQL, Equipo, UsuarioWindows, FechaHora) VALUES (@UsuarioSQL, @Equipo, @UsuarioWindows, @FechaHora)";

                using (SqlCommand cmd = new SqlCommand(query, cnAudit))
                {
                    cmd.Parameters.AddWithValue("@UsuarioSQL", usuarioSQL);
                    cmd.Parameters.AddWithValue("@Equipo", Environment.MachineName);
                    cmd.Parameters.AddWithValue("@UsuarioWindows", Environment.UserName);
                    cmd.Parameters.AddWithValue("@FechaHora", DateTime.Now);

                    try
                    {
                        cnAudit.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {


                        // Este mensaje para que al capturista le salte error si la auditoría falla, no se que tan bueno sea que se entere que registro
                        // su compu y usuario d(OwO)b, lo de menos es despues comentarlo tehhe~
                        MessageBox.Show("Error al registrar auditoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

//                            ,ooo888888888888888oooo,
//                          o8888YYYYYY77iiiiooo8888888o
//                         8888YYYY77iiYY8888888888888888
//                        [88YYY77iiY88888888888888888888]
//                        88YY7iYY888888888888888888888888
//                       [88YYi 88888888888888888888888888]
//                       i88Yo8888888888888888888888888888i
//                       i]        ^^^88888888^^^     o  [i
//                      oi8  i           o8o          i  8io
//                    ,77788o ^^  ,oooo8888888ooo,   ^ o88777,
//                    7777788888888888888888888888888888877777
//                     77777888888888888888888888888888877777
//                      77777788888888^7777777^8888888777777
//       ,oooo888 ooo   88888778888^7777ooooo7777^8887788888        ,o88^^^^888oo
//    o8888777788[];78 88888888888888888888888888888888888887 7;8^ 888888888oo^88
//   o888888iii788 ]; o 78888887788788888^;;^888878877888887 o7;[]88888888888888o
//   88888877 ii78[]8;7o 7888878^ ^8788^;;;;;;^878^ ^878877 o7;8 ]878888888888888
//  [88888888887888 87;7oo 777888o8888^;ii;;ii;^888o87777 oo7;7[]8778888888888888
//  88888888888888[]87;777oooooooooooooo888888oooooooooooo77;78]88877i78888888888
// o88888888888888 877;7877788777iiiiiii;;;;;iiiiiiiii77877i;78] 88877i;788888888
// 88^;iiii^88888 o87;78888888888888888888888888888888888887;778] 88877ii;7788888
//;;;iiiii7iiii^  87;;888888888888888888888888888888888888887;778] 888777ii;78888
//;iiiii7iiiii7iiii77;i88888888888888888888i7888888888888888877;77i 888877777ii78
//iiiiiiiiiii7iiii7iii;;;i7778888888888888ii7788888888888777i;;;;iiii 88888888888
//i;iiiiiiiiiiii7iiiiiiiiiiiiiiiiiiiiiiiiii8877iiiiiiiiiiiiiiiiiii877   88888
//ii;;iiiiiiiiiiiiii;;;ii^^^;;;ii77777788888888888887777iii;;  77777           78
//77iii;;iiiiiiiiii;;;ii;;;;;;;;;^^^^8888888888888888888777ii;;  ii7         ;i78
//^ii;8iiiiiiii ';;;;ii;;;;;;;;;;;;;;;;;;^^oo ooooo^^^88888888;;i7          7;788
//o ^;;^^88888^     'i;;;;;;;;;;;;;;;;;;;;;;;;;;;^^^88oo^^^^888ii7         7;i788
//88ooooooooo         ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;; 788oo^;;          7;i888
//887ii8788888      ;;;;;;;ii;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;^87           7;788
//887i8788888^     ;;;;;;;ii;;;;;;;oo;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,      ;;888
//87787888888     ;;;;;;;ii;;;;;;;888888oo;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,;i788
//87i8788888^       ';;;ii;;;;;;;8888878777ii8ooo;;;;;;;;;;;;;;;;;;;;;;;;;;i788 7
//77i8788888           ioo;;;;;;oo^^ooooo ^7i88^ooooo;;;;;;;;;;;;;;;;;;;;i7888 78
//7i87788888o         7;ii788887i7;7;788888ooooo7888888ooo;;;;;;;;;;;;;;oo ^^^ 78
//i; 7888888^      8888^o;ii778877;7;7888887;;7;7788878;878;;    ;;;;;;;i78888o ^
//i8 788888       [88888^^ ooo ^^^^^;;77888^^^^;;7787^^^^ ^^;;;;  iiii;i78888888
//^8 7888^        [87888 87 ^877i;i8ooooooo8778oooooo888877ii; iiiiiiii788888888
//  ^^^          [7i888 87;; ^8i;;i7888888888888888887888888   i7iiiiiii88888^^
//               87;88 o87;;;;o 87i;;;78888788888888888888^^ o 8ii7iiiiii;;
//               87;i8 877;77888o ^877;;;i7888888888888^^ 7888 78iii7iii7iiii
//               ^87; 877;778888887o 877;;88888888888^ 7ii7888 788oiiiiiiiii
//                 ^ 877;7 7888888887 877i;;8888887ii 87i78888 7888888888
//                  [87;;7 78888888887 87i;;888887i  87ii78888 7888888888]
//                  877;7 7788888888887 887i;887i^  87ii788888 78888888888
//                  87;i8 788888888888887 887ii;;^ 87ii7888888 78888888888
//                 [87;i8 7888888888888887 ^^^^   87ii77888888 78888888888
//                 87;;78 7888888888888887ii      87i78888888 778888888888
//                 87;788 7888888888888887i]      87i78888888 788888888888
//                [87;88 778888888888888887       7ii78888888 788888888888
//                87;;88 78888888888888887]       ii778888888 78888888888]
//                7;;788 7888888888888888]        i7888888888 78888888888'
//                7;;788 7888888888888888         'i788888888 78888888888
//                7;i788 788888888888888]          788888888 77888888888]
//                '7;788 778888888888888]         [788888888 78888888888'
//                ';77888 78888888888888          8888888888 7888888888]
//                 778888 78888888888888          8888888888 7888888888]
//                  78888 7888888888888]         [8888888888 7888888888
//                   7888 788888888888]          88888888888 788888888]
//                    778 78888888888]           ]888888888 778888888]
//                    oooooo ^88888^              ^88888^^^^^^^^8888]
//                   87;78888ooooooo8o            ,oooooo oo888oooooo
//                   [877;i77888888888]          [;78887i8888878i7888;
//                    ^877;;ii7888ii788          ;i777;7788887787;778;
//                     ^87777;;;iiii777          ;77^^^^^^^^^^^^^^^^;;
//                        ^^^^^^^^^ii7]           ^ o88888888877iiioo
//                           77777o               [88777777iiiiii;;778
//                            77777iii            8877iiiii;;;77888888]
//                            77iiii;8           [77ii;778 788888888888
//                            7iii;;88           iii;78888 778888888888
//                           77i;78888]          ;;;;i88888 78888888888
//                         ,7;78888888          [;;i788888 7888888888]
//                          i;788888888           ;i7888888 7888888888
//                          ;788888888]           i77888888 788888888]
//                          ';88888888'           [77888888 788888888]
//                           [[8ooo88]             78888888 788888888
//                            [88888]              78888888 788888888
//                              ^^^                [7888888 77888888]
//                                                  88888888 7888887
//                                                  77888888 7888887
//                                                   ;i88888 788888i
//                                                  ,;;78888 788877i7
//                                                 ,7;;i;777777i7i;;7
//                                                 87778^^^ ^^^^87778
//                                                  ^^^^ o777777o ^^^
//                                                  o77777iiiiii7777o
//                                                 7777iiii88888iii777
//                                                ;;;i7778888888877ii;;
//                   Imperial Stormtrooper       [i77888888^^^^8888877i]
//                  (Standard Shock Trooper)     77888^oooo8888oooo^8887]
//                                              [788888888888888888888888]
//                                              88888888888888888888888888
//                                              ]8888888^iiiiiiiii^888888]
//                       Bob VanderClay           iiiiiiiiiiiiiiiiiiiiii
//                                                    ^^^^^^^^^^^^^