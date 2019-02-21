namespace CloverCES
{
    partial class wfAreaSelect
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
            this.chbGlobal = new System.Windows.Forms.CheckBox();
            this.cbbArea = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbPlanta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chbGlobal);
            this.panel1.Controls.Add(this.cbbArea);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbbPlanta);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 166);
            this.panel1.TabIndex = 1;
            // 
            // chbGlobal
            // 
            this.chbGlobal.AutoSize = true;
            this.chbGlobal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbGlobal.Location = new System.Drawing.Point(22, 77);
            this.chbGlobal.Name = "chbGlobal";
            this.chbGlobal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbGlobal.Size = new System.Drawing.Size(145, 24);
            this.chbGlobal.TabIndex = 1;
            this.chbGlobal.Text = "Monitor Global";
            this.chbGlobal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chbGlobal.UseVisualStyleBackColor = true;
            // 
            // cbbArea
            // 
            this.cbbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbArea.FormattingEnabled = true;
            this.cbbArea.Location = new System.Drawing.Point(89, 118);
            this.cbbArea.Name = "cbbArea";
            this.cbbArea.Size = new System.Drawing.Size(121, 28);
            this.cbbArea.TabIndex = 2;
            this.cbbArea.SelectionChangeCommitted += new System.EventHandler(this.cbbArea_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Area:";
            // 
            // cbbPlanta
            // 
            this.cbbPlanta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPlanta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPlanta.FormattingEnabled = true;
            this.cbbPlanta.Location = new System.Drawing.Point(89, 24);
            this.cbbPlanta.Name = "cbbPlanta";
            this.cbbPlanta.Size = new System.Drawing.Size(121, 28);
            this.cbbPlanta.TabIndex = 0;
            this.cbbPlanta.SelectionChangeCommitted += new System.EventHandler(this.cbbPlanta_SelectionChangeCommitted);
            this.cbbPlanta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbPlanta_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Planta:";
            // 
            // wfAreaSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(292, 190);
            this.Controls.Add(this.panel1);
            this.Name = "wfAreaSelect";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar el Area";
            this.Activated += new System.EventHandler(this.wfAreaSelect_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wfAreaSelect_FormClosing);
            this.Load += new System.EventHandler(this.wfAreaSelect_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbPlanta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbGlobal;
    }
}