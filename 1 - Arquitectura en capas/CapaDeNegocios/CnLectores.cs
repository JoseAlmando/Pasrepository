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
    public class CnLectores
    {
        private CLectores obj = new CLectores();

        private String _matricula;
        private String _nombre;
        private String _telefono;
        private String _obs;
        private Int32 _id;
        public String Matricula
        {
             set
            {
               _matricula = value;
            }
            get { return _matricula; }
        }
        public String Nombre
        {
            set
            {
                _nombre = value;
            }
            get { return _nombre; }
        }
        public String Telefono
        {
            set
            {
                _telefono = value;
            }
            get { return _telefono; }
        }
        public String Obs
        {
             set
            {
               _obs = value;
            }
            get { return _obs; }
        }

        public int Id { get => _id; set => _id = value; }

        public CnLectores() { }
        public void InsertarLector()
        {
            obj.InsertarLector(_matricula, _nombre, _telefono, _obs);
        }
        public void EditarLector()
        {
            obj.EditarLector(_matricula, _nombre, _telefono, _obs, Id);
        }
        public DataTable MostrarLector()
        {
            DataTable tabla = new DataTable();
            tabla = obj.MostrarLector();
            return tabla;
        }
        public void EliminarLector()
        {
            obj.EliminarLector(_id);
        }
    }
}
