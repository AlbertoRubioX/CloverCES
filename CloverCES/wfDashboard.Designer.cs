namespace CloverCES
{
    partial class wfDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chtBarras1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chtPastel = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblHora = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnConf = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtBarras1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtPastel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(186)))), ((int)(((byte)(191)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chtBarras1);
            this.panel1.Controls.Add(this.chtPastel);
            this.panel1.Location = new System.Drawing.Point(41, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 368);
            this.panel1.TabIndex = 0;
            // 
            // chtBarras1
            // 
            this.chtBarras1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chtBarras1.BorderlineColor = System.Drawing.Color.Black;
            this.chtBarras1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.Empty;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Cyan;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DeepSkyBlue;
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.Maroon;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.Name = "ChartArea1";
            this.chtBarras1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.chtBarras1.Legends.Add(legend1);
            this.chtBarras1.Location = new System.Drawing.Point(14, 14);
            this.chtBarras1.Name = "chtBarras1";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=LightToDark, LabelStyle=Top";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.Cyan;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Series1";
            this.chtBarras1.Series.Add(series1);
            this.chtBarras1.Size = new System.Drawing.Size(806, 338);
            this.chtBarras1.TabIndex = 0;
            this.chtBarras1.Text = "chart1";
            // 
            // chtPastel
            // 
            this.chtPastel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chtPastel.BorderlineColor = System.Drawing.Color.Black;
            this.chtPastel.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chtPastel.BorderSkin.BorderWidth = 2;
            chartArea2.Area3DStyle.Enable3D = true;
            chartArea2.Area3DStyle.Inclination = 40;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Cyan;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DeepSkyBlue;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chtPastel.ChartAreas.Add(chartArea2);
            this.chtPastel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleForeColor = System.Drawing.Color.White;
            legend2.TitleSeparatorColor = System.Drawing.Color.White;
            this.chtPastel.Legends.Add(legend2);
            this.chtPastel.Location = new System.Drawing.Point(14, 14);
            this.chtPastel.Name = "chtPastel";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.CustomProperties = "PieLineColor=LightGray, PieDrawingStyle=SoftEdge, LabelsHorizontalLineSize=2, Pie" +
    "LabelStyle=Outside, LabelsRadialLineSize=0";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.Transparent;
            series2.LabelForeColor = System.Drawing.Color.DarkTurquoise;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series2.SmartLabelStyle.CalloutLineWidth = 2;
            this.chtPastel.Series.Add(series2);
            this.chtPastel.Size = new System.Drawing.Size(806, 338);
            this.chtPastel.TabIndex = 1;
            this.chtPastel.Text = "chart1";
            this.chtPastel.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.BackColor = System.Drawing.Color.Transparent;
            this.lblHora.Font = new System.Drawing.Font("Calibri", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(673, 479);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(174, 37);
            this.lblHora.TabIndex = 1;
            this.lblHora.Text = "00:00:00 AM";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::CloverCES.Properties.Resources.if_arrow_back_outline_216436;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(7, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(44, 32);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::CloverCES.Properties.Resources.if_delete_216170;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(880, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 32);
            this.btnClose.TabIndex = 3;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConf
            // 
            this.btnConf.BackColor = System.Drawing.Color.Transparent;
            this.btnConf.BackgroundImage = global::CloverCES.Properties.Resources.if_Configuration_2_01_1976057;
            this.btnConf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConf.FlatAppearance.BorderSize = 0;
            this.btnConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConf.Location = new System.Drawing.Point(880, 492);
            this.btnConf.Name = "btnConf";
            this.btnConf.Size = new System.Drawing.Size(44, 32);
            this.btnConf.TabIndex = 4;
            this.btnConf.UseVisualStyleBackColor = false;
            this.btnConf.Click += new System.EventHandler(this.btnConf_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 10000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // wfDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CloverCES.Properties.Resources.CES_LASER;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(923, 527);
            this.ControlBox = false;
            this.Controls.Add(this.btnConf);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.panel1);
            this.Name = "wfDashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wfDashboard_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.wfDashboard_FormClosed);
            this.Load += new System.EventHandler(this.wfDashboard_Load);
            this.Resize += new System.EventHandler(this.wfDashboard_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtBarras1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtPastel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtBarras1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtPastel;
        private System.Windows.Forms.Button btnConf;
        private System.Windows.Forms.Timer timer3;
    }
}