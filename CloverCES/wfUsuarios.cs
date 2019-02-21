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
    public partial class wfUsuarios : Form
    {
        private bool _lbCambioDet;
        private int _liSDIndex;
        private int _liCons;
        public wfUsuarios()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfUsuarios_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfUsuarios_Activated(object sender, EventArgs e)
        {
            cbbUsuario.Focus();
        }
        private void Inicio()
        {
            CargarCol();
            DataTable dtU = UsuarioLogica.ListarVista();
            dgwUsuarios.DataSource = dtU;
            dgwUsuarios.ClearSelection();

            cbbUsuario.ResetText();
            DataTable dt = UsuarioLogica.Listar();
            cbbUsuario.DataSource = dt;
            cbbUsuario.ValueMember = "usuario";
            cbbUsuario.DisplayMember = "usuario";
            cbbUsuario.SelectedIndex = -1;

            cbbTurno.ResetText();
            Dictionary<string, string> Turno = new Dictionary<string, string>();
            Turno.Add("1", "1");
            Turno.Add("2", "2");
            cbbTurno.DataSource = new BindingSource(Turno, null);
            cbbTurno.DisplayMember = "Value";
            cbbTurno.ValueMember = "Key";
            cbbTurno.SelectedIndex = 0;

            cbbPlanta.ResetText();
            DataTable data = PlantaLogica.Listar();
            cbbPlanta.DataSource = data;
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.DisplayMember = "nombre";
            cbbPlanta.SelectedIndex = -1;

            cbbLinea.ResetText();
            cbbLinea.DataSource = null;

            cbbPuesto.ResetText();
            Dictionary<string, string> Pto = new Dictionary<string, string>();
            Pto.Add("OP", "OPERADOR");
            Pto.Add("CA", "CAPTURISTA");
            Pto.Add("SP", "SUPERVISOR");
            Pto.Add("AD", "ADMINISTRADOR");
            cbbPuesto.DataSource = new BindingSource(Pto, null);
            cbbPuesto.DisplayMember = "Value";
            cbbPuesto.ValueMember = "Key";
            cbbPuesto.SelectedIndex = 0;

            chbRamp.Checked = false;
            txtRamp.Clear();
            txtRamp.Enabled = false;

            
            cbbUsuario.Focus();
        }
       

        private void cbbPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void cbbPlanta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LineaLogica line = new LineaLogica();
                line.Planta = cbbPlanta.SelectedValue.ToString();
                DataTable dt = LineaLogica.ListarPta(line);
                cbbLinea.DataSource = dt;
                cbbLinea.ValueMember = "linea";
                cbbLinea.DisplayMember = "linea";
                cbbLinea.SelectedValue = -1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), "Error..." + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

      

        #region regSave
        private bool Valida()
        {
            bool bValida = false;

            if (string.IsNullOrEmpty(cbbUsuario.Text))
            {
                MessageBox.Show("No se a especificado el Usuario", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbUsuario.Focus();
                return bValida;
            }

            if (cbbTurno.SelectedIndex ==-1)
            {
                MessageBox.Show("No se a especificado el Turno", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbTurno.Focus();
                return bValida;
            }

            if(cbbPuesto.SelectedValue.ToString() == "OP")
            {
                if (cbbPlanta.SelectedIndex == -1)
                {
                    MessageBox.Show("No se a especificado la Planta", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbPlanta.Focus();
                    return bValida;
                }


                if (cbbLinea.SelectedIndex == -1)
                {
                    MessageBox.Show("No se a especificado la Linea", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbLinea.Focus();
                    return bValida;
                }

                if (chbRamp.Checked && (string.IsNullOrEmpty(txtRamp.Text) || string.IsNullOrWhiteSpace(txtRamp.Text)))
                {
                    MessageBox.Show("No se a especificado el porcentaje de rampeo", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRamp.Focus();
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

                UsuarioLogica user = new UsuarioLogica();
                user.Usuario = cbbUsuario.Text.ToString().ToUpper();
                if (cbbPlanta.SelectedIndex == -1)
                    user.Planta = null;
                else
                    user.Planta = cbbPlanta.SelectedValue.ToString();
                if (cbbLinea.SelectedIndex == -1)
                    user.Linea = null;
                else
                    user.Linea = cbbLinea.SelectedValue.ToString();

                if (cbbTurno.SelectedIndex != -1)
                    user.Turno = cbbTurno.SelectedValue.ToString();
                else
                    user.Turno = null;

                user.Puesto = cbbPuesto.SelectedValue.ToString();
                if (chbRamp.Checked)
                    user.IndRamp = "1";
                else
                    user.IndRamp = "0";
                double dVal = 0;
                if (double.TryParse(txtRamp.Text, out dVal))
                    user.Rampeo = dVal;
                else
                    user.Rampeo = 0;
                //user.User = gsUsuario;
                
                if (UsuarioLogica.Guardar(user) == 0)
                {
                    MessageBox.Show("Error al intentar guardar el Usuario", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region regBotones
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
            Guardar();
            Inicio();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbUsuario.SelectedIndex == -1)
                return;

            
            DialogResult Result = MessageBox.Show("Desea borrar el Usuario?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    UsuarioLogica user = new UsuarioLogica();
                    user.Usuario = cbbUsuario.SelectedValue.ToString();

                    
                    if (UsuarioLogica.Eliminar(user))
                    {
                        MessageBox.Show("El Usuario ha sido borrado", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (cbbUsuario.Text.Length >= 20)
                e.Handled = true;
        }

        #endregion

        #region regCaptura
        private void cbbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string sUsuario = cbbUsuario.SelectedValue.ToString();
                UsuarioLogica user = new UsuarioLogica();
                user.Usuario = sUsuario;
                DataTable datos = UsuarioLogica.Consultar(user);
                if (datos.Rows.Count != 0)
                {
                    cbbPuesto.SelectedValue = datos.Rows[0]["puesto"].ToString();
                    if(datos.Rows[0]["puesto"].ToString() == "OP")
                    {
                        cbbTurno.SelectedValue = datos.Rows[0]["turno"].ToString();
                        cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();

                        LineaLogica line = new LineaLogica();
                        line.Planta = cbbPlanta.SelectedValue.ToString();
                        DataTable dt = LineaLogica.ListarPta(line);
                        cbbLinea.DataSource = dt;
                        cbbLinea.ValueMember = "linea";
                        cbbLinea.DisplayMember = "linea";
                        cbbLinea.SelectedValue = datos.Rows[0]["linea"].ToString();

                        if (datos.Rows[0]["ind_ramp"].ToString() == "1")
                            chbRamp.Checked = true;
                        else
                            chbRamp.Checked = false;
                        if (!string.IsNullOrEmpty(datos.Rows[0]["rampeo"].ToString()))
                            txtRamp.Text = datos.Rows[0]["rampeo"].ToString();
                    }
                    else
                    {
                        cbbTurno.ResetText();
                        cbbPlanta.ResetText();
                        cbbLinea.ResetText();
                        chbRamp.Checked = false;
                        txtRamp.Clear();
                    }
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

                if (string.IsNullOrEmpty(cbbUsuario.Text))
                {
                    cbbUsuario.SelectedIndex = -1;
                    return;
                }

                string sUsuario = cbbUsuario.Text.ToUpper().Trim().ToString();
                UsuarioLogica user = new UsuarioLogica();
                user.Usuario = sUsuario;
                DataTable datos = UsuarioLogica.Consultar(user);
                if (datos.Rows.Count != 0)
                {
                    cbbUsuario.SelectedValue = datos.Rows[0]["usuario"].ToString();
                    cbbTurno.SelectedValue = datos.Rows[0]["turno"].ToString();
                    cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();
                    cbbPuesto.SelectedValue = datos.Rows[0]["puesto"].ToString();

                    LineaLogica line = new LineaLogica();
                    line.Planta = cbbPlanta.SelectedValue.ToString();
                    DataTable dt = LineaLogica.ListarPta(line);
                    cbbLinea.DataSource = dt;
                    cbbLinea.ValueMember = "linea";
                    cbbLinea.DisplayMember = "linea";
                    cbbLinea.SelectedValue = datos.Rows[0]["linea"].ToString();

                    if (datos.Rows[0]["ind_ramp"].ToString() == "1")
                        chbRamp.Checked = true;
                    else
                        chbRamp.Checked = false;
                    if (!string.IsNullOrEmpty(datos.Rows[0]["rampeo"].ToString()))
                        txtRamp.Text = datos.Rows[0]["rampeo"].ToString();
                }
                else
                {
                    Inicio();
                    cbbUsuario.Text = sUsuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #region regGrid
        private void CargarCol()
        {

            if (dgwUsuarios.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Usuarios");
                dtNew.Columns.Add("Usuario", typeof(string));
                dtNew.Columns.Add("Planta", typeof(string));
                dtNew.Columns.Add("Linea", typeof(string));
                dtNew.Columns.Add("Turno", typeof(string));
                dtNew.Columns.Add("ind_ramp", typeof(string));
                dtNew.Columns.Add("Rampeo", typeof(string));
                dgwUsuarios.DataSource = dtNew;
            }

            dgwUsuarios.Columns[4].Visible = false;

        }
        private void dgwUsuarios_Click(object sender, EventArgs e)
        {
            if (dgwUsuarios.CurrentRow == null)
                return;
            if (cbbUsuario.DataSource == null)
                return;

            _liSDIndex = dgwUsuarios.CurrentRow.Index;
            DataGridViewRow row = dgwUsuarios.Rows[_liSDIndex];
            if (!string.IsNullOrEmpty(row.Cells[0].Value.ToString()))
            {
                cbbUsuario.SelectedValue = row.Cells[0].Value.ToString();
                cbbArea_SelectionChangeCommitted(sender, e);
            }
            
        }

        private void dgwUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            dgwUsuarios_Click(sender, e);
        }

        private void dgwUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int iRow = e.RowIndex;
            if ((iRow % 2) == 0)
                e.CellStyle.BackColor = Color.LightGreen;
            else
                e.CellStyle.BackColor = Color.White;

            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void dgwUsuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                int iIndex = e.ColumnIndex;
                _lbCambioDet = true;
            }
            if (e.ColumnIndex == 1)
            { 
                string sNombre = dgwUsuarios[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                if (!string.IsNullOrEmpty(sNombre) && !string.IsNullOrWhiteSpace(sNombre))
                {
                    PlantaLogica pl = new PlantaLogica();
                    pl.Planta = sNombre;
                    if (!PlantaLogica.Verificar(pl))
                    {
                        dgwUsuarios[6, e.RowIndex].Value = "0";
                        MessageBox.Show("La planta no se encuentra registrada", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                        dgwUsuarios[6, e.RowIndex].Value = "1";
                }
            }
            if (e.ColumnIndex == 2)
            {
                string sPlanta = dgwUsuarios[1, e.RowIndex].Value.ToString().ToUpper();
                string sNombre = dgwUsuarios[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                if (!string.IsNullOrEmpty(sNombre) && !string.IsNullOrWhiteSpace(sNombre))
                {
                    LineaLogica ln = new LineaLogica();
                    ln.Planta = sPlanta;
                    ln.Linea = sNombre;
                    if (!LineaLogica.Verificar(ln))
                    {
                        dgwUsuarios[6, e.RowIndex].Value = "0";
                        MessageBox.Show("La linea no se encuentra registrada", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                        dgwUsuarios[6, e.RowIndex].Value = "1";
                }
            }
        }
        #endregion

        private void chbRamp_CheckedChanged(object sender, EventArgs e)
        {
            txtRamp.Enabled = chbRamp.Checked;
        }

        private void cbbPuesto_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbbPuesto.SelectedIndex !=-1)
            {
                if(cbbPuesto.SelectedValue.ToString() == "OP")
                    gbxOper.Enabled = true;
                else
                    gbxOper.Enabled = false;
            }
        }
        #endregion
    }
}
