using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Logica;
using Datos;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace CloverCES
{
    public partial class wfImportarDatos : Form
    {
        private string _lsProceso = "DB010";
        public wfImportarDatos()
        {
            InitializeComponent();
        }

        private void Inicio()
        {
            txtArchivo.Clear();

            cbbPlanta.ResetText();
            DataTable data = PlantaLogica.Listar();
            cbbPlanta.DataSource = data;
            cbbPlanta.DisplayMember = "nombre";
            cbbPlanta.ValueMember = "planta";
            cbbPlanta.SelectedIndex = 1;

            cbbTurno.ResetText();
            Dictionary<string, string> Turno = new Dictionary<string, string>();
            Turno.Add("1", "1");
            Turno.Add("2", "2");
            cbbTurno.DataSource = new BindingSource(Turno, null);
            cbbTurno.DisplayMember = "Value";
            cbbTurno.ValueMember = "Key";
            cbbTurno.SelectedIndex = 0;

            cbbHora.ResetText();
            Dictionary<string, string> Hora = new Dictionary<string, string>();
            Hora.Add("7", "07:00");
            Hora.Add("8", "08:00");
            Hora.Add("9", "09:00");
            Hora.Add("10", "10:00");
            Hora.Add("11", "11:00");
            Hora.Add("12", "12:00");
            Hora.Add("13", "13:00");
            Hora.Add("14", "14:00");
            Hora.Add("15", "15:00");
            Hora.Add("16", "16:00");
            cbbHora.DataSource = new BindingSource(Hora, null);
            cbbHora.DisplayMember = "Value";
            cbbHora.ValueMember = "Key";
            cbbHora.SelectedIndex = -1;

            dgwDatos.DataSource = null;
            dgwDatadet.DataSource = null;
            CargarColumnas();
            txtArchivo.Focus();
        }

        private void wfImportarDatos_Load(object sender, EventArgs e)
        {
            Inicio();
            
        }
        private void CargarColumnas()
        {
            if (dgwDatadet.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Metadet");
                dtNew.Columns.Add("folio", typeof(long));
                dtNew.Columns.Add("consec", typeof(int));
                dtNew.Columns.Add("Usuario", typeof(string));
                dtNew.Columns.Add("Planta", typeof(string));
                dtNew.Columns.Add("Linea", typeof(string));
                dtNew.Columns.Add("Meta", typeof(double));
                dtNew.Columns.Add("Real", typeof(double));
                dgwDatadet.DataSource = dtNew;
            }

            dgwDatadet.Columns[0].Visible = false;
            dgwDatadet.Columns[1].Visible = false;
        }
        private void CargarColFile()
        {
            if (dgwDatos.Rows.Count == 0)
            {
                DataTable dtNew = new DataTable("Daily");
                dtNew.Columns.Add("usuario", typeof(string));
                dtNew.Columns.Add("real", typeof(double));
                dgwDatos.DataSource = dtNew;
            }
            
        }
        private void btnFile_Click(object sender, EventArgs e)
        {
            Inicio();

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx;*.csv";
            //dialog.Filter = "All Files (*.*)|*.*";

            dialog.Title = "Seleccione el archivo de Excel";

            dialog.FileName = string.Empty;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                btnImportar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                txtArchivo.Text = dialog.FileName;
               
                LlenarGrid2(txtArchivo.Text);

                Cursor = Cursors.Arrow;
                btnImportar.Enabled = true;
            }
        }
        private void LlenarGridCvs(string archivo)
        {
            try
            {
                string pathOnly = Path.GetDirectoryName(archivo);
                string fileName = Path.GetFileName(archivo);

                string sql = @"SELECT * FROM [" + fileName + "]";

                using (OleDbConnection connection = new OleDbConnection(
                          @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                          ";Extended Properties=\"Text;HDR=No\""))
                using (OleDbCommand command = new OleDbCommand(sql, connection))
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgwDatos.DataSource = dataTable;
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GeneraReporte(string _asUser,double _dReal)
        {
            try
            {
                string sTurno = cbbTurno.SelectedValue.ToString();
                string sHora = cbbHora.Text.ToString();
                
                UsuarioLogica user = new UsuarioLogica();
                user.Usuario = _asUser;
                DataTable dtU = UsuarioLogica.Consultar(user);
                string sIndRam = dtU.Rows[0]["ind_ramp"].ToString();
                double dRampeo = double.Parse(dtU.Rows[0]["rampeo"].ToString());
                string sLinea = dtU.Rows[0]["linea"].ToString();
                string sPlanta = dtU.Rows[0]["planta"].ToString();

                LineaLogica line = new LineaLogica();
                line.Linea = sLinea;
                line.Planta = sPlanta;
                DataTable dtL = LineaLogica.Consultar(line);
                string sMateria = dtL.Rows[0]["standar"].ToString();

                LinestdLogica lins = new LinestdLogica();
                lins.Linea = sLinea;
                lins.Turno = sTurno;
                DataTable dtStd = LinestdLogica.ConsultarTurno(lins);

                double dMeta = 0;
                for (int x = 0; x < dtStd.Rows.Count; x++)
                {

                    string sNombre = dtStd.Rows[x][3].ToString();
                    double dEstd = 0;
                    if (!double.TryParse(dtStd.Rows[x][4].ToString(), out dEstd))
                        dEstd = 0;

                    dMeta += dEstd;

                    if (sHora == sNombre)
                    {
                        AgregaLinea(_asUser, sPlanta, sLinea, dMeta, _dReal);
                        break;
                    }
                }

                //guarda t_metadia

            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        private void AgregaLinea(string _asUsuario, string _asPlanta, string _asLinea, double _adMeta, double _adReal)
        {
            DataTable dt = dgwDatadet.DataSource as DataTable;
            dt.Rows.Add(0, 0,_asUsuario, _asPlanta, _asLinea, _adMeta, _adReal);
        }
        private void AgregaDato(string _asUsuario,double _adReal)
        {
            DataTable dt = dgwDatos.DataSource as DataTable;
            dt.Rows.Add(_asUsuario, _adReal);
        }
        private void LlenarGrid2(string _asArchivo)
        {
            try
            {
                dgwDatos.DataSource = null;
                CargarColFile();
            
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbooks xlWorkbookS = xlApp.Workbooks;
                Excel.Workbook xlWorkbook = xlWorkbookS.Open(_asArchivo);
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                string sUsuario = string.Empty;
                double dReal = 0;
                for (int i = 1; i < rowCount; i++)
                {
                    if (xlRange.Cells[i, 1] == null)
                        break;

                    if (xlRange.Cells[i, 5].Value2 == null)
                        continue;
                    else
                    {
                        sUsuario = xlRange.Cells[i, 1].Value2.ToString();
                        if (!double.TryParse(xlRange.Cells[i, 5].Value2.ToString(), out dReal))
                            continue;
                        else
                            AgregaDato(sUsuario,dReal);
                    }
                        
                }
                xlApp.DisplayAlerts = false;
                xlWorkbook.Close();
                xlApp.DisplayAlerts = true;
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void LlenarGrid(string archivo)
        {

            OleDbCommand cmd = new OleDbCommand();
           
            //declaramos las variables         
            OleDbConnection conexion = null;
            DataSet dataSet = null;
            OleDbDataAdapter dataAdapter = null;

            string cadenaConexionArchivoExcel = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1\"";
            //string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Mode=Read;Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\"";
            try
            {
                conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                conexion.Open(); //abrimos la conexion
                //DataTable dt = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //string sSheet = dt.Columns[0].ToString();
                var sheet = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string sSheet = sheet.Rows[0]["TABLE_NAME"].ToString();
                if (string.IsNullOrEmpty(sSheet))
                {
                    MessageBox.Show("No hay una hoja para leer");
                    return;
                }
                string consultaHojaExcel = "Select * from [" + sSheet + "]";
                dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                dataSet = new DataSet(); // creamos  la instancia del objeto DataSet
                dataAdapter.TableMappings.Add("tbl", "Table");
                dataAdapter.Fill(dataSet);//llenamos el dataset
                DataTable table = dataSet.Tables[0];
                dgwDatos.DataSource = table;

                conexion.Close();//cerramos la conexion
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                MessageBox.Show("Error, Verificar el archivo o el nombre de la hoja" + Environment.NewLine + ex.Message, Text, MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }
        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArchivo.Text) || string.IsNullOrWhiteSpace(txtArchivo.Text))
                return;

            if (cbbHora.SelectedIndex == -1)
            {
                MessageBox.Show("Favor de indicar la hora de producción", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbHora.Focus();
                return;
            }

            if (dgwDatadet.Rows.Count > 0)
            {
                dgwDatadet.DataSource = null;
                CargarColumnas();
            }
                

            if (dgwDatos.Rows.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                int iCont = 0;

                try
                {
                    string sMensaje = string.Empty;
                    foreach (DataGridViewRow row in dgwDatos.Rows)
                    {

                        if (string.IsNullOrEmpty(Convert.ToString(row.Cells[0].Value)))
                            continue;

                        string sUser = Convert.ToString(row.Cells[0].Value);

                        if (sUser.StartsWith("Location"))
                            continue;

                        if (sUser.StartsWith("Processor"))
                            continue;

                        string sCant = Convert.ToString(row.Cells[1].Value);

                        double dReal = 0;
                        if (!double.TryParse(sCant, out dReal))
                            dReal = 0;

                        UsuarioLogica user = new UsuarioLogica();
                        user.Usuario = sUser;
                        user.Turno = cbbTurno.SelectedValue.ToString();
                        if (UsuarioLogica.VerificarTurno(user))
                        {
                            DataTable dtU = UsuarioLogica.Consultar(user);
                            string sPlanta = dtU.Rows[0]["planta"].ToString();
                            if (sPlanta == cbbPlanta.SelectedValue.ToString())
                            {
                                GeneraReporte(sUser, dReal);
                                iCont++;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(sMensaje))
                                sMensaje = sUser;
                            else
                                sMensaje = sMensaje + Environment.NewLine + sUser;
                            
                            continue;
                        }
                    }

                    //if(!string.IsNullOrEmpty(sMensaje))
                    //{
                    //    sMensaje = "Estos Usuarios fueron omitidos en el reporte por falta de reigstro en el sistema:" + Environment.NewLine + sMensaje;
                    //    MessageBox.Show(sMensaje, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }

                if (iCont > 0)
                    btnReport.Enabled = true;

                Cursor = Cursors.Arrow;
                //MessageBox.Show("La Importación se ha Completado. " + Environment.NewLine + "Registros Cargados: " + iCont.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor = Cursors.Default; 
            }
            else
                MessageBox.Show("No se encontraron datos para importar", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbbTurno_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbbHora.ResetText();
            Dictionary<string, string> Hora = new Dictionary<string, string>();

            if (cbbTurno.SelectedValue.ToString() == "1")
            {
                Hora.Add("7", "07:00");
                Hora.Add("8", "08:00");
                Hora.Add("9", "09:00");
                Hora.Add("10", "10:00");
                Hora.Add("11", "11:00");
                Hora.Add("12", "12:00");
                Hora.Add("13", "13:00");
                Hora.Add("14", "14:00");
                Hora.Add("15", "15:00");
                Hora.Add("16", "16:00");
            }
            else
            {
                Hora.Add("17", "17:20");
                Hora.Add("18", "18:20");
                Hora.Add("19", "19:20");
                Hora.Add("20", "20:20");
                Hora.Add("21", "21:20");
                Hora.Add("22", "22:20");
                Hora.Add("23", "23:20");
                Hora.Add("0", "00:20");
                Hora.Add("1", "01:20");
            }
            cbbHora.DataSource = new BindingSource(Hora, null);
            cbbHora.DisplayMember = "Value";
            cbbHora.ValueMember = "Key";
            cbbHora.SelectedIndex = -1;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgwDatadet.Rows.Count == 0)
                    return;

                Cursor = Cursors.WaitCursor;
                
                long lFolio = AccesoDatos.Consec(_lsProceso);
                double dMetaGlob = 0;
                double dRealGlob = 0;
                foreach (DataGridViewRow row in dgwDatadet.Rows)
                {
                    double dMeta = Convert.ToDouble(row.Cells[5].Value);
                    double dReal = Convert.ToDouble(row.Cells[6].Value);
                    dMetaGlob += dMeta;
                    dRealGlob += dReal;
                }

                MetadiaLogica met = new MetadiaLogica();
                met.Folio = lFolio;
                met.Fecha = DateTime.Today;
                met.Planta = cbbPlanta.SelectedValue.ToString();
                met.Turno = cbbTurno.SelectedValue.ToString();
                met.Hora = cbbHora.Text.ToString();
                met.Meta = dMetaGlob;
                met.Real = dRealGlob;
                met.Usuario = Global.gsUsuario;
                if (MetadiaLogica.Guardar(met) == 0)
                {
                    MessageBox.Show("Error al intentar guardar" + Environment.NewLine + "MetadiaLogica.Guardar()", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    return;
                }

                //metadet
                foreach (DataGridViewRow row in dgwDatadet.Rows)
                {
                    string sUsuario = Convert.ToString(row.Cells[2].Value);
                    string sPlanta = Convert.ToString(row.Cells[3].Value);
                    string sLinea = Convert.ToString(row.Cells[4].Value);
                    double dMeta = Convert.ToDouble(row.Cells[5].Value);
                    double dReal = Convert.ToDouble(row.Cells[6].Value);
                    string sRamp = string.Empty;
                    double dRampeo = 0;
                    if (dMeta == 0)
                        dMeta = dReal;

                    UsuarioLogica user = new UsuarioLogica();
                    user.Usuario = sUsuario;
                    DataTable dtU = UsuarioLogica.Consultar(user);
                    sRamp = dtU.Rows[0]["ind_ramp"].ToString();
                    if (sRamp == "1")
                        dRampeo = double.Parse(dtU.Rows[0]["rampeo"].ToString());
                    
                    if(dRampeo > 0)
                    {
                        dRampeo = dRampeo / 100;
                        double dRa = dMeta * dRampeo;
                        dMeta = dMeta - dRa;
                    }
                    
                    double dPorc = dReal / dMeta;
                    if (dPorc < 0)
                        dPorc = 0;
                    dPorc = dPorc * 100;

                    MetadetLogica med = new MetadetLogica();
                    med.Folio = lFolio;
                    med.Consec = 0;
                    med.Usuario = sUsuario;
                    med.Planta = sPlanta;
                    med.Linea = sLinea;
                    med.Meta = dMeta;
                    med.Real = dReal;
                    med.Porcen = Math.Round(dPorc,2);

                    if(MetadetLogica.Guardar(med) == 0)
                    {
                        MessageBox.Show("Error al intentar guardar la Linea" + med, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cursor = Cursors.Default;
                        return;
                    }
                }
                Cursor = Cursors.Default;
                Inicio();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }    
        }

        private void dgwDatadet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int iRow = e.RowIndex;
            if ((iRow % 2) == 0)
                e.CellStyle.BackColor = Color.LightBlue;
            else
                e.CellStyle.BackColor = Color.White;

            if (e.Value != null)
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }
    }
}
