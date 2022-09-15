namespace Prueba
{
    partial class MenuInicio
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
            this.btnABMSocios = new System.Windows.Forms.Button();
            this.btnPagosSocios = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnABMSocios
            // 
            this.btnABMSocios.Location = new System.Drawing.Point(82, 115);
            this.btnABMSocios.Name = "btnABMSocios";
            this.btnABMSocios.Size = new System.Drawing.Size(121, 23);
            this.btnABMSocios.TabIndex = 0;
            this.btnABMSocios.Text = "ABM Socios";
            this.btnABMSocios.UseVisualStyleBackColor = true;
            this.btnABMSocios.Click += new System.EventHandler(this.btnABMSocios_Click);
            // 
            // btnPagosSocios
            // 
            this.btnPagosSocios.Location = new System.Drawing.Point(82, 162);
            this.btnPagosSocios.Name = "btnPagosSocios";
            this.btnPagosSocios.Size = new System.Drawing.Size(121, 23);
            this.btnPagosSocios.TabIndex = 1;
            this.btnPagosSocios.Text = "Pagos Socios";
            this.btnPagosSocios.UseVisualStyleBackColor = true;
            this.btnPagosSocios.Click += new System.EventHandler(this.btnPagosSocios_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido. Seleccione una opción para ingresar:";
            // 
            // MenuInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPagosSocios);
            this.Controls.Add(this.btnABMSocios);
            this.Name = "MenuInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú principal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnABMSocios;
        private System.Windows.Forms.Button btnPagosSocios;
        private System.Windows.Forms.Label label1;
    }
}