using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("Enter a name: ");
                var name = Console.ReadLine();

                var person = new Persons { FirstMidName = name };
                db.Persons.Add(person);
                db.SaveChanges();

                var query = from p in db.Persons orderby p.FirstMidName select p;

                Console.WriteLine("All persons in the database");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstMidName);
                }

                Console.ReadKey();
            }
        }
    }
}
