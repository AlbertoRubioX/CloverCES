using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class ConfigLogica
    {
        public string Clave { get; set; }
        public string Ruta { get; set; }
        public string Laser { get; set; }
        public double RotMin { get; set; }
        public double MargenW { get; set; }
        public double MargenH { get; set; }
        public double PaddingX { get; set; }
        public double PaddingY { get; set; }
        public double MargenW1 { get; set; }
        public double MargenH1 { get; set; }
        public double PorcStd { get; set; }

        public static int Guardar(ConfigLogica conf)
        {
            string[] parametros = { "@Clave", "@Ruta", "@Laser", "@RotMin", "@MargenW", "@MargenH", "@PaddingX", "@PaddingY", "@MargenW1", "@MargenH1", "@PorcStd" };
            return AccesoDatos.Actualizar("sp_mant_config", parametros, conf.Clave, conf.Ruta, conf.Laser, conf.RotMin, conf.MargenW, conf.MargenH, conf.PaddingX,conf.PaddingY,conf.MargenW1,conf.MargenH1,conf.PorcStd);
        }

        public static DataTable Consultar()
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_config WHERE clave = '01'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

    }
}
