using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BookEntities())
            {
                var book = new Book()
                {
                    BookName = "Dangerous Murder",
                    Theme = "Horror",
                    Price = 399,
                };
                db.Book
            }
        }
    }

    public class Book
    {
        public string BookName { get; set; }
        public string Theme { get; set; }
        public decimal Price { get; set; }
    }


}
