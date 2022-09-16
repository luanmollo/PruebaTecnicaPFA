namespace Prueba
{
    partial class frmPagosSocios
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
            this.dgvPagosSocios = new System.Windows.Forms.DataGridView();
            this.lblPagosRealizadosMes = new System.Windows.Forms.Label();
            this.lblSocio = new System.Windows.Forms.Label();
            this.txtSocio = new System.Windows.Forms.TextBox();
            this.txtPagosRealizadosMes = new System.Windows.Forms.TextBox();
            this.btnVerPagosSocio = new System.Windows.Forms.Button();
            this.btnVolverMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPagosSocios
            // 
            this.dgvPagosSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagosSocios.Location = new System.Drawing.Point(50, 23);
            this.dgvPagosSocios.Name = "dgvPagosSocios";
            this.dgvPagosSocios.ReadOnly = true;
            this.dgvPagosSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagosSocios.Size = new System.Drawing.Size(467, 244);
            this.dgvPagosSocios.TabIndex = 0;
            this.dgvPagosSocios.SelectionChanged += new System.EventHandler(this.dgvPagosSocios_SelectionChanged);
            // 
            // lblPagosRealizadosMes
            // 
            this.lblPagosRealizadosMes.AutoSize = true;
            this.lblPagosRealizadosMes.Location = new System.Drawing.Point(50, 338);
            this.lblPagosRealizadosMes.Name = "lblPagosRealizadosMes";
            this.lblPagosRealizadosMes.Size = new System.Drawing.Size(168, 13);
            this.lblPagosRealizadosMes.TabIndex = 1;
            this.lblPagosRealizadosMes.Text = "Pagos realizados en el último mes:";
            // 
            // lblSocio
            // 
            this.lblSocio.AutoSize = true;
            this.lblSocio.Location = new System.Drawing.Point(50, 301);
            this.lblSocio.Name = "lblSocio";
            this.lblSocio.Size = new System.Drawing.Size(37, 13);
            this.lblSocio.TabIndex = 2;
            this.lblSocio.Text = "Socio:";
            // 
            // txtSocio
            // 
            this.txtSocio.Location = new System.Drawing.Point(272, 294);
            this.txtSocio.Name = "txtSocio";
            this.txtSocio.ReadOnly = true;
            this.txtSocio.Size = new System.Drawing.Size(100, 20);
            this.txtSocio.TabIndex = 3;
            // 
            // txtPagosRealizadosMes
            // 
            this.txtPagosRealizadosMes.Location = new System.Drawing.Point(272, 331);
            this.txtPagosRealizadosMes.Name = "txtPagosRealizadosMes";
            this.txtPagosRealizadosMes.ReadOnly = true;
            this.txtPagosRealizadosMes.Size = new System.Drawing.Size(100, 20);
            this.txtPagosRealizadosMes.TabIndex = 4;
            // 
            // btnVerPagosSocio
            // 
            this.btnVerPagosSocio.Location = new System.Drawing.Point(50, 375);
            this.btnVerPagosSocio.Name = "btnVerPagosSocio";
            this.btnVerPagosSocio.Size = new System.Drawing.Size(174, 23);
            this.btnVerPagosSocio.TabIndex = 5;
            this.btnVerPagosSocio.Text = "Ver todos los pagos del socio";
            this.btnVerPagosSocio.UseVisualStyleBackColor = true;
            this.btnVerPagosSocio.Click += new System.EventHandler(this.btnVerPagosSocio_Click);
            // 
            // btnVolverMenu
            // 
            this.btnVolverMenu.Location = new System.Drawing.Point(413, 375);
            this.btnVolverMenu.Name = "btnVolverMenu";
            this.btnVolverMenu.Size = new System.Drawing.Size(104, 23);
            this.btnVolverMenu.TabIndex = 17;
            this.btnVolverMenu.Text = "Volver al Menú";
            this.btnVolverMenu.UseVisualStyleBackColor = true;
            this.btnVolverMenu.Click += new System.EventHandler(this.btnVolverMenu_Click);
            // 
            // frmPagosSocios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.btnVolverMenu);
            this.Controls.Add(this.btnVerPagosSocio);
            this.Controls.Add(this.txtPagosRealizadosMes);
            this.Controls.Add(this.txtSocio);
            this.Controls.Add(this.lblSocio);
            this.Controls.Add(this.lblPagosRealizadosMes);
            this.Controls.Add(this.dgvPagosSocios);
            this.Name = "frmPagosSocios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos de Socios";
            this.Load += new System.EventHandler(this.frmPagosSocios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagosSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPagosSocios;
        private System.Windows.Forms.Label lblPagosRealizadosMes;
        private System.Windows.Forms.Label lblSocio;
        private System.Windows.Forms.TextBox txtSocio;
        private System.Windows.Forms.TextBox txtPagosRealizadosMes;
        private System.Windows.Forms.Button btnVerPagosSocio;
        private System.Windows.Forms.Button btnVolverMenu;
    }
}