
using System;
using System.Linq;

public class Cat : Feline
{
    private string[] typeFoodEating =
    {
        "Vegetable",
        "Meat"
    };

    public Cat(string name, double weight, double foodGrowth, string livingRegion, string breed)
        :base(name, weight, foodGrowth, livingRegion, breed)
    {
        
    }

    public override string ProduceSound()
    {
        return "Meow";
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

