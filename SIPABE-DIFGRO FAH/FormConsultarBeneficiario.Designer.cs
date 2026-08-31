namespace SIPABE_DIFGRO_FAH
{
    partial class ConsultarBeneficiario : ReaLTaiizor.Forms.LostForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCurpBeneficiario = new ReaLTaiizor.Controls.HopeTextBox();
            this.btnConsultar = new ReaLTaiizor.Controls.HopeButton();
            this.btnRegresar = new ReaLTaiizor.Controls.HopeButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(722, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESCANEE LA CURP DEL BENEFICIARIO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCurpBeneficiario
            // 
            this.txtCurpBeneficiario.BackColor = System.Drawing.Color.White;
            this.txtCurpBeneficiario.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtCurpBeneficiario.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.txtCurpBeneficiario.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtCurpBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurpBeneficiario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtCurpBeneficiario.Hint = "";
            this.txtCurpBeneficiario.Location = new System.Drawing.Point(135, 156);
            this.txtCurpBeneficiario.MaxLength = 32767;
            this.txtCurpBeneficiario.Multiline = false;
            this.txtCurpBeneficiario.Name = "txtCurpBeneficiario";
            this.txtCurpBeneficiario.PasswordChar = '\0';
            this.txtCurpBeneficiario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCurpBeneficiario.SelectedText = "";
            this.txtCurpBeneficiario.SelectionLength = 0;
            this.txtCurpBeneficiario.SelectionStart = 0;
            this.txtCurpBeneficiario.Size = new System.Drawing.Size(437, 49);
            this.txtCurpBeneficiario.TabIndex = 1;
            this.txtCurpBeneficiario.TabStop = false;
            this.txtCurpBeneficiario.UseSystemPasswordChar = false;
            this.txtCurpBeneficiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurpBeneficiario_KeyPress);
            this.txtCurpBeneficiario.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCurpBeneficiario_PreviewKeyDown);
            this.txtCurpBeneficiario.TextChanged += new System.EventHandler(this.txtCurpBeneficiario_TextChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnConsultar.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnConsultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsultar.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnConsultar.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnConsultar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnConsultar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnConsultar.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnConsultar.Location = new System.Drawing.Point(171, 239);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnConsultar.Size = new System.Drawing.Size(145, 67);
            this.btnConsultar.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.TextColor = System.Drawing.Color.White;
            this.btnConsultar.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.btnRegresar.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.btnRegresar.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRegresar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRegresar.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.btnRegresar.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.btnRegresar.Location = new System.Drawing.Point(351, 239);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.btnRegresar.Size = new System.Drawing.Size(196, 62);
            this.btnRegresar.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.TextColor = System.Drawing.Color.White;
            this.btnRegresar.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // ConsultarBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 399);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtCurpBeneficiario);
            this.Controls.Add(this.label1);
            this.Name = "ConsultarBeneficiario";
            this.Text = "Búsqueda beneficiario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.HopeTextBox txtCurpBeneficiario;
        private ReaLTaiizor.Controls.HopeButton btnConsultar;
        private ReaLTaiizor.Controls.HopeButton btnRegresar;
    }
}