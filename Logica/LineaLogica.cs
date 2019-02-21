using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class LineaLogica
    {
        public string Planta { get; set; }
        public string Linea { get; set; }
        public string Nombre { get; set; }
        public string Area { get; set; }
        public string Material { get; set; }
        public string Global { get; set; }
        public static int Guardar(LineaLogica line)
        {
            string[] parametros = { "@Planta", "@Linea", "@Nombre", "@Area", "@Material" };
            return AccesoDatos.Actualizar("sp_mant_lineas", parametros, line.Planta, line.Linea, line.Nombre, line.Area, line.Material);
        }

        public static int GuardarPta(LineaLogica line)
        {
            string[] parametros = { "@Planta", "@Linea", "@Nombre", "@Area" };
            return AccesoDatos.Actualizar("sp_mant_lineas", parametros, line.Planta, line.Linea, line.Nombre, line.Area);
        }

        public static DataTable Consultar(LineaLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_lineas WHERE planta = '" + line.Planta + "' and linea = '"+ line.Linea+"'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static DataTable ConsultarLine(LineaLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_lineas WHERE linea = '" + line.Linea + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static DataTable ConsultarArea(LineaLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_lineas WHERE planta = '" + line.Planta + "' and ('"+line.Global+"' = '1' or ('"+line.Global+"' = '0' and area = '"  + line.Area + "')) ORDER BY linea");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(LineaLogica line)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_lineas WHERE planta = '" + line.Planta + "' and linea = '" + line.Linea + "'";
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

        public static bool VerificarMaq(LineaLogica line)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_lineas WHERE nombre = '" + line.Nombre + "'";
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
                datos = AccesoDatos.Consultar("SELECT * FROM t_lineas order by planta,linea");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ListarPta(LineaLogica line)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT planta,linea as Linea,nombre as Estación,area as Area FROM t_lineas where planta='" +line.Planta+"' order by linea");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Eliminar(LineaLogica line)
        {
            try
            {
                string sQuery = "DELETE FROM t_lineas WHERE planta = '" + line.Planta + "' and linea = '" + line.Linea + "'";
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
