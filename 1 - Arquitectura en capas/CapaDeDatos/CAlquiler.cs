using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDeDatos
{
    public class CAlquiler
    {
        private CapaDatos conexion = new CapaDatos();

        DataTable tabla = new DataTable();
        SqlCommand sql = new SqlCommand();

        public DataTable Mostrar()
        {
        SqlDataReader leer;
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "MostrarAlquiler";
            sql.CommandType = CommandType.StoredProcedure;
            leer = sql.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
     
        public void InsertarAlquiler(string matricula, string ISBN, DateTime f)
        {
           
            try
            {
                sql = new SqlCommand();
                sql.Connection = conexion.AbirConexion();
                sql.CommandText = "InsertarAlquiler";
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@MatriculaL", matricula);
                sql.Parameters.AddWithValue("@ISBN", ISBN);
                sql.Parameters.AddWithValue("@FechaE", f);
                sql.ExecuteNonQuery();
                conexion.CerrarConexion();

            }
            catch
            {
                conexion.CerrarConexion();

            }

        }

        public void EditarAlquiler(string matricula, string ISBN, DateTime f, int id)
        {
            try
            {
                
                sql = new SqlCommand();
                sql.Connection = conexion.AbirConexion();
                sql.CommandText = "EditarAlquiler";
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@MatriculaL", matricula);
                sql.Parameters.AddWithValue("@ISBN", ISBN);
                sql.Parameters.AddWithValue("@FechaE", f);
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
            }
            catch
            {

            }

        }
        public void EliminarAlquiler(int id)
        {
            try
            {
                sql = new SqlCommand();
                sql.Connection = conexion.AbirConexion();
                sql.CommandText = "EliminarAlquiler";
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@idAlquiler", id);
                
                sql.ExecuteNonQuery();
                conexion.CerrarConexion();
            }
            catch
            {

            }
        }
        public DataTable LlenarLector(string n)
        {
            sql = new SqlCommand();
            SqlDataReader leer;
            DataTable a = new DataTable();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "select * from Lectores where Matricula = '" + n+"';";
            sql.CommandType = CommandType.Text;
            leer =  sql.ExecuteReader();
            a.Load(leer);
            return a;

        }
        public DataTable LlenarLibro(string n)
        {
            sql = new SqlCommand();
            SqlDataReader leer;
            DataTable a = new DataTable();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "select * from Libros where ISBN = '" + n + "';";
            sql.CommandType = CommandType.Text;
            leer = sql.ExecuteReader();
            a.Load(leer);
            return a;

        }
    }
}
