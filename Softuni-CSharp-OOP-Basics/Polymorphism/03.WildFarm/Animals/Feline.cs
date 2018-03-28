
public abstract class Feline : Mammal
{
    protected string breed;

    public Feline(string name, double weight, double foodGrowth, string livingRegion, string breed)
        :base(name, weight, foodGrowth, livingRegion)
    {
        this.breed = breed;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.name}, {this.breed}, {this.weight}, {this.livingRegion}, {this.foodEaten}]";
    }
}

