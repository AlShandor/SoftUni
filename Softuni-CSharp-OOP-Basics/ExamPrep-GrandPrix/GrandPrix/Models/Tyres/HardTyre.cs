
public class HardTyre : Tyre
{
    public HardTyre(string name, double hardness) 
        : base(name, hardness)
    {
    }

    public override void DegradeTyre()
    {
        this.Degradation -= this.Hardness;
    }
}

