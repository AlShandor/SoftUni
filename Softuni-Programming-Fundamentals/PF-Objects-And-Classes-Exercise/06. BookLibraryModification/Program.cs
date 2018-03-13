using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06.BookLibraryModification
{
    class Program
    {
        class Book
        {
            public string Title { get; set; }
            //public string Author { get; set; }
            //public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            //public string ISBN { get; set; }
            //public double Price { get; set; }

        }
        
        class Library
        {
            public List<Book> ListOfBooks = new List<Book>();
        }

        static void Main(string[] args)
        {
            int numOfBooks = int.Parse(Console.ReadLine());
            Library libraryOfBooks = GetBookLibrary(numOfBooks);
            DateTime dateToCheck = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            foreach (var book in libraryOfBooks.ListOfBooks.OrderBy(b => b.ReleaseDate).ThenBy(b => b.Title))
            {
                if (book.ReleaseDate > dateToCheck)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate:dd.MM.yyyy}");
                }
            }
        }
        
        private static Library GetBookLibrary(int numOfBooks)
        {
            Library libraryOfBooks = new Library();
            for (int i = 0; i < numOfBooks; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ').ToArray();
                Book newBook = new Book()
                {
                    Title = tokens[0],
                    //Author = tokens[1],
                    //Publisher = tokens[2],
                    ReleaseDate = DateTime.ParseExact(tokens[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    //ISBN = tokens[4],
                    //Price = double.Parse(tokens[5])
                };
                libraryOfBooks.ListOfBooks.Add(newBook);
            }
            return libraryOfBooks;
        }
    }
}
