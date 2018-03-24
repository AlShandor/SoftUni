
using System;
using System.Collections.Generic;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int BASE_CALORIES = 2;
    private int weight;
    private string type;
    private Dictionary<string, double> typeOfToppings = new Dictionary<string, double>
    {
        {"meat", 1.2 },
        {"veggies", 0.8 },
        {"cheese", 1.1 },
        {"sauce", 0.9 }
    };

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }
    
    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{Type} weight should be in the range[1..50].");
            }
            weight = value;
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (!typeOfToppings.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double GetCaloriesPerGram()
    {
        return (BASE_CALORIES * Weight) * typeOfToppings[type.ToLower()];
    }
}
