using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace CloverCES
{
    public partial class wfMainMenu : Form
    {
        public wfMainMenu()
        {
            InitializeComponent();
        }
        private void wfMainMenu_Load(object sender, EventArgs e)
        {
            tssVersion.Text = "v 1.0.0.46";
            UsuarioLogica user = new UsuarioLogica();
            user.Usuario = Global.gsUsuario;
            if (!UsuarioLogica.VerificarAcceso(user))
            {
                MessageBox.Show("Usuario sin Acceso al Sistema", "CloverCES Daily Processing", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }

            DataTable data = UsuarioLogica.Consultar(user);
            Global.gsNivel = data.Rows[0]["puesto"].ToString();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void estacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wfAreas Areas = new wfAreas();
            Areas.ShowDialog();
        }

        private void plantasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.gsNivel != "AD")
                return;

            wfPlantas Plantas = new wfPlantas();
            Plantas.ShowDialog();
        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.gsNivel != "AD")
                return;

            wfConfig Conf = new wfConfig();
            Conf.Show();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            wfDashboard wfBoard = new wfDashboard();
            wfBoard.Show();
        }

        private void origenDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wfImportarDatos ImpoDt = new wfImportarDatos();
            ImpoDt.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void materialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.gsNivel == "CA")
                return;

            wfMateriales Mate = new wfMateriales();
            Mate.ShowDialog();
        }

        private void lineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wfLineas line = new wfLineas();
            line.Show();
        }

        private void usuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            wfUsuarios User = new wfUsuarios();
            User.Show();
        }

        private void metaDiariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wfReporteador RepMeta = new wfReporteador();
            RepMeta.ShowDialog();
        }
    }
}
