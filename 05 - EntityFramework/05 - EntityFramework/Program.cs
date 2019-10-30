using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05___EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            traer();
            deleted("a");
            traer();
            Console.Read();
        }
        public static void traer()
        {
            using(AlumnoEntities db = new AlumnoEntities())
            {
                var lst = db.Alumnos;

                foreach (var x in lst)
                {
                    Console.WriteLine("{0} {1} {2}", x.Nombre, x.Apellidos, x.Edad);
                }
            }
        }

        public static void insert(string nombre, string apellido, int edad)
        {
            using (AlumnoEntities db = new AlumnoEntities())
            {
                var lst = db.Alumnos;
                Alumnos alumnos = new Alumnos();
                alumnos.Nombre = nombre;
                alumnos.Apellidos = apellido;
                alumnos.Edad = edad;
                alumnos.FechaRegistro = DateTime.Now;

                db.Alumnos.Add(alumnos);
                db.SaveChanges();
            }
        }

        public static void update(string nombreb, string nombre, string apellido, int edad)
        {
            using (AlumnoEntities db = new AlumnoEntities())
            {
                var lst = db.Alumnos;
                Alumnos alumnos = db.Alumnos.Where(nom => nom.Nombre == nombreb).FirstOrDefault();
                alumnos.Nombre = nombre;
                alumnos.Apellidos = apellido;
                alumnos.Edad = edad;
                alumnos.FechaRegistro = DateTime.Now;

                db.Entry(alumnos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void deleted(string nombreb)
        {
            using (AlumnoEntities db = new AlumnoEntities())
            {
                var lst = db.Alumnos;
                Alumnos alumnos = db.Alumnos.Where(nom => nom.Nombre == nombreb).FirstOrDefault();
                db.Alumnos.Remove(alumnos);
                db.SaveChanges();
            }
        }
    }
}
