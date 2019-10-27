using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDeDatos
{
    class CapaDatos
    {

        private SqlConnection conexion = new SqlConnection("Server=JoseAlmando-pc\\SQLEXPRESS;Database=Biblioteca2;Integrated Security=true;");

        public SqlConnection AbirConexion()
        {

            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;

        }

        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
