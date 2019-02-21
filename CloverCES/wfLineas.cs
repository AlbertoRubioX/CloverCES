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
    public partial class wfLineas : Form
    {
        private string _lsNomAnt;
        private bool _lbCambioDet;
        private bool _lbCambioDet2;
        public wfLineas()
        {
            InitializeComponent();
        }

        #region regIncio
        private void wfLineas_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void wfLineas_Activated(object sender, EventArgs e)
        {
            cbbLinea.Focus();
        }
        private void Inicio()
        {
            cbbLinea.ResetText();
            DataTable data = LineaLogica.Listar();
            cbbLinea.DataSource = data;
            cbbLinea.ValueMember = "linea";
            cbbLinea.DisplayMember = "linea";
            cbbLinea.SelectedIndex = -1;

            txtNombre.Clear();

            cbbPlanta.ResetText();
            DataTable dtT = PlantaLogica.Listar();
            cbbPlanta.DataSource = dtT;
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.DisplayMember = "nombre";
            cbbPlanta.SelectedIndex = -1;

            cbbArea.ResetText();
            cbbArea.DataSource = null;

            cbbMaterial.ResetText();
            DataTable dt = MaterialLogica.Listar();
            cbbMaterial.DataSource = dt;
            cbbMaterial.ValueMember = "material";
            cbbMaterial.DisplayMember = "nombre";
            cbbMaterial.SelectedIndex = -1;

            dgwTurno1.DataSource = null;

            dgwTurno2.DataSource = null;
            dgwLineasRemove.DataSource = null;

            CargarStd();

            cbbLinea.Focus();
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
        private void CargarStd()
        {

            if (dgwTurno1.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Lineastd");
                dtNew.Columns.Add("linea", typeof(string));
                dtNew.Columns.Add("consec", typeof(string));
                dtNew.Columns.Add("turno", typeof(string));
                dtNew.Columns.Add("Hora", typeof(string));
                dtNew.Columns.Add("Meta", typeof(double));
                dgwTurno1.DataSource = dtNew;
            }

            dgwTurno1.Columns[0].Visible = false;
            dgwTurno1.Columns[1].Visible = false;
            dgwTurno1.Columns[2].Visible = false;

            dgwTurno1.Columns[3].Width = ColumnWith(dgwTurno1, 40);
            dgwTurno1.Columns[4].Width = ColumnWith(dgwTurno1, 40);

            if (dgwTurno2.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Lineastd");
                dtNew.Columns.Add("linea", typeof(string));
                dtNew.Columns.Add("consec", typeof(string));
                dtNew.Columns.Add("turno", typeof(string));
                dtNew.Columns.Add("Hora", typeof(string));
                dtNew.Columns.Add("Meta", typeof(double));
                dgwTurno2.DataSource = dtNew;
            }

            dgwTurno2.Columns[0].Visible = false;
            dgwTurno2.Columns[1].Visible = false;
            dgwTurno2.Columns[2].Visible = false;

            dgwTurno2.Columns[3].Width = ColumnWith(dgwTurno1, 40);
            dgwTurno2.Columns[4].Width = ColumnWith(dgwTurno1, 40);

        }

        private void cbbLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbLinea.Text.Length >= 9)
                e.Handled = true;
        }

        private void cbbLinea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LineaLogica line = new LineaLogica();
                line.Linea = cbbLinea.SelectedValue.ToString();
                DataTable datos = LineaLogica.ConsultarLine(line);
                if (datos.Rows.Count != 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();

                    AreaLogica area = new AreaLogica();
                    area.Planta = datos.Rows[0]["planta"].ToString();
                    DataTable dtA = AreaLogica.ListarPlanta(area);
                    cbbArea.DataSource = dtA;
                    cbbArea.ValueMember = "area";
                    cbbArea.DisplayMember = "area";
                    cbbArea.SelectedValue = datos.Rows[0]["area"].ToString();

                    cbbMaterial.SelectedValue = datos.Rows[0]["standar"].ToString();

                    LinestdLogica lin = new LinestdLogica();
                    lin.Linea = cbbLinea.SelectedValue.ToString();
                    lin.Turno = "1";
                    DataTable Lista = LinestdLogica.Listar(lin);
                    dgwTurno1.DataSource = Lista;

                    lin.Turno = "2";
                    DataTable Lista2 = LinestdLogica.Listar(lin);
                    dgwTurno2.DataSource = Lista2;
                    txtNombre.Focus();
                }

                CargarStd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void cbbLinea_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                    Close();

                if (e.KeyCode != Keys.Enter)
                    return;

                LineaLogica line = new LineaLogica();
                line.Linea = cbbLinea.SelectedValue.ToString();
                DataTable datos = LineaLogica.ConsultarLine(line);
                if (datos.Rows.Count != 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    cbbPlanta.SelectedValue = datos.Rows[0]["planta"].ToString();

                    AreaLogica area = new AreaLogica();
                    area.Planta = datos.Rows[0]["planta"].ToString();
                    DataTable dtA = AreaLogica.ListarPlanta(area);
                    cbbArea.DataSource = dtA;
                    cbbArea.ValueMember = "area";
                    cbbArea.DisplayMember = "area";
                    cbbArea.SelectedValue = datos.Rows[0]["area"].ToString();

                    cbbMaterial.SelectedValue = datos.Rows[0]["standar"].ToString();


                    LinestdLogica lin = new LinestdLogica();
                    lin.Linea = cbbLinea.SelectedValue.ToString();
                    lin.Turno = "1";
                    DataTable Lista = LinestdLogica.Listar(lin);
                    dgwTurno1.DataSource = Lista;

                    lin.Turno = "2";
                    DataTable Lista2 = LinestdLogica.Listar(lin);
                    dgwTurno2.DataSource = Lista2;
                    txtNombre.Focus();
                }

                CargarStd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void cbbPlanta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
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
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                _lbCambioDet = true;
            }
                if (e.ColumnIndex == 3)
            {
                int iIndex = e.ColumnIndex;

                string sNombre = dgwTurno1[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                if (!string.IsNullOrEmpty(sNombre) && !string.IsNullOrWhiteSpace(sNombre))
                {
                    foreach (DataGridViewRow row in dgwTurno1.Rows)
                    {
                        if (row.Index == e.RowIndex)
                            continue;

                        if (row.Cells[iIndex].Value == null)
                            continue;

                        string sVal = row.Cells[iIndex].Value.ToString().ToUpper();
                        if (sNombre == sVal)
                        {
                            MessageBox.Show(string.Format("El valor capturado ya se encuentra registrado", sVal), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgwTurno1[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                            break;
                        }
                    }
                }
            }
        }

        private void dgwTurno2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                _lbCambioDet2 = true;
            }
            if (e.ColumnIndex == 3)
            {
                int iIndex = e.ColumnIndex;

                string sNombre = dgwTurno2[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
                if (!string.IsNullOrEmpty(sNombre) && !string.IsNullOrWhiteSpace(sNombre))
                {
                    foreach (DataGridViewRow row in dgwTurno2.Rows)
                    {
                        if (row.Index == e.RowIndex)
                            continue;

                        if (row.Cells[iIndex].Value == null)
                            continue;

                        string sVal = row.Cells[iIndex].Value.ToString().ToUpper();
                        if (sNombre == sVal)
                        {
                            MessageBox.Show(string.Format("El valor capturado ya se encuentra registrado", sVal), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgwTurno2[e.ColumnIndex, e.RowIndex].Value = string.Empty;
                            break;
                        }
                    }
                }
            }
        }

        private void dgwTurno2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

                dgwTurno1.Rows.Remove(_crow);
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

            if (string.IsNullOrEmpty(cbbLinea.Text))
            {
                cbbLinea.Focus();
                return bValida;
            }

            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("No se a especificado el nombre de la Linea", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return bValida;
            }

            if (dgwTurno1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgwTurno1.Rows)
                {
                    if (row.Index == dgwTurno1.Rows.Count - 1)
                        break;

                    if (dgwTurno1.IsCurrentRowDirty)
                        dgwTurno1.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    if (string.IsNullOrEmpty(row.Cells[3].Value.ToString()))
                    {
                        LineaRemove(dgwTurno1.CurrentRow);
                    }

                }
                return true;
            }
            if (dgwTurno2.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgwTurno2.Rows)
                {
                    if (row.Index == dgwTurno2.Rows.Count - 1)
                        break;

                    if (dgwTurno2.IsCurrentRowDirty)
                        dgwTurno2.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    if (string.IsNullOrEmpty(row.Cells[3].Value.ToString()))
                    {
                        LineaRemove(dgwTurno2.CurrentRow);
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

                LineaLogica linea = new LineaLogica();
                linea.Linea = cbbLinea.Text.ToString().ToUpper();
                linea.Nombre = txtNombre.Text.ToString();
                linea.Planta = cbbPlanta.SelectedValue.ToString();
                linea.Area = cbbArea.SelectedValue.ToString();
                linea.Material = cbbMaterial.SelectedValue.ToString();

                if (LineaLogica.Guardar(linea) == 0)
                {
                    MessageBox.Show("Error al intentar guardar la Linea", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //BORRA ESTACIONES ELIMINADAS
                foreach (DataGridViewRow row in dgwLineasRemove.Rows)
                {
                    string sLinea = row.Cells[0].Value.ToString();
                    int iCons = 0;
                    if(int.TryParse(row.Cells[0].Value.ToString(),out iCons))
                    {
                        if (!string.IsNullOrEmpty(sLinea))
                        {
                            LinestdLogica lines = new LinestdLogica();
                            lines.Linea = sLinea;
                            lines.Consec = iCons;
                            try
                            {
                                LinestdLogica.Eliminar(lines);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "LineaLogica.Eliminar(mode);" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                    }
                    
                }

                if(_lbCambioDet)
                {
                    foreach (DataGridViewRow row in dgwTurno1.Rows)
                    {
                        if (row.Index == dgwTurno1.Rows.Count - 1)
                            break;

                        if (dgwTurno1.IsCurrentRowDirty)
                            dgwTurno1.CommitEdit(DataGridViewDataErrorContexts.Commit);

                        
                        string sHora = Convert.ToString(row.Cells[3].Value);
                        int iCons = 0;
                        if (!int.TryParse(row.Cells[1].Value.ToString(), out iCons))
                            iCons = 0;

                        double dMeta = 0;
                        if (!double.TryParse(row.Cells[4].Value.ToString(), out dMeta))
                            dMeta = 0;

                        LinestdLogica lines = new LinestdLogica();
                        lines.Linea = cbbLinea.SelectedValue.ToString();
                        lines.Consec = iCons;
                        lines.Turno = "1";
                        lines.Nombre = sHora;
                        lines.Estandar = dMeta;
                        if (LinestdLogica.Guardar(lines) == -1)
                        {
                            MessageBox.Show("Error al intentar guardar la Hora " + sHora, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }

                if (_lbCambioDet2)
                {
                    foreach (DataGridViewRow row in dgwTurno2.Rows)
                    {
                        if (row.Index == dgwTurno2.Rows.Count - 1)
                            break;

                        if (dgwTurno2.IsCurrentRowDirty)
                            dgwTurno2.CommitEdit(DataGridViewDataErrorContexts.Commit);


                        string sHora = Convert.ToString(row.Cells[3].Value);
                        int iCons = 0;
                        if (!int.TryParse(row.Cells[1].Value.ToString(), out iCons))
                            iCons = 0;

                        double dMeta = 0;
                        if (!double.TryParse(row.Cells[4].Value.ToString(), out dMeta))
                            dMeta = 0;

                        LinestdLogica lines = new LinestdLogica();
                        lines.Linea = cbbLinea.SelectedValue.ToString();
                        lines.Consec = iCons;
                        lines.Turno = "2";
                        lines.Nombre = sHora;
                        lines.Estandar = dMeta;
                        if (LinestdLogica.Guardar(lines) == -1)
                        {
                            MessageBox.Show("Error al intentar guardar la Hora " + sHora, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Guardar())
                Close();
            else
                Inicio();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbbLinea.SelectedIndex == -1)
                return;
            if(tabControl1.SelectedIndex == 0)
            {
                if (dgwTurno1.SelectedRows.Count == 0)
                    return;
                else
                {
                    if (string.IsNullOrEmpty(dgwTurno1.SelectedCells[3].Value.ToString()))
                        return;
                }
                LineaRemove(dgwTurno1.CurrentRow);
            }
            else
            {
                if (dgwTurno2.SelectedRows.Count == 0)
                    return;
                else
                {
                    if (string.IsNullOrEmpty(dgwTurno2.SelectedCells[3].Value.ToString()))
                        return;
                }
                LineaRemove(dgwTurno2.CurrentRow);
            }
        
            CargarStd();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbbLinea.SelectedIndex == -1)
                return;

            
            DialogResult Result = MessageBox.Show("Desea borrar la Linea?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                try
                {
                    LineaLogica lin = new LineaLogica();
                    lin.Linea = cbbLinea.SelectedValue.ToString();

                    //if (LineaLogica.AntesDeEliminar(lin))
                    //{
                    //    MessageBox.Show("La Linea no se puede borrar, debido a que cuenta con movimientos en el Sistema", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}

                    if (LineaLogica.Eliminar(lin))
                    {
                        MessageBox.Show("La Linea ha sido borrada", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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




        #endregion

        private void cbbMaterial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgwTurno1.DataSource = null;
            dgwTurno2.DataSource = null;
            CargarStd();

            MaterialLogica mat = new MaterialLogica();
            mat.Material = cbbMaterial.SelectedValue.ToString();
            DataTable data = MaterialLogica.Consultar(mat);

            double dStd = 0;
            if(!double.TryParse(data.Rows[0]["estandar"].ToString(), out dStd))
                dStd = 0;
            
            //std 1er turno
            for(int i = 0; i < 10; i++)
            {
                int iHora = 7;
                iHora += i;
                string sHora = iHora.ToString().PadLeft(2,'0') + ":00";
                DataTable dt = dgwTurno1.DataSource as DataTable;
                dt.Rows.Add(cbbLinea.SelectedValue.ToString(), 0, "1",sHora, dStd);
            }

            for (int i = 0; i < 9; i++)
            {
                int iHora = 17;
                iHora += i;
                if (i == 7)
                    iHora = 0;
                else
                {
                    if (i == 8)
                        iHora = 1;
                }
                string sHora = iHora.ToString().PadLeft(2,'0') + ":20";
                DataTable dt = dgwTurno2.DataSource as DataTable;
                dt.Rows.Add(cbbLinea.SelectedValue.ToString(), 0, "2", sHora, dStd);
            }

            _lbCambioDet = true;
            _lbCambioDet2 = true;
            CargarStd();
        }
    }
}
