using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class MaterialLogica
    {
        public string Material { get; set; }
        public string Nombre { get; set; }
        public double Estandar { get; set; }
        public string Usuario { get; set; }

        public static int Guardar(MaterialLogica mate)
        {
            string[] parametros = { "@Material", "@Nombre", "@Estandar", "@Usuario" };
            return AccesoDatos.Actualizar("sp_mant_materiales", parametros, mate.Material, mate.Nombre, mate.Estandar, mate.Usuario);
        }

        public static DataTable Consultar(MaterialLogica mate)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_materiales WHERE material = '" + mate.Material + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

       
        public static bool Verificar(MaterialLogica mate)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_materiales WHERE material = '" + mate.Material + "'";
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
                datos = AccesoDatos.Consultar("SELECT * FROM t_materiales");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        

        public static bool Eliminar(MaterialLogica mate)
        {
            try
            {
                string sQuery = "DELETE FROM t_materiales WHERE material = '" + mate.Material + "'";
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
