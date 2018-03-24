
public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public double Hardness
    {
        get { return hardness; }
        private set { hardness = value; }
    }

    public double Degradation
    {
        get { return degradation; }
        protected set { degradation = value; }
    }

    public abstract void DegradeTyre();
}

