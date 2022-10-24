namespace _3CapaYerko3A
{
    partial class FormVerAdministradores
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
            this.btnDescargarPdf = new System.Windows.Forms.Button();
            this.dataAdministradores = new System.Windows.Forms.DataGridView();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelecionarCargos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdministradores)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDescargarPdf
            // 
            this.btnDescargarPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(61)))), ((int)(((byte)(64)))));
            this.btnDescargarPdf.FlatAppearance.BorderSize = 0;
            this.btnDescargarPdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(90)))), ((int)(((byte)(115)))));
            this.btnDescargarPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDescargarPdf.Location = new System.Drawing.Point(14, 116);
            this.btnDescargarPdf.Name = "btnDescargarPdf";
            this.btnDescargarPdf.Size = new System.Drawing.Size(201, 34);
            this.btnDescargarPdf.TabIndex = 25;
            this.btnDescargarPdf.Text = "Descargar pdf";
            this.btnDescargarPdf.UseVisualStyleBackColor = false;
            this.btnDescargarPdf.Click += new System.EventHandler(this.btnDescargarPdf_Click);
            // 
            // dataAdministradores
            // 
            this.dataAdministradores.AllowUserToAddRows = false;
            this.dataAdministradores.AllowUserToDeleteRows = false;
            this.dataAdministradores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataAdministradores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdministradores.Location = new System.Drawing.Point(14, 156);
            this.dataAdministradores.Name = "dataAdministradores";
            this.dataAdministradores.ReadOnly = true;
            this.dataAdministradores.Size = new System.Drawing.Size(789, 221);
            this.dataAdministradores.TabIndex = 24;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(455, 79);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(56, 17);
            this.lblCargo.TabIndex = 23;
            this.lblCargo.Text = "Cargo: ";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(11, 79);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(66, 17);
            this.lblUsuario.TabIndex = 22;
            this.lblUsuario.Text = "Usuario: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(196, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Usuarios Registrados";
            // 
            // cbSelecionarCargos
            // 
            this.cbSelecionarCargos.FormattingEnabled = true;
            this.cbSelecionarCargos.Location = new System.Drawing.Point(451, 116);
            this.cbSelecionarCargos.Name = "cbSelecionarCargos";
            this.cbSelecionarCargos.Size = new System.Drawing.Size(219, 30);
            this.cbSelecionarCargos.TabIndex = 26;
            this.cbSelecionarCargos.SelectedIndexChanged += new System.EventHandler(this.cbSelecionarCargos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(255, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 22);
            this.label2.TabIndex = 27;
            this.label2.Text = "Seleccione cargos:";
            // 
            // FormVerAdministradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(38)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(818, 402);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSelecionarCargos);
            this.Controls.Add(this.btnDescargarPdf);
            this.Controls.Add(this.dataAdministradores);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.Name = "FormVerAdministradores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVerAdministradores";
            this.Load += new System.EventHandler(this.FormVerAdministradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAdministradores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDescargarPdf;
        private System.Windows.Forms.DataGridView dataAdministradores;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSelecionarCargos;
        private System.Windows.Forms.Label label2;
    }
}