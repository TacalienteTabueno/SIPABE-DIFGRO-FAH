namespace SIPABE_DIFGRO_FAH
{
    partial class MenuPrincipalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtUsuarioActual = new System.Windows.Forms.TextBox();
            this.BtnCapturaQR = new System.Windows.Forms.Button();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtUsuarioActual
            // 
            this.TxtUsuarioActual.Location = new System.Drawing.Point(47, 31);
            this.TxtUsuarioActual.Name = "TxtUsuarioActual";
            this.TxtUsuarioActual.Size = new System.Drawing.Size(180, 20);
            this.TxtUsuarioActual.TabIndex = 0;
            // 
            // BtnCapturaQR
            // 
            this.BtnCapturaQR.Location = new System.Drawing.Point(407, 96);
            this.BtnCapturaQR.Name = "BtnCapturaQR";
            this.BtnCapturaQR.Size = new System.Drawing.Size(177, 40);
            this.BtnCapturaQR.TabIndex = 1;
            this.BtnCapturaQR.Text = "REGISTAR";
            this.BtnCapturaQR.UseVisualStyleBackColor = true;
            this.BtnCapturaQR.Click += new System.EventHandler(this.BtnCapturaQR_Click);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(403, 178);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(180, 35);
            this.BtnConsultar.TabIndex = 2;
            this.BtnConsultar.Text = "CONSULTAR";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // MenuPrincipalForm
            // 
            this.ClientSize = new System.Drawing.Size(690, 414);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnCapturaQR);
            this.Controls.Add(this.TxtUsuarioActual);
            this.Name = "MenuPrincipalForm";
            this.Load += new System.EventHandler(this.MenuPrincipalForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnConsultaPral;
        private System.Windows.Forms.TextBox TxtUsuarioActual;
        private System.Windows.Forms.Button BtnCapturaQR;
        private System.Windows.Forms.Button BtnConsultar;
    }
}