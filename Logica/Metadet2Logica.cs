using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class Metadet2Logica
    {
       
        public string Usuario { get; set; }
        public string Planta { get; set; }
        public double Real { get; set; }
       
        public static int Guardar(Metadet2Logica met)
        {
            string[] parametros = { "@Usuario", "@Real" };
            return AccesoDatos.Actualizar("sp_mant_metadet2", parametros, met.Usuario, met.Real);
        }

        public static DataTable Consultar(Metadet2Logica met)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_metadet2 WHERE usuario = '" + met.Usuario + "' and cast(fecha as date) = cast('" + DateTime.Today + "' as date)");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }


        public static bool Verificar(Metadet2Logica met)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_metadet2 WHERE usuario = '" + met.Usuario+ "' and cast(fecha as date) = cast('" + DateTime.Today + "' as date)";
                DataTable datos = AccesoDatos.Consultar(sQuery);
                if (datos.Rows.Count != 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
