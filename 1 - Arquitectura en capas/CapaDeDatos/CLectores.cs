using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDeDatos
{
   public class CLectores
    {
        private CapaDatos conexion = new CapaDatos();
        SqlCommand sql = new SqlCommand();

        public DataTable MostrarLector()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "MostrarLectores";
            sql.CommandType = CommandType.Text;
            leer = sql.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
     

        public void InsertarLector(string matricula, string nombre, string telefono, string obs)
        {
                sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
                sql.CommandText = "InsertarLector";
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Matricula", matricula);
                sql.Parameters.AddWithValue("@Nombre", nombre);
                sql.Parameters.AddWithValue("@Telefono", telefono);
                sql.Parameters.AddWithValue("@Observaciones", obs);
                sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void EditarLector(string matricula, string nombre, string telefono, string obs, int id)
        {
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "EditarLector";
            sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Matricula", matricula);
                sql.Parameters.AddWithValue("@Nombre", nombre);
                sql.Parameters.AddWithValue("@Telefono", telefono);
                sql.Parameters.AddWithValue("@Observaciones", obs);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void EliminarLector(int id)
        {
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "EliminarLector";
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@idLector",id);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

    }
}
