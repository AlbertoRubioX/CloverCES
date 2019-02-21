using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class AreaLogica
    {
        public string Area { get; set; }
        public string Planta { get; set; }
        public string Estacion { get; set; }
        public string Global { get; set; }

        public static int Guardar(AreaLogica area)
        {
            string[] parametros = { "@Area", "@Planta", "@Estacion", "@Global" };
            return AccesoDatos.Actualizar("sp_mant_areas", parametros, area.Area, area.Planta, area.Estacion, area.Global);
        }

        public static DataTable Consultar(AreaLogica area)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_areas WHERE area = '" + area.Area + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ConsultarEstacion(AreaLogica area)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_areas WHERE estacion = '" + area.Estacion + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static bool Verificar(AreaLogica area)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_areas WHERE area = '" + area.Area + "' and planta = '"+area.Planta+"'";
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
        
        public static bool VerificarEstacion(AreaLogica area)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_areas WHERE estacion = '" + area.Estacion + "'";
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
        public static DataTable Listar()
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_areas");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ListarPlanta(AreaLogica area)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_areas where planta = '"+area.Planta+"' order by area");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }


        public static bool Eliminar(AreaLogica area)
        {
            try
            {
                string sQuery = "DELETE FROM t_areas WHERE area = '" + area.Area + "'";
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
