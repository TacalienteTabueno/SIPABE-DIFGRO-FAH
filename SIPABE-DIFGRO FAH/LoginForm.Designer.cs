namespace SIPABE_DIFGRO_FAH
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Txt_User = new System.Windows.Forms.TextBox();
            this.Txt_Pass = new System.Windows.Forms.TextBox();
            this.TxtCapturistaNamae = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(257, 306);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(280, 57);
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.Text = "Ingresar";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Txt_User
            // 
            this.Txt_User.Location = new System.Drawing.Point(287, 183);
            this.Txt_User.MaxLength = 32770;
            this.Txt_User.Name = "Txt_User";
            this.Txt_User.Size = new System.Drawing.Size(224, 20);
            this.Txt_User.TabIndex = 1;
            this.Txt_User.Leave += new System.EventHandler(this.Txt_User_Leave);
            // 
            // Txt_Pass
            // 
            this.Txt_Pass.Location = new System.Drawing.Point(287, 243);
            this.Txt_Pass.Name = "Txt_Pass";
            this.Txt_Pass.PasswordChar = '*';
            this.Txt_Pass.Size = new System.Drawing.Size(224, 20);
            this.Txt_Pass.TabIndex = 2;
            // 
            // TxtCapturistaNamae
            // 
            this.TxtCapturistaNamae.Location = new System.Drawing.Point(325, 418);
            this.TxtCapturistaNamae.Name = "TxtCapturistaNamae";
            this.TxtCapturistaNamae.Size = new System.Drawing.Size(145, 20);
            this.TxtCapturistaNamae.TabIndex = 3;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtCapturistaNamae);
            this.Controls.Add(this.Txt_Pass);
            this.Controls.Add(this.Txt_User);
            this.Controls.Add(this.Btn_Login);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.TextBox Txt_User;
        private System.Windows.Forms.TextBox Txt_Pass;
        private System.Windows.Forms.TextBox TxtCapturistaNamae;
    }
}

