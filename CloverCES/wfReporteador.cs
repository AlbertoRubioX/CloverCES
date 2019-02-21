using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using Logica;

namespace CloverCES
{
    public partial class wfReporteador : Form
    {
        public wfReporteador()
        {
            InitializeComponent();
        }

        private void wfReporteador_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(@"\\mxni-fs-01\Temp\wrivera\agonz0\CloverCES\Reportes\CrystalReport2.rpt");

                
                DataTable dtSource = MetadiaLogica.Reporte();
                rptDoc.SetDataSource(dtSource);
                crystalReportViewer1.ReportSource = rptDoc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
            }
        }
    }
}
