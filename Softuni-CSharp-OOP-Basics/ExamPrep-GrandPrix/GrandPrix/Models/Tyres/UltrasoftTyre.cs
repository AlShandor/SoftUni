
public class UltrasoftTyre : Tyre
{
    private double grip;
    
    public UltrasoftTyre(string name, double hardness, double grip) 
        : base(name, hardness)
    {
        this.Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        protected set { grip = value; }
    }

    public override void DegradeTyre()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
}

