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
    public partial class wfPlantas : Form
    {
        private string _lsNomAnt;
        private bool _lbCambioDet;
        public wfPlantas()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfPlantas_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfPlantas_Activated(object sender, EventArgs e)
        {
            cbbPlanta.Focus();
        }
        private void Inicio()
        {
            cbbPlanta.ResetText();
            DataTable data = PlantaLogica.Listar();
            cbbPlanta.DataSource = data;
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.DisplayMember = "planta";
            cbbPlanta.SelectedIndex = -1;

            txtNombre.Clear();
            _lsNomAnt = string.Empty;
            dgwLineas.DataSource = null;
            dgwLineasRemove.DataSource = null;

            CargarLineas();

            cbbPlanta.Focus();
        }
        private int ColumnWith(DataGridView _dtGrid, double _dColWith)
        {

            double dW = _dtGrid.Width - 10;
            double dTam = _dColWith;
            double dPor = dTam / 100;
            dTam = dW * dPor;
            dTam = Math.Truncate(dTam);

            return Convert.ToInt32(dTam);
        }
        private void CargarLineas()
        {

            if (dgwLineas.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Lineas");
                dtNew.Columns.Add("planta", typeof(string));
                dtNew.Columns.Add("Linea", typeof(string));
                dtNew.Columns.Add("Estación", typeof(string));
                dtNew.Columns.Add("Area", typeof(string));
                dgwLineas.DataSource = dtNew;
            }

            dgwLineas.Columns[0].Visible = false;

            dgwLineas.Columns[1].Width = ColumnWith(dgwLineas, 25);
            dgwLineas.Columns[2].Width = ColumnWith(dgwLineas, 40);
            dgwLineas.Columns[3].Width = ColumnWith(dgwLineas, 20);

        }

        private void cbbPlanta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbPlanta.Text.Length >= 9)
                e.Handled = true;
        }

        private void cbbPlanta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                PlantaLogica plan = new PlantaLogica();
                plan.Planta = cbbPlanta.SelectedValue.ToString();
                DataTable datos = PlantaLogica.Consultar(plan);
                if (datos.Rows.Count != 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();

                    LineaLogica lin = new LineaLogica();
                    lin.Planta = cbbPlanta.SelectedValue.ToString();
                    DataTable Lista = LineaLogica.ListarPta(lin);
                    dgwLineas.DataSource = Lista;

                    txtNombre.Focus();
                }

                CargarLineas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region regLineas
        private void dgwLineas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void dgwLineas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                int iIndex = e.ColumnIndex;
                _lbCambioDet = true;

                string sNombre = dgwLineas[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                if (!string.IsNullOrEmpty(sNombre) && !string.IsNullOrWhiteSpace(sNombre))
                {
                    foreach (DataGridViewRow row in dgwLineas.Rows)
                    {
                        if (row.Index == e.RowIndex)
                            continue;

                        if (row.Cells[iIndex].Value == null)
                            continue;

                        string sVal = row.Cells[iIndex].Value.ToString().ToUpper();
                        if (sNombre == sVal)
                        {
                            MessageBox.Show(string.Format("El valor capturado ya se encuentra registrado", sVal), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgwLineas[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                            break;
                        }
                    }
                }
            }
        }

        private void LineaRemove(DataGridViewRow _crow)
        {
            try
            {
                if (!string.IsNullOrEmpty(_crow.Cells[0].Value.ToString()))
                {
                    //mandar al listado para borrar de bd al guardar cambios
                    if (dgwLineasRemove.Rows.Count == 0)
                    {
                        DataTable dtNew = new DataTable("Eliminar");
                        dtNew.Columns.Add("planta", typeof(string));
                        dtNew.Columns.Add("linea", typeof(string));
                        dgwLineasRemove.DataSource = dtNew;
                    }

                    string sPlanta = _crow.Cells[0].Value.ToString();
                    string sLinea = _crow.Cells[1].Value.ToString();

                    DataTable dt = dgwLineasRemove.DataSource as DataTable;
                    dt.Rows.Add(sPlanta, sLinea);
                }

                dgwLineas.Rows.Remove(_crow);
                _lbCambioDet = true;

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region regSave
        private bool Valida()
        {
            bool bValida = false;

            if (string.IsNullOrEmpty(cbbPlanta.Text))
            {
                MessageBox.Show("No se a especificado la clave la Planta", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbPlanta.Focus();
                return bValida;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("No se a especificado el nombre de la Planta", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return bValida;
            }

            if (dgwLineas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgwLineas.Rows)
                {
                    if (row.Index == dgwLineas.Rows.Count - 1)
                        break;

                    if (dgwLineas.IsCurrentRowDirty)
                        dgwLineas.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    if (string.IsNullOrEmpty(row.Cells[2].Value.ToString()))
                    {
                        LineaRemove(dgwLineas.CurrentRow);
                    }

                }
                return true;
            }

            return bValida;
        }

        private bool Guardar()
        {
            try
            {
                if (!Valida())
                    return false;

                PlantaLogica plan = new PlantaLogica();
                plan.Planta = cbbPlanta.Text.ToString().ToUpper();
                plan.Nombre = txtNombre.Text.ToString();
                if (PlantaLogica.Guardar(plan) == 0)
                {
                    MessageBox.Show("Error al intentar guardar la Planta", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //BORRA ESTACIONES ELIMINADAS
                foreach (DataGridViewRow row in dgwLineasRemove.Rows)
                {
                    string sPlanta = row.Cells[0].Value.ToString();
                    string sLinea = row.Cells[1].Value.ToString();
                    if (!string.IsNullOrEmpty(sPlanta))
                    {
                        LineaLogica line = new LineaLogica();
                        line.Planta = sPlanta;
                        line.Linea = sLinea;
                        try
                        {
                            LineaLogica.Eliminar(line);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "LineaLogica.Eliminar(mode);" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }

                if(_lbCambioDet)
                {
                    foreach (DataGridViewRow row in dgwLineas.Rows)
                    {
                        if (row.Index == dgwLineas.Rows.Count - 1)
                            break;

                        if (dgwLineas.IsCurrentRowDirty)
                            dgwLineas.CommitEdit(DataGridViewDataErrorContexts.Commit);

                        string sPlanta = cbbPlanta.SelectedValue.ToString();
                        string sLine = Convert.ToString(row.Cells[1].Value);
                        string sNombre = Convert.ToString(row.Cells[2].Value);
                        string sArea = Convert.ToString(row.Cells[3].Value);

                        LineaLogica line = new LineaLogica();
                        line.Planta = sPlanta;
                        line.Linea = sLine;
                        line.Nombre = sNombre;
                        line.Area = sArea;

                        if (LineaLogica.GuardarPta(line) == -1)
                        {
                            MessageBox.Show("Error al intentar guardar la linea " + sLine, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
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

            if (dgwLineas.SelectedRows.Count == 0)
                return;
            else
            {
                if (string.IsNullOrEmpty(dgwLineas.SelectedCells[1].Value.ToString()))
                    return;
            }

            
            LineaRemove(dgwLineas.CurrentRow);
            CargarLineas();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbPlanta.SelectedIndex == -1)
                return;

            
            DialogResult Result = MessageBox.Show("Desea borrar la Planta?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    PlantaLogica plan = new PlantaLogica();
                    plan.Planta = cbbPlanta.SelectedValue.ToString();

                    if (PlantaLogica.AntesDeEliminar(plan))
                    {
                        MessageBox.Show("La Planta no se puede borrar, debido a que cuenta con movimientos en el Sistema", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (PlantaLogica.Eliminar(plan))
                    {
                        MessageBox.Show("La Planta ha sido borrada", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbbPlanta_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                    Close();

                if (e.KeyCode != Keys.Enter)
                    return;

                PlantaLogica plan = new PlantaLogica();
                plan.Planta = cbbPlanta.SelectedValue.ToString();
                DataTable datos = PlantaLogica.Consultar(plan);
                if (datos.Rows.Count != 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();

                    LineaLogica lin = new LineaLogica();
                    lin.Planta = cbbPlanta.SelectedValue.ToString();
                    DataTable Lista = LineaLogica.ListarPta(lin);
                    dgwLineas.DataSource = Lista;

                    txtNombre.Focus();
                }

                CargarLineas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
