namespace SIPABE_DIFGRO_FAH
{
    partial class FormConsultarBeneficiario
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
            this.txtCurpBeneficiario = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(722, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "ESCANEE LA CURP DEL BENEFICIARIO";
            // 
            // txtCurpBeneficiario
            // 
            this.txtCurpBeneficiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurpBeneficiario.Location = new System.Drawing.Point(150, 180);
            this.txtCurpBeneficiario.Name = "txtCurpBeneficiario";
            this.txtCurpBeneficiario.Size = new System.Drawing.Size(527, 40);
            this.txtCurpBeneficiario.TabIndex = 1;
            this.txtCurpBeneficiario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurpBeneficiario.TextChanged += new System.EventHandler(this.txtCurpBeneficiario_TextChanged);
            this.txtCurpBeneficiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurpBeneficiario_KeyPress);
            this.txtCurpBeneficiario.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCurpBeneficiario_PreviewKeyDown);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(161, 281);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(145, 67);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "CONSULTAR";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(463, 285);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(196, 62);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "REGRESAR";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // FormConsultarBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.txtCurpBeneficiario);
            this.Controls.Add(this.label1);
            this.Name = "FormConsultarBeneficiario";
            this.Text = "Búsqueda beneficiario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurpBeneficiario;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnRegresar;
    }
}