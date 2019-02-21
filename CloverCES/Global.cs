using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloverCES
{
    public class Global
    {
        public static string gsUsuario;
        public static string gsNivel;
        public static string gsVersion;
        public static string gsEstacion;
        public static string gsPlanta;
        public static string gsArea;
        public static string gsTurno;
        public static string gsNombreUs;
        public static bool gbCambio;

        public static void Turno()
        {

            DateTime dtFecha = DateTime.Now;
            if (dtFecha.Hour >= 5 && dtFecha.Hour <= 16)
            {
                gsTurno = "1";
            }
            else
                gsTurno = "2";
        }
    }
}
