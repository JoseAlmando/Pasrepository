using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace CapaDeDatos
{
    public class CLibros
    {
        CapaDatos conexion = new CapaDatos();


        
        SqlCommand sql = new SqlCommand();
        public DataTable MostrarLibros()
        {
            SqlDataReader leer;
            DataTable tabla = new DataTable();
            sql = new SqlCommand();
            sql.Connection = conexion.AbirConexion();
            sql.CommandText = "MostrarLibros";
            sql.CommandType = CommandType.StoredProcedure;
            leer = sql.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void InsertarLibro(string Autor, string Categoria, string Editoria, string ISBN, string Titulo, DateTime Fecha, string Idioma, string Desc)
        {
            sql = new SqlCommand("InsertarLibro",conexion.AbirConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Autor",Autor);
            sql.Parameters.AddWithValue("@Categoria",Categoria);
            sql.Parameters.AddWithValue("@Editoria",Editoria);
            sql.Parameters.AddWithValue("@ISBN",ISBN);
            sql.Parameters.AddWithValue("@Titulo",Titulo);
            sql.Parameters.AddWithValue("@FechaL",Fecha);
            sql.Parameters.AddWithValue("@Idioma",Idioma);
            sql.Parameters.AddWithValue("@Descripcion",Desc);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void EditarLibro(string Autor, string Categoria, string Editoria, string ISBN, string Titulo, DateTime Fecha, string Idioma, string Desc)
        {
           sql = new SqlCommand("EditarLibro", conexion.AbirConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@Autor", Autor);
            sql.Parameters.AddWithValue("@Categoria", Categoria);
            sql.Parameters.AddWithValue("@Editoria", Editoria);
            sql.Parameters.AddWithValue("@ISBN", ISBN);
            sql.Parameters.AddWithValue("@Titulo", Titulo);
            sql.Parameters.AddWithValue("@FechaL", Fecha);
            sql.Parameters.AddWithValue("@Idioma", Idioma);
            sql.Parameters.AddWithValue("@Descripcion", Desc);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public void EliminarLibro(string id)
        {
            sql = new SqlCommand("EliminarLibro", conexion.AbirConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@ISBN", id);
            sql.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
    }
}
