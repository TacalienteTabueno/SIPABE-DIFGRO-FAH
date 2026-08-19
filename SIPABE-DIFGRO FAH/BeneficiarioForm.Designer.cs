namespace SIPABE_DIFGRO_FAH
{
    partial class BeneficiarioForm
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
            this.SuspendLayout();
            // 
            // TxtCurp
            // 
            this.TxtCurp.Location = new System.Drawing.Point(36, 46);
            this.TxtCurp.Name = "TxtCurp";
            this.TxtCurp.Size = new System.Drawing.Size(214, 20);
            this.TxtCurp.TabIndex = 0;
            this.TxtCurp.TextChanged += new System.EventHandler(this.TxtCurp_TextChanged);
            // 
            // BeneficiarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtCurp);
            this.Name = "BeneficiarioForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BeneficiarioForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCurp;
    }
}