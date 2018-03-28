
public abstract class Bird : Animal
{
    private double wingSize;

    public Bird(string name, double weight, double foodGrowth, double wingSize) 
        :base(name, weight, foodGrowth)
    {
        this.wingSize = wingSize;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} [{this.name}, {this.wingSize}, {this.weight}, {this.foodEaten}]";
    }
}

