using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;

namespace Logica
{
    public class UsuarioLogica
    {
        public string Usuario { get; set; }
        public string Planta { get; set; }
        public string Linea { get; set; }
        public string Turno { get; set; }
        public string IndRamp { get; set; }
        public double Rampeo { get; set; }
        public string Puesto { get; set; }
        public string User { get; set; }

        public static int Guardar(UsuarioLogica user)
        {
            string[] parametros = { "@Usuario", "@Planta", "@Linea", "@Turno", "@IndRamp", "@Rampeo", "@Puesto", "@User" };
            return AccesoDatos.Actualizar("sp_mant_usuarios", parametros, user.Usuario, user.Planta, user.Linea, user.Turno, user.IndRamp, user.Rampeo, user.Puesto, user.User);
        }

        public static DataTable Consultar(UsuarioLogica user)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_usuarios WHERE usuario = '" + user.Usuario + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        
        public static DataTable ConsultarPta(UsuarioLogica user)
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT * FROM t_usuarios WHERE planta = '" + user.Planta + "' and turno = '"+user.Turno+"'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }
        public static bool Verificar(UsuarioLogica user)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_usuarios WHERE usuario = '" + user.Usuario + "'";
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
        public static bool VerificarTurno(UsuarioLogica user)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_usuarios WHERE usuario = '" + user.Usuario + "' and turno = '"+user.Turno+"'";
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

        public static bool VerificarLinea(UsuarioLogica user)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_usuarios WHERE planta = '"+user.Planta+"' and linea = '" + user.Linea + "' and turno = '"+user.Turno+"'";
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

        public static bool VerificarAcceso(UsuarioLogica user)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_usuarios WHERE usuario ='"+user.Usuario+"' and puesto <>'OP'";
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
        public static bool VerificarOperador(UsuarioLogica user)
        {
            try
            {
                string sQuery;
                sQuery = "SELECT * FROM t_usuarios WHERE usuario = '" + user.Usuario + "' and puesto = 'OP' and linea is not null";
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
                datos = AccesoDatos.Consultar("SELECT * FROM t_usuarios");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static DataTable ListarVista()
        {
            DataTable datos = new DataTable();
            try
            {
                datos = AccesoDatos.Consultar("SELECT usuario as Usuario,planta as Planta,linea as Linea,turno as Turno,ind_ramp,rampeo as Rampeo FROM t_usuarios where puesto='OP'");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return datos;
        }

        public static bool Eliminar(UsuarioLogica user)
        {
            try
            {
                string sQuery = "DELETE FROM t_usuarios WHERE usuario = '" + user.Usuario + "'";
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
