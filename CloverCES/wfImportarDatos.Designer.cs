namespace CloverCES
{
    partial class wfImportarDatos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbPlanta = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbHora = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTurno = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwDatos = new System.Windows.Forms.DataGridView();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwDatadet = new System.Windows.Forms.DataGridView();
            this.btnReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatos)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatadet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbbPlanta);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbbHora);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbbTurno);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgwDatos);
            this.panel1.Controls.Add(this.btnImportar);
            this.panel1.Controls.Add(this.txtArchivo);
            this.panel1.Controls.Add(this.btnFile);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 526);
            this.panel1.TabIndex = 4;
            // 
            // cbbPlanta
            // 
            this.cbbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPlanta.FormattingEnabled = true;
            this.cbbPlanta.Location = new System.Drawing.Point(113, 66);
            this.cbbPlanta.Name = "cbbPlanta";
            this.cbbPlanta.Size = new System.Drawing.Size(98, 21);
            this.cbbPlanta.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Planta:";
            // 
            // cbbHora
            // 
            this.cbbHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHora.FormattingEnabled = true;
            this.cbbHora.Location = new System.Drawing.Point(377, 66);
            this.cbbHora.Name = "cbbHora";
            this.cbbHora.Size = new System.Drawing.Size(76, 21);
            this.cbbHora.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hora:";
            // 
            // cbbTurno
            // 
            this.cbbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTurno.FormattingEnabled = true;
            this.cbbTurno.Location = new System.Drawing.Point(267, 66);
            this.cbbTurno.Name = "cbbTurno";
            this.cbbTurno.Size = new System.Drawing.Size(48, 21);
            this.cbbTurno.TabIndex = 6;
            this.cbbTurno.SelectionChangeCommitted += new System.EventHandler(this.cbbTurno_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Turno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CESApp File:";
            // 
            // dgwDatos
            // 
            this.dgwDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDatos.Location = new System.Drawing.Point(20, 95);
            this.dgwDatos.Name = "dgwDatos";
            this.dgwDatos.Size = new System.Drawing.Size(51, 31);
            this.dgwDatos.TabIndex = 1;
            this.dgwDatos.Visible = false;
            // 
            // btnImportar
            // 
            this.btnImportar.BackgroundImage = global::CloverCES.Properties.Resources.print_preview;
            this.btnImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImportar.Enabled = false;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Location = new System.Drawing.Point(470, 61);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(39, 29);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Tag = "Cargar Datos";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Location = new System.Drawing.Point(113, 31);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.Size = new System.Drawing.Size(340, 20);
            this.txtArchivo.TabIndex = 3;
            // 
            // btnFile
            // 
            this.btnFile.BackgroundImage = global::CloverCES.Properties.Resources._1492140657_excel;
            this.btnFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFile.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFile.Location = new System.Drawing.Point(470, 26);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(39, 29);
            this.btnFile.TabIndex = 0;
            this.btnFile.Tag = "Importar Origen de datos";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 94);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwDatadet);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Location = new System.Drawing.Point(11, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 402);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            // 
            // dgwDatadet
            // 
            this.dgwDatadet.AllowUserToAddRows = false;
            this.dgwDatadet.AllowUserToDeleteRows = false;
            this.dgwDatadet.AllowUserToResizeColumns = false;
            this.dgwDatadet.AllowUserToResizeRows = false;
            this.dgwDatadet.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgwDatadet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwDatadet.Location = new System.Drawing.Point(9, 19);
            this.dgwDatadet.Name = "dgwDatadet";
            this.dgwDatadet.ReadOnly = true;
            this.dgwDatadet.RowHeadersVisible = false;
            this.dgwDatadet.Size = new System.Drawing.Size(524, 326);
            this.dgwDatadet.TabIndex = 10;
            this.dgwDatadet.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwDatadet_CellFormatting);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.Enabled = false;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = global::CloverCES.Properties.Resources.if_Save_48;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReport.Location = new System.Drawing.Point(176, 351);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(151, 45);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Guardar";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // wfImportarDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 546);
            this.Controls.Add(this.panel1);
            this.Name = "wfImportarDatos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Origen de Datos";
            this.Load += new System.EventHandler(this.wfImportarDatos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwDatadet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.DataGridView dgwDatos;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbHora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dgwDatadet;
        private System.Windows.Forms.ComboBox cbbPlanta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}