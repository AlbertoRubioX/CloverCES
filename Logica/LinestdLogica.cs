using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class LinestdLogica
    {
        public string Linea { get; set; }
        public int Consec { get; set; }
        public string Turno { get; set; }
        public string Nombre { get; set; }
        public double Estandar { get; set; }
        public static int Guardar(LinestdLogica line)
        {
            string[] parametros = { "@Linea", "@Consec", "@Turno", "@Nombre", "@Estandar" };
            return AccesoDatos.Actualizar("sp_mant_linestd", parametros, line.Linea, line.Consec, line.Turno, line.Nombre, line.Estandar);
        }
        
        public static DataTable Consultar(LinestdLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_linestd WHERE linea = '"+ line.Linea+"'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ConsultarTurno(LinestdLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_linestd WHERE linea = '"+line.Linea+"' and turno= '"+line.Turno+"' ORDER BY consec");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(LinestdLogica line)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_linestd WHERE linea = '" + line.Linea + "' and consec = "+line.Consec+"";
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
        
        public static DataTable Listar(LinestdLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT linea,consec,turno,nombre as Hora,estandar as Meta FROM t_linestd where linea='"+line.Linea+"' and turno='"+line.Turno+"' order by nombre");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        
        public static bool Eliminar(LinestdLogica line)
        {
            try
            {
                string sQuery = "DELETE FROM t_linestd WHERE linea = '" + line.Linea + "' and consec="+line.Consec+"";
                if (AccesoDatos.Borrar(sQuery) != 0)
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
