using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDeNegocios;
namespace CapaDePresentacion
{
    public partial class Alquiler : Form
    {
        public Alquiler()
        {
            InitializeComponent();
        }
        CnAlquiler cal = new CnAlquiler();
        private void Alquiler_Load(object sender, EventArgs e) => Mostrar();

        private void label9_Click(object sender, EventArgs e) => this.Close();

        public void Mostrar()
        {
            CnAlquiler call = new CnAlquiler();
            CnLibros cas = new CnLibros();
            CnLectores cass = new CnLectores();
            dataGridView1.DataSource = call.Mostrar();
            tbISBN.DataSource = cas.MostrarLibros();
            tbISBN.DisplayMember = "Libros";
            tbISBN.ValueMember = "ISBN";
        }
        string mensaje, metodo;
        MessageBoxIcon icono = MessageBoxIcon.Information;
        MessageBoxButtons buton = MessageBoxButtons.OK;
        DialogResult condicion;
        private void btInsertar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            InsertarAlquiler();
        }
        private void EditarAlquiler()
        {

            metodo = "Actualizar libro";
            try
            {
                if (tbISBN.Text == "" || mtbMatricula.Text == "")
                {
                    mensaje = "Llenar campo/os vacio/os";
                    icono = MessageBoxIcon.Exclamation;
                    buton = MessageBoxButtons.OK;
                }
                else
                {
                    mensaje = "¿Seguro que quieres actualizar el libro?";
                    buton = MessageBoxButtons.YesNo;
                    icono = MessageBoxIcon.Question;
                    condicion = MessageBox.Show(mensaje, metodo, buton, icono);
                    if (condicion == DialogResult.Yes)
                    {
                        cal.Matricula = mtbMatricula.Text;
                        cal.ISBN = tbISBN.Text;
                        cal.FechaE = DateTime.Parse(dtpfe.Text);
                        cal.Id = Int32.Parse(tbid.Text);
                        cal.EditarAlquiler();
                        mensaje = "Libro actualizado";
                        buton = MessageBoxButtons.OK;
                        icono = MessageBoxIcon.Information;
                    }
                    else
                    {
                        mensaje = "Operacion cancelada";
                        buton = MessageBoxButtons.OK;
                        icono = MessageBoxIcon.Information;
                    }
                }
            }
            catch
            {
                mensaje = "A ocurrido un error";
                buton = MessageBoxButtons.OK;
                icono = MessageBoxIcon.Error;
            }
            MessageBox.Show(mensaje, metodo, buton, icono);
        }

        private void InsertarAlquiler()
        {

            metodo = "Alquiler libro";
            try
            {

                mensaje = "Alquiler insertado con exito";
                icono = MessageBoxIcon.Information;
                buton = MessageBoxButtons.OK;

                if (tbISBN.Text == "" || mtbMatricula.Text == "")
                {
                    mensaje = "Llenar campo/os vacio/os";
                    icono = MessageBoxIcon.Exclamation;
                    buton = MessageBoxButtons.OK;
                }
                else
                {

                    cal.Matricula = mtbMatricula.Text;
                    cal.ISBN = tbISBN.Text;
                    cal.FechaE = DateTime.Parse(dtpfe.Text);
                    cal.InsertarAlquiler();
                    Mostrar();
                    
                    vaciarControles();
                }

            }
            catch (Exception es)
            {
                mensaje = "A ocurrido un error " + es.ToString();
                buton = MessageBoxButtons.OK;
                icono = MessageBoxIcon.Error;
            }
            MessageBox.Show(mensaje, metodo, buton, icono);

        }

        private void vaciarControles()
        {
            tbid.Text = "";
            tbISBN.Text = "";
            tbNombreLector.Text = "";
            tbObs.Text = "";
            tbTituloLibro.Text = "";
            mtbMatricula.Text = "";
            mtbTelefono.Text = "";
            mtbMatricula.Focus();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            EditarAlquiler();
            Mostrar();
            vaciarControles();
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

            metodo = "Eliminar alquiler";
            try
            {
                mensaje = "¿Seguro que quieres eliminar el libro?";
                buton = MessageBoxButtons.YesNo;
                icono = MessageBoxIcon.Question;
                condicion = MessageBox.Show(mensaje, metodo, buton, icono);
                if (condicion == DialogResult.Yes)
                {

                    cal.Id = Int16.Parse(tbid.Text);
                    cal.EliminarAlquiler();
                    mensaje = "Alquiler eliminado.";
                    buton = MessageBoxButtons.OK;
                    icono = MessageBoxIcon.Information;
                    Mostrar();
                }
                else
                {
                    mensaje = "Operacion cancelada";
                    buton = MessageBoxButtons.OK;
                    icono = MessageBoxIcon.Information;
                }

            }
            catch (Exception es)
            {
                mensaje = "A ocurrido un error" + es.ToString(); ;
                buton = MessageBoxButtons.OK;
                icono = MessageBoxIcon.Error;
            }
            MessageBox.Show(mensaje, metodo, buton, icono);
            vaciarControles();
        }

        private void mtbMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                cal.Matricula = mtbMatricula.Text;
                cal.ISBN = tbISBN.Text;
                DataTable data;
                data = cal.LlenarDatos();
                DataRow row = data.Rows[0];
                tbNombreLector.Text = row["Nombre"].ToString();
                tbObs.Text = row["Observaciones"].ToString();
                mtbTelefono.Text = row["Telefono"].ToString();
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable data;
            data = cal.LlenarLibro();
            DataRow row = data.Rows[0];
            cal.ISBN = tbISBN.Text;
            row = data.Rows[0];
            tbTituloLibro.Text = row[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ralquiler ralquiler = new Ralquiler();
            ralquiler.Id = Int32.Parse(tbid.Text);
            ralquiler.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            mtbMatricula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbNombreLector.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbISBN.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbTituloLibro.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtpfs.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtpfe.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            mtbTelefono.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tbObs.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }
    }
}
