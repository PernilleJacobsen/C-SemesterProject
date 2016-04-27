using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjectInheritanceEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {

                var student = new Student
                {
                    FirstMidName = "Jeanette",
                    LastName = "Borring-Møller",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.People.Add(student);

                var student1 = new Student
                {
                    FirstMidName = "Pernille",
                    LastName = "Jacobsen",
                    EnrollmentDate = DateTime.Parse(DateTime.Today.ToString())
                };
                
                context.People.Add(student1);

                var techaer = new Teacher
                {
                    FirstMidName = "Anders",
                    LastName = "Kalhauge",
                    HireDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.People.Add(techaer);

                var techaer1 = new Teacher
                {
                    FirstMidName = "Anden",
                    LastName = "Lærer",
                    HireDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.People.Add(techaer1);
                context.SaveChanges();
            }
        }
    }
    public partial class Person
    {
        public int ID { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
    }
    public partial class Student : Person
    {
        public System.DateTime EnrollmentDate { get; set; }
    }
    public partial class Teacher : Person
    {
        public System.DateTime HireDate { get; set; }
    }
    public partial class SchoolContext : DbContext
    {
        public static string CONN =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCHOOLDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //@"Data Source=(localdb)\mssqllocaldb;Integrated Security=True";  

        public SchoolContext() : base(CONN)
        {
            Database.SetInitializer<SchoolContext>(
          //new DropCreateDatabaseAlways<PetClubContext>()
          new DropCreateDatabaseAlways<SchoolContext>()
          );
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
