using System;
using System.Linq;

public class Dog : Mammal
{
    private string[] typeFoodEating =
    {
        "Meat"
    };

    public Dog(string name, double weight, double foodGrowth, string livingRegion) 
        : base(name, weight, foodGrowth, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override void Eat(Food food)
    {
        if (!typeFoodEating.Contains(food.GetType().Name))
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }

        base.Eat(food);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.name}, {this.weight}, {this.livingRegion}, {this.foodEaten}]";
    }
}

