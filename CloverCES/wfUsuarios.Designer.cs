namespace CloverCES
{
    partial class wfUsuarios
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxOper = new System.Windows.Forms.GroupBox();
            this.cbbPuesto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwUsuarios = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.chbRamp = new System.Windows.Forms.CheckBox();
            this.txtRamp = new System.Windows.Forms.TextBox();
            this.cbbLinea = new System.Windows.Forms.ComboBox();
            this.cbbTurno = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbUsuario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbPlanta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxOper.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnNew,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(553, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::CloverCES.Properties.Resources.Save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Guardar";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = global::CloverCES.Properties.Resources.New;
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "Nuevo";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::CloverCES.Properties.Resources.Trash;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Borrar";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnClose.Image = global::CloverCES.Properties.Resources.Exit;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(23, 22);
            this.btnClose.Text = "Salir";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbbPuesto);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.cbbUsuario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.gbxOper);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 505);
            this.panel1.TabIndex = 1;
            // 
            // gbxOper
            // 
            this.gbxOper.Controls.Add(this.label5);
            this.gbxOper.Controls.Add(this.chbRamp);
            this.gbxOper.Controls.Add(this.txtRamp);
            this.gbxOper.Controls.Add(this.label4);
            this.gbxOper.Controls.Add(this.cbbLinea);
            this.gbxOper.Controls.Add(this.label2);
            this.gbxOper.Controls.Add(this.cbbTurno);
            this.gbxOper.Controls.Add(this.label1);
            this.gbxOper.Controls.Add(this.cbbPlanta);
            this.gbxOper.Location = new System.Drawing.Point(18, 51);
            this.gbxOper.Name = "gbxOper";
            this.gbxOper.Size = new System.Drawing.Size(494, 95);
            this.gbxOper.TabIndex = 7;
            this.gbxOper.TabStop = false;
            // 
            // cbbPuesto
            // 
            this.cbbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPuesto.FormattingEnabled = true;
            this.cbbPuesto.Location = new System.Drawing.Point(294, 24);
            this.cbbPuesto.Name = "cbbPuesto";
            this.cbbPuesto.Size = new System.Drawing.Size(184, 21);
            this.cbbPuesto.TabIndex = 1;
            this.cbbPuesto.SelectedValueChanged += new System.EventHandler(this.cbbPuesto_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(238, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Puesto:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwUsuarios);
            this.groupBox2.Location = new System.Drawing.Point(18, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 333);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // dgwUsuarios
            // 
            this.dgwUsuarios.AllowUserToAddRows = false;
            this.dgwUsuarios.AllowUserToResizeRows = false;
            this.dgwUsuarios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgwUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwUsuarios.Location = new System.Drawing.Point(6, 19);
            this.dgwUsuarios.Name = "dgwUsuarios";
            this.dgwUsuarios.ReadOnly = true;
            this.dgwUsuarios.RowHeadersVisible = false;
            this.dgwUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgwUsuarios.Size = new System.Drawing.Size(482, 299);
            this.dgwUsuarios.TabIndex = 0;
            this.dgwUsuarios.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwUsuarios_CellFormatting);
            this.dgwUsuarios.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwUsuarios_CellValueChanged);
            this.dgwUsuarios.SelectionChanged += new System.EventHandler(this.dgwUsuarios_SelectionChanged);
            this.dgwUsuarios.Click += new System.EventHandler(this.dgwUsuarios_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "%";
            // 
            // chbRamp
            // 
            this.chbRamp.AutoSize = true;
            this.chbRamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRamp.Location = new System.Drawing.Point(198, 65);
            this.chbRamp.Name = "chbRamp";
            this.chbRamp.Size = new System.Drawing.Size(76, 17);
            this.chbRamp.TabIndex = 3;
            this.chbRamp.Text = "Rampeo:";
            this.chbRamp.UseVisualStyleBackColor = true;
            this.chbRamp.CheckedChanged += new System.EventHandler(this.chbRamp_CheckedChanged);
            // 
            // txtRamp
            // 
            this.txtRamp.Location = new System.Drawing.Point(276, 64);
            this.txtRamp.MaxLength = 6;
            this.txtRamp.Name = "txtRamp";
            this.txtRamp.Size = new System.Drawing.Size(72, 20);
            this.txtRamp.TabIndex = 4;
            // 
            // cbbLinea
            // 
            this.cbbLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLinea.FormattingEnabled = true;
            this.cbbLinea.Location = new System.Drawing.Point(276, 24);
            this.cbbLinea.Name = "cbbLinea";
            this.cbbLinea.Size = new System.Drawing.Size(116, 21);
            this.cbbLinea.TabIndex = 1;
            // 
            // cbbTurno
            // 
            this.cbbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTurno.FormattingEnabled = true;
            this.cbbTurno.Location = new System.Drawing.Point(65, 59);
            this.cbbTurno.Name = "cbbTurno";
            this.cbbTurno.Size = new System.Drawing.Size(81, 21);
            this.cbbTurno.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Turno:";
            // 
            // cbbUsuario
            // 
            this.cbbUsuario.FormattingEnabled = true;
            this.cbbUsuario.Location = new System.Drawing.Point(83, 24);
            this.cbbUsuario.Name = "cbbUsuario";
            this.cbbUsuario.Size = new System.Drawing.Size(121, 21);
            this.cbbUsuario.TabIndex = 0;
            this.cbbUsuario.SelectionChangeCommitted += new System.EventHandler(this.cbbArea_SelectionChangeCommitted);
            this.cbbUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbArea_KeyDown);
            this.cbbUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbArea_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(228, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Linea:";
            // 
            // cbbPlanta
            // 
            this.cbbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPlanta.FormattingEnabled = true;
            this.cbbPlanta.Location = new System.Drawing.Point(65, 24);
            this.cbbPlanta.Name = "cbbPlanta";
            this.cbbPlanta.Size = new System.Drawing.Size(121, 21);
            this.cbbPlanta.TabIndex = 0;
            this.cbbPlanta.SelectionChangeCommitted += new System.EventHandler(this.cbbPlanta_SelectionChangeCommitted);
            this.cbbPlanta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbPlanta_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Planta:";
            // 
            // wfUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 545);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "wfUsuarios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Católogo de Usuarios";
            this.Activated += new System.EventHandler(this.wfUsuarios_Activated);
            this.Load += new System.EventHandler(this.wfUsuarios_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxOper.ResumeLayout(false);
            this.gbxOper.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbPlanta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbLinea;
        private System.Windows.Forms.ComboBox cbbTurno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRamp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbRamp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgwUsuarios;
        private System.Windows.Forms.GroupBox gbxOper;
        private System.Windows.Forms.ComboBox cbbPuesto;
        private System.Windows.Forms.Label label6;
    }
}