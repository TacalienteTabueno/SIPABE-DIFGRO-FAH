namespace SIPABE_DIFGRO_FAH
{
    partial class Consultar1
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
            this.TxtBuscador = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtBuscador
            // 
            this.TxtBuscador.Location = new System.Drawing.Point(56, 136);
            this.TxtBuscador.Name = "TxtBuscador";
            this.TxtBuscador.Size = new System.Drawing.Size(270, 20);
            this.TxtBuscador.TabIndex = 0;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(337, 229);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(165, 89);
            this.BtnBuscar.TabIndex = 1;
            this.BtnBuscar.Text = "BUSCAR";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // Consultar1
            // 
            this.ClientSize = new System.Drawing.Size(565, 398);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBuscador);
            this.Name = "Consultar1";
            this.Load += new System.EventHandler(this.Consultar1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtBuscador;
        private System.Windows.Forms.Button BtnBuscar;
    }
}