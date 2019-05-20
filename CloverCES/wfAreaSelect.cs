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
    public partial class wfAreaSelect : Form
    {
        public string _lsArea;
        public string _lsPlanta;
        public string _lsGlobal;
        public int int_lineaInicial;
        public int int_lineaFinal;
        public wfAreaSelect()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfAreaSelect_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfAreaSelect_Activated(object sender, EventArgs e)
        {
            cbbArea.Focus();
        }
        private void Inicio()
        {
            cbbPlanta.ResetText();
            DataTable data = PlantaLogica.Listar();
            cbbPlanta.DataSource = data;
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.DisplayMember = "nombre";
            cbbPlanta.SelectedIndex = -1;

            chbGlobal.Checked = true;

            cbbArea.Enabled = false;
            cbbArea.ResetText();
            DataTable dtArea = AreaLogica.Listar();
            cbbArea.DataSource = dtArea;
            cbbArea.ValueMember = "area";
            cbbArea.DisplayMember = "area";
            cbbArea.SelectedIndex = -1;

            cbbPlanta.Focus();
        }
       
        private void cbbPlanta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cbbArea.Enabled = true;
                AreaLogica area = new AreaLogica();
                area.Planta = cbbPlanta.SelectedValue.ToString();
                DataTable dt = AreaLogica.ListarPlanta(area);
                cbbArea.DataSource = dt;
                cbbArea.ValueMember = "area";
                cbbArea.DisplayMember = "area";
                cbbArea.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), "Error..." + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

      

        #region regSave
        private bool Valida()
        {
            bool bValida = false;

            if (string.IsNullOrEmpty(cbbArea.Text))
            {
                MessageBox.Show("No se a especificado la clave del Area", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbPlanta.Focus();
                return bValida;
            }

            if (string.IsNullOrEmpty(cbbPlanta.SelectedValue.ToString()))
            {
                MessageBox.Show("No se a especificado la Planta", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbPlanta.Focus();
                return bValida;
            }


           
            return true;
        }

       
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void cbbArea_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void wfAreaSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbbPlanta.SelectedIndex != -1)
                _lsPlanta = cbbPlanta.SelectedValue.ToString();

            if (cbbArea.SelectedIndex != -1)
                _lsArea = cbbArea.SelectedValue.ToString();

            if (chbGlobal.Checked)
                _lsGlobal = "1";
            else
                _lsGlobal = "0";

            if(numUpdDown_rangoInicial.Value> numUpdDown_rangoFinal.Value)
            {
                MessageBox.Show("El rango inicial no pude ser mayor que el rango final,porfavor verifique los rangos.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }


            int_lineaInicial = (int)numUpdDown_rangoInicial.Value;
            int_lineaFinal = (int)numUpdDown_rangoFinal.Value;
        }

        private void cbbPlanta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void chbox_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chbox_selectAll.Checked == true)
            {
                chbox_linean1.Checked = true;
                chbox_linean2.Checked = true;
                chbox_linean3.Checked = true;
                chbox_linean4.Checked = true;
            }
            else
            {
                chbox_linean1.Checked = false;
                chbox_linean2.Checked = false;
                chbox_linean3.Checked = false;
                chbox_linean4.Checked = false;
            }
        }
    }
}
