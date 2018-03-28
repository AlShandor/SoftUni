
public abstract class Mammal : Animal
{
    protected string livingRegion;

    public Mammal(string name, double weight, double foodGrowth, string livingRegion)
        :base(name, weight, foodGrowth)
    {
        this.livingRegion = livingRegion;
    }
}
