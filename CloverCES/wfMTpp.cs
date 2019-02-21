using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Logica;
using Tulpep.NotificationWindow;

namespace CloverCES
{
    public partial class wfMTpp : Form
    {
        private double _ldPorcStd;
        public wfMTpp()
        {
            InitializeComponent();
        }
        private void wfMTpp_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }
        private void wfMTpp_Load(object sender, EventArgs e)
        {
            Inicio();
        }
        private void Inicio()
        {
            try
            {
                DataTable dtConf = ConfigLogica.Consultar();
                _ldPorcStd = Double.Parse(dtConf.Rows[0]["porc_std"].ToString());

                progressBar1.Style = ProgressBarStyle.Continuous;

                EstacionLogica est = new EstacionLogica();
                est.Linea = Global.gsEstacion;

                //if (EstacionLogica.VerificarMaq(est))

                UsuarioLogica user = new UsuarioLogica();
                user.Usuario = Global.gsUsuario;
                if (UsuarioLogica.VerificarOperador(user))
                {

                    DataTable data = UsuarioLogica.Consultar(user);
                    string sLinea = data.Rows[0]["linea"].ToString();

                    //data = EstacionLogica.ConsultarLinea(est);
                    //string sLinea = data.Rows[0]["estacion"].ToString();

                    string sComp = string.Empty;

                    sComp = ImportarDatos(sLinea);
                    
                    if (!string.IsNullOrEmpty(sComp))
                    {
                        btnMT.Text = sLinea;
                        btnPorc.Text = sComp + "%";
                        double dVal = Math.Round(double.Parse(sComp), 0);
                        if (dVal < 0)
                            dVal = 0;
                        if (dVal > 100)
                            dVal = 100;
                        
                        if (dVal >= _ldPorcStd)
                        {
                            btnMT.ForeColor = Color.PaleGreen;
                        }
                        else
                        {
                            btnMT.ForeColor = Color.Crimson;
                        }
                            

                        int iVal = 0;
                        if (int.TryParse(Convert.ToString(dVal), out iVal))
                        {
                            progressBar1.Value = (int)dVal;
                        }
                    }
                    else
                        Close();
                }
                else
                    Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Inicio()" + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void MotrarNotifiacion(string asLinea, string asHora,string asPrc)
        {
            PopupNotifier pNoti = new PopupNotifier();
            pNoti.Image = Properties.Resources.Notiicon;
            pNoti.TitleText = "Porcentaje de Produccion " + asHora;
            pNoti.ContentText = "Linea " + asLinea + " | Porcentaje: " + asPrc.ToString();
            pNoti.Popup();
        }
        private string ImportarDatos(string _asLinea)
        {
            string sReturn = string.Empty;
            try
            {
                //lineas de seccion 3 de laser
                DataTable dtLine = new DataTable();
                LineaLogica line = new LineaLogica();
                line.Linea = _asLinea;
                dtLine = LineaLogica.ConsultarLine(line);
                string sPlanta = dtLine.Rows[0]["planta"].ToString();

                /****/
                //Notifiaciones pendientes
                MetadetLogica med = new MetadetLogica();
                med.Planta = sPlanta;
                med.Linea = _asLinea;
                long lFolio = 0;
                DataTable data = MetadetLogica.ConsultarNoti(med);
                for(int i = 0; i < data.Rows.Count; i++)
                {
                    //enviar notificacion por carga pendiente
                    lFolio = long.Parse(data.Rows[i]["folio"].ToString());
                    int iCons = int.Parse(data.Rows[i]["consec"].ToString());
                    string sHora = data.Rows[i]["hora"].ToString();
                    double dMta = double.Parse(data.Rows[i]["meta"].ToString());
                    double dRel = double.Parse(data.Rows[i]["real"].ToString());
                    double dPrc = (dMta / dRel) *100;
                    dPrc = Math.Round(dPrc, 2);
                    string sPorc = dPrc.ToString() + " %";

                    MotrarNotifiacion(_asLinea, sHora, sPorc);
                }

                //ultimo reporte cargado de cesapp
                MetadiaLogica met = new MetadiaLogica();
                met.Planta = sPlanta;
                met.Turno = Global.gsTurno;
                met.Fecha = DateTime.Today;
                lFolio = MetadiaLogica.LastFolio(met);
                if (lFolio == 0)
                    return sReturn;

                met.Folio = lFolio;
                
                //cargar datos de daily processing
                DataTable dtDaily = new DataTable();
                MetadetLogica med2 = new MetadetLogica();
                med2.Folio = lFolio;
                med2.Linea = _asLinea;
                dtDaily = MetadetLogica.VistaIndividual(med2);
                if (dtDaily.Rows.Count > 0)
                {
                    double dMeta = Double.Parse(dtDaily.Rows[0]["meta"].ToString());
                    double dReal = Double.Parse(dtDaily.Rows[0]["real"].ToString());
                    double dPorc = dReal / dMeta;
                    dPorc = dPorc * 100;
                    dPorc = Math.Round(dPorc, 2);
                    sReturn = dPorc.ToString();
                }

                return sReturn;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Archivo sin formato Estandar" + Environment.NewLine + "ImportarDatosTxt.." + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return sReturn;
        }

        private string ImportarDatosTxt(string _asLinea)
        {
            string sReturn = string.Empty;
            try
            {
                DataTable dtConf = ConfigLogica.Consultar();
                string sURL = dtConf.Rows[0]["ruta_laser"].ToString();
                string sFile = dtConf.Rows[0]["laser_file"].ToString();
                sFile = sURL + @"\" + sFile;

                string[] records = File.ReadAllLines(sFile);
                foreach (string record in records)
                {
                    string[] fields = record.Split('\t');
                    string sMT = fields[0].ToString();
                    if (_asLinea != sMT)
                        continue;

                    string sMeta = fields[1].ToString().TrimStart().TrimEnd();
                    string sReal = fields[2].ToString().TrimStart().TrimEnd();
                    sMeta = sMeta.Replace(",", "");
                    int iCant = 0;
                    if (!int.TryParse(sMeta, out iCant))
                        continue;

                    string sCump = fields[3].ToString().TrimStart().TrimEnd();
                    sCump = sCump.Replace("%", "");

                    double dCant = 0;
                    if (double.TryParse(sCump, out dCant))
                    {
                        dCant = Math.Round(dCant, 2);
                        sReturn = Convert.ToString(dCant);
                    }
                    
                    return sReturn;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Favor de Notificar al Administrador" + Environment.NewLine + "Archivo sin formato Estandar" + Environment.NewLine + "ImportarDatos(" + _asLinea + ") ..." + ex.ToString(), "ERROR " + Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return sReturn;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Inicio();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
