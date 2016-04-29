using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProject
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

                var teacher = new Teacher
                {
                    FirstMidName = "Anders",
                    LastName = "Kalhauge",
                    HireDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.People.Add(teacher);

                var teacher1 = new Teacher
                {
                    FirstMidName = "Anden",
                    LastName = "Lærer",
                    HireDate = DateTime.Parse(DateTime.Today.ToString())
                };

                context.People.Add(teacher1);
                context.SaveChanges();
            }
        }
    }
   
    public abstract partial class Person
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
        public virtual DbSet<Person> People { get; set; }

        public static string CONN =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCHOOLDB9;
    Integrated Security=True;Connect Timeout=30;Encrypt=False;
    TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //@"Data Source=(localdb)\mssqllocaldb;Integrated Security=True";  

        public SchoolContext() : base(CONN)
        {
            Database.SetInitializer<SchoolContext>(
          //new DropCreateDatabaseIfModelChanges<SchoolContext>()
          new DropCreateDatabaseAlways<SchoolContext>()
          );
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           //modelBuilder.Entity<Person>()
          //  .Property(p => p.ID)
          //  .HasDatabaseGenerationOption(DatabaseGenerationOption.None);

            modelBuilder.Entity<Teacher>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Teacher");
            });

            modelBuilder.Entity<Student>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Student");
            });
        }
    }
}

    

