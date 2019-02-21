namespace CloverCES
{
    partial class wfLineas
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
            this.btnRemove = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbArea = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cbbPlanta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbMaterial = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgwLineasRemove = new System.Windows.Forms.DataGridView();
            this.dgwTurno1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgwTurno2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbLinea = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwLineasRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTurno1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTurno2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.btnNew,
            this.btnRemove,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 25);
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
            this.btnSave.Tag = "";
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
            this.btnNew.Tag = "";
            this.btnNew.Text = "Nuevo";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemove.Image = global::CloverCES.Properties.Resources.remove_line;
            this.btnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(23, 22);
            this.btnRemove.Tag = "";
            this.btnRemove.Text = "Eliminar";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::CloverCES.Properties.Resources.Trash;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Tag = "";
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
            this.panel1.Controls.Add(this.cbbArea);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.cbbPlanta);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbbMaterial);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbbLinea);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 453);
            this.panel1.TabIndex = 1;
            // 
            // cbbArea
            // 
            this.cbbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbArea.FormattingEnabled = true;
            this.cbbArea.Location = new System.Drawing.Point(315, 67);
            this.cbbArea.Name = "cbbArea";
            this.cbbArea.Size = new System.Drawing.Size(80, 21);
            this.cbbArea.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Area:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(178, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // cbbPlanta
            // 
            this.cbbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPlanta.FormattingEnabled = true;
            this.cbbPlanta.Location = new System.Drawing.Point(79, 67);
            this.cbbPlanta.Name = "cbbPlanta";
            this.cbbPlanta.Size = new System.Drawing.Size(122, 21);
            this.cbbPlanta.TabIndex = 2;
            this.cbbPlanta.SelectionChangeCommitted += new System.EventHandler(this.cbbPlanta_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Planta:";
            // 
            // cbbMaterial
            // 
            this.cbbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaterial.FormattingEnabled = true;
            this.cbbMaterial.Location = new System.Drawing.Point(79, 101);
            this.cbbMaterial.Name = "cbbMaterial";
            this.cbbMaterial.Size = new System.Drawing.Size(121, 21);
            this.cbbMaterial.TabIndex = 4;
            this.cbbMaterial.SelectionChangeCommitted += new System.EventHandler(this.cbbMaterial_SelectionChangeCommitted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 143);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(386, 290);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgwLineasRemove);
            this.tabPage1.Controls.Add(this.dgwTurno1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(378, 264);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Turno 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgwLineasRemove
            // 
            this.dgwLineasRemove.AllowUserToAddRows = false;
            this.dgwLineasRemove.AllowUserToDeleteRows = false;
            this.dgwLineasRemove.AllowUserToResizeColumns = false;
            this.dgwLineasRemove.AllowUserToResizeRows = false;
            this.dgwLineasRemove.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwLineasRemove.Location = new System.Drawing.Point(50, 26);
            this.dgwLineasRemove.Name = "dgwLineasRemove";
            this.dgwLineasRemove.Size = new System.Drawing.Size(240, 150);
            this.dgwLineasRemove.TabIndex = 1;
            this.dgwLineasRemove.Visible = false;
            // 
            // dgwTurno1
            // 
            this.dgwTurno1.AllowUserToDeleteRows = false;
            this.dgwTurno1.AllowUserToResizeColumns = false;
            this.dgwTurno1.AllowUserToResizeRows = false;
            this.dgwTurno1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgwTurno1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTurno1.Location = new System.Drawing.Point(6, 6);
            this.dgwTurno1.MultiSelect = false;
            this.dgwTurno1.Name = "dgwTurno1";
            this.dgwTurno1.RowHeadersWidth = 25;
            this.dgwTurno1.RowTemplate.Height = 18;
            this.dgwTurno1.Size = new System.Drawing.Size(369, 252);
            this.dgwTurno1.TabIndex = 0;
            this.dgwTurno1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwLineas_CellFormatting);
            this.dgwTurno1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwLineas_CellValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgwTurno2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(378, 264);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Turno 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgwTurno2
            // 
            this.dgwTurno2.AllowUserToDeleteRows = false;
            this.dgwTurno2.AllowUserToResizeColumns = false;
            this.dgwTurno2.AllowUserToResizeRows = false;
            this.dgwTurno2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgwTurno2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTurno2.Location = new System.Drawing.Point(5, 6);
            this.dgwTurno2.MultiSelect = false;
            this.dgwTurno2.Name = "dgwTurno2";
            this.dgwTurno2.RowHeadersWidth = 25;
            this.dgwTurno2.RowTemplate.Height = 18;
            this.dgwTurno2.Size = new System.Drawing.Size(369, 252);
            this.dgwTurno2.TabIndex = 1;
            this.dgwTurno2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwTurno2_CellFormatting);
            this.dgwTurno2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwTurno2_CellValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Material:";
            // 
            // cbbLinea
            // 
            this.cbbLinea.FormattingEnabled = true;
            this.cbbLinea.Location = new System.Drawing.Point(79, 25);
            this.cbbLinea.Name = "cbbLinea";
            this.cbbLinea.Size = new System.Drawing.Size(93, 21);
            this.cbbLinea.TabIndex = 0;
            this.cbbLinea.SelectionChangeCommitted += new System.EventHandler(this.cbbLinea_SelectionChangeCommitted);
            this.cbbLinea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbLinea_KeyDown);
            this.cbbLinea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbLinea_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Linea:";
            // 
            // wfLineas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "wfLineas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Lineas";
            this.Activated += new System.EventHandler(this.wfLineas_Activated);
            this.Load += new System.EventHandler(this.wfLineas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwLineasRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTurno1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTurno2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnRemove;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgwTurno1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbLinea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgwLineasRemove;
        private System.Windows.Forms.ComboBox cbbMaterial;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgwTurno2;
        private System.Windows.Forms.ComboBox cbbArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cbbPlanta;
        private System.Windows.Forms.Label label3;
    }
}