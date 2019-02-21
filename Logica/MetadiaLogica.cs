using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Data;
using Datos;
namespace Logica
{
    public class MetadiaLogica
    {
        public long Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string Planta { get; set; }
        public string Turno { get; set; }
        public string Hora { get; set; }
        public double Meta { get; set; }
        public double Real { get; set; }
        public string Usuario { get; set; }
        public static int Guardar(MetadiaLogica met)
        {
            string[] parametros = { "@Folio", "@Fecha", "@Planta", "@Turno", "@Hora", "@Meta", "@Real", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_metadia", parametros, met.Folio, met.Fecha, met.Planta, met.Turno, met.Hora, met.Meta, met.Real, met.Usuario);
        }
        
        public static DataTable Consultar(MetadiaLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_metadia WHERE folio = "+ met.Folio+"");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        
        public static bool Verificar(MetadiaLogica met)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_metadia WHERE cast(fecha as date) = cast('"+DateTime.Today+"' as date) and hora = '" + met.Hora+ "' ";
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
        
        public static DataTable Listar(MetadiaLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * from t_metadia");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static long LastFolio(MetadiaLogica met)
        {
            long lFolio;
            try
            {
                DataTable datos = new DataTable();                
                datos = AccesoDatos.Consultar("SELECT max(folio) from t_metadia where planta = '" + met.Planta + "' ");
                if (datos.Rows.Count > 0)
                {
                    if (!long.TryParse(datos.Rows[0][0].ToString(), out lFolio))
                        lFolio = 0;
                }
                else
                    lFolio = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lFolio;
        }
        public static long LastFolioDia(MetadiaLogica met)
        {
            long lFolio;
            try
            {
                DataTable datos = new DataTable();
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                DateTime dt = met.Fecha;
                string sFecha = dt.ToString("d");
                datos = AccesoDatos.Consultar("SELECT max(folio) from t_metadia where planta = '" + met.Planta + "' and fecha = CAST('" + sFecha + "' AS Date) and turno = '" + met.Turno + "' ");
                //datos = AccesoDatos.Consultar("SELECT max(folio) from t_metadia where planta = '" + met.Planta + "' ");
                if (datos.Rows.Count > 0)
                {
                    if (!long.TryParse(datos.Rows[0][0].ToString(), out lFolio))
                        lFolio = 0;
                }
                else
                    lFolio = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lFolio;
        }

        public static DataTable Reporte()
        {
            DataTable datos = new DataTable();
            try
            {
                string[] parametros = { };
                datos = AccesoDatos.ConsultaSP("sp_rep_metadia", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datos;
        }
    }
}
