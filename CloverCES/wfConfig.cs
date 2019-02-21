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
    public partial class wfConfig : Form
    {
        private string _lsNomAnt;
        private bool _lbCambioDet;
        public wfConfig()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfConfig_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfConfig_Activated(object sender, EventArgs e)
        {
            txtRotMin.Focus();
        }
        private void Inicio()
        {
            DataTable dtConf = ConfigLogica.Consultar();
            txtURL.Text = dtConf.Rows[0]["ruta_laser"].ToString();
            txtFile.Text = dtConf.Rows[0]["laser_file"].ToString();
            txtRotMin.Text = dtConf.Rows[0]["rotacion_min"].ToString();
            txtMargW.Text = dtConf.Rows[0]["margen_w"].ToString();
            txtMargH.Text = dtConf.Rows[0]["margen_h"].ToString();
            txtPadX.Text = dtConf.Rows[0]["padding_x"].ToString();
            txtPadY.Text = dtConf.Rows[0]["padding_y"].ToString();
            txtMargW1.Text = dtConf.Rows[0]["margen_w1"].ToString();
            txtMargH1.Text = dtConf.Rows[0]["margen_h1"].ToString();
            txtPorcStd.Text = dtConf.Rows[0]["porc_std"].ToString();
            txtRotMin.Focus();

        }
       
        #endregion    

        #region regSave
        private bool Valida()
        {
            bool bValida = false;

            if(string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("El URL no puede estar vacio", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtURL.Focus();
                return bValida;
            }

            if (string.IsNullOrEmpty(txtFile.Text))
            {
                MessageBox.Show("El Archivo no puede estar vacio", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtFile.Focus();
                return bValida;
            }

            double dVal = 0;
            if (!double.TryParse(txtRotMin.Text, out dVal))
            {
                MessageBox.Show("Favor de indicar una rotación valida", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtRotMin.Focus();
                return bValida;
            }

            if (!double.TryParse(txtPorcStd.Text, out dVal))
            {
                MessageBox.Show("Favor de indicar el Porcentaje Estandar", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPorcStd.Focus();
                return bValida;
            }
            else
            {
                if(dVal <= 0)
                {
                    MessageBox.Show("Favor de indicar el Porcentaje Estandar", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPorcStd.Focus();
                    return bValida;
                }
            }

            return true;
        }

        private bool Guardar()
        {
            try
            {
                if (!Valida())
                    return false;

                ConfigLogica conf = new ConfigLogica();
                conf.Ruta = txtURL.Text.ToString();
                conf.Laser = txtFile.Text.ToString();
                conf.RotMin = double.Parse(txtRotMin.Text);
                conf.MargenW = double.Parse(txtMargW.Text);
                conf.MargenH = double.Parse(txtMargH.Text);
                conf.PaddingX = double.Parse(txtPadX.Text);
                conf.PaddingY = double.Parse(txtPadY.Text);
                conf.MargenW1 = double.Parse(txtMargW1.Text);
                conf.MargenH1 = double.Parse(txtMargH1.Text);
                conf.PorcStd = double.Parse(txtPorcStd.Text);

                if (ConfigLogica.Guardar(conf) == 0)
                {
                    MessageBox.Show("Error al intentar guardar", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + "EstacionLogica.Guardar(mod)" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Guardar())
                Close();
            else
                Inicio();

        }

        private void txtRotMin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }
}
