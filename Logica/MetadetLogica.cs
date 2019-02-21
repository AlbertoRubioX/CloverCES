using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class MetadetLogica
    {
        public long Folio { get; set; }
        public int Consec { get; set; }
        public string Usuario { get; set; }
        public string Planta { get; set; }
        public string Linea { get; set; }
        public double Meta { get; set; }
        public double Real { get; set; }
        public double Porcen { get; set; }
        public string Global { get; set; }
        public string Area { get; set; }
        public static int Guardar(MetadetLogica met)
        {
            string[] parametros = { "@Folio", "@Consec", "@Usuario", "@Planta", "@Linea",  "@Meta", "@Real", "@Porcentaje" };
            return AccesoDatos.Actualizar("sp_mant_metadet", parametros, met.Folio, met.Consec, met.Usuario, met.Planta, met.Linea, met.Meta, met.Real, met.Porcen);
        }
        
        public static DataTable Consultar(MetadetLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_metadet WHERE folio = "+ met.Folio+"");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static DataTable ConsultarNoti(MetadetLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                string sSql = "SELECT md.folio,md.consec, mt.hora, md.meta,md.real FROM t_metadet md inner join t_metadia mt on md.folio = mt.folio  "+
                "WHERE md.planta = '"+met.Planta+"' and md.linea = '"+met.Linea+"'  and cast(mt.fecha as date) = cast(getdate() as date) and md.ind_noti = '0'";
                datos = AccesoDatos.Consultar(sSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(MetadetLogica met)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_metadet WHERE folio = " + met.Folio + " and consec = "+met.Consec+"";
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
        
        public static DataTable Listar(MetadetLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * from t_metadet");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable VistaGrafica(MetadetLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                string sSql = "SELECT md.linea,md.meta,SUM(md.real) FROM t_metadet md INNER JOIN t_lineas li on md.linea = li.linea ";
                sSql +="WHERE md.folio = "+met.Folio+" and('"+met.Global+"' = '1' or('"+met.Global+"' = '0' and li.area = '"+met.Area+ "')) GROUP BY md.linea,md.meta ORDER BY md.linea";
                datos = AccesoDatos.Consultar(sSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable VistaIndividual(MetadetLogica met)
        {
            DataTable datos = new DataTable();
            try
            {
                string sSql = "SELECT meta,sum(real) as real FROM t_metadet md WHERE folio = " + met.Folio + " and linea='"+met.Linea+ "' GROUP BY meta"; 
                datos = AccesoDatos.Consultar(sSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
    }
}
