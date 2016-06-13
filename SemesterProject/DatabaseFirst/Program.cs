using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //instans 
            using (var db = new SCHOOL())
            {
                Console.WriteLine("You are about to enter SCHOOL Petshop");
                // LINQ query der henter dyrs navne

                var query = from p in db.Pets select p;
                //itererer over query og henter navn

                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                
                Console.ReadKey();
            }
        }
    }
}
