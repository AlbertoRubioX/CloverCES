using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Datos;
using Logica;

namespace CloverCES
{
    public partial class wfDashboard : Form
    {
        FormWindowState _WindowStateAnt;
        private int _iWidthAnt;
        private int _iHeightAnt;
        private string _lsProceso = "DB010";
        private string _sFechaMod;
        private string _lsTurno;
        private string _lsURL;
        private string _lsFile;
        private string _lsSynURL;
        private string _lsSynFile;
        private double _ldRotMin;
        private double _ldMargenWX;//panel
        private double _ldMargenHY;
        private double _ldPaddingY;
        private double _ldPaddingX;
        private double _ldMargenWX1;//chart
        private double _ldMargenHY1;
        private double _ldPorcStd;

        private string _lsDiaAnt = string.Empty;
        private string _lsArea = string.Empty;
        private string _lsPlanta = string.Empty;
        private string _lsGlobal = string.Empty;
        private string _lsEstacion = string.Empty;
        private string _lsHora = string.Empty;
        private string _lsHrReg = string.Empty;
        private bool _lbLoadFile;
        private int _rangoInicial;
        private int _rangoFinal;
        public wfDashboard()
        {
            InitializeComponent();

            _iWidthAnt = Width;
            _iHeightAnt = Height;
            _WindowStateAnt = WindowState;
        }
        public void ResizeControl(Control ac_Control, int ai_Hor, ref int ai_WidthAnt, ref int ai_HegihtAnt, int ai_Retorna)
        {
            if (ai_WidthAnt == 0)
                ai_WidthAnt = ac_Control.Width;
            if (ai_WidthAnt == ac_Control.Width)
                return;

            int _dif = ai_WidthAnt - ac_Control.Width;
            int _difh = ai_HegihtAnt - ac_Control.Height;

            if (ai_Hor == 1)
                ac_Control.Height = this.Height - _difh;
            if (ai_Hor == 2)
                ac_Control.Width = this.Width - _dif;
            if (ai_Hor == 3)
            {
                ac_Control.Width = this.Width - _dif;
                ac_Control.Height = this.Height - _difh;
            }
            if (ai_Retorna == 1)
            {
                ai_WidthAnt = this.Width;
                ai_HegihtAnt = this.Height;
            }
        }

        private void InicialPosition()
        {
            double dW = this.Width - 14;
            double dH = this.Height - 14;

            _ldMargenWX = _ldMargenWX / 100;
            _ldMargenHY = _ldMargenHY / 100;

            //DIM W Y POSICION X
            double dWp = dW * _ldMargenWX;
            double dLX = dW * (_ldMargenWX / 2);
            int iWith = (int)dW - (int)dWp;
            panel1.Width = iWith;

            //DIM H Y POSICION Y
            double dHp = dH * _ldMargenHY;
            double dLY = dH * (_ldMargenHY / 2);
            int iHeight = (int)dH - (int)dHp;
            int iLY = (int)dLY;
            int iLX = (int)dLX;

            if (_ldPaddingY > 0)
                iLY += (int)_ldPaddingY;
            if (_ldPaddingX > 0)
                iLX += (int)_ldPaddingX;

            panel1.Height = iHeight;
            panel1.Location = new Point(iLX, iLY);

            //chart dentro del panel
            _ldMargenWX1 = _ldMargenWX1 / 100;
            _ldMargenHY1 = _ldMargenHY1 / 100;
            dW = panel1.Width;
            dH = panel1.Height;
            dWp = dW * _ldMargenWX1;
            dLX = dW * (_ldMargenWX1 / 2);
            iWith = (int)dW - (int)dWp;
            
            chtPastel.Width = iWith;
            chtBarras1.Width = iWith;

            dHp = dH * _ldMargenHY1;
            dLY = dH * (_ldMargenHY1 / 2);
            iHeight = (int)dH - (int)dHp;
            iLY = (int)dLY;

            chtPastel.Height = iHeight;
            chtBarras1.Height = iHeight;
            chtPastel.Location = new Point((int)dLX, iLY);
            chtBarras1.Location = new Point((int)dLX, iLY);

        }

