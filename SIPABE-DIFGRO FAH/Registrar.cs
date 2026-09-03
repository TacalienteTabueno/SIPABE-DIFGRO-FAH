 using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
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
    public partial class Registrar : LostForm
    {
        //PANTONE
        private readonly Color ColorVinoPrincipal = Color.FromArgb(105, 28, 50);    // Pantone 7421 C
        private readonly Color ColorVinoHeader = Color.FromArgb(88, 17, 26);     // Vino oscuro
        private readonly Color ColorBeige = Color.FromArgb(245, 235, 215);       // Marfil/Beige
        private readonly Color ColorDorado = Color.FromArgb(197, 160, 89);       // Acento dorado
        private readonly Color ColorBordeSuave = Color.FromArgb(215, 200, 180);
        // Constructor que acepta texto para que funcione el escaner correctamente
        public Registrar()
        {
            InitializeComponent();


            this.Image = null;
            this.ShowIcon = false;      // Oculta el ícono de la esquina
            this.Text = string.Empty;

            // 2. Colores de la ventana
            this.BackColor = ColorVinoPrincipal;
            this.ForeColor = ColorBeige;
            this.HeaderColor = ColorVinoHeader;
            this.BorderColor = ColorDorado;

            ConfigurarDiseñoYPosiciones();
            this.Shown += (s, e) =>
            {
                if (this.TxtQR != null)
                {
                    this.ActiveControl = this.TxtQR;
                    this.TxtQR.Focus();
                }
            };
        }
        private void ConfigurarDiseñoYPosiciones()
        {
           // 1. Dimensiones de la estructura
    int anchoLabel = 220;       // Ancho fijo para que el texto de las etiquetas no se corte
    int anchoCaja = 300;        // Ancho de los HopeTextBox
    int altoCaja = 32;          // Alto de cada campo
    int separacion = 10;        // Espacio vertical entre filas
    int espacioEntre = 12;      // Espacio horizontal entre la etiqueta y el cuadro de texto
    int posYInicial = 65;       // Altura de inicio

    // 2. Centrar el bloque completo (Label + Espacio + TextBox) en la ventana
    int anchoBloqueTotal = anchoLabel + espacioEntre + anchoCaja;
    int posXLabel = (this.ClientSize.Width - anchoBloqueTotal) / 2;
    int posXTextBox = posXLabel + anchoLabel + espacioEntre;

        var camposConEtiqueta = new (HopeTextBox txt, string textoLabel)[]
        {
            (this.TxtCurp, "CURP:"),
            (this.TxtNombres, "NOMBRE(S):"),
            (this.TxtApellidoPaterno, "PRIMER APELLIDO:"),
            (this.TxtApellidoMaterno, "SEGUNDO APELLIDO:"),
            (this.TxtFechaNacimiento, "FECHA DE NACIMIENTO:"),
            (this.TxtSexo, "SEXO:"),
            (this.TxtEntidadNacimiento, "ENTIDAD DE NACIMIENTO:"),
            (this.TxtEntidadRegistro, "ENTIDAD DE REGISTRO:")      
     };

            int yActual = posYInicial;

            foreach (var item in camposConEtiqueta)
            {
                if (item.txt != null)
                {
                    // --- Crear y configurar Label dinámica ---
                    Label lbl = new Label
                    {
                        Text = item.textoLabel,
                        Location = new Point(posXLabel, yActual), 
                        Size = new Size(anchoLabel, altoCaja),
                        ForeColor = ColorBeige,                       // Texto beige sobre el fondo vino
                        Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleRight,     // Alineado a la derecha hacia la caja de texto
                        BackColor = Color.Transparent,
                        AutoSize = false
                    };

                    this.Controls.Add(lbl);
                    lbl.BringToFront();

                    item.txt.Location = new Point(posXTextBox, yActual);
                    item.txt.Size = new Size(anchoCaja, altoCaja);
                    item.txt.BackColor = ColorBeige;
                    item.txt.BaseColor = ColorBeige;
                    item.txt.BorderColorA = ColorDorado;
                    item.txt.BorderColorB = ColorBordeSuave;
                    item.txt.ForeColor = ColorVinoPrincipal;
                    item.txt.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    item.txt.Hint = string.Empty;
                  

                    yActual += altoCaja + separacion;

                }
            }
            int anchoBoton = 200;           // Ancho adecuado para que quepan lado a lado
            int altoBoton = 46;
            int separacionBotones = 25;     // Espacio entre ambos botones
            int espacioAntesBoton = 20;
            int posYBotones = yActual + espacioAntesBoton;

            // Cálculo para centrar el bloque de los dos botones
            int anchoTotalGrupo = (anchoBoton * 2) + separacionBotones;
            int posXInicio = (this.ClientSize.Width - anchoTotalGrupo) / 2;

            if (this.BtnRegistrar != null)
            {
                this.BtnRegistrar.Size = new Size(anchoBoton, altoBoton);
                this.BtnRegistrar.Location = new Point(posXInicio, posYBotones);
                this.BtnRegistrar.Text = "REGISTRAR";
                this.BtnRegistrar.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
                this.BtnRegistrar.PrimaryColor = ColorBeige;
                this.BtnRegistrar.TextColor = ColorVinoPrincipal;
                this.BtnRegistrar.BorderColor = ColorDorado;
                this.BtnRegistrar.HoverTextColor = ColorDorado;
                this.BtnRegistrar.Cursor = Cursors.Hand;
                this.BtnRegistrar.BringToFront();
            }
            if (this.TxtQR != null)
            {
                this.TxtQR.Visible = true;                   // Mantiene la capacidad de recibir foco
                this.TxtQR.Location = new Point(-2000, -2000); // Se envía fuera del área visible
                this.TxtQR.Size = new Size(100, 30);
            }


            if (this.BtnRegresar != null)
            {
                this.BtnRegresar.Size = new Size(anchoBoton, altoBoton);
                this.BtnRegresar.Location = new Point(posXInicio + anchoBoton + separacionBotones, posYBotones);
                this.BtnRegresar.Text = "REGRESAR";
                this.BtnRegresar.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
                this.BtnRegresar.PrimaryColor = ColorBeige;
                this.BtnRegresar.TextColor = ColorVinoPrincipal;
                this.BtnRegresar.BorderColor = ColorDorado;
                this.BtnRegresar.HoverTextColor = ColorDorado;
                this.BtnRegresar.Cursor = Cursors.Hand;
                this.BtnRegresar.BringToFront();
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Evaluamos ContainsFocus (no Focused) y atrapamos tanto Tab como Enter que mandan los lectores
            if ((keyData == Keys.Tab || keyData == Keys.Enter) && (TxtQR != null && TxtQR.ContainsFocus))
            {
                ProcesarCodigoQR();
                return true; // Le decimos a Windows que ya procesamos la tecla
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // =========================================================
        // EL PROCESADOR DEL ESCANEO
        // =========================================================
// ⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡦⣶⣶⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⣉⣭⠟⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⠋⠁⠀⠀⠀⠀⠈⢻⡄⠀⠀⠀⠀⠀⠀⣀⣠⣴⢭⣄⠀⠀⣖⠛⢦⠀⠀⠀⣇⣀⡀⠀⠀⠀⠀⠀⡄⠀⠀⠀⢠⡞⠛⠻
// ⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⡆⢠⣴⡾⠋⠁⠀⠀⠀⠀⠙⡆⠀⠀⠈⡇⢠⠞⣿⠉⠉⢷⠀⠀⠀⠀⡷⠀⠀⠀⠀⠳⣄⡀
// ⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⢰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⡿⡷⠦⡤⡀⠀⠀⠀⠀⠀⢹⠀⠀⠀⣇⠏⡟⡇⠀⢀⡼⠃⠀⠀⡛⣆⡀⠀⠀⠀⠀⠈⣹
// ⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠓⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡏⡇⠀⠀⠀⣳⠀⠀⠀⢦⡼⠏⠀⠀⢰⡇⠀⣟⡇⠀⠀⠀⠀⠀⡴⠃⡇⠉⣙⡷⡶⠾⠏⠀
// ⣿⣿⣿⣿⡟⠀⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠀⠀⠀⢘⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⠹⡄⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⣀⣾⠧⠤⡷⡧⠄⠄⠤⠂⣫⠃⢰⠃⠀⠀⡏⠀⠀⠀⠀
// ⣿⣿⣿⣿⡇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⢹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣆⠀⠀⠀⠀⠀⠀⠀⢀⡼⠋⠁⠀⢠⠗⡇⠀⠀⠀⠀⢰⠁⠀⡇⠀⠀⠀⠱⣀⠀⢰
// ⣿⣿⣿⣿⡇⣿⠰⡀⠈⠄⠀⠀⠀⠀⠀⠀⠀⢳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⣇⣀⣀⣀⡀⢀⡷⠁⠀⠀⣀⡀⡏⣽⠀⠀⠀⠀⠀⡇⠀⠈⣇⠀⠀⠀⠀⠀⠉⠀⠀
// ⣿⣿⣿⣿⣇⢻⡇⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠾⠿⠀⠀⠀⠀⠀⠀⠒⠾⢮⣒⣿⠂⢂⡬⢭⡿⢽⣁⡂⡶⡗⢻⡮⠥⠐⣒⠚⠭⢓⡤⠄⡙⢦⠀⠀⢠⣶⣦⡀⠀⠀
// ⣿⣿⣿⣿⣿⣿⣿⣄⢳⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⠠⠀⠀⠀⠀⠀⠀⠡⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⠁⠀⠀⠀⠀⣷⠀⠀⠀⠉⠁⡏⡃⡏⠉⠁⠀⠉⠀⠁⠧⣆⠁⠉⠀⠀⠟⠉⣿⡇
// ⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠱⣄⠀⠀⠀⠀⠀⠘⠆⠀⠈⢿⣦⠀⠀⠠⠀⠀⠀⠀⠀⢰⣶⣶⠂⠀⠀⠀⠀⠀⠀⠀⢠⡿⠋⠉⠉⠒⠄⡃⢵⠀⠀⠀⠀⠀⢳⠆⡇⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢶⣤⠤⠖⠋⠀⠀
// ⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⡶⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⡄⠀⠀⠀⠀⠀⠀⠘⣦⣀⠀⠀⠀⢠⣀⠀⠀⠈⠳⠦⠀⠀⠀⠀⠀⠀⠐⠀⢻⡟⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⠀⠀⠀⠀⠀⠙⣧⠀⠀⠀⠀⠀⢸⣸⠀⠀⠀⡴⣺⠟⠊⠀⢠⠄⠀⠀⢹⡇⠀⠀⠀⡰
// ⣿⣿⣿⣿⣿⡿⠃⠜⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣇⠀⠀⠀⣷⣄⠀⠀⠈⠛⢷⣶⣤⡄⠙⠳⠦⣤⡀⠈⠀⠀⠀⡀⠸⣤⣄⠀⠀⠀⡀⠀⠀⠀⠀⠀⡟⠀⠀⠀⠀⠀⠀⠀⠀⠈⠷⢤⢀⠀⠀⡇⢽⠀⡏⠁⣿⠀⠀⠀⠀⡇⠀⠀⣠⣿⠀⡴⡮⠗⠦⣄
// ⣿⣿⣿⣿⠟⢠⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠈⠻⠷⠆⢰⣿⣿⣷⣤⡀⠈⠻⣿⣿⣿⣦⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠠⠀⠀⢀⠀⠀⠀⠀⠀⠸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠢⠉⣦⠀⢏⢿⡇⡇⠀⠘⡟⠖⠊⠀⠙⠛⠛⠋⠀⡟⠁⠀⠀⠀⣿
// ⣿⣿⡿⢃⣴⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢶⣶⣄⠄⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⠉⠀⢀⣠⣴⣶⣶⣶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠘⡧⣿⣞⡇⢳⡀⠀⠙⠦⡄⠀⠀⠀⠀⠀⠀⠀⠃⠀⠀⠀⡾
// ⣿⠋⣰⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣦⡀⢀⣾⣄⠠⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⢹⡷⡿⠉⠑⠙⠷⢦⣤⣤⣭⡒⢄⡀⠀⠀⠀⠀⣤⠟⠁⠀
// ⣡⣿⣿⠃⠀⠀⠀⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⢰⡿⢋⣴⣿⣿⣿⣿⣦⣤⡹⣿⣿⣿⣿⣿⣿⣿⣿⣧⡁⠀⠈⠉⠛⠛⠿⣿⣷⣀⡐⠠⠷⣼⠂⠀⠈⠀⠀⠀⠀⠀⠀⠀⠉⠑⢤⣆⠀⠀⡇⠀⣴⣿⠇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠉⠣⡙⣦⣤⡾⠉⠀⠀⠀⠀⠀
// ⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣉⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⡛⢿⣿⣿⣿⣿⣿⣿⣿⣷⣴⣆⣠⡀⠀⠀⠉⠛⠛⠛⠋⠉⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡝⡆⠉⠛⠉⡇⣽⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⠟⠉⠹⠏⠉⠻⣆⠀⠀⠀
// ⣿⡡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⢌⡛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⣦⣄⣀⣀⡠⠀⡤⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠆⠀⣀⣸⣲⣟⣦⡄⠀⠀⠀⠀⣴⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀
// ⡻⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢿⣿⣿⣿⣿⣿⣿⣿⡿⠋⢀⣤⣄⣠⣴⠟⢁⡴⠁⠀⠀⠀⠀⠀⠀⠀⡼⢾⠟⠋⠉⣿⡇⠈⣿⡄⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠤⡤⠞⡟⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡛⢿⣿⣿⣿⣴⣿⣿⣿⠟⣁⠔⣫⣴⠀⡀⠀⠀⠀⠀⠀⠀⢹⣿⠃⠀⠀⠈⣾⠀⠀⠐⣻⠀⠀⠘⣧⠀⠀⠀⠀⠀⠀⠀⢀⡞⠁⠀⠀⠀
// ⠀⠀⠀⡠⠀⠀⡐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡉⢿⡿⠻⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣭⣀⡂⠉⢛⠻⠿⢋⠥⢊⣡⣾⣿⣷⡄⠀⢠⠀⠀⠀⠀⠠⢷⢹⠀⠀⠀⢠⣿⠀⠀⠈⠁⠀⠀⠀⠈⣧⠀⠀⠀⠀⠀⢰⡏⠀⠀⢀⡀⠀
// ⠀⠀⡔⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣆⣻⣿⣷⣬⣹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣦⣌⣒⠂⠭⠍⠛⠻⢿⠃⠀⣸⠀⢀⡠⡪⠑⢳⡘⡆⠀⠀⣯⡿⠀⠀⢄⠀⠀⠀⠀⠀⢫⣆⢠⡀⠀⠸⣇⠀⠀⠀⠀⢻⡀
// ⢀⡜⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⠀⠀⣿⠀⠀⠀⠀⠀⠀⠙⢦⡣⡀⢸⡇⠀⢀⣞⠃⠀⠀⠀⠀⠈⠩⣿⡰⠀⠀⢿⢦⣄⣀⡼⠋⠀
// ⠈⣴⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⡟⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⢷⣷⣖⢶⡿⠳⠒⠦⠤⡤⠊⡤⡏⠀⠀⠀⠀⠉⠉⠉⠀⠀⠀
// ⣾⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠘⠀⣧⠀⠀⠀⠀⡴⡞⠉⠀⠀⠀⣼⡿⠈⠻⡏⠀⠀⠀⠀⠀⠀⠉⢿⢗⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠙⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⢹⠀⠀⠀⠀⡿⠁⠀⠀⠀⠀⠀⡿⡇⠀⠀⣿⡇⠴⠶⣄⠀⠀⠀⣸⠋⠀⠀⠀⠑⣦⠀⠀⠀
// ⡾⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣦⣌⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⢠⡃⠀⠀⠀⠀⠀⠀⣏⡇⠀⠀⣿⡇⠀⠀⠈⢿⡄⠈⠀⠀⣠⡤⣤⡀⢹⡆⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣿⣿⣶⣄⡙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢠⠀⢠⠀⠀⠀⠀⠹⠷⣦⠄⠀⠀⠀⢿⠇⢠⢣⠟⠀⠀⠀⠀⢹⡆⡴⠏⠁⠀⠀⠙⢧⢼⠇⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⠙⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢸⡇⠘⠀⠀⠀⠀⠀⠈⠒⢿⢷⣶⣦⣿⣵⡮⠄⠀⠀⠀⠀⠀⡿⠇⠀⠀⠀⠀⠀⠀⢘⡿⡏⠀⠀
// ⣴⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⣶⣬⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⢿⡿⡅⠀⠀⠀⠀⠀⠀⣯⠁⠀⠀⠀⠀⠀⠀⢠⣿⠏⠀⠀
// ⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡏⡗⡇⠀⠀⠀⠀⡠⡿⠋⠀⠀⠀⠠⠴⠖⠫⠋⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⠉⠀⠀⣀⣠⣴⣶⡶⠃⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⢰⡏⠀⣿⠀⢠⡦⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠿⠟⠋⠉⣁⣠⣤⣶⣶⣿⣿⣿⣿⣿⡟⢡⡆⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⡠⣻⣫⡽⠟⠓⠉⠉⠛⢶⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠟⠛⠛⠉⠉⠀⠀⠀⠛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣿⡇⠀⠀⠂⢀⡔⠒⠀⠀⠀⢀⡧⡾⣿⠏⠀⠀⠀⠀⠀⠀⠀⠰⡏⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠠⠷⠦⠤⠴⠖⠻⠻⡇⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠇⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣯⡀⠀⠀⠀⠀⠀⠀⢀⣠⡾⠋⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⡤⠀⠀⠀⠀⣾⠻⣟⡒⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⣿⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⠃⠀⠀⠀⠀⠀⠇⠀⠙⡟⢟⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢻⡿⠛⢉⠤⠂⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠼⣇⠀⠀⠀⠀⠀⠀⠇⠀⠀⠘⡎⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣠⡆⠀⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⡠⢊⣡⠞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣾⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣴⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣕⢦⡀⠀⠀⠀⠀⣀⠖⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠋⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠯⠭⠍⠩⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⠀⠀⠀⢺⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣠⡄⠀⢸⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⣿⡇⠀⠀⣿⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
// ⢸⡇⠀⡆⢹⣿⣧⠀⠀⠀⠀
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        private void ProcesarCodigoQR()
        {
            string escaneoRaw = TxtQR.Text.Trim();

            if (string.IsNullOrEmpty(escaneoRaw)) return;

            try
            {
                // Parte la cadena de texto y cambia los los caracteres especiales llamando
                // la clase que es equivalente a los modulos que separaban y corregian, ahora estan combinados
                string Curp = UtilidadesQR.ParseWord(escaneoRaw, 1, "|", false, false);
                string CurpAnexo = UtilidadesQR.ParseWord(escaneoRaw, 2, "|", false, false);
                string ApellidoPaterno = UtilidadesQR.ParseWord(escaneoRaw, 3, "|", false, false);
                string ApellidoMaterno = UtilidadesQR.ParseWord(escaneoRaw, 4, "|", false, false);
                string Nombres = UtilidadesQR.ParseWord(escaneoRaw, 5, "|", false, false);
                string Sexo = UtilidadesQR.ParseWord(escaneoRaw, 6, "|", false, false);
                string FechaNacimiento = UtilidadesQR.ParseWord(escaneoRaw, 7, "|", false, false);
                string EntidadNacimiento = UtilidadesQR.ParseWord(escaneoRaw, 8, "|", false, false);
                string EntidadRegistro = UtilidadesQR.ParseWord(escaneoRaw, 9, "|", false, false);

                // Ahora los valores caen (asi como yo caigo en la desesperacion cada dia) donde corresponden
                TxtCurp.Text = Curp;
                TxtCurpAnexo.Text = CurpAnexo;
                TxtApellidoPaterno.Text = ApellidoPaterno;
                TxtApellidoMaterno.Text = ApellidoMaterno;
                TxtNombres.Text = Nombres;
                TxtSexo.Text = Sexo;
                TxtFechaNacimiento.Text = FechaNacimiento;
                TxtEntidadNacimiento.Text = EntidadNacimiento;
                TxtEntidadRegistro.Text = EntidadRegistro;

                // Limpiamos el campo lector para que no quede la cadena de texto toda fea
                //TxtQR.Clear();
                TxtCurp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El código QR no tiene el formato esperado.\nDetalle: " + ex.Message,
                                "Error de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TxtQR.Clear();
                TxtQR.Focus();
            }
        }
        

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQR_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Instanciar el menú principal
            MenuPrincipalForm menu = new MenuPrincipalForm();

            // 2. Asegurar que aparezca centrado en pantalla
            menu.StartPosition = FormStartPosition.CenterScreen;

            // 3. Mostrar el menú
            menu.Show();
          

            // 4. Cerrar la ventana actual
            this.Close();
        }
    }
}