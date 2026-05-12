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


    public partial class BeneficiarioForm : Form


    {

        public static string CadenaDeConexionGlobal { get; private set; }
        public static string NombreCapturistaActual { get; private set; }
        public static string UsuarioSQLActual { get; private set; }

        public BeneficiarioForm()
        {
            InitializeComponent();

        }

        private void BeneficiarioForm_Load(object sender, EventArgs e)
        {

        }
    }
}
