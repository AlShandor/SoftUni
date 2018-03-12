namespace _09.BookLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class BookLibrary
    {
        public static void Main(string[] args)
        {
            Library library = CreateLibrary();
            AuthorAndSumOfPrices(library);
        }

        public class Library
        {
            public string Name { get; set; }

            public List<Book> Books { get; set; }
        }

        public class Book
        {
            public string Title { get; set; }

            public string Author { get; set; }

            public string Publisher { get; set; }

            public DateTime ReleaseDate { get; set; }

            public string ISBN_Number { get; set; }

            public double Price { get; set; }
        }

        private static void AuthorAndSumOfPrices(Library library)
        {
            Dictionary<string, double> authorByPrices = PricesByAuthor(library.Books);
            File.WriteAllLines("../../Authors by Prices.txt", authorByPrices.Select(x => $"{x.Key} -> {x.Value:F2}"));
        }

        private static Dictionary<string, double> PricesByAuthor(List<Book> books)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            for (int i = 0; i < books.Count; i++)
            {
                if (!result.ContainsKey(books[i].Author))
                {
                    result[books[i].Author] = 0;
                }

                result[books[i].Author] += books[i].Price;
            }

            // ordered descending by price and then by author’s name lexicographically
            result = result
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        private static Library CreateLibrary()
        {
            Library library = new Library { Name = "The Penguins", Books = new List<Book>() };
            string[] booksData = File.ReadAllLines("../../Input.txt");

            for (int i = 0; i < booksData.Length; i++)
            {
                library.Books.Add(BuildBook(booksData[i]));
            }

            return library;
        }

        private static Book BuildBook(string bookDetails)
        {
            string[] data = bookDetails.Split(' ');

            // {title} {author} {publisher} {release date} {ISBN} {price}.
            // LOTR Tolkien GeorgeAllen 29.07.1954 0395082999 30.00
            Book book = new Book
            {
                Title = data[0],
                Author = data[1],
                Publisher = data[2],
                ReleaseDate = DateTime.ParseExact(data[3], "d.MM.yyyy", CultureInfo.InvariantCulture),
                ISBN_Number = data[4],
                Price = double.Parse(data[5])
            };

            return book;
        }
    }
}