
using System;
using System.Text;

public class Book
{
    private const int MIN_TITLE_LENGTH = 3;

    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }
    
    public string Author
    {
        get { return author; }
        set
        {
            
            string[] nameTokens = value.Split();
            if (nameTokens.Length > 1)
            {
                if (char.IsDigit(nameTokens[1][0]))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            
            author = value;
        }
    }

    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < MIN_TITLE_LENGTH)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Type: {this.GetType().Name}")
            .AppendLine($"Title: {this.Title}")
            .AppendLine($"Author: {this.Author}")
            .AppendLine($"Price: {this.Price:f2}");

        return sb.ToString().TrimEnd();
    }
}

