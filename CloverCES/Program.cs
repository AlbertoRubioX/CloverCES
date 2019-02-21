using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Logica;

namespace CloverCES
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Global.gsUsuario = Environment.UserName.ToString().ToUpper();
            Global.gsEstacion = Environment.MachineName.ToString().ToUpper();

            LineaLogica lin = new LineaLogica();
            lin.Nombre = Global.gsEstacion;

            Global.Turno();
            UsuarioLogica user = new UsuarioLogica();
            user.Usuario = Global.gsUsuario;


            //if (LineaLogica.VerificarMaq(lin))
            if (UsuarioLogica.VerificarOperador(user))
                Application.Run(new wfMTpp()); //Line monitor
            else
            {
                AreaLogica area = new AreaLogica();
                area.Estacion = Global.gsEstacion;
                if(AreaLogica.VerificarEstacion(area))
                {
                    Application.Run(new wfDashboard()); //Area dashboard
                }
                else
                {
                    DataTable dtConf = ConfigLogica.Consultar();
                    string sMonLaser = dtConf.Rows[0]["monitor_laser"].ToString();
                    //sMonLaser = "MEXI0848";
                    if (Global.gsEstacion == sMonLaser)
                    {
                        Application.Run(new wfDashboard()); //Area dashboard
                    }
                    else
                        Application.Run(new wfMainMenu());
                }
            }
        }
    }
}
