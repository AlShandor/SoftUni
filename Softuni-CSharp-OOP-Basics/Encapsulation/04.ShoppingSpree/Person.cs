
using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        BagOfProducts = new List<string>();
    }

    public string Name
    {
        get
        { return name; }
        set
        {
            if (value == String.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }

    }
    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public List<string> BagOfProducts;

    public override string ToString()
    {
        return BagOfProducts.Count == 0
           ? $"{Name} - Nothing bought"
           : $"{Name} - {string.Join(", ", BagOfProducts)}";
    }
}
