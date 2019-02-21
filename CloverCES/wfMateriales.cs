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
    public partial class wfMateriales : Form
    {
        private string _lsNomAnt;
        private bool _lbCambioDet;
        public wfMateriales()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfMateriales_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfMateriales_Activated(object sender, EventArgs e)
        {
            cbbMaterial.Focus();
        }
        private void Inicio()
        {
            cbbMaterial.ResetText();
            DataTable dtmate = MaterialLogica.Listar();
            cbbMaterial.DataSource = dtmate;
            cbbMaterial.ValueMember = "material";
            cbbMaterial.DisplayMember = "material";
            cbbMaterial.SelectedIndex = -1;

            txtNombre.Clear();
            txtEstd.Clear();

            cbbMaterial.Focus();
        }
       
        #endregion

      

        #region regSave
        private bool Valida()
        {
            bool bValida = false;

            if (string.IsNullOrEmpty(cbbMaterial.Text))
            {
                cbbMaterial.Focus();
                return bValida;
            }

            
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("No se a especificado el nombre", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return bValida;
            }

            if (string.IsNullOrEmpty(txtEstd.Text) || string.IsNullOrWhiteSpace(txtEstd.Text))
            {
                MessageBox.Show("No se a especificado el estandar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEstd.Focus();
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

                MaterialLogica mate = new MaterialLogica();
                mate.Material = cbbMaterial.Text.ToString().ToUpper();
                mate.Nombre = txtNombre.Text.ToString();
                double dEstd = 0;
                if (double.TryParse(txtEstd.Text, out dEstd))
                    mate.Estandar = dEstd;
                else
                    mate.Estandar = 0;
                
                if (MaterialLogica.Guardar(mate) == 0)
                {
                    MessageBox.Show("Error al intentar guardar el Material", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + "MaterialLogica.Guardar(mate)" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbMaterial.SelectedIndex == -1)
                return;

            
            DialogResult Result = MessageBox.Show("Desea borrar el Material?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    MaterialLogica mate = new MaterialLogica();
                    mate.Material = cbbMaterial.SelectedValue.ToString();

                    
                    if (MaterialLogica.Eliminar(mate))
                    {
                        MessageBox.Show("El Material ha sido borrado", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbbMaterial.Text.Length >= 9)
                e.Handled = true;
        }

        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbbMaterial.Text))
                    return;

                MaterialLogica mate = new MaterialLogica();
                mate.Material = cbbMaterial.Text.ToString().ToUpper();
                DataTable datos =MaterialLogica.Consultar(mate);
                if (datos.Rows.Count != 0)
                {

                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    txtEstd.Text = datos.Rows[0]["estandar"].ToString();
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

                if (string.IsNullOrEmpty(cbbMaterial.Text))
                    return;

                MaterialLogica mate = new MaterialLogica();
                mate.Material = cbbMaterial.Text.ToString().ToUpper();
                DataTable datos = MaterialLogica.Consultar(mate);
                if (datos.Rows.Count != 0)
                {
                    cbbMaterial.SelectedValue = datos.Rows[0]["material"].ToString();
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    txtEstd.Text = datos.Rows[0]["estandar"].ToString();
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
