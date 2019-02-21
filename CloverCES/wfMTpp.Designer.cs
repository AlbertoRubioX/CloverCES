namespace CloverCES
{
    partial class wfMTpp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wfMTpp));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPorc = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPorc);
            this.panel1.Controls.Add(this.btnMT);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(30, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 232);
            this.panel1.TabIndex = 2;
            // 
            // btnPorc
            // 
            this.btnPorc.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            this.btnPorc.FlatAppearance.BorderSize = 2;
            this.btnPorc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPorc.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnPorc.Location = new System.Drawing.Point(3, 55);
            this.btnPorc.Name = "btnPorc";
            this.btnPorc.Size = new System.Drawing.Size(216, 87);
            this.btnPorc.TabIndex = 3;
            this.btnPorc.Text = "%";
            this.btnPorc.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(21, 173);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(183, 33);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Tag = "MT01";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(3, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(216, 79);
            this.panel2.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Productivity";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnMin
            // 
            this.btnMin.BackgroundImage = global::CloverCES.Properties.Resources.if_minimize_82798;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Location = new System.Drawing.Point(212, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(42, 22);
            this.btnMin.TabIndex = 3;
            this.btnMin.Tag = "Minimizar";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMT
            // 
            this.btnMT.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnMT.FlatAppearance.BorderSize = 2;
            this.btnMT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMT.ForeColor = System.Drawing.Color.PaleGreen;
            this.btnMT.Location = new System.Drawing.Point(3, 3);
            this.btnMT.Name = "btnMT";
            this.btnMT.Size = new System.Drawing.Size(216, 46);
            this.btnMT.TabIndex = 1;
            this.btnMT.Text = "MT00";
            this.btnMT.UseVisualStyleBackColor = true;
            // 
            // wfMTpp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(278, 317);
            this.ControlBox = false;
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "wfMTpp";
            this.Opacity = 0.88D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.wfMTpp_Load);
            this.Resize += new System.EventHandler(this.wfMTpp_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMT;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnPorc;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        protected System.Windows.Forms.Timer timer1;
    }
}

