using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace CapaDeDatos
{
   public class CLogin
    {
        private CapaDatos conexion = new CapaDatos();

        public SqlDataReader leer;
        public SqlDataReader iniciarS(string user, string pass)
        {
            SqlCommand coma = new SqlCommand("SpIniciarS", conexion.AbirConexion());
            coma.CommandType = CommandType.StoredProcedure;
            coma.Parameters.AddWithValue("@User", user);
            coma.Parameters.AddWithValue("@Pass", pass);

            leer = coma.ExecuteReader();
            return leer;
        }
    }
}
