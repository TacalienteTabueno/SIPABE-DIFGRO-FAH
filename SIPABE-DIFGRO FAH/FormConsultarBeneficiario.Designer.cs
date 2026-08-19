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
            this.txtCurpBeneficiario.Location = new System.Drawing.Point(144, 189);
            this.txtCurpBeneficiario.Name = "txtCurpBeneficiario";
            this.txtCurpBeneficiario.Size = new System.Drawing.Size(527, 40);
            this.txtCurpBeneficiario.TabIndex = 1;
            this.txtCurpBeneficiario.TextChanged += new System.EventHandler(this.txtCurpBeneficiario_TextChanged);
            this.txtCurpBeneficiario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurpBeneficiario_KeyDown);
            this.txtCurpBeneficiario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurpBeneficiario_KeyPress);
            // 
            // FormConsultarBeneficiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCurpBeneficiario);
            this.Controls.Add(this.label1);
            this.Name = "FormConsultarBeneficiario";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCurpBeneficiario;
    }
}