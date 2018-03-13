using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BookLibrary
{
    class Program
    {
        class Book
        {
            //public string Title { get; set; }
            public string Author { get; set; }
            //public string Publisher { get; set; }
            //public DateTime ReleaseDate { get; set; }
            //public string ISBN { get; set; }
            public double Price { get; set; }

        }

        class Library
        {
            public List<Book> ListOfBooks = new List<Book>();
        }

        static void Main(string[] args)
        {
            int numOfBooks = int.Parse(Console.ReadLine());
            Library libraryOfBooks = GetBookLibrary(numOfBooks);
            var authorsBySumOfPrices = GetAuthorsBySumOfPrices(libraryOfBooks);
            foreach (var author in authorsBySumOfPrices.OrderByDescending(price => price.Value).ThenBy(name => name.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }

        }

        private static Dictionary<string, double> GetAuthorsBySumOfPrices(Library libraryOfBooks)
        {
            Dictionary<string, double> AuthorsBySumOfPrices = new Dictionary<string, double>();
            foreach (var book in libraryOfBooks.ListOfBooks)
            {
                if (!AuthorsBySumOfPrices.ContainsKey(book.Author))
                {
                    AuthorsBySumOfPrices.Add(book.Author, book.Price);
                }
                else
                {
                    AuthorsBySumOfPrices[book.Author]+= book.Price;
                }
            }
            return AuthorsBySumOfPrices;
        }

        private static Library GetBookLibrary(int numOfBooks)
        {
            Library libraryOfBooks = new Library();
            for (int i = 0; i < numOfBooks; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ').ToArray();
                Book newBook = new Book()
                {
                    //Title = tokens[0],
                    Author = tokens[1],
                    //Publisher = tokens[2],
                    //ReleaseDate = DateTime.ParseExact(tokens[3], "dd.MM.YYYY", CultureInfo.InvariantCulture),
                    //ISBN = tokens[4],
                    Price = double.Parse(tokens[5])
                };
                libraryOfBooks.ListOfBooks.Add(newBook);
            }
            return libraryOfBooks;
        }
    }
}
