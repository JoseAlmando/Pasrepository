using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos;
using System.Data.SqlClient;
using System.Data;
namespace CapaDeNegocios
{
    public class CnAlquiler
    {
        private CAlquiler cal = new CAlquiler();

        private String _matricula;
        private String _ISBN;
        private DateTime _fechaE;
        private Int32 _id;
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string ISBN { get => _ISBN; set => _ISBN = value; }
        public DateTime FechaE { get => _fechaE; set => _fechaE = value; }
        public int Id { get => _id; set => _id = value; }
        public string c;
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            tabla = cal.Mostrar();
            return tabla;
        }
        public void InsertarAlquiler()
        {
            cal.InsertarAlquiler(_matricula, _ISBN, _fechaE);

        }
        public void EditarAlquiler()
        {
            cal.EditarAlquiler(_matricula, _ISBN, _fechaE, _id);
        }
        public void EliminarAlquiler()
        {
            cal.EliminarAlquiler(_id);
        }
        public DataTable LlenarDatos()
        {
            DataTable leer;
            leer = cal.LlenarLector(_matricula);
            return leer;
        }
        public DataTable LlenarLibro()
        {
            DataTable leer;
            leer = cal.LlenarLibro(_ISBN);
            return leer;
        }
    }
}
