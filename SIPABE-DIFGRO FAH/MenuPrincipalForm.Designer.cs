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
            this.BtnCapturaQR = new System.Windows.Forms.Button();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnCapturaQR
            // 
            this.BtnCapturaQR.Location = new System.Drawing.Point(273, 164);
            this.BtnCapturaQR.Name = "BtnCapturaQR";
            this.BtnCapturaQR.Size = new System.Drawing.Size(187, 97);
            this.BtnCapturaQR.TabIndex = 1;
            this.BtnCapturaQR.Text = "REGISTAR";
            this.BtnCapturaQR.UseVisualStyleBackColor = true;
            this.BtnCapturaQR.Click += new System.EventHandler(this.BtnCapturaQR_Click);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Location = new System.Drawing.Point(89, 164);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(187, 97);
            this.BtnConsultar.TabIndex = 2;
            this.BtnConsultar.Text = "CONSULTAR";
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "BIENVENIDO A SIPABE 2027";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(438, 164);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(187, 97);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MenuPrincipalForm
            // 
            this.ClientSize = new System.Drawing.Size(690, 337);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.BtnCapturaQR);
            this.Name = "MenuPrincipalForm";
            this.Load += new System.EventHandler(this.MenuPrincipalForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnConsultaPral;
        private System.Windows.Forms.Button BtnCapturaQR;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}