namespace SIPABE_DIFGRO_FAH
{
    partial class Registrar
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
            this.TxtCurp = new System.Windows.Forms.TextBox();
            this.TxtNombres = new System.Windows.Forms.TextBox();
            this.TxtApellidoMaterno = new System.Windows.Forms.TextBox();
            this.TxtApellidoPaterno = new System.Windows.Forms.TextBox();
            this.TxtCurpAnexo = new System.Windows.Forms.TextBox();
            this.TxtQR = new System.Windows.Forms.TextBox();
            this.TxtEntidadRegistro = new System.Windows.Forms.TextBox();
            this.TxtEntidadNacimiento = new System.Windows.Forms.TextBox();
            this.TxtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.TxtSexo = new System.Windows.Forms.TextBox();
            this.BtnRegistrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtCurp
            // 
            this.TxtCurp.Enabled = false;
            this.TxtCurp.Location = new System.Drawing.Point(275, 84);
            this.TxtCurp.Name = "TxtCurp";
            this.TxtCurp.Size = new System.Drawing.Size(182, 20);
            this.TxtCurp.TabIndex = 0;
            // 
            // TxtNombres
            // 
            this.TxtNombres.Enabled = false;
            this.TxtNombres.Location = new System.Drawing.Point(275, 188);
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.Size = new System.Drawing.Size(182, 20);
            this.TxtNombres.TabIndex = 1;
            this.TxtNombres.TextChanged += new System.EventHandler(this.textBox11_TextChanged);
            // 
            // TxtApellidoMaterno
            // 
            this.TxtApellidoMaterno.Enabled = false;
            this.TxtApellidoMaterno.Location = new System.Drawing.Point(275, 162);
            this.TxtApellidoMaterno.Name = "TxtApellidoMaterno";
            this.TxtApellidoMaterno.Size = new System.Drawing.Size(182, 20);
            this.TxtApellidoMaterno.TabIndex = 2;
            // 
            // TxtApellidoPaterno
            // 
            this.TxtApellidoPaterno.Enabled = false;
            this.TxtApellidoPaterno.Location = new System.Drawing.Point(275, 136);
            this.TxtApellidoPaterno.Name = "TxtApellidoPaterno";
            this.TxtApellidoPaterno.Size = new System.Drawing.Size(182, 20);
            this.TxtApellidoPaterno.TabIndex = 3;
            // 
            // TxtCurpAnexo
            // 
            this.TxtCurpAnexo.Enabled = false;
            this.TxtCurpAnexo.Location = new System.Drawing.Point(275, 110);
            this.TxtCurpAnexo.Name = "TxtCurpAnexo";
            this.TxtCurpAnexo.Size = new System.Drawing.Size(182, 20);
            this.TxtCurpAnexo.TabIndex = 4;
            // 
            // TxtQR
            // 
            this.TxtQR.Location = new System.Drawing.Point(12, 12);
            this.TxtQR.Name = "TxtQR";
            this.TxtQR.Size = new System.Drawing.Size(182, 20);
            this.TxtQR.TabIndex = 5;
            // 
            // TxtEntidadRegistro
            // 
            this.TxtEntidadRegistro.Enabled = false;
            this.TxtEntidadRegistro.Location = new System.Drawing.Point(275, 292);
            this.TxtEntidadRegistro.Name = "TxtEntidadRegistro";
            this.TxtEntidadRegistro.Size = new System.Drawing.Size(182, 20);
            this.TxtEntidadRegistro.TabIndex = 6;
            // 
            // TxtEntidadNacimiento
            // 
            this.TxtEntidadNacimiento.Enabled = false;
            this.TxtEntidadNacimiento.Location = new System.Drawing.Point(275, 266);
            this.TxtEntidadNacimiento.Name = "TxtEntidadNacimiento";
            this.TxtEntidadNacimiento.Size = new System.Drawing.Size(182, 20);
            this.TxtEntidadNacimiento.TabIndex = 7;
            // 
            // TxtFechaNacimiento
            // 
            this.TxtFechaNacimiento.Enabled = false;
            this.TxtFechaNacimiento.Location = new System.Drawing.Point(275, 240);
            this.TxtFechaNacimiento.Name = "TxtFechaNacimiento";
            this.TxtFechaNacimiento.Size = new System.Drawing.Size(182, 20);
            this.TxtFechaNacimiento.TabIndex = 8;
            // 
            // TxtSexo
            // 
            this.TxtSexo.Enabled = false;
            this.TxtSexo.Location = new System.Drawing.Point(275, 214);
            this.TxtSexo.Name = "TxtSexo";
            this.TxtSexo.Size = new System.Drawing.Size(182, 20);
            this.TxtSexo.TabIndex = 9;
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.Location = new System.Drawing.Point(32, 88);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(123, 42);
            this.BtnRegistrar.TabIndex = 10;
            this.BtnRegistrar.Text = "REGISTRAR";
            this.BtnRegistrar.UseVisualStyleBackColor = true;
            // 
            // Registrar
            // 
            this.ClientSize = new System.Drawing.Size(528, 384);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.TxtSexo);
            this.Controls.Add(this.TxtFechaNacimiento);
            this.Controls.Add(this.TxtEntidadNacimiento);
            this.Controls.Add(this.TxtEntidadRegistro);
            this.Controls.Add(this.TxtQR);
            this.Controls.Add(this.TxtCurpAnexo);
            this.Controls.Add(this.TxtApellidoPaterno);
            this.Controls.Add(this.TxtApellidoMaterno);
            this.Controls.Add(this.TxtNombres);
            this.Controls.Add(this.TxtCurp);
            this.Name = "Registrar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox TxtLectorQR;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;

        private System.Windows.Forms.TextBox TxtCurp;
        private System.Windows.Forms.TextBox TxtNombres;
        private System.Windows.Forms.TextBox TxtApellidoMaterno;
        private System.Windows.Forms.TextBox TxtApellidoPaterno;
        private System.Windows.Forms.TextBox TxtCurpAnexo;
        private System.Windows.Forms.TextBox TxtQR;
        private System.Windows.Forms.TextBox TxtEntidadRegistro;
        private System.Windows.Forms.TextBox TxtEntidadNacimiento;
        private System.Windows.Forms.TextBox TxtFechaNacimiento;
        private System.Windows.Forms.TextBox TxtSexo;
        private System.Windows.Forms.Button BtnRegistrar;
    }
}