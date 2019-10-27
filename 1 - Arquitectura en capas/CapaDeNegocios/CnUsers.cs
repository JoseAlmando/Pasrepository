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
    public class CnUsers
    {
        CUsers cnuser = new CUsers();
        private String _users;
        private String _pass;
        private int _id;

        public string Users { get => _users; set => _users = value; }
        public string Pass { get => _pass; set => _pass = value; }
        public Int32 Id { get => _id; set => _id = value; }

        public void InsertarUsuario()
        {
            cnuser.InsertarUsuario(_users,_pass);

        }
       
        public void EditarUsuario()
        {
            cnuser.EditarUsuario(_users, _pass, _id);

        }
        public DataTable MostrarUsuarios()
        {
            DataTable tabla = new DataTable();
            tabla = cnuser.MostrarUsuarios();
            return tabla;
        }
        public void EliminarUsuario()
        {
            cnuser.EliminarUsuario(_id);
        }
    }
}
