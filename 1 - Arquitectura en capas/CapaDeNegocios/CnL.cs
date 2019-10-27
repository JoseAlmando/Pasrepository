using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data;
using System.Data.SqlClient;
namespace CapaDeNegocios
{
    public  class CnL
    {

       private CLogin objeto = new CLogin(); //Ins al login

        private String User_;
        private String Pass_;

        public String User
        {
            set { if (value == "Usuario") { User_ = "No hay dato"; } else User_ = value; }
            get { return User_; }
        }
        public String Pass
        {
            set {
                Pass_ = value;
            }
            get { return Pass_; }
        }

        public CnL() { }

        public SqlDataReader IniciarS()
        {
            SqlDataReader Log;
            Log = objeto.iniciarS(User_, Pass_);

            return Log;
        }
    }
}
