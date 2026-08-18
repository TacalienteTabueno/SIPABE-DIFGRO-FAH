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

// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢡⣶⡏⣿⠆⠀⣴⣿⡇⡀⠀⠀⠀⢸⣿⣦⢢⣄⠢⡘⢿⣿⣿⣶⣄⡀⠂⠐⢿⣿⣿⣿⢦⣔⠿⣶⣦⡀⠸⣿⣿⣿⣶⠰⡙⣿⣿⣿⣿⣿⣿⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢃⣿⣿⢁⣿⠀⣸⣿⡟⣸⡇⠀⠀⠀⠘⣿⣿⡈⠸⣄⢠⡒⢝⢿⣿⣿⣿⣶⣄⡀⠙⢿⣧⡕⢌⠳⣬⡃⢝⠢⢌⠻⣿⣿⣇⢻⡌⢿⣿⣿⣿⣿⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢸⣿⢠⢹⣿⢱⡟⢠⡆⠀⠀⠀⢹⡋⡳⠁⢿⡘⣿⣶⣄⠈⠋⡻⢿⣿⣿⣆⡂⠙⢿⣷⣦⣾⣿⣷⣦⣄⣀⣀⠉⠛⠈⠿⠌⠿⣿⣿⣿⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠻⢸⡏⠀⣼⡇⠜⣰⣿⣿⡄⠀⠀⠀⠣⢷⠁⠈⣧⢻⣿⣿⡿⠂⠈⣑⠮⣙⠻⣿⣦⠠⡌⡛⢿⣿⣿⣿⡿⣿⣿⣿⠿⠿⢋⣅⠘⣿⣿⣿⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⢸⡇⢰⡿⠁⣰⣿⣿⣿⣷⡀⠀⠀⠀⠢⡃⣦⠹⡘⣿⠏⠀⣰⣾⣿⣷⠄⠉⠀⠈⠁⢱⣬⣒⠬⡙⠻⠶⣦⣤⣄⣒⠃⣩⣼⣧⡙⢿⣿⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠨⠃⠚⡄⣼⣿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠙⣿⣆⠣⢫⠀⣰⡿⢛⠡⠈⠀⠀⠀⢀⠀⠀⢻⣿⣷⣤⢳⣤⣐⣒⡂⣾⡿⠻⣿⣿⣿⣎⢻⣿⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠈⢰⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠂⠺⣿⣧⠈⣷⡟⠀⠀⡄⠀⠀⠀⠀⠈⣿⠀⡘⣿⡿⣿⢸⣿⣿⣿⠁⣿⡇⠑⠌⢿⣿⣿⣧⢹⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⢿⡆⠀⠀⠀⢸⡿⢋⣥⣤⣤⣤⣀⡈⠙⠳⠀⠀⠁⡹⣿⡧⡘⣧⡄⢸⡇⠀⢀⠀⠀⠀⡟⢠⣧⢹⢻⣿⣸⡏⡿⠃⠀⣿⠁⠀⠈⠎⠘⡇⢻⣧⣿
// ⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⢧⠀⠀⠀⠈⡸⣿⣿⣿⣿⣿⣿⣿⣶⣤⣜⠀⠀⠑⢜⢷⡀⠈⠳⣮⡛⠎⠛⠐⠋⣈⣼⣿⣿⢸⢸⠇⠟⠈⠀⠀⢠⠃⠀⠀⠀⠀⢦⢠⣷⣽⣿
// ⣿⣿⣿⣿⣿⣿⢿⡿⠿⠿⢿⣿⡇⣆⠀⠀⠀⠀⢳⣮⠙⠛⠉⠙⠉⠀⠀⠈⠉⣷⣄⢄⠀⠀⣛⠎⠢⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⢸⢈⡠⢠⢗⠀⠀⠀⠀⠀⠀⢀⡀⢾⣇⣿⣿⣿
// ⣿⣿⣟⡃⠊⠀⠤⢤⣌⠁⠐⢤⣅⠙⠀⠀⠀⠤⡈⢫⠄⠀⣠⣶⣿⣿⣿⣿⣿⣿⣿⣦⣁⠄⣠⣤⣌⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⠈⠘⣁⣵⡿⠀⠀⠀⠀⠁⠙⠸⢡⡌⢿⣿⣿⣿
// ⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⡄⠀⢤⣀⠈⠈⠏⢾⣿⡿⢛⣭⠥⠈⢹⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢀⣿⣿⣿⠇⠀⢀⠀⠀⡘⣠⣁⣾⣿⣾⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣆⠈⢻⣿⣶⣦⡌⠑⣚⣩⠖⣩⢆⣾⣿⣿⣿⣿⣿⣿⣭⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⢸⣿⣿⣿⠀⢀⢰⠀⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢧⡀⠹⣿⣿⣿⣶⣌⡰⡇⣿⢸⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⠉⠉⡁⢀⣿⣿⣿⡟⡀⢸⣿⣿⡏⠀⠀⣧⣠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠙⢿⣿⣿⣷⡄⠀⢹⢸⣿⣿⣿⣿⠿⠋⠀⣀⡈⠁⠀⣾⡇⢸⣿⣿⣿⡿⠁⢸⣿⡟⡇⠉⣰⠻⢹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⣬⣙⠿⣷⠀⡈⢇⢿⣿⣿⣿⣦⡀⢯⡰⣧⢱⣴⣿⡇⣸⣿⣿⡿⢁⠀⢸⣿⠁⠇⣰⣿⣷⣄⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠀⣸⡿⢿⣷⡮⠰⡘⠂⠈⠿⣿⣿⣿⣷⣌⢿⣦⣽⣿⣿⡇⣿⣿⡟⣡⣿⡄⢸⣿⠀⡄⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣴⣦⣤⣴⣿⣷⣦⡔⣿⡄⡘⠂⠠⠈⠛⠿⣿⣿⣮⠻⣿⣿⠟⢡⣿⢏⣼⣿⣿⢡⡸⣿⣧⡀⡻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿
// ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠲⠶⠶⠮⠭⠭⠍⠛⠋⠀⢈⣋⠀⠀⣠⣎⠺⣿⣶⣄⡉⠛⠶⣶⡶⠟⣡⣾⣿⣿⣿⣾⢡⣍⢹⣷⠀⠐⠈⠻⠿⠿⠿⠿⠿⠿⠻⠻⠟⠟

{
    public partial class BeneficiarioForm : Form
    {
        // =========================================================
        // BOB EL CONSTRUCTOR 1: El predeterminado (Sin datos)
        // Se usa si en algun momento se llega a abrir esta ventana en blanco que esperemos que nel.
        // =========================================================
        public BeneficiarioForm()
        {
            InitializeComponent();
        }

        // =========================================================
        // BOB EL CONSTRUCTOR 2: El cargado (Con el dato de busqueda osease como quien dice el CURP)
        // Este es el que dispara el buscador cuando el beneficiario si existe.
        // =========================================================
        public BeneficiarioForm(string datoRecibido)
        {
            InitializeComponent();

            // Acomodamos el dato que nos mandó el buscador directamente en la caja de texto,
            // así le ahorramos trabajo al capturista.
            TxtCurp.Text = datoRecibido;
        }

        private void BeneficiarioForm_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar código que quieras que se ejecute justo cuando 
            // la ventana termina de cargar visualmente.
        }

        private void TxtCurp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}