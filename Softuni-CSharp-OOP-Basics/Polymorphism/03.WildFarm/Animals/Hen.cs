
public class Hen : Bird
{
    public override string ProduceSound()
    {
        return "Cluck";
    }

    public Hen(string name, double weight, double foodGrowth, double wingSize) 
        : base(name, weight, foodGrowth, wingSize)
    {
    }
}

