using System;


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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Btn_Login = new ReaLTaiizor.Controls.HopeButton();
            this.Txt_User = new ReaLTaiizor.Controls.HopeTextBox();
            this.Txt_Pass = new ReaLTaiizor.Controls.HopeTextBox();
            this.TxtCapturistaNamae = new ReaLTaiizor.Controls.HopeTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Login
            // 
            this.Btn_Login.BackColor = System.Drawing.Color.Goldenrod;
            this.Btn_Login.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.Btn_Login.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.Btn_Login.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Btn_Login.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.Maroon;
            this.Btn_Login.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.Btn_Login.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.Btn_Login.Location = new System.Drawing.Point(96, 432);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.Btn_Login.Size = new System.Drawing.Size(280, 47);
            this.Btn_Login.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.Btn_Login.TabIndex = 0;
            this.Btn_Login.Text = "Ingresar";
            this.Btn_Login.TextColor = System.Drawing.Color.White;
            this.Btn_Login.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Txt_User
            // 
            this.Txt_User.BackColor = System.Drawing.Color.White;
            this.Txt_User.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.Txt_User.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.Txt_User.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.Txt_User.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_User.ForeColor = System.Drawing.Color.Maroon;
            this.Txt_User.Hint = "";
            this.Txt_User.Location = new System.Drawing.Point(96, 282);
            this.Txt_User.MaxLength = 32770;
            this.Txt_User.Multiline = false;
            this.Txt_User.Name = "Txt_User";
            this.Txt_User.PasswordChar = '\0';
            this.Txt_User.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Txt_User.SelectedText = "";
            this.Txt_User.SelectionLength = 0;
            this.Txt_User.SelectionStart = 0;
            this.Txt_User.Size = new System.Drawing.Size(280, 38);
            this.Txt_User.TabIndex = 1;
            this.Txt_User.TabStop = false;
            this.Txt_User.UseSystemPasswordChar = false;
            this.Txt_User.Leave += new System.EventHandler(this.Txt_User_Leave);
            // 
            // Txt_Pass
            // 
            this.Txt_Pass.BackColor = System.Drawing.Color.White;
            this.Txt_Pass.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.Txt_Pass.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.Txt_Pass.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.Txt_Pass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Pass.ForeColor = System.Drawing.Color.Maroon;
            this.Txt_Pass.Hint = "";
            this.Txt_Pass.Location = new System.Drawing.Point(96, 358);
            this.Txt_Pass.MaxLength = 32767;
            this.Txt_Pass.Multiline = false;
            this.Txt_Pass.Name = "Txt_Pass";
            this.Txt_Pass.PasswordChar = '*';
            this.Txt_Pass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Txt_Pass.SelectedText = "";
            this.Txt_Pass.SelectionLength = 0;
            this.Txt_Pass.SelectionStart = 0;
            this.Txt_Pass.Size = new System.Drawing.Size(280, 38);
            this.Txt_Pass.TabIndex = 2;
            this.Txt_Pass.TabStop = false;
            this.Txt_Pass.UseSystemPasswordChar = false;
            // 
            // TxtCapturistaNamae
            // 
            this.TxtCapturistaNamae.BackColor = System.Drawing.Color.White;
            this.TxtCapturistaNamae.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.TxtCapturistaNamae.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.TxtCapturistaNamae.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.TxtCapturistaNamae.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.TxtCapturistaNamae.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.TxtCapturistaNamae.Hint = "";
            this.TxtCapturistaNamae.Location = new System.Drawing.Point(321, 78);
            this.TxtCapturistaNamae.MaxLength = 32767;
            this.TxtCapturistaNamae.Multiline = false;
            this.TxtCapturistaNamae.Name = "TxtCapturistaNamae";
            this.TxtCapturistaNamae.PasswordChar = '\0';
            this.TxtCapturistaNamae.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtCapturistaNamae.SelectedText = "";
            this.TxtCapturistaNamae.SelectionLength = 0;
            this.TxtCapturistaNamae.SelectionStart = 0;
            this.TxtCapturistaNamae.Size = new System.Drawing.Size(145, 38);
            this.TxtCapturistaNamae.TabIndex = 3;
            this.TxtCapturistaNamae.TabStop = false;
            this.TxtCapturistaNamae.UseSystemPasswordChar = false;
            this.TxtCapturistaNamae.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(197, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 30);
            this.label1.TabIndex = 5;
            this.label1.Text = "SIPABE DIF GUERRERO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(471, 508);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtCapturistaNamae);
            this.Controls.Add(this.Txt_Pass);
            this.Controls.Add(this.Txt_User);
            this.Controls.Add(this.Btn_Login);
            this.Name = "LoginForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.HopeButton Btn_Login;
        private ReaLTaiizor.Controls.HopeTextBox Txt_User;
        private ReaLTaiizor.Controls.HopeTextBox Txt_Pass;
        private ReaLTaiizor.Controls.HopeTextBox TxtCapturistaNamae;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

