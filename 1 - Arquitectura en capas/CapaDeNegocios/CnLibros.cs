using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDeDatos;
namespace CapaDeNegocios
{
    public class CnLibros
    {
        CLibros clibros = new CLibros();

       

        private String _autor;
        private String _categoria;
        private String _editoria;
        private String _ISBN;
        private DateTime _FechaL;
        private String _titulo;
        private String _idioma;
        private String _descripcion;

        public string Autor { get => _autor; set => _autor = value; }
        public string Categoria { get => _categoria; set => _categoria = value; }
        public string Editoria { get => _editoria; set => _editoria = value; }
        public string ISBN { get => _ISBN; set => _ISBN = value; }
        public DateTime FechaL { get => _FechaL; set => _FechaL = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Idioma { get => _idioma; set => _idioma = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        public DataTable MostrarLibros()
        {
            DataTable tabla = new DataTable();
            tabla = clibros.MostrarLibros();
            return tabla;
        }

        public void InsertarLibro()
        {
            clibros.InsertarLibro(_autor, _categoria, _editoria, _ISBN, _titulo, _FechaL, _idioma, _descripcion);
        }
        public void EditarLibro()
        {
            clibros.EditarLibro(_autor, _categoria, _editoria, _ISBN, _titulo, _FechaL, _idioma, _descripcion);
        }
        public void EliminarLibro()
        {
            clibros.EliminarLibro(_ISBN);
        }
    }
}
