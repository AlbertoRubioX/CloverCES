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
    public partial class wfAreas : Form
    {
        private string _lsNomAnt;
        private bool _lbCambioDet;
        public wfAreas()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfAreas_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfAreas_Activated(object sender, EventArgs e)
        {
            cbbArea.Focus();
        }
        private void Inicio()
        {
            cbbArea.ResetText();
            DataTable dtArea = AreaLogica.Listar();
            cbbArea.DataSource = dtArea;
            cbbArea.ValueMember = "area";
            cbbArea.DisplayMember = "area";
            cbbArea.SelectedIndex = -1;

            cbbPlanta.ResetText();
            DataTable data = PlantaLogica.Listar();
            cbbPlanta.DataSource = data;
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.DisplayMember = "nombre";
            cbbPlanta.SelectedIndex = -1;
            txtNombre.Clear();
            chbGlobal.Checked = false;

            cbbArea.Focus();
        }
       

        private void cbbPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void cbbPlanta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
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

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("No se a especificado la Estación", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return bValida;
            }

           
            return true;
        }

        private bool Guardar()
        {
            try
            {
                if (!Valida())
                    return false;

                AreaLogica area = new AreaLogica();
                area.Area = cbbArea.Text.ToString().ToUpper();
                area.Planta = cbbPlanta.SelectedValue.ToString();
                area.Estacion = txtNombre.Text.ToString();
                if (chbGlobal.Checked)
                    area.Global = "1";
                else
                    area.Global = "0";

                if (AreaLogica.Guardar(area) == 0)
                {
                    MessageBox.Show("Error al intentar guardar el Area", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Inicio();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Guardar())
                Close();
            else
                Inicio();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbbPlanta.SelectedIndex == -1)
                return;

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbArea.SelectedIndex == -1)
                return;

            
            DialogResult Result = MessageBox.Show("Desea borrar el Area?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    AreaLogica area = new AreaLogica();
                    area.Area = cbbArea.SelectedValue.ToString();

                    
                    if (AreaLogica.Eliminar(area))
                    {
                        MessageBox.Show("El Area ha sido borrada", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Inicio();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
        }

        private void cbbArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbArea.Text.Length >= 9)
                e.Handled = true;
        }

        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbbArea.Text))
                    return;

                AreaLogica area = new AreaLogica();
                area.Area = cbbArea.Text.ToString().ToUpper();
                DataTable datos =AreaLogica.Consultar(area);
                if (datos.Rows.Count != 0)
                {
                    cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();
                    txtNombre.Text = datos.Rows[0]["estacion"].ToString();
                    if (datos.Rows[0]["ind_global"].ToString() == "1")
                        chbGlobal.Checked = true;
                    else
                        chbGlobal.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbbArea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                    Close();

                if (e.KeyCode != Keys.Enter)
                    return;

                if (string.IsNullOrEmpty(cbbArea.Text))
                    return;

                AreaLogica area = new AreaLogica();
                area.Area = cbbArea.Text.ToString().ToUpper();
                DataTable datos = AreaLogica.Consultar(area);
                if (datos.Rows.Count != 0)
                {
                    cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();
                    txtNombre.Text = datos.Rows[0]["estacion"].ToString();
                    if (datos.Rows[0]["ind_global"].ToString() == "1")
                        chbGlobal.Checked = true;
                    else
                        chbGlobal.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
