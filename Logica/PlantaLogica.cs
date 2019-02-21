using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class PlantaLogica
    {
        public string Planta { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }

        public static int Guardar(PlantaLogica pta)
        {
            string[] parametros = { "@Planta","@Nombre", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_plantas", parametros, pta.Planta, pta.Nombre, pta.Usuario);
        }

        public static DataTable Consultar(PlantaLogica pta)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_plantas WHERE planta = '" + pta.Planta + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Verificar(PlantaLogica pta)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_plantas WHERE planta = '" + pta.Planta + "'";
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
                datos = AccesoDatos.Consultar("SELECT * FROM t_plantas");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static bool AntesDeEliminar(PlantaLogica plan)
        {
            try
            {
                string sQuery;

                DataTable datos = new DataTable();

                sQuery = "SELECT * FROM t_areas WHERE planta = '" + plan.Planta + "'";
                datos = AccesoDatos.Consultar(sQuery);
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
        public static bool Eliminar(PlantaLogica pta)
        {
            try
            {
                string sQuery = "DELETE FROM t_lineas WHERE planta = '" + pta.Planta + "'";
                if (AccesoDatos.Borrar(sQuery) != 0)
                    return true;

                sQuery = "DELETE FROM t_plantas WHERE planta = '" + pta.Planta + "'";
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
