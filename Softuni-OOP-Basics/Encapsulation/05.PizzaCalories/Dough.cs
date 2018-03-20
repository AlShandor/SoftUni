
using System;
using System.Collections.Generic;

public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const int BASE_CALORIES = 2;
    private int weight;
    private Dictionary<string, double> flourTypes = new Dictionary<string, double>
    {
        { "white", 1.5 },
        { "wholegrain", 1.0 }
    };
    private Dictionary<string, double> bakingTechniques = new Dictionary<string, double>
    {
        { "crispy", 0.9 },
        { "chewy", 1.1 },
        { "homemade", 1.0 }
    };

    private string flour;
    private string technique;

    public Dough(string flour, string technique, int weight)
    {
        Flour = flour;
        Technique = technique;
        Weight = weight;
    }

    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            weight = value;
        }
    }

    public string Flour
    {
        get { return flour;}
        private set
        {
            if (!flourTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            flour = value;
        }
    }

    public string Technique
    {
        get { return technique;}
        private set
        {
            if (!bakingTechniques.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            technique = value;
        }
    }

    public double GetCaloriesPerGram()
    {
        return (BASE_CALORIES * Weight) * flourTypes[flour.ToLower()] * bakingTechniques[technique.ToLower()];
    }
}
