using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDeDatos
{
    public class CUsers
    {
        CapaDatos conexion = new CapaDatos();

        SqlCommand sql = new SqlCommand();

        public void InsertarUsuario(string USERS, string PASS)
        {
            sql = new SqlCommand ();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "InsertarUsuario";
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@NombreUsuario", USERS);
            sql.Parameters.AddWithValue("@Pass", PASS);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        
        public void EditarUsuario(string USERS, string PASS, int id)
        {
           
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "EditarUsuario";
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@NombreUsuario", USERS);
            sql.Parameters.AddWithValue("@Pass", PASS);
            sql.Parameters.AddWithValue("@id", id);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public DataTable MostrarUsuarios()
        {
             SqlDataReader leer;
            sql = new SqlCommand();
             DataTable tabla = new DataTable();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "MostrarUsuarios";
            sql.CommandType = CommandType.StoredProcedure;
            leer = sql.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public void EliminarUsuario(int id)
        {
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "EliminarUsuarios";
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@idUsu",id);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
