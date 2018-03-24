
using System;
using System.Collections.Generic;

public class Pizza
{
    private const int MAX_LENGTH = 15;
    private string name;
    private Dough dough;
    private List<Topping> toppings = new List<Topping>();
    private int numberOfToppings = 0;
    
    public Pizza(string name)
    {
        Name = name;
    }

    public Dough Dough
    {
        get { return dough; }
         set { dough = value; }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public double TotalCalories
    {
        get { return GetTotalCalories(); }
    }

    public int NumberOfToppings
    {
        get { return numberOfToppings;}
        private set
        {
            numberOfToppings = value;
            if (numberOfToppings > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
        }
    }

    private double GetTotalCalories()
    {
        double total = 0;
        total += dough.GetCaloriesPerGram();
        foreach (var topping in toppings)
        {
            total += topping.GetCaloriesPerGram();
        }

        return total;
    }

    public void AddTopping(Topping newTopping)
    {
        toppings.Add(newTopping);
        NumberOfToppings++;
    }
}
