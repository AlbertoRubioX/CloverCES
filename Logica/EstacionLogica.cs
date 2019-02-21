using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class EstacionLogica
    {
        public string Estacion { get; set; }
        public string Planta { get; set; }
        public string Linea { get; set; }
        public string Proceso { get; set; }
        public string Area { get; set; }
        public string Usuario { get; set; }

        public static int Guardar(EstacionLogica est)
        {
            string[] parametros = { "@Estacion", "@Planta", "@Linea", "@Proceso", "@Area", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_estacion", parametros, est.Estacion, est.Planta, est.Linea, est.Proceso, est.Area, est.Usuario);
        }

        public static DataTable Consultar(EstacionLogica est)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_estacion WHERE estacion = '" + est.Estacion + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ConsultarLinea(EstacionLogica est)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_estacion WHERE maquina = '" + est.Linea + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(EstacionLogica est)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_estacion WHERE estacion = '" + est.Estacion + "'";
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

        public static bool VerificarMaq(EstacionLogica est)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_estacion WHERE maquina = '" + est.Linea + "'";
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
                datos = AccesoDatos.Consultar("SELECT * FROM t_estacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ListarProceso()
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_mod02 where modulo = 'EMP'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Eliminar(EstacionLogica est)
        {
            try
            {
                string sQuery = "DELETE FROM t_estacion WHERE estacion = '" + est.Estacion + "'";
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
