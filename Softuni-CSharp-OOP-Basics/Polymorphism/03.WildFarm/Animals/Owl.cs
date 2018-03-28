using System;
using System.Linq;

public class Owl : Bird
{
    private string[] typeFoodEating =
    {
        "Meat"
    };

    public Owl(string name, double weight, double foodGrowth, double wingSize) 
        : base(name, weight, foodGrowth, wingSize)
    {
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }

    public override void Eat(Food food)
    {
        if (!typeFoodEating.Contains(food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        base.Eat(food);
    }
}