        private bool Inicio()
        {

            bool bReturn = true;
            _lsEstacion = Global.gsEstacion;

            DataTable dtConf = ConfigLogica.Consultar();
            _lsURL = dtConf.Rows[0]["ruta_laser"].ToString();
            _lsFile = dtConf.Rows[0]["laser_file"].ToString();
            _lsSynURL = dtConf.Rows[0]["sync_dir"].ToString();
            _lsSynFile = dtConf.Rows[0]["sync_file"].ToString();
            _ldRotMin = Double.Parse(dtConf.Rows[0]["rotacion_min"].ToString());
            _ldMargenWX = Double.Parse(dtConf.Rows[0]["margen_w"].ToString());
            _ldMargenHY = Double.Parse(dtConf.Rows[0]["margen_h"].ToString());
            _ldPaddingX = Double.Parse(dtConf.Rows[0]["padding_x"].ToString());
            _ldPaddingY = Double.Parse(dtConf.Rows[0]["padding_y"].ToString());
            _ldMargenWX1 = Double.Parse(dtConf.Rows[0]["margen_w1"].ToString());
            _ldMargenHY1 = Double.Parse(dtConf.Rows[0]["margen_h1"].ToString());
            _ldPorcStd = Double.Parse(dtConf.Rows[0]["porc_std"].ToString());
            _lsDiaAnt = dtConf.Rows[0]["ind_lastday"].ToString();

            try
            {
                AreaLogica area = new AreaLogica();
                area.Estacion = _lsEstacion;//MEXI
                DataTable dtArea = AreaLogica.ConsultarEstacion(area);
                int iCont = dtArea.Rows.Count;
                if (iCont > 0)
                {
                    _lsArea = dtArea.Rows[0]["area"].ToString();
                    _lsPlanta = dtArea.Rows[0]["planta"].ToString();
                    _lsGlobal = dtArea.Rows[0]["ind_global"].ToString();

                    if (_lsGlobal == "1" && _lsArea == "LAS00")
                    {
                        _lbLoadFile = true;

                        int iMonitorCount = Screen.AllScreens.Length;
                        if(iMonitorCount>0)
                        {/*
                            wfDashboard Dash2 = new wfDashboard();
                            Screen[] screens = Screen.AllScreens;
                            
                            Dash2.StartPosition = FormStartPosition.Manual;
                            Dash2.Location = Screen.AllScreens[1].WorkingArea.Location;
                            Dash2.Show();
                           */ 
                        }
                    }
                }
                else
                {
                    wfAreaSelect Areas = new wfAreaSelect();
                    
                    Areas.ShowDialog();


                    _lsPlanta = Areas._lsPlanta;
                    _lsArea = Areas._lsArea;
                    _lsGlobal = Areas._lsGlobal;
                    _rangoInicial = Areas.int_lineaInicial;
                    _rangoFinal = Areas.int_lineaFinal;
                    
                    
                    if (string.IsNullOrEmpty(_lsArea) && _lsGlobal == "0")
                        _lsGlobal = "1";

                    if (string.IsNullOrEmpty(_lsPlanta))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "AreaLogica.ConsultarEstacion()" + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            CargarDatos();
            
            if (_ldRotMin > 0)
            {
                double dMilseg = _ldRotMin * 60000;
                int iMilsg = (int)dMilseg;
                timer1.Interval = iMilsg;
            }
            timer1.Start();

            return bReturn;
        }
        private void wfDashboard_Load(object sender, EventArgs e)
        {

            if (!Inicio())
                Close();
            else
            {
                InicialPosition();

                WindowState = FormWindowState.Maximized;

                timer2.Start();
                lblHora.Text = DateTime.Now.ToLongTimeString();
            }
        }

        #region regSyncro
        
        private void DailyProcessing()
        {
            DataTable dtData = new DataTable();

            _lsTurno = "2";
            DateTime dtTime = DateTime.Now;
            int iHora = dtTime.Hour;
            if (iHora >= 5 && iHora <= 16)
                _lsTurno = "1";

            if (iHora > 23)
                iHora -= 23;

            _lsHrReg = Convert.ToString(iHora).PadLeft(2, '0') + ":00";
            MetadiaLogica mdia = new MetadiaLogica();
            mdia.Hora = _lsHrReg;
            if (MetadiaLogica.Verificar(mdia))
                return;

            string sHrFile = DateTime.Now.Hour.ToString();

            iHora += 2;//CT zone

            if (iHora < 12)
                sHrFile = iHora.ToString() + "am";
            else
            {
                if (iHora > 23)
                {
                    if (iHora == 24)
                        iHora = 12;
                    else
                        iHora -= 24;
                    sHrFile = iHora.ToString() + "am";
                }
                else
                {
                    if (iHora > 12)
                        iHora -= 12;
                    sHrFile = iHora.ToString() + "pm";
                }
            }


            string sArchivo = _lsSynFile + sHrFile + ".xlsx";
            string sFile = _lsSynURL + @"\" + sArchivo;
            if(!File.Exists(sFile))
                return;
            else
            {
                if (!FileLocked(sFile))
                    dtData = CargarArchivo(sFile);

                File.Delete(sFile);
            }
            // SAVE DATA
            if (dtData.Rows.Count > 0)
            {
                DataTable dtMt = new DataTable("Metadet");
                dtMt.Columns.Add("folio", typeof(long));
                dtMt.Columns.Add("consec", typeof(int));
                dtMt.Columns.Add("Usuario", typeof(string));
                dtMt.Columns.Add("Planta", typeof(string));
                dtMt.Columns.Add("Linea", typeof(string));
                dtMt.Columns.Add("Meta", typeof(double));
                dtMt.Columns.Add("Real", typeof(double));

                dtMt = CargarMT(dtData,dtMt);

                if(dtMt.Rows.Count > 0)
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        long lFolio = AccesoDatos.Consec(_lsProceso);
                        double dMetaGlob = 0;
                        double dRealGlob = 0;
                        for (int x = 0; x < dtMt.Rows.Count; x++)
                        {
                            double dMeta = Convert.ToDouble(dtMt.Rows[x][5].ToString());
                            double dReal = Convert.ToDouble(dtMt.Rows[x][6].ToString());
                            dMetaGlob += dMeta;
                            dRealGlob += dReal;
                        }

                        MetadiaLogica met = new MetadiaLogica();
                        met.Folio = lFolio;
                        met.Fecha = DateTime.Today;
                        if(DateTime.Now.Hour < 5)
                            met.Fecha = DateTime.Today.AddDays(-1);
                        met.Planta = _lsPlanta;
                        met.Turno = _lsTurno;
                        met.Hora = _lsHrReg;
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
                        for (int x=0; x < dtMt.Rows.Count; x++)
                        {
                            string sUsuario = dtMt.Rows[x][2].ToString();
                            string sPlanta = dtMt.Rows[x][3].ToString();
                            string sLinea = dtMt.Rows[x][4].ToString();
                            double dMeta = Convert.ToDouble(dtMt.Rows[x][5].ToString());
                            double dReal = Convert.ToDouble(dtMt.Rows[x][6].ToString());
                            if (dMeta == 0)
                                dMeta = dReal;

                            if (_lsTurno == "2")
                            {
                                Metadet2Logica met2 = new Metadet2Logica();
                                met2.Usuario = sUsuario;

                                DataTable dtAnt = Metadet2Logica.Consultar(met2);
                                if (dtAnt.Rows.Count > 0)
                                {
                                    double dRealAnt = double.Parse(dtAnt.Rows[0][3].ToString());
                                    dReal -= dRealAnt;
                                }
                            }

                            string sRamp = string.Empty;
                            double dRampeo = 0;
                            UsuarioLogica user = new UsuarioLogica();
                            user.Usuario = sUsuario;
                            DataTable dtU = UsuarioLogica.Consultar(user);
                            sRamp = dtU.Rows[0]["ind_ramp"].ToString();
                            if (sRamp == "1")
                                dRampeo = double.Parse(dtU.Rows[0]["rampeo"].ToString());

                            if (dRampeo > 0)
                            {
                                dRampeo = dRampeo / 100;
                                double dRa = dMeta * dRampeo;
                                dMeta = dMeta - dRa;
                            }
                            if (dReal < 0)
                                dReal = 0;
                               
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
                            med.Porcen = Math.Round(dPorc, 2);
                            
                            if (MetadetLogica.Guardar(med) == 0)
                            {
                                MessageBox.Show("Error al intentar guardar la Linea", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                        Cursor = Cursors.Default;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        protected virtual bool FileLocked(string _asFile)
        {
            try
            {
                using (Stream stream = new FileStream(_asFile, FileMode.Open))
                    stream.Close();

            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
        private DataTable CargarMT(DataTable _dtDatos,DataTable _dtMT)
        {
            Cursor = Cursors.WaitCursor;
            int iCont = 0;

            try
            {
                string sMensaje = string.Empty;
                for (int row=0; row < _dtDatos.Rows.Count; row++)
                {

                    if (string.IsNullOrEmpty(_dtDatos.Rows[row][0].ToString()))
                        continue;

                    string sUser = _dtDatos.Rows[row][0].ToString();

                    if (sUser.StartsWith("Location"))
                        continue;

                    if (sUser.StartsWith("MX03"))
                        continue;

                    string sCant = _dtDatos.Rows[row][1].ToString();

                    double dReal = 0;
                    if (!double.TryParse(sCant, out dReal))
                        dReal = 0;

                    UsuarioLogica user = new UsuarioLogica();
                    user.Usuario = sUser;
                    user.Turno = _lsTurno;
                    if (UsuarioLogica.VerificarTurno(user))
                    {
                        DataTable dtU = UsuarioLogica.Consultar(user);
                        string sPlanta = dtU.Rows[0]["planta"].ToString();
                        if (sPlanta == "LAS")
                        {
                            _dtMT = GeneraReporte(sUser, dReal, _dtMT);
                            iCont++;
                        }
                    }
                    else
                    {
                        if(_lsTurno == "1")
                        {
                            Metadet2Logica met2 = new Metadet2Logica();
                            met2.Usuario = sUser;
                            met2.Real = dReal;
                            Metadet2Logica.Guardar(met2);
                        }

                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
                return _dtMT;
            }
                        
            Cursor = Cursors.Default;
            return _dtMT;
        }
        private DataTable GeneraReporte(string _asUser, double _dReal,DataTable _dt)
        {
            try
            {
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
                lins.Turno = _lsTurno;
                DataTable dtStd = LinestdLogica.ConsultarTurno(lins);

                double dMeta = 0;
                for (int x = 0; x < dtStd.Rows.Count; x++)
                {

                    string sNombre = dtStd.Rows[x][3].ToString();
                    double dEstd = 0;
                    if (!double.TryParse(dtStd.Rows[x][4].ToString(), out dEstd))
                        dEstd = 0;

                    dMeta += dEstd;
                    if (_lsHrReg.Substring(0,2) == sNombre.Substring(0,2))
                    {
                        // GUARDAR REGISTRO <>>
                        //AgregaLinea(_asUser, sPlanta, sLinea, dMeta, _dReal);
                        _dt.Rows.Add(0, 0, _asUser, sPlanta, sLinea, dMeta, _dReal);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de notificar al Administrador" + Environment.NewLine + ex.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return _dt;
            }
            return _dt;
        }
        private DataTable CargarArchivo(string _asArchivo)
        {
            DataTable dtDatos = new DataTable("Daily");
            try
            {
                //dgwDatos.DataSource = null;
                //CargarColFile();
                dtDatos.Columns.Add("usuario", typeof(string));
                dtDatos.Columns.Add("real", typeof(double));

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
                            dtDatos.Rows.Add(sUsuario,dReal);
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

            return dtDatos;
        }

        private DataTable ImportarDatos(string _asPlanta, string _asArea, string _asGlobal)
        {
            DataTable dt = new DataTable();
            try
            {
                bool bInicial = false;
                //lineas de seccion 3 de laser
                DataTable dtLine = new DataTable();
                LineaLogica line = new LineaLogica();
                line.Planta = _asPlanta;
                line.Area = _asArea;
                line.Global = _asGlobal;
                dtLine = LineaLogica.ConsultarArea(line);

                dt.Columns.Add("linea", typeof(string));
                dt.Columns.Add("meta", typeof(string));
                dt.Columns.Add("real", typeof(string));
                dt.Columns.Add("cump", typeof(string));

                //ultimo reporte cargado de cesapp
                MetadiaLogica met = new MetadiaLogica();
                met.Planta = _asPlanta;
                met.Turno = Global.gsTurno;
                //CultureInfo en = new CultureInfo("en-US");
                met.Fecha = DateTime.Today;
                if (DateTime.Now.Hour < 5)
                    met.Fecha = DateTime.Today.AddDays(-1);

                long lFolio = MetadiaLogica.LastFolioDia(met);

                if (lFolio == 0)
                {
                    if(_lsDiaAnt == "1")
                        lFolio = MetadiaLogica.LastFolio(met);
                    else
                        return dt;
                    //cargar meta sin saldo
                    //bInicial = true;
                }
                met.Folio = lFolio;
                DataTable dtHora = MetadiaLogica.Consultar(met);
                _lsHora = dtHora.Rows[0]["hora"].ToString();

                if (_lsDiaAnt == "1")
                    _lsHora = dtHora.Rows[0]["f_id"].ToString();

                //cargar datos de daily processing
                DataTable dtDaily = new DataTable();
                MetadetLogica med = new MetadetLogica();
                med.Folio = lFolio;
                med.Global = _asGlobal;
                med.Area = _asArea;
                dtDaily = MetadetLogica.VistaGrafica(med);
                foreach(DataRow row in dtDaily.Rows)
                {
                    DataRow r = dt.NewRow();
                    //string sUsuario = row[0].ToString();
                    string sMT = row[0].ToString();
                    double dMeta = Convert.ToDouble(row[1].ToString());
                    double dReal = Convert.ToDouble(row[2].ToString());

                    double dPorc = dReal / dMeta;
                    dPorc = dPorc * 100;
                    dPorc = Math.Round(dPorc, 2);

                    r[0] = sMT;
                    r[1] = dMeta.ToString();
                    r[2] = dReal.ToString();
                    r[3] = dPorc.ToString();
                    dt.Rows.Add(r);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Archivo sin formato Estandar" + Environment.NewLine + "ImportarDatosTxt.." + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return dt;
        }
        private DataTable ImportarDatosTxt(string _asPlanta, string _asArea, string _asGlobal)
        {
            DataTable dt = new DataTable();
            try
            {
                //lineas de seccion 3 de laser
                DataTable dtLine = new DataTable();
                LineaLogica line = new LineaLogica();
                line.Planta = _asPlanta;
                line.Area = _asArea;
                line.Global = _asGlobal;
                dtLine = LineaLogica.ConsultarArea(line);
                
                dt.Columns.Add("linea", typeof(string));
                dt.Columns.Add("meta", typeof(string));
                dt.Columns.Add("real", typeof(string));
                dt.Columns.Add("cump", typeof(string));

                string sFile = _lsURL + @"\" + _lsFile;

                string[] records = File.ReadAllLines(sFile);
                DateTime lastModified = File.GetLastWriteTime(sFile);
                _sFechaMod = lastModified.ToString();

                foreach (string record in records)
                {
                    DataRow r = dt.NewRow();
                    string[] fields = record.Split('\t');

                    if (string.IsNullOrEmpty(fields[0].ToString()))
                        continue;

                    string sMT = fields[0].ToString();
                    string sMeta = fields[1].ToString().TrimStart().TrimEnd();
                    string sReal = fields[2].ToString().TrimStart().TrimEnd();

                    if (sMT != "TOTAL")
                        sMeta = sMeta.Replace(",", "");

                    int iCant = 0;
                    if (!int.TryParse(sMeta, out iCant))
                        iCant = 0;

                    string sCump = fields[3].ToString().TrimStart().TrimEnd();
                    sCump = sCump.Replace("%", "");

                    double dCant = 0;
                    if (!double.TryParse(sCump, out dCant))
                        continue;

                    foreach (DataRow row in dtLine.Rows)
                    {
                        string sLinea = row[1].ToString();
                        if (sLinea == sMT || sMT == "TOTAL")
                        {
                            r[0] = sMT;
                            r[1] = sMeta;
                            r[2] = sReal;
                            r[3] = sCump;
                            dt.Rows.Add(r);
                            break;
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Archivo sin formato Estandar" + Environment.NewLine + "ImportarDatosTxt.." + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return dt;
        }

        #endregion

        private void CargarDatos()
        {
            try
            {
                if (_lbLoadFile)
                    DailyProcessing();

                DataTable datos = new DataTable();

                string sMetaGlobal = string.Empty;
                string sRealGlobal = string.Empty;
                string sCumpTotal = string.Empty;


                
                chtBarras1.Series[0].Points.Clear();
                chtBarras1.Palette = ChartColorPalette.SeaGreen;
                chtBarras1.Annotations.Clear();

                chtPastel.Series[0].Points.Clear();

                datos = ImportarDatos(_lsPlanta, _lsArea, _lsGlobal);
                if (datos.Rows.Count != 0)
                {
                    if (string.IsNullOrEmpty(_lsHora))
                        chtBarras1.Series[0].LegendText = _lsPlanta;
                    else
                        chtBarras1.Series[0].LegendText = _lsHora;
                    
                    //chtBarras1.Series[0].Legend
                    /*
                    chtBarras1.Palette = ChartColorPalette.SeaGreen;
                    chtBarras1.Annotations.Clear();
                    */
                    chtBarras1.ChartAreas["ChartArea1"].AxisX.Title = "HORA POR HORA";
                    chtBarras1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Calibri", 14, FontStyle.Bold);
                    chtBarras1.ChartAreas["ChartArea1"].AxisY.Title = "PORCENTAJE DE PRODUCCION";
                    //chtBarras1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
                    chtBarras1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Calibri", 14, FontStyle.Bold);

                    double dMetaGlobal = 0;
                    double dRealGlobal = 0;


                    ///////////////////////////////////////////////////
                    int cont = 0;
                    for (int x = 0; x <datos.Rows.Count; x++)
                    {
                        int band = 0;

                        for(int y = _rangoInicial; y <= _rangoFinal; y++)
                        {
                            string linea = "";
                            if (y < 10) linea = "0" + y;
                            else linea = y.ToString();

                            if (datos.Rows[x][0].ToString().EndsWith(linea))
                            {
                                band = 1;
                                break;
                            }                            
                        }

                        if (band == 0) continue;

                        string sCump = datos.Rows[x][3].ToString().Trim();
                        double dCump = 0;
                        if (!double.TryParse(sCump, out dCump))
                            continue;

                        //BARRAS
                        chtBarras1.Series[0].Points.AddXY(datos.Rows[x][0].ToString(), datos.Rows[x][3].ToString());
                        chtBarras1.Series[0].Points[cont].Label = sCump + "%";
                        chtBarras1.Series[0].Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
                        chtBarras1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Calibri", 14F, FontStyle.Bold);
                        chtBarras1.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
                        chtBarras1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Caliri", 12F, FontStyle.Bold);
                        //chtBarras1.ChartAreas[0].AxisX.LabelStyle.Angle = new AxisScrollBar

                        TextAnnotation tA = new TextAnnotation();
                        tA.Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
                        double dPorcj = double.Parse(datos.Rows[x][2].ToString());
                        tA.Text = (String.Format("{0:0,0}", dPorcj));
                        tA.SetAnchor(chtBarras1.Series[0].Points[cont]);
                        chtBarras1.Annotations.Add(tA);
                        
                        if (dCump > _ldPorcStd)
                        {
                            chtBarras1.Series[0].Points[cont].Color = Color.LightGreen;
                        }
                        else
                        {
                            chtBarras1.Series[0].Points[cont].Color = Color.PaleVioletRed;
                            //chtBarras1.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = Color.PaleVioletRed;
                            //chtBarras1.ChartAreas[0].AxisX[x].LabelStyle.ForeColor = Color.PaleVioletRed;
                        }
                            

                        chtBarras1.Series[0].SmartLabelStyle.Enabled = true;
                        chtBarras1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                        chtBarras1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                        chtBarras1.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
                        chtBarras1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep45;
                        
                        double dMeta = 0;
                        double dReal = 0;
                        if (double.TryParse(datos.Rows[x][1].ToString(), out dMeta))
                            dMetaGlobal += dMeta;
                        if (double.TryParse(datos.Rows[x][2].ToString(), out dReal))
                            dRealGlobal += dReal;

                        cont++;
                    }

                   
  
                    ///////////////////////////////////////////////////

                    sMetaGlobal = String.Format("{0:0,0}", dMetaGlobal);
                    chtBarras1.Titles.Clear();
                    chtBarras1.Titles.Add("META: " + sMetaGlobal);
                    chtBarras1.Titles[0].ForeColor = Color.White;
                    chtBarras1.Titles[0].Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);

                    //PASTEL
                    chtPastel.Series[0].Points.Clear();
                    double dFalt = 0;
                    double dCumpTotal = 0;
                    dCumpTotal = dRealGlobal / dMetaGlobal;
                    dCumpTotal = Math.Round(dCumpTotal, 2);
                    dCumpTotal = dCumpTotal * 100;

                    if (dRealGlobal < dMetaGlobal)
                        dFalt = dMetaGlobal - dRealGlobal;
                    else
                        dFalt = 0;

                    chtPastel.Series[0].Points.AddXY("REAL", dCumpTotal);
                    chtPastel.Series[0].Points[0].Label = "REAL HORA X HORA" + Environment.NewLine + dCumpTotal.ToString() + "%" + Environment.NewLine + String.Format("{0:0,0}", dRealGlobal);
                    chtPastel.Series[0].Points[0].LegendText = "REAL";
                    double dPorc = 0;
                    if (dFalt > 0)
                    {
                        dPorc = dFalt / dMetaGlobal;
                        dPorc = dPorc * 100;
                        dPorc = Math.Round(dPorc, 2);
                    }
                    string sPorc = dPorc.ToString();
                    string sFalt = String.Format("{0:0,0}", dFalt);
                    chtPastel.Series[0].Points.AddXY("FALTANTE", sPorc);
                    chtPastel.Series[0].Points[1].Label = "FALTANTE" + Environment.NewLine + sPorc + "%" + Environment.NewLine + sFalt;
                    chtPastel.Series[0].Points[1].LegendText = "FALTANTE";


                    if (dCumpTotal >= _ldPorcStd)
                        chtPastel.Series[0].Points[1].Color = Color.LightGreen;
                    else
                        chtPastel.Series[0].Points[1].Color = Color.OrangeRed;

                    chtPastel.Titles.Clear();
                    chtPastel.Titles.Add("META: " + sMetaGlobal);
                    chtPastel.Titles[0].ForeColor = Color.White;
                    chtPastel.Titles[0].Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);

                    chtPastel.Series[0].SmartLabelStyle.Enabled = true;
                    chtPastel.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
                    chtPastel.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
                }
                else
                {
                    chtBarras1.Series[0].Points.Clear();
                    //MessageBox.Show("No se encontro informacion para mostrar", "CloverCES Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Dashboard" + Environment.NewLine + "LoadChart.." + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
            
        private void timer2_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CargarDatos();
            if (chtBarras1.Visible)
            {
                chtBarras1.Visible = false;
                chtPastel.Visible = true;
                timer3.Start();
            }
            else
            {
                chtPastel.Visible = false;
                chtBarras1.Visible = true;
                timer3.Stop();
            }
                
        }

        private void wfDashboard_Resize(object sender, EventArgs e)
        {

            if (WindowState != _WindowStateAnt && WindowState != FormWindowState.Minimized)
            {
                _WindowStateAnt = WindowState;

                ResizeControl(panel1, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(chtBarras1, 3, ref _iWidthAnt, ref _iHeightAnt, 0);
                ResizeControl(chtPastel, 3, ref _iWidthAnt, ref _iHeightAnt, 1);

                int iW = this.Width - 70;
                btnClose.Location = new Point(iW, btnClose.Location.Y);

                int iW2 = lblHora.Width;
                iW2 = iW2 / 2;
                int iWt = this.Width / 2;
                iWt = iWt - iW2;

                int iH = this.Height;
                int iY = iH - 100;
                iWt = this.Width - 270;
                lblHora.Location = new Point(iWt, iY);

                iY = iH - 70;
                btnConf.Location = new Point(iW, iY);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chtBarras1.Visible)
            {
                chtBarras1.Visible = false;
                chtPastel.Visible = true;
            }
            else
            {
                chtPastel.Visible = false;
                chtBarras1.Visible = true;
            }
        }

        private void btnConf_Click(object sender, EventArgs e)
        {
            wfConfig Conf = new wfConfig();
            Conf.ShowDialog();
            Inicio();
        }

        private void wfDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            
        }

        private void wfDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Dispose();
            timer1 = null;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (chtPastel.Visible)
            {
                chtPastel.Visible = false;
                chtBarras1.Visible = true;
                timer3.Stop();
            }
            else
            {
                chtBarras1.Visible = false;
                chtPastel.Visible = true;
            }
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            if (ControlBox.Equals(false)) {

                ControlBox = true;
                btn_lock.BackgroundImage = Properties.Resources.Unlock;
            }
            else
            {
                ControlBox = false;
                btn_lock.BackgroundImage = Properties.Resources.Padlock;
                this.WindowState = FormWindowState.Maximized;
            }
          
        }
    }
}
